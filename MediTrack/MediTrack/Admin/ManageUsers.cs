using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediTrack.Admin
{
    public partial class ManageUsers : BaseForm
    {
        private const int MinAge = 18;
        private const int MaxAdmins = 3;
        private static readonly string[] Roles = { "Admin", "Doctor", "Receptionist" };

        private readonly string _username, _companyName, _companyId, _userId, _sessionToken;
        private readonly string _strengthDefaultText;
        private BsonDocument _selected;   // the user currently loaded into the text boxes
        private readonly System.Windows.Forms.Timer _searchTimer = new System.Windows.Forms.Timer { Interval = 300 };
        private static readonly Collation CaseInsensitive = new Collation("en", strength: CollationStrength.Primary);
        private static IMongoCollection<BsonDocument> Users =>
            DatabaseService.GetDatabase().GetCollection<BsonDocument>("users");
        private static IMongoCollection<BsonDocument> Sessions =>
            DatabaseService.GetDatabase().GetCollection<BsonDocument>("userSessions");

        public ManageUsers(string username, string companyName, string userId, string sessionToken)
        {
            InitializeComponent();
            InitializeTitleBar(closeButton, titleBar, titleLabel);

            _username = username;
            _companyName = companyName;
            _userId = userId;
            _sessionToken = sessionToken;
            _companyId = CompanyService.GetCompanyId(companyName);

            SetUserContext(_username, _userId, _sessionToken);
            SetUserContext(_username, _companyId);

            lblAdminName.Text = $"{_username} | Admin";
            titleLabel.Text = $"{_companyName} ";
            _strengthDefaultText = lblPasswordStrength.Text;

            cmbUserLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUserLevel.Items.Clear();
            cmbUserLevel.Items.AddRange(Roles);

            SetupGrid();

            txtPassword.TextChanged += OnPasswordTextChanged;
            dtpBirthdate.ValueChanged += OnBirthdateChanged;

            KeyPreview = true;
            KeyDown += ManageUsers_KeyDown;
            SetupTooltips();

            Load += async (s, e) => await LoadUsersAsync();
            _searchTimer.Tick += async (s, e) => { _searchTimer.Stop(); await LoadUsersAsync(); };
            txtSearch.TextChanged += (s, e) => { _searchTimer.Stop(); _searchTimer.Start(); };
        }

        private async Task<bool> AdminLimitReachedAsync(ObjectId companyOid, ObjectId? excludeId)
        {
            var f = Builders<BsonDocument>.Filter;
            var filter = f.Eq("companyId", companyOid) & f.Eq("role", "Admin");
            if (excludeId.HasValue) filter &= f.Ne("_id", excludeId.Value);

            return await Users.CountDocumentsAsync(filter) >= MaxAdmins;
        }

        // ── Grid ──────────────────────────────────────────────────────────────

        private void SetupGrid()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);

            dgvUsers.Columns.Clear();
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "employeeNo", HeaderText = "Employee No.", FillWeight = 14 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "username", HeaderText = "Username", FillWeight = 13 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "lastName", HeaderText = "Last Name", FillWeight = 12 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "firstName", HeaderText = "First Name", FillWeight = 12 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "middleName", HeaderText = "Middle Name", FillWeight = 10 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "contact", HeaderText = "Contact #", FillWeight = 11 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "age", HeaderText = "Age", FillWeight = 5 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "birthdate", HeaderText = "Birthdate", FillWeight = 11 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "role", HeaderText = "User Level", FillWeight = 11 });

            dgvUsers.SelectionChanged += (s, e) => LoadSelectedUser();
        }

        // Only this company's users
        private async Task LoadUsersAsync()
        {
            if (!ObjectId.TryParse(_companyId, out var companyOid)) return;

            try
            {
                await EnsureEmployeeNumbersAsync(companyOid);

                var docs = await Users
                    .Find(BuildUserFilter(companyOid))
                    .Sort(Builders<BsonDocument>.Sort.Ascending("username"))
                    .ToListAsync();

                dgvUsers.Rows.Clear();

                foreach (var d in docs)
                {
                    string first = Str(d, "firstName");
                    string last = Str(d, "lastName");

                    // Older accounts only have a full name: show it under First Name
                    if (first == "" && last == "") first = Str(d, "fullName");

                    var dob = BirthDate(d);
                    int i = dgvUsers.Rows.Add(
                        Str(d, "employeeNo"),
                        Str(d, "username"),
                        last,
                        first,
                        Str(d, "middleName"),
                        Str(d, "contactNumber"),
                        dob.HasValue ? CalcAge(dob.Value).ToString() : "",
                        dob.HasValue ? dob.Value.ToString("MMM dd, yyyy") : "",
                        Str(d, "role"));

                    dgvUsers.Rows[i].Tag = d;
                }

                dgvUsers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gives an employee number to any user that doesn't have one yet (oldest accounts first)
        private static async Task EnsureEmployeeNumbersAsync(ObjectId companyOid)
        {
            var f = Builders<BsonDocument>.Filter;

            var missing = await Users
                .Find(f.Eq("companyId", companyOid) & f.Exists("employeeNo", false))
                .Sort(Builders<BsonDocument>.Sort.Ascending("createdAt"))
                .Project(Builders<BsonDocument>.Projection.Include("_id"))
                .ToListAsync();

            foreach (var d in missing)
            {
                string number = await EmployeeNumberService.NextAsync(companyOid);

                await Users.UpdateOneAsync(
                    f.Eq("_id", d["_id"]) & f.Exists("employeeNo", false),
                    Builders<BsonDocument>.Update.Set("employeeNo", number));
            }
        }

        private void LoadSelectedUser()
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            if (dgvUsers.SelectedRows[0].Tag is not BsonDocument d) return;

            _selected = d;

            string first = Str(d, "firstName");
            string last = Str(d, "lastName");
            if (first == "" && last == "") first = Str(d, "fullName");

            txtUsername.Text = Str(d, "username");
            txtLastName.Text = last;
            txtFirstName.Text = first;
            txtMiddleName.Text = Str(d, "middleName");
            txtContact.Text = Str(d, "contactNumber");

            var dob = BirthDate(d);
            dtpBirthdate.Value = dob ?? DateTime.Today;
            txtAge.Text = dob.HasValue ? CalcAge(dob.Value).ToString() : "";

            cmbUserLevel.SelectedIndex = Array.IndexOf(Roles, Str(d, "role"));

            // The stored password is never shown. Leave blank on Edit to keep it unchanged.
            txtPassword.Text = "";
        }

        // ── Add ───────────────────────────────────────────────────────────────

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ObjectId.TryParse(_companyId, out var companyOid)) return;
            if (!TryReadInputs(isEdit: false, out var input)) return;

            try
            {
                SetBusy(true);

                if (await UsernameTakenAsync(companyOid, input.Username, null))
                {
                    Warn($"The username '{input.Username}' is already used in this company.");
                    txtUsername.FocusInner();
                    return;
                }
                if (input.Role == "Admin" && await AdminLimitReachedAsync(companyOid, null))
                {
                    Warn($"This company already has {MaxAdmins} admin accounts, which is the maximum allowed.");
                    cmbUserLevel.Focus();
                    return;
                }

                string employeeNo = await EmployeeNumberService.NextAsync(companyOid);

                var now = DateTime.UtcNow;
                var doc = new BsonDocument
                {
                    { "companyId", companyOid },
                    { "employeeNo", employeeNo },
                    { "username", input.Username },
                    { "password", input.Password },   // plaintext for the demo; hash before real use
                    { "firstName", input.First },
                    { "middleName", input.Middle },
                    { "lastName", input.Last },
                    { "fullName", FullName(input) },
                    { "role", input.Role },
                    { "birthDate", input.BirthDate },
                    { "isActive", true },
                    { "mustChangePassword", true },
                    { "createdBy", _username },
                    { "createdAt", now },
                    { "updatedAt", now }
                };
                if (!string.IsNullOrEmpty(input.Contact))
                    doc["contactNumber"] = input.Contact;

                await Users.InsertOneAsync(doc);

                MessageBox.Show($"User '{input.Username}' added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                await LoadUsersAsync();
            }
            catch (MongoWriteException ex) when (ex.WriteError?.Category == ServerErrorCategory.DuplicateKey)
            {
                Warn($"The username '{input.Username}' is already used in this company.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not add the user:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusy(false);
            }
        }

        // ── Edit ──────────────────────────────────────────────────────────────

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (!ObjectId.TryParse(_companyId, out var companyOid)) return;

            if (_selected == null)
            {
                Warn("Please select a user from the list to edit.");
                return;
            }

            if (!TryReadInputs(isEdit: true, out var input)) return;

            var id = _selected["_id"].AsObjectId;
            bool isOwner = _selected.GetValue("isCompanyOwner", false).ToBoolean();
            bool isSelf = id.ToString() == _userId;

            // Protect the original admin and your own account from losing admin rights
            if ((isOwner || isSelf) && input.Role != "Admin")
            {
                Warn(isOwner
                    ? "The company's original admin must stay an Admin."
                    : "You can't remove your own Admin access.");
                cmbUserLevel.Focus();
                return;
            }

            try
            {
                SetBusy(true);

                if (await UsernameTakenAsync(companyOid, input.Username, id))
                {
                    Warn($"The username '{input.Username}' is already used in this company.");
                    txtUsername.FocusInner();
                    return;
                }
                bool becomingAdmin = input.Role == "Admin" && Str(_selected, "role") != "Admin";
                if (becomingAdmin && await AdminLimitReachedAsync(companyOid, id))
                {
                    Warn($"This company already has {MaxAdmins} admin accounts, which is the maximum allowed.");
                    cmbUserLevel.Focus();
                    return;
                }

                var u = Builders<BsonDocument>.Update;
                var updates = new List<UpdateDefinition<BsonDocument>>
                {
                    u.Set("username", input.Username),
                    u.Set("firstName", input.First),
                    u.Set("middleName", input.Middle),
                    u.Set("lastName", input.Last),
                    u.Set("fullName", FullName(input)),
                    u.Set("role", input.Role),
                    u.Set("birthDate", input.BirthDate),
                    u.Set("updatedAt", DateTime.UtcNow)
                };

                updates.Add(string.IsNullOrEmpty(input.Contact)
                    ? u.Unset("contactNumber")
                    : u.Set("contactNumber", input.Contact));

                // Password is only changed when a new one was typed
                if (!string.IsNullOrEmpty(input.Password))
                    updates.Add(u.Set("password", input.Password));

                var filter = Builders<BsonDocument>.Filter.Eq("_id", id)
                           & Builders<BsonDocument>.Filter.Eq("companyId", companyOid);

                await Users.UpdateOneAsync(filter, u.Combine(updates));

                MessageBox.Show("User updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                await LoadUsersAsync();
            }
            catch (MongoWriteException ex) when (ex.WriteError?.Category == ServerErrorCategory.DuplicateKey)
            {
                Warn($"The username '{input.Username}' is already used in this company.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not update the user:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusy(false);
            }
        }

        // ── Delete ────────────────────────────────────────────────────────────

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ObjectId.TryParse(_companyId, out var companyOid)) return;

            if (_selected == null)
            {
                Warn("Please select a user from the list to delete.");
                return;
            }

            var id = _selected["_id"].AsObjectId;
            string name = Str(_selected, "username");

            if (_selected.GetValue("isCompanyOwner", false).ToBoolean())
            {
                Warn("The company's original admin account can't be deleted.");
                return;
            }
            if (id.ToString() == _userId)
            {
                Warn("You can't delete the account you are logged in with.");
                return;
            }

            if (MessageBox.Show($"Delete user '{name}'? This cannot be undone.", "Confirm Delete",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;


            string typed = PromptForPassword(this, "Confirm Deletion",
                $"Enter your admin password to delete '{name}':");
            if (typed == null) return;

            try
            {
                SetBusy(true);
                if (!await VerifyCurrentAdminPasswordAsync(typed))
                {
                    Warn("Incorrect password. The user was not deleted.");
                    return;
                }
                await Users.DeleteOneAsync(
                    Builders<BsonDocument>.Filter.Eq("_id", id)
                    & Builders<BsonDocument>.Filter.Eq("companyId", companyOid));

                // Sign the deleted user out everywhere
                await Sessions.UpdateManyAsync(
                    Builders<BsonDocument>.Filter.Eq("userId", id)
                    & Builders<BsonDocument>.Filter.Eq("isActive", true),
                    Builders<BsonDocument>.Update
                        .Set("isActive", false)
                        .Set("logoutTime", DateTime.UtcNow));

                MessageBox.Show("User deleted successfully.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                await LoadUsersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not delete the user:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusy(false);
            }
        }

        // ── Clear ─────────────────────────────────────────────────────────────

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();

        private void ClearFields()
        {
            _selected = null;

            txtUsername.Text = "";
            txtPassword.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtContact.Text = "";
            txtAge.Text = "";
            txtSearch.Text = "";
            dtpBirthdate.Value = DateTime.Today;
            cmbUserLevel.SelectedIndex = -1;
            lblPasswordStrength.Text = _strengthDefaultText;
            lblPasswordStrength.ForeColor = SystemColors.ControlText;

            dgvUsers.ClearSelection();
            txtUsername.FocusInner();
        }

        // ── Input reading and validation ──────────────────────────────────────

        private class UserInput
        {
            public string Username, Password, First, Middle, Last, Contact, Role;
            public DateTime BirthDate;   // stored as a UTC date so the calendar day never shifts
        }

        private bool TryReadInputs(bool isEdit, out UserInput input)
        {
            input = null;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string first = Collapse(txtFirstName.Text);
            string middle = Collapse(txtMiddleName.Text);
            string last = Collapse(txtLastName.Text);
            string contact = txtContact.Text.Trim();
            string role = cmbUserLevel.SelectedItem as string;
            DateTime dob = dtpBirthdate.Value.Date;

            if (!Regex.IsMatch(username, @"^[A-Za-z0-9._-]{3,50}$"))
            {
                Warn("Username must be 3 to 50 characters: letters, numbers, dot, dash or underscore (no spaces).");
                txtUsername.FocusInner();
                return false;
            }

            // New users need a password; on Edit it's optional (blank keeps the current one)
            if (!isEdit || password.Length > 0)
            {
                if (GetStrength(password) == "Weak")
                {
                    Warn("Password is too weak.\nUse at least 6 characters mixing letters and numbers (8+ with upper and lower case for Strong).");
                    txtPassword.FocusInner();
                    return false;
                }
            }

            var nameRule = new Regex(@"^\p{L}[\p{L}\s.'-]{0,49}$");
            if (!nameRule.IsMatch(last))
            {
                Warn("Please enter a valid last name.");
                txtLastName.FocusInner();
                return false;
            }
            if (!nameRule.IsMatch(first))
            {
                Warn("Please enter a valid first name.");
                txtFirstName.FocusInner();
                return false;
            }
            if (middle.Length > 0 && !nameRule.IsMatch(middle))
            {
                Warn("Please enter a valid middle name, or leave it blank.");
                txtMiddleName.FocusInner();
                return false;
            }

            if (contact.Length > 0 && !Regex.IsMatch(Regex.Replace(contact, @"[\s\-().]", ""), @"^\+?\d{7,15}$"))
            {
                Warn("Please enter a valid contact number (7-15 digits, optional leading +).");
                txtContact.FocusInner();
                return false;
            }

            if (dob >= DateTime.Today || CalcAge(dob) < MinAge)
            {
                Warn($"Please select a valid birthdate. Employees must be at least {MinAge} years old.");
                dtpBirthdate.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(role))
            {
                Warn("Please select a user level.");
                cmbUserLevel.Focus();
                return false;
            }

            input = new UserInput
            {
                Username = username,
                Password = password,
                First = first,
                Middle = middle,
                Last = last,
                Contact = contact,
                Role = role,
                BirthDate = DateTime.SpecifyKind(dob, DateTimeKind.Utc)
            };
            return true;
        }

        private async Task<bool> UsernameTakenAsync(ObjectId companyOid, string username, ObjectId? excludeId)
        {
            var f = Builders<BsonDocument>.Filter;
            var filter = f.Eq("companyId", companyOid) & f.Eq("username", username);
            if (excludeId.HasValue)
                filter &= f.Ne("_id", excludeId.Value);

            long count = await Users.CountDocumentsAsync(filter,
                new CountOptions { Collation = CaseInsensitive, Limit = 1 });
            return count > 0;
        }

        // ── Live updates: password strength and age ───────────────────────────

        private void OnPasswordTextChanged(object sender, EventArgs e)
        {
            string strength = GetStrength(txtPassword.Text);

            if (strength == "")
            {
                lblPasswordStrength.Text = _strengthDefaultText;
                lblPasswordStrength.ForeColor = SystemColors.ControlText;
                return;
            }

            lblPasswordStrength.Text = $"Password: {strength}";
            lblPasswordStrength.ForeColor = strength switch
            {
                "Strong" => Color.Green,
                "Medium" => Color.DarkOrange,
                _ => Color.Red
            };
        }

        private void OnBirthdateChanged(object sender, EventArgs e)
        {
            var dob = dtpBirthdate.Value.Date;
            txtAge.Text = dob < DateTime.Today ? CalcAge(dob).ToString() : "";
        }

        private static string GetStrength(string pw)
        {
            if (string.IsNullOrEmpty(pw)) return "";

            int classes = 0;
            if (pw.Any(char.IsLower)) classes++;
            if (pw.Any(char.IsUpper)) classes++;
            if (pw.Any(char.IsDigit)) classes++;
            if (pw.Any(c => !char.IsLetterOrDigit(c))) classes++;

            if (pw.Length >= 8 && classes >= 3) return "Strong";
            if (pw.Length >= 6 && classes >= 2) return "Medium";
            return "Weak";
        }

        // ── Helpers ───────────────────────────────────────────────────────────

        private static string Str(BsonDocument d, string key) =>
            d.TryGetValue(key, out var v) && v.IsString ? v.AsString : "";

        private static DateTime? BirthDate(BsonDocument d) =>
            d.TryGetValue("birthDate", out var v) && v.IsBsonDateTime
                ? v.ToUniversalTime().Date
                : (DateTime?)null;

        private static int CalcAge(DateTime dob)
        {
            var today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age)) age--;
            return age;
        }

        private static string Collapse(string s) => Regex.Replace(s.Trim(), @"\s+", " ");

        private static string FullName(UserInput i) =>
            string.Join(" ", new[] { i.First, i.Middle, i.Last }.Where(s => !string.IsNullOrWhiteSpace(s)));

        private static void Warn(string message) =>
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void SetBusy(bool busy)
        {
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnClear.Enabled = !busy;
        }

        // ── Keyboard: F1 Add, F2 Edit, F3 Delete, F4 Clear, ESC back ──────────

        private void ManageUsers_KeyDown(object sender, KeyEventArgs e)
        {
            var shortcuts = new Dictionary<Keys, EventHandler>
            {
                { Keys.F1, btnAdd_Click },
                { Keys.F2, btnEdit_Click },
                { Keys.F3, btnDelete_Click },
                { Keys.F4, btnClear_Click },
                { Keys.Escape, (s, ev) => GoBack() }
            };

            if (shortcuts.TryGetValue(e.KeyCode, out var handler))
            {
                handler(sender, e);
                e.Handled = true;
            }
        }

        private void GoBack()
        {
            SetNavigating(true);
            new AdminDashboard(_username, _companyName, _userId, _sessionToken).Show();
            Hide();
        }

        private void SetupTooltips()
        {
            var tip = new ToolTip { InitialDelay = 200, ShowAlways = true };
            tip.SetToolTip(btnAdd, "F1 - Add user");
            tip.SetToolTip(btnEdit, "F2 - Save changes to the selected user");
            tip.SetToolTip(btnDelete, "F3 - Delete the selected user");
            tip.SetToolTip(btnClear, "F4 - Clear all text fields");
        }

        private FilterDefinition<BsonDocument> BuildUserFilter(ObjectId companyOid)
        {
            var f = Builders<BsonDocument>.Filter;
            var filter = f.Eq("companyId", companyOid);   // always stay inside this company

            string term = Regex.Replace(txtSearch.Text.Trim(), @"\s+", " ");
            if (term.Length == 0) return filter;

            var rx = new BsonRegularExpression(Regex.Escape(term), "i");

            return filter & f.Or(
                f.Regex("employeeNo", rx),
                f.Regex("username", rx),
                f.Regex("firstName", rx),
                f.Regex("middleName", rx),
                f.Regex("lastName", rx),
                f.Regex("fullName", rx));
        }

        private static string PromptForPassword(IWin32Window owner, string title, string message)
        {
            using var dlg = new Form
            {
                Text = title,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                ClientSize = new Size(380, 150)
            };

            var lbl = new Label { Text = message, Left = 15, Top = 15, Width = 350, Height = 40 };
            var txt = new TextBox { Left = 15, Top = 62, Width = 350, UseSystemPasswordChar = true };
            var ok = new Button { Text = "Confirm", Left = 195, Top = 105, Width = 80, DialogResult = DialogResult.OK };
            var cancel = new Button { Text = "Cancel", Left = 285, Top = 105, Width = 80, DialogResult = DialogResult.Cancel };

            dlg.Controls.AddRange(new Control[] { lbl, txt, ok, cancel });
            dlg.AcceptButton = ok;
            dlg.CancelButton = cancel;

            return dlg.ShowDialog(owner) == DialogResult.OK ? txt.Text : null;   // null = cancelled
        }

        private async Task<bool> VerifyCurrentAdminPasswordAsync(string typed)
        {
            if (!ObjectId.TryParse(_userId, out var me) || !ObjectId.TryParse(_companyId, out var companyOid))
                return false;

            var f = Builders<BsonDocument>.Filter;
            var doc = await Users.Find(f.Eq("_id", me) & f.Eq("companyId", companyOid)).FirstOrDefaultAsync();

            // Plaintext compare for the demo. With hashing: BCrypt.Net.BCrypt.Verify(typed, hash)
            return doc != null && Str(doc, "role") == "Admin" && Str(doc, "password") == typed;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard dash = new AdminDashboard(_username, _companyName, _userId, _sessionToken);
            this.Hide();
            dash.Show();
            
        }
    }
}
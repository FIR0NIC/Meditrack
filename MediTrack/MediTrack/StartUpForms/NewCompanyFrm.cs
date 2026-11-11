using DnsClient;
using MediTrack.StartUpForms;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediTrack
{
    // Initial setup: registers a new company and creates its first Admin account.
    // Required controls: txtCompanyName, txtEmailAdd, txtContactNum, btnCreateCompany,
    //                    roundedButton1 (back button), closeButton, titleBar, titleLabel
    public partial class NewCompanyFrm : BaseForm
    {
        private const string AdminUsername = "admin";
        private bool _busy;

        public NewCompanyFrm()
        {
            InitializeComponent();
            InitializeTitleBar(closeButton, titleBar, titleLabel);

            // Make sure each button is wired exactly once, even if the designer already wired it
            btnCreateCompany.Click -= btnCreateCompany_Click;
            btnCreateCompany.Click += btnCreateCompany_Click;
            roundedButton1.Click -= roundedButton1_Click;
            roundedButton1.Click += roundedButton1_Click;
        }

        // ── Keyboard: Enter/Down = next field, Up = previous, Enter on last = submit, ESC = back ──

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                GoBack();
                return true;
            }

            if (keyData == Keys.Enter || keyData == Keys.Down || keyData == Keys.Up)
            {
                bool up = keyData == Keys.Up;

                if (txtCompanyName.ContainsFocus)
                {
                    if (!up) txtEmailAdd.FocusInner();
                    return true;
                }
                if (txtEmailAdd.ContainsFocus)
                {
                    if (up) txtCompanyName.FocusInner(); else txtContactNum.FocusInner();
                    return true;
                }
                if (txtContactNum.ContainsFocus)
                {
                    if (up) txtEmailAdd.FocusInner();
                    else if (keyData == Keys.Enter) btnCreateCompany_Click(this, EventArgs.Empty);
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e) { }

        private void roundedButton1_Click(object sender, EventArgs e) => GoBack();

        private void GoBack()
        {
            if (_busy) return;
            this.Hide();
            new WelcomeFrm().Show();
        }

        // ── Create company + first admin ──────────────────────────────────────

        private async void btnCreateCompany_Click(object sender, EventArgs e)
        {
            if (_busy) return;

            string companyName = Regex.Replace(txtCompanyName.Text.Trim(), @"\s+", " ");
            string emailAddress = txtEmailAdd.Text.Trim();
            string contactNumber = txtContactNum.Text.Trim();

            // ── Step 1: field validation (no database needed) ──────────────────
            string nameKey = NormalizeName(companyName);

            if (companyName.Length < 3 || companyName.Length > 60 || nameKey.Length < 2)
            {
                Warn("Please enter a company name (3 to 60 characters, with letters or numbers).");
                txtCompanyName.FocusInner();
                return;
            }

            if (!string.IsNullOrEmpty(emailAddress) && !IsValidEmailFormat(emailAddress))
            {
                Warn("Please enter a valid email address.");
                txtEmailAdd.FocusInner();
                return;
            }

            if (!string.IsNullOrEmpty(contactNumber) && !IsValidPhoneNumber(contactNumber))
            {
                Warn("Please enter a valid contact number (7-15 digits, optional leading +).");
                txtContactNum.FocusInner();
                return;
            }

            try
            {
                SetBusy(true, "Checking...");

                // ── Step 2: email domain check (skipped if we can't reach DNS) ─────
                if (!string.IsNullOrEmpty(emailAddress))
                {
                    bool domainOk = await EmailDomainCanReceiveMailAsync(emailAddress.Split('@')[1]);
                    if (!domainOk)
                    {
                        Warn("The email domain does not exist or cannot receive emails.\nPlease use a real email address.");
                        txtEmailAdd.FocusInner();
                        return;
                    }
                }

                // ── Step 3: duplicate checks ───────────────────────────────────────
                var db = DatabaseService.GetDatabase();
                var companies = db.GetCollection<BsonDocument>("companies");
                var users = db.GetCollection<BsonDocument>("users");

                string emailLower = emailAddress.ToLowerInvariant();
                string contactDigits = Regex.Replace(contactNumber, @"\D", "");

                if (await ExistsAsync(companies, "nameKey", nameKey))
                {
                    Warn($"A company named '{companyName}' (or a very similar name) already exists.\nPlease choose a different name.");
                    txtCompanyName.FocusInner();
                    return;
                }

                if (!string.IsNullOrEmpty(emailAddress) && await ExistsAsync(companies, "emailLower", emailLower))
                {
                    Warn($"The email '{emailAddress}' is already registered to another company.\nPlease use a different email address.");
                    txtEmailAdd.FocusInner();
                    return;
                }

                if (!string.IsNullOrEmpty(contactNumber) && await ExistsAsync(companies, "contactDigits", contactDigits))
                {
                    Warn($"The contact number '{contactNumber}' is already registered to another company.\nPlease use a different contact number.");
                    txtContactNum.FocusInner();
                    return;
                }

                // ── Step 4: create company and admin together (all or nothing) ─────
                SetBusy(true, "Creating...");

                var companyId = ObjectId.GenerateNewId();
                string password = GeneratePassword();
                var now = DateTime.UtcNow;

                var companyDoc = new BsonDocument
                {
                    { "_id", companyId },
                    { "name", companyName },
                    { "nameKey", nameKey },
                    { "isActive", true },
                    { "createdAt", now }
                };
                if (!string.IsNullOrEmpty(emailAddress))
                {
                    companyDoc["email"] = emailAddress;
                    companyDoc["emailLower"] = emailLower;
                }
                if (!string.IsNullOrEmpty(contactNumber))
                {
                    companyDoc["contactNumber"] = contactNumber;
                    companyDoc["contactDigits"] = contactDigits;
                }

                // Plaintext password to match the current demo LoginService.
                // When you switch to hashing, store BCrypt.HashPassword(password) in "passwordHash" instead.
                var adminDoc = new BsonDocument
                {
                    { "companyId", companyId },
                    { "username", AdminUsername },
                    { "password", password },
                    { "fullName", "System Administrator" },
                    { "role", "Admin" },
                    { "isActive", true },
                    { "mustChangePassword", true },
                    { "isCompanyOwner", true },   // the admin created automatically with the company
                    { "createdBy", "system" },
                    { "createdAt", now },
                    { "updatedAt", now }
                };
                if (!string.IsNullOrEmpty(emailAddress))
                    adminDoc["email"] = emailAddress;

                using (var session = await DatabaseService.GetClient().StartSessionAsync())
                {
                    session.StartTransaction();
                    try
                    {
                        adminDoc["employeeNo"] = await EmployeeNumberService.NextAsync(companyId, session);
                        await companies.InsertOneAsync(session, companyDoc);
                        await users.InsertOneAsync(session, adminDoc);
                        await session.CommitTransactionAsync();
                    }
                    catch
                    {
                        await session.AbortTransactionAsync();
                        throw;
                    }
                }

                ShowSuccess(companyName, password, emailAddress, contactNumber);

                new LogInForm().Show();
                this.Hide();
            }
            catch (MongoWriteException ex) when (ex.WriteError?.Category == ServerErrorCategory.DuplicateKey)
            {
                // Someone registered the same name/email/number a moment ago
                Warn("A company with these details was just registered.\nPlease change the name, email or contact number and try again.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating company:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusy(false, "Create Company");
            }
        }

        private void ShowSuccess(string companyName, string password, string email, string contact)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Company '{companyName}' created successfully!");
            sb.AppendLine();
            sb.AppendLine("Admin Credentials:");
            sb.AppendLine($"Company:  {companyName}");
            sb.AppendLine($"Username: {AdminUsername}");
            sb.AppendLine($"Password: {password}");
            sb.AppendLine();
            sb.AppendLine("⚠️ Save this password. You won't see it again.");

            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(contact))
            {
                sb.AppendLine();
                sb.AppendLine("Company Contact Information:");
                if (!string.IsNullOrEmpty(email)) sb.AppendLine($"Email: {email}");
                if (!string.IsNullOrEmpty(contact)) sb.AppendLine($"Contact Number: {contact}");
            }

            sb.AppendLine();
            sb.Append("Copy the login details to the clipboard?");

            var answer = MessageBox.Show(sb.ToString(), "Company Created",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (answer == DialogResult.Yes)
            {
                try
                {
                    Clipboard.SetText($"Company: {companyName}\r\nUsername: {AdminUsername}\r\nPassword: {password}");
                }
                catch { /* clipboard can be locked by another app; ignore */ }
            }
        }

        // ── Helpers ───────────────────────────────────────────────────────────

        private void SetBusy(bool busy, string buttonText)
        {
            _busy = busy;
            btnCreateCompany.Enabled = !busy;
            btnCreateCompany.Text = buttonText;
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
        }

        private static void Warn(string message) =>
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private static async Task<bool> ExistsAsync(IMongoCollection<BsonDocument> col, string field, string value)
        {
            long count = await col.CountDocumentsAsync(
                Builders<BsonDocument>.Filter.Eq(field, value),
                new CountOptions { Limit = 1 });
            return count > 0;
        }

        // "Sample  Clinic!" and "sample clinic" both become "sampleclinic"
        private static string NormalizeName(string name) =>
            Regex.Replace(name.ToLowerInvariant(), @"[^\p{L}\p{N}]", "");

        private static bool IsValidEmailFormat(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.Contains('.') && email.Split('@').Length == 2;
            }
            catch { return false; }
        }

        // Returns true if the domain can receive mail, or if DNS can't be reached (don't block offline setup)
        private static async Task<bool> EmailDomainCanReceiveMailAsync(string domain)
        {
            try
            {
                var lookup = new LookupClient(new LookupClientOptions
                {
                    Timeout = TimeSpan.FromSeconds(5),
                    Retries = 1
                });

                var mx = await lookup.QueryAsync(domain, QueryType.MX);
                if (mx.Answers.MxRecords().Any()) return true;

                // No MX record: a domain can still accept mail on its A record
                var a = await lookup.QueryAsync(domain, QueryType.A);
                return a.Answers.ARecords().Any();
            }
            catch
            {
                return true;
            }
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            string cleaned = Regex.Replace(phoneNumber, @"[\s\-().]", "");
            return Regex.IsMatch(cleaned, @"^\+?\d{7,15}$");
        }

        // Random 10-character password; skips look-alike characters (0/O, 1/l/I)
        private static string GeneratePassword(int length = 10)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789";
            var sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
                sb.Append(chars[RandomNumberGenerator.GetInt32(chars.Length)]);
            return sb.ToString();
        }
    }
}
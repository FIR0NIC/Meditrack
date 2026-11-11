using MongoDB.Bson;
using MongoDB.Driver;
using MediTrack.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediTrack.Receptionist
{
    public partial class ReceptionistDashboard : BaseForm
    {
        // MediTrack has no companies collection, so one fixed id is used (matches LoginService).
        private const string ClinicId = "meditrack";

        private readonly string _username;
        private readonly string _companyName;
        private readonly string _companyId;
        private readonly string _userId;
        private readonly string _sessionToken;
        private readonly LoginService _loginService = new LoginService();
        private DataTable _inventoryStatusTable;

        public ReceptionistDashboard(string username, string companyName, string userId, string sessionToken)
        {
            InitializeComponent();
            InitializeTitleBar(closeButton, titleBar, titleLabel);

            _username = username;
            _companyName = companyName;
            _userId = userId;
            _sessionToken = sessionToken;
            _companyId = ClinicId;

            // Set user context with session info for BaseForm
            SetUserContext(_username, _userId, _sessionToken);
            SetUserContext(_username, _companyId); // For audit logging

            lblInventoryName.Text = $"{_username} | Receptionist";
            titleLabel.Text = $"{_companyName} ";

            SetupInventoryStatusGrid();
            this.Load += async (s, e) => await LoadInventoryStatusAsync();

            this.KeyPreview = true;
           // this.KeyDown += Dashboard_KeyDown;
           // InitializeShortcutHints();
        }

        // ── Setup Inventory Status Grid ────────────────────────────────────────

        private void SetupInventoryStatusGrid()
        {
            dgvInventStatus.AutoGenerateColumns = false;
            dgvInventStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventStatus.ReadOnly = true;
            dgvInventStatus.RowHeadersVisible = false;
            dgvInventStatus.AllowUserToAddRows = false;
            dgvInventStatus.BackgroundColor = Color.White;
            dgvInventStatus.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);

            // Clear existing columns first to avoid duplicates
            dgvInventStatus.Columns.Clear();

            // Add columns
            dgvInventStatus.Columns.Add(new DataGridViewTextBoxColumn { Name = "product_code", HeaderText = "Product Code", FillWeight = 12 });
            dgvInventStatus.Columns.Add(new DataGridViewTextBoxColumn { Name = "product_name", HeaderText = "Product Name", FillWeight = 25 });
            dgvInventStatus.Columns.Add(new DataGridViewTextBoxColumn { Name = "current_stock", HeaderText = "Current Stock", FillWeight = 10, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvInventStatus.Columns.Add(new DataGridViewTextBoxColumn { Name = "reorder_level", HeaderText = "Reorder Level", FillWeight = 10, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvInventStatus.Columns.Add(new DataGridViewTextBoxColumn { Name = "status", HeaderText = "Stock Status", FillWeight = 12 });
            dgvInventStatus.Columns.Add(new DataGridViewTextBoxColumn { Name = "last_updated", HeaderText = "Last Stock Update", FillWeight = 15 });
            dgvInventStatus.Columns.Add(new DataGridViewTextBoxColumn { Name = "category", HeaderText = "Category", FillWeight = 10 });

            // Color the status column
            dgvInventStatus.CellFormatting += DgvInventStatus_CellFormatting;
        }

        private void DgvInventStatus_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvInventStatus.Columns[e.ColumnIndex].Name != "status" || e.Value == null)
                return;

            string status = e.Value.ToString();
            e.CellStyle.Font = new Font(dgvInventStatus.Font, FontStyle.Bold);

            switch (status)
            {
                case "Critical - Low Stock":
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.BackColor = Color.FromArgb(255, 220, 220);
                    break;
                case "Warning - Approaching Reorder":
                    e.CellStyle.ForeColor = Color.Orange;
                    e.CellStyle.BackColor = Color.FromArgb(255, 245, 200);
                    break;
                case "Normal - Adequate Stock":
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.BackColor = Color.FromArgb(220, 255, 220);
                    break;
                case "Out of Stock":
                    e.CellStyle.ForeColor = Color.DarkRed;
                    e.CellStyle.BackColor = Color.FromArgb(255, 200, 200);
                    e.CellStyle.Font = new Font(dgvInventStatus.Font, FontStyle.Bold | FontStyle.Italic);
                    break;
            }
        }

        // ── Load Inventory Status ─────────────────────────────────────────────

        private async Task LoadInventoryStatusAsync()
        {
            try
            {
                SetLoadingState(true);

                var dt = await FetchInventoryStatusAsync();
                _inventoryStatusTable = dt;

                dgvInventStatus.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int rowIndex = dgvInventStatus.Rows.Add();
                    var gridRow = dgvInventStatus.Rows[rowIndex];

                    gridRow.Cells["product_code"].Value = row["product_code"];
                    gridRow.Cells["product_name"].Value = row["product_name"];
                    gridRow.Cells["current_stock"].Value = row["current_stock"];
                    gridRow.Cells["reorder_level"].Value = row["reorder_level"];
                    gridRow.Cells["status"].Value = row["status"];
                    gridRow.Cells["last_updated"].Value = row["last_stock_update"];
                    gridRow.Cells["category"].Value = row["category"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory status:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        // Reads the "products" and "categories" collections and works out the stock status in C#
        private async Task<DataTable> FetchInventoryStatusAsync()
        {
            var db = DatabaseService.GetDatabase();

            // categories: id -> name
            var categoryDocs = await db.GetCollection<BsonDocument>("categories")
                .Find(FilterDefinition<BsonDocument>.Empty)
                .ToListAsync();

            var categoryNames = categoryDocs.ToDictionary(
                c => c["_id"].ToString(),
                c => c.GetValue("name", "").ToString());

            var products = await db.GetCollection<BsonDocument>("products")
                .Find(FilterDefinition<BsonDocument>.Empty)
                .ToListAsync();

            var items = products.Select(p =>
            {
                int qty = ToInt(p.GetValue("quantity", 0));
                int reorder = ToInt(p.GetValue("reorderLevel", 0));

                string status;
                int rank;
                if (qty <= 0) { status = "Out of Stock"; rank = 1; }
                else if (qty <= reorder) { status = "Critical - Low Stock"; rank = 2; }
                else if (qty <= reorder * 2) { status = "Warning - Approaching Reorder"; rank = 3; }
                else { status = "Normal - Adequate Stock"; rank = 4; }

                var catId = p.GetValue("categoryId", BsonNull.Value);
                string category = !catId.IsBsonNull && categoryNames.TryGetValue(catId.ToString(), out var name)
                    ? name : "";

                var stockedIn = p.GetValue("stockedInDate", BsonNull.Value);

                return new
                {
                    Code = p.GetValue("productCode", "").ToString(),
                    Name = p.GetValue("productName", "").ToString(),
                    Qty = qty,
                    Reorder = reorder,
                    Status = status,
                    Rank = rank,
                    LastUpdate = stockedIn.IsBsonDateTime
                        ? (object)stockedIn.ToUniversalTime().ToLocalTime()
                        : DBNull.Value,
                    Category = category,
                    Price = p.GetValue("price", 0).IsNumeric ? p["price"].ToDouble() : 0.0
                };
            })
            .OrderBy(i => i.Rank)
            .ThenBy(i => i.Name);

            var dt = new DataTable();
            dt.Columns.Add("product_code", typeof(string));
            dt.Columns.Add("product_name", typeof(string));
            dt.Columns.Add("current_stock", typeof(int));
            dt.Columns.Add("reorder_level", typeof(int));
            dt.Columns.Add("status", typeof(string));
            dt.Columns.Add("last_stock_update", typeof(DateTime));
            dt.Columns.Add("category", typeof(string));
            dt.Columns.Add("price", typeof(double));

            foreach (var i in items)
                dt.Rows.Add(i.Code, i.Name, i.Qty, i.Reorder, i.Status, i.LastUpdate, i.Category, i.Price);

            return dt;
        }

        private static int ToInt(BsonValue v) => v.IsNumeric ? v.ToInt32() : 0;

        private void SetLoadingState(bool loading)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(SetLoadingState), loading);
                return;
            }

            if (loading)
            {
                Cursor = Cursors.WaitCursor;
                dgvInventStatus.Enabled = false;
                btnRefresh.Enabled = false;
            }
            else
            {
                Cursor = Cursors.Default;
                dgvInventStatus.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadInventoryStatusAsync();
        }

        // ── Navigation ────────────────────────────────────────────────────────

        private void ShowSubScreen(Form form)
        {
            form.Show();
            this.Hide();
        }

        /*private void btnManageProducts_Click(object sender, EventArgs e) =>
            ShowSubScreen(new ManageProdFrm(_username, _companyName, _userId, _sessionToken));

        private void btnManageStocks_Click(object sender, EventArgs e) =>
            ShowSubScreen(new ManageStocks(_username, _companyName, _userId, _sessionToken)); */

        // ── Logout ────────────────────────────────────────────────────────────

        private async void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // CRITICAL: Set static flag first
            BaseForm.SetAppExiting(true);

            // Stop the session timer
            StopSessionMonitoring();

            try
            {
                // Terminate session in database
                await _loginService.LogoutSessionAsync(_userId, _sessionToken);
                await LogLogoutAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Logout error: {ex.Message}");
            }

            // Navigate to login form and close current
            new LogInForm().Show();
            this.Close();
        }

        // Records the logout in the loginAudit collection
        private async Task LogLogoutAsync()
        {
            try
            {
                BsonValue uid = ObjectId.TryParse(_userId, out var oid) ? (BsonValue)oid : BsonNull.Value;

                await DatabaseService.GetDatabase()
                    .GetCollection<BsonDocument>("loginAudit")
                    .InsertOneAsync(new BsonDocument
                    {
                        { "userId", uid },
                        { "username", _username },
                        { "success", true },
                        { "reason", "logout" },
                        { "machine", Environment.MachineName },
                        { "timestamp", DateTime.UtcNow }
                    });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Logout audit failed: {ex.Message}");
            }
        }

        // ── Keyboard Shortcuts ────────────────────────────────────────────────

        /*private void Dashboard_KeyDown(object sender, KeyEventArgs e)
        {
            var shortcuts = new Dictionary<Keys, EventHandler>
            {
                { Keys.Escape, btnLogOut_Click },
                { Keys.F1,     btnManageProducts_Click },
                { Keys.F2,     btnManageStocks_Click },
                { Keys.F5,     (s, ev) => btnRefresh_Click(s, ev) }
            };

            if (shortcuts.TryGetValue(e.KeyCode, out var handler))
            {
                handler?.Invoke(sender, e);
                e.Handled = true;
            }
        }

        private void InitializeShortcutHints()
        {
            var shortcuts = new Dictionary<Button, string>
            {
                { btnLogOut,        "ESC — Logout" },
                { btnManageProducts,"F1 — Manage Products (Read Only)" },
                { btnManageStocks,  "F2 — Manage Stocks" },
                { btnRefresh,       "F5 — Refresh Status" }
            };

            var toolTip = new ToolTip { InitialDelay = 200, ShowAlways = true };

            foreach (var (button, hint) in shortcuts)
            {
                toolTip.SetToolTip(button, hint);
                AttachHoverEffect(button);
            }
        }

        private void AttachHoverEffect(Button btn)
        {
            var originalLocation = btn.Location;

            btn.MouseEnter += (s, e) =>
            {
                btn.Location = new Point(originalLocation.X, originalLocation.Y - 3);
                btn.Padding = new Padding(0, 0, 0, 6);
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.Location = originalLocation;
                btn.Padding = new Padding(0);
            };
        } */
    }
}
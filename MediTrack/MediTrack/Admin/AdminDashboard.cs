using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml;
using MediTrack.Admin;

namespace MediTrack
{
    public partial class AdminDashboard : BaseForm
    {
        private readonly string _username;
        private readonly string _companyName;
        private readonly string _companyId;
        private readonly string _userId;
        private readonly string _sessionToken;
        private bool _isClosing = false;
        private readonly LoginService _loginService = new LoginService();
        //private SettingsForm _settingsForm; // Keep reference to settings form

        public AdminDashboard(string username, string companyName, string userId, string sessionToken)
        {
            InitializeComponent();
            InitializeTitleBar(closeButton, titleBar, titleLabel);

            _username = username;
            _companyName = companyName;
            _userId = userId;
            _sessionToken = sessionToken;
            // _companyId = GetCompanyId(_companyName);

            // Set user context with session info for BaseForm
            SetUserContext(_username, _userId, _sessionToken);
            SetUserContext(_username, _companyId); // For audit logging

            lblAdminName.Text = $"{_username} | Admin";
            titleLabel.Text = $"{_companyName} ";

            this.KeyPreview = true;
            //this.KeyDown += AdminDashboard_KeyDown;
            //InitializeShortcutHints();
        }

        /*  private string GetCompanyId(string companyName)
          {
              try
              {
                  using var conn = DatabaseService.GetConnection();
                  conn.Open();

                  const string query = "SELECT id FROM public.companies WHERE LOWER(name) = LOWER(@name) LIMIT 1";
                  using var cmd = new NpgsqlCommand(query, conn);
                  cmd.Parameters.AddWithValue("@name", companyName);

                  return cmd.ExecuteScalar()?.ToString();
              }
              catch (Exception ex)
              {
                  System.Diagnostics.Debug.WriteLine($"Error resolving company: {ex.Message}");
                  return null;
              }
          } */

        private async void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            _isClosing = true;
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

        private async Task LogLogoutAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(_companyId))
                {
                    //await AuditService.LogLogoutAsync(_username, _companyId, Environment.MachineName);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Logout audit failed: {ex.Message}");
            }
        }

        private void btnManageUsers_Click(object sender, EventArgs e) =>
            ShowFormAsDialog(new ManageUsers(_username, _companyName, _userId, _sessionToken));

        private void ShowFormAsDialog(Form form)
        {
            form.Show();
            this.Hide();
        }

        

        /*

               private void btnManageCategory_Click(object sender, EventArgs e) =>
                   ShowFormAsDialog(new ProdCategoryFrm(_username, _companyName, _userId, _sessionToken));

               private void btnManageProducts_Click(object sender, EventArgs e) =>
                   ShowFormAsDialog(new ManageProdFrm(_username, _companyName, _userId, _sessionToken));

               private void btnManageStocks_Click(object sender, EventArgs e) =>
                   ShowFormAsDialog(new ManageStocks(_username, _companyName, _userId, _sessionToken));

               private void btnTransactions_Click(object sender, EventArgs e) =>
                   ShowFormAsDialog(new TransactionsForm(_username, _companyName, _userId, _sessionToken));

               private void btnBusinessStats_Click(object sender, EventArgs e) =>
                   ShowFormAsDialog(new BusinessStatsForm(_username, _companyName, _userId, _sessionToken));

               private void btnSettings_Click(object sender, EventArgs e)
               {
                   // Check if settings form is already open
                   if (_settingsForm == null || _settingsForm.IsDisposed)
                   {
                       _settingsForm = new SettingsForm(_username, _companyName, _userId, _sessionToken);
                       _settingsForm.FormClosed += (s, args) => _settingsForm = null; // Clear reference when closed
                       _settingsForm.Show(); // Show without hiding admin dashboard
                   }
                   else
                   {
                       _settingsForm.BringToFront(); // Bring to front if already open
                       _settingsForm.Focus();
                   }
               }

               private void btnAudit_Click(object sender, EventArgs e) =>
                   ShowFormAsDialog(new EmployeeLogsFrm(_username, _companyName, _userId, _sessionToken));

             
               private async void btnSalesReport_Click(object sender, EventArgs e)
               {
                   var exporter = new SalesReportExporter(_companyName, _companyId, this);
                   await exporter.ShowDateRangeDialogAndExport();
               }

               private void AdminDashboard_KeyDown(object sender, KeyEventArgs e)
               {
                   //Admin CHeatShit fix
                   if (e.KeyCode == Keys.H)
                   {
                       AdminShortcutCheatSheet();
                       e.Handled = true;
                       return;
                   }

                   var shortcuts = new Dictionary<Keys, EventHandler>
                   {
                       { Keys.Escape, btnLogOut_Click },
                       { Keys.F1, btnManageUsers_Click },
                       { Keys.F2, btnManageCategory_Click },
                       { Keys.F3, btnManageProducts_Click },
                       { Keys.F4, btnManageStocks_Click },
                       { Keys.F5, btnTransactions_Click },
                       { Keys.F6, btnBusinessStats_Click },
                       { Keys.F7, btnSalesReport_Click },
                       { Keys.F8, btnAudit_Click },
                       { Keys.F9, btnSettings_Click },
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
                       { btnLogOut, "ESC" }, { btnManageUsers, "F1" }, { btnManageCategory, "F2" },
                       { btnManageProducts, "F3" }, { btnManageStocks, "F4" }, { btnTransactions, "F5" },
                       { btnBusinessStats, "F6" }, { btnSalesReport, "F7" },{ btnAudit, "F8" }, { btnSettings, "F9" }
                   };

                   var toolTip = new ToolTip { InitialDelay = 200, ShowAlways = true };

                   foreach (var (button, shortcut) in shortcuts)
                   {
                       toolTip.SetToolTip(button, shortcut);
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
               }

               private void btnSubscriptionOffers_Click(object sender, EventArgs e)
               {
                   using var subForm = new SubscriptionForm();
                   subForm.ShowDialog(this);
               }

               private void AdminShortcutCheatSheet()
               {
                   string adminCheatSheet =
                       @"Shortcuts:
       ESC - Logout
       F1 - Manage Users
       F2 - Manage Category
       F3 - Manage Products
       F4 - Manage Stocks
       F5 - Transactions
       F6 - Business Stats
       F7 - Sales Report
       F8 - Audit
       F9 - Settings
       Up & Down arrow Keys - Navigate between text boxes";

                   MessageBox.Show(adminCheatSheet, "Shortcuts:",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
           } */
    }
}
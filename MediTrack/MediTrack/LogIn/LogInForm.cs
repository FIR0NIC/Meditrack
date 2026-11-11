using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediTrack.Receptionist;
//using MediTrack.Doctor;
using MediTrack.Properties;

namespace MediTrack
{
    public partial class LogInForm : BaseForm
    {
        private readonly LoginService _loginService = new();
        private readonly CredentialsService _credentialsService = new();
        private const string UsernamePlaceholder = "Username", PasswordPlaceholder = "Password", CompanyPlaceholder = "Company Name";

        public LogInForm()
        {
            InitializeComponent();
            InitializeTitleBar(closeButton, titleBar, titleLabel);
            KeyPreview = true;
            KeyDown += LogInForm_KeyDown;
        }

        private async void btnSignInClick(object sender, EventArgs e)
        {
            var (username, password, company) = GetSanitizedInputs();
            if (!ValidateInputs(username, password, company)) return;

            if (chckUserComp.Checked) _credentialsService.SaveCredentials(username, company);

            var result = await _loginService.AuthenticateAsync(username, password, company);

            if (!result.Success)
            {
                if (result.IsLockedOut)
                {
                    // Display lockout message with timer
                    int minutes = result.RemainingSeconds / 60;
                    int seconds = result.RemainingSeconds % 60;
                    MessageBox.Show(
                        $"Account is temporarily locked.\n\n" +
                        $"Please try again in {minutes} minute(s) and {seconds} second(s).\n\n",
                        "Account Locked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (result.RemainingAttempts > 0)
                {
                    MessageBox.Show(
                        $"{result.ErrorMessage}\n" +
                        $"WARNING: {result.RemainingAttempts} attempt(s) remaining before account lockout.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                var target = result.FocusTarget;
                if (target == ControlToFocus.Username) { txtUsername.Clear(); txtUsername.FocusInner(); }
                else if (target == ControlToFocus.Password) { txtPassword.Clear(); txtPassword.FocusInner(); }
                else if (target == ControlToFocus.Company) { txtCompany.Clear(); txtCompany.FocusInner(); }
                return;
            }

            // Login is already recorded in the loginAudit collection by LoginService.

            // Route by MongoDB role: "Admin", "Doctor", "Receptionist"
            Form dashboard = result.Role.ToUpperInvariant() switch
            {
                "ADMIN" => new AdminDashboard(username, result.CompanyName, result.UserId, result.SessionToken),
                "DOCTOR" => new DoctorDashboard(username, result.CompanyName, result.UserId, result.SessionToken),
                "RECEPTIONIST" => new ReceptionistDashboard(username, result.CompanyName, result.UserId, result.SessionToken),
                _ => null
            };

            if (dashboard == null)
            {
                MessageBox.Show(
                    $"The role '{result.Role}' has no dashboard assigned.\nPlease contact an administrator.",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dashboard.Show();
            Hide();
        }

        private (string username, string password, string company) GetSanitizedInputs()
        {
            string u = txtUsername.Text.Trim(), p = txtPassword.Text, c = txtCompany.Text.Trim();
            return (u == UsernamePlaceholder ? "" : u, p == PasswordPlaceholder ? "" : p, c == CompanyPlaceholder ? "" : c);
        }

        private bool ValidateInputs(string u, string p, string c)
        {
            if (!string.IsNullOrEmpty(u) && !string.IsNullOrEmpty(p) && !string.IsNullOrEmpty(c)) return true;
            MessageBox.Show("Please fill all of the text boxes.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (string.IsNullOrEmpty(u)) txtUsername.FocusInner();
            else if (string.IsNullOrEmpty(p)) txtPassword.FocusInner();
            else txtCompany.FocusInner();
            return false;
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            chckUserComp.Checked = _credentialsService.IsRememberEnabled;
            if (_credentialsService.IsRememberEnabled)
            {
                var (savedUsername, savedCompany) = _credentialsService.LoadSavedCredentials();
                if (!string.IsNullOrEmpty(savedUsername)) { txtUsername.Text = savedUsername; txtUsername.InnerForeColor = Color.Black; }
                if (!string.IsNullOrEmpty(savedCompany)) { txtCompany.Text = savedCompany; txtCompany.InnerForeColor = Color.Black; }
            }
        }

        private void LogInForm_Shown(object sender, EventArgs e)
        {
            if (_credentialsService.IsRememberEnabled) txtPassword.FocusInner();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (chckUserComp.Checked)
            {
                var (u, _, c) = GetSanitizedInputs();
                if (!string.IsNullOrEmpty(u)) _credentialsService.SaveCredentials(u, c);
            }
            else _credentialsService.ClearCredentials();
        }

        private void chckUserComp_CheckedChanged(object sender, EventArgs e)
        {
            if (chckUserComp.Checked)
            {
                var (u, _, c) = GetSanitizedInputs();
                if (!string.IsNullOrEmpty(u)) _credentialsService.SaveCredentials(u, c);
            }
            else _credentialsService.ClearCredentials();
        }

        private void txtUsername_Enter(object sender, EventArgs e) => PlaceholderTextHelper.ClearPlaceholder(txtUsername, UsernamePlaceholder);
        private void txtUsername_Leave(object sender, EventArgs e) => PlaceholderTextHelper.SetPlaceholder(txtUsername, UsernamePlaceholder);
        private void txtPassword_Enter(object sender, EventArgs e) => PlaceholderTextHelper.ClearPlaceholder(txtPassword, PasswordPlaceholder, true);
        private void txtPassword_Leave(object sender, EventArgs e) => PlaceholderTextHelper.SetPlaceholder(txtPassword, PasswordPlaceholder, true);
        private void txtCompany_Enter(object sender, EventArgs e) => PlaceholderTextHelper.ClearPlaceholder(txtCompany, CompanyPlaceholder);
        private void txtCompany_Leave(object sender, EventArgs e) => PlaceholderTextHelper.SetPlaceholder(txtCompany, CompanyPlaceholder);
        private void txtPassword_TextChanged(object sender, EventArgs e) => PlaceholderTextHelper.HandlePasswordTextChanged(txtPassword, PasswordPlaceholder);

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (sender == txtCompany) txtUsername.FocusInner();
                else if (sender == txtUsername) txtPassword.FocusInner();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (sender == txtPassword) txtUsername.FocusInner();
                else if (sender == txtUsername) txtCompany.FocusInner();
                e.Handled = true;
            }
        }

        private void LogInForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSignInClick(sender, e); e.Handled = true; }
            else if (e.KeyCode == Keys.Escape) { CloseButton_Click(sender, e); e.Handled = true; }
        }
    }
}
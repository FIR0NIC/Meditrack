using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediTrack
{
    public class BaseForm : Form
    {
        protected string CurrentUsername { get; private set; }
        protected string CurrentUserId { get; private set; }
        protected string CurrentSessionToken { get; private set; }
        private System.Windows.Forms.Timer _sessionTimer;
        private LoginService _loginService = new LoginService();
        private Point mouseOffset;
        private string _username;
        private string _companyId;
        private bool _isLoggingOut = false;
        private bool _sessionExpiredShown = false;
        private static bool _isAppExiting = false;
        private string _userId;
        private string _sessionToken;
        private bool _isClosing = false;
        private bool _isNavigating = false;

        // Property to control whether exit confirmation is needed
        protected virtual bool RequireExitConfirmation => true;

        protected void SetUserContext(string username, string userId, string sessionToken)
        {
            CurrentUsername = username;
            CurrentUserId = userId;
            CurrentSessionToken = sessionToken;
            _userId = userId;
            _sessionToken = sessionToken;
            _isLoggingOut = false;
            _sessionExpiredShown = false;
            _isClosing = false;
            _isNavigating = false;

            //CrashRecoveryService.RegisterActiveSession(userId, sessionToken);

            if (_sessionTimer == null && !_isLoggingOut && !_isAppExiting)
            {
                _sessionTimer = new System.Windows.Forms.Timer();
                _sessionTimer.Interval = 30000;
                _sessionTimer.Tick += OnTimerTick;
                _sessionTimer.Start();
            }
        }

        protected void SetUserContext(string username, string companyId)
        {
            _username = username;
            _companyId = companyId;
        }

        public void StopSessionMonitoring()
        {
            _isLoggingOut = true;
            _isAppExiting = true;

            if (_sessionTimer != null)
            {
                _sessionTimer.Enabled = false;
                _sessionTimer.Stop();
                _sessionTimer.Tick -= OnTimerTick;
                _sessionTimer.Dispose();
                _sessionTimer = null;
            }
        }

        protected void SetNavigating(bool navigating)
        {
            _isNavigating = navigating;
        }

        private async void OnTimerTick(object sender, EventArgs e)
        {
            if (_sessionTimer != null)
            {
                _sessionTimer.Enabled = false;
            }

            await ValidateCurrentSession();

            if (_sessionTimer != null && !_isLoggingOut && !_isAppExiting && !_sessionExpiredShown)
            {
                _sessionTimer.Enabled = true;
            }
        }

        private async Task ValidateCurrentSession()
        {
            if (_isLoggingOut || _sessionExpiredShown || _isAppExiting) return;

            if (string.IsNullOrEmpty(CurrentUserId) || string.IsNullOrEmpty(CurrentSessionToken))
                return;

            bool isValid = await _loginService.ValidateSessionAsync(CurrentUserId, CurrentSessionToken);

            if (!isValid)
            {
                _isLoggingOut = true;
                _sessionExpiredShown = true;
                _isAppExiting = true;

                if (_sessionTimer != null)
                {
                    _sessionTimer.Enabled = false;
                    _sessionTimer.Stop();
                    _sessionTimer.Tick -= OnTimerTick;
                    _sessionTimer.Dispose();
                    _sessionTimer = null;
                }

                if (InvokeRequired)
                {
                    Invoke(new Action(() => ShowSessionExpiredMessage()));
                }
                else
                {
                    ShowSessionExpiredMessage();
                }
            }
        }

        private void ShowSessionExpiredMessage()
        {
            MessageBox.Show(
                "Your session has expired because you logged in from another device.\n\n" +
                "The application will now close.",
                "Session Expired",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            Application.Exit();
        }

        protected override async void OnFormClosing(FormClosingEventArgs e)
        {
            if (_isNavigating)
            {
                base.OnFormClosing(e);
                return;
            }

            if (_isClosing) return;
            _isClosing = true;

            if (e.CloseReason == CloseReason.UserClosing && !_isLoggingOut && RequireExitConfirmation)
            {
                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to exit?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.No)
                {
                    _isClosing = false;
                    e.Cancel = true;
                    return;
                }

                await PerformLogoutAsync();
            }

            StopSessionMonitoring();
            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            StopSessionMonitoring();
            base.OnFormClosed(e);
        }

        // Make this method virtual so child forms can override
        protected virtual async Task PerformLogoutAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(_userId) && !string.IsNullOrEmpty(_sessionToken))
                {
                    await _loginService.LogoutSessionAsync(_userId, _sessionToken);
                }

                if (!string.IsNullOrEmpty(_companyId) && !string.IsNullOrEmpty(_username))
                {
                    //await AuditService.LogLogoutAsync(_username, _companyId, Environment.MachineName);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Logout error: {ex.Message}");
            }
        }

        protected void InitializeTitleBar(Button closeButton, params Control[] draggableControls)
        {
            foreach (var control in draggableControls)
                control.MouseDown += TitleBar_MouseDown;

            if (closeButton != null)
                closeButton.Click += CloseButton_Click;
        }

        // Make this method virtual so child forms can override
        public virtual async void CloseButton_Click(object sender, EventArgs e)
        {
            if (_isClosing) return;
            _isClosing = true;

            // Check if this form requires exit confirmation
            if (RequireExitConfirmation)
            {
                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to exit?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.No)
                {
                    _isClosing = false;
                    return;
                }
            }
            //CrashRecoveryService.UnregisterActiveSession(_sessionToken);

            await PerformLogoutAsync();
            StopSessionMonitoring();
            Application.Exit();
        }

        public static void SetAppExiting(bool exiting)
        {
            _isAppExiting = exiting;
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset = new Point(-e.X, -e.Y);
                var titleBar = sender as Control;
                titleBar.MouseMove += TitleBar_MouseMove;
                titleBar.MouseUp += TitleBar_MouseUp;
            }
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            var titleBar = sender as Control;
            titleBar.MouseMove -= TitleBar_MouseMove;
            titleBar.MouseUp -= TitleBar_MouseUp;
        }
    }
}
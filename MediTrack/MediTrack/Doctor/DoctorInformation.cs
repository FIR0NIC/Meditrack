using MediTrack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediTrack
{
    public partial class DoctorInformation : BaseForm
    {
        private readonly string _username, _companyName, _companyId, _userId, _sessionToken;
        public DoctorInformation(string username, string companyName, string userId, string sessionToken)
        {
            InitializeComponent();
            InitializeTitleBar(closeButton, titleBar, titleLabel);
        }
         private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            var titleBar = sender as Control;
            titleBar.MouseMove -= TitleBar_MouseMove;
            titleBar.MouseUp -= TitleBar_MouseUp;
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
        public virtual async void CloseButton_Click(object sender, EventArgs e)
        {
            if (_isClosing) return;
            _isClosing = true;

            
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
            

            await PerformLogoutAsync();
            StopSessionMonitoring();
            Application.Exit();
        }
        protected void InitializeTitleBar(Button closeButton, params Control[] draggableControls)
        {
            foreach (var control in draggableControls)
                control.MouseDown += TitleBar_MouseDown;

            if (closeButton != null)
                closeButton.Click += CloseButton_Click;
        }

        private void btnSaveAndReturn_Click(object sender, EventArgs e)
        {
            var doctorDashboard = new DoctorDashboard(
         CurrentUsername,
         CurrentCompanyName,
         CurrentUserId,
         CurrentSessionToken);

            doctorDashboard.Show();

        }
    }
}

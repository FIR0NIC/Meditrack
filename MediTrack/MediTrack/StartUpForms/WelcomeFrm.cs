using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediTrack.StartUpForms
{
    public partial class WelcomeFrm : BaseForm
    {
        public WelcomeFrm()
        {
            InitializeComponent();
            InitializeTitleBar(closeButton, titleBar, titleLabel);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to create a new company?",
                "Confirm Action",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                NewCompanyFrm newCompany = new NewCompanyFrm();
                newCompany.Show();
                this.Hide();
            }
        }

        private void btnOldUser_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you already have a company?",
                "Confirm Action",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                LogInForm logIn = new LogInForm();
                logIn.Show();
                this.Hide();
            }
        }

        private void chckDontShow_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DontShowWelcome = chckDontShow.Checked;
            Properties.Settings.Default.Save();
        }
    }
}

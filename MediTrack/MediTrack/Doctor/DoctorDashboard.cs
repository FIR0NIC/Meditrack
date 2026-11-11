using MediTrack;
using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediTrack
{
    public partial class DoctorDashboard : BaseForm
    {
        private readonly string _username, _companyName, _companyId, _userId, _sessionToken;       
        private DataTable _productsTable;
        private bool _isCartView = false;
        private bool _suppressSelectionChanged = false;
        private bool _isSearching = false;
        private readonly LoginService _loginService = new LoginService();
        private decimal _vatRate = 12m;
        public DoctorDashboard(string username, string companyName, string userId, string sessionToken)
        {
            InitializeComponent();
            InitializeTitleBar(closeButton, titleBar, titleLabel);

            _username = username;
            _companyName = companyName;
            
            _userId = userId;
            _sessionToken = sessionToken;

            lblDoctorName.Text = $"{_username} | Cashier";
            titleLabel.Text = $"{_companyName}";
            SetUserContext(_username, _userId, _sessionToken);
            SetUserContext(_username, _companyId);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblCashierName_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalPrice_Click(object sender, EventArgs e)
        {

        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            var doctorInformation = new DoctorInformation(
                CurrentUsername,
                CurrentCompanyName,
                CurrentUserId,
                CurrentSessionToken);
            doctorInformation.Show();
        }

    }
}
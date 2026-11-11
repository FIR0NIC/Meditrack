namespace MediTrack
{
    partial class DoctorDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorDashboard));
            titleBar = new Panel();
            closeButton = new Button();
            lblDoctorName = new Label();
            titleLabel = new Label();
            btnLogOut = new RoundedButton();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1 = new Panel();
            txtPatientName = new CustomControls.CustomTextBox();
            txtPatientNumber = new CustomControls.CustomTextBox();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblNoOfPatients = new Label();
            panel2 = new Panel();
            label8 = new Label();
            usersBindingSource = new BindingSource(components);
            lblProducts = new Label();
            dgvPatientRecords = new DataGridView();
            btnEditProfile = new RoundedButton();
            panel3 = new Panel();
            label1 = new Label();
            lblSpecialization = new Label();
            btnDoctorAvailability = new RoundedButton();
            label4 = new Label();
            lblEmail = new Label();
            lblContactNo = new Label();
            titleBar.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPatientRecords).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // titleBar
            // 
            titleBar.BackColor = Color.FromArgb(44, 62, 80);
            titleBar.Controls.Add(closeButton);
            titleBar.Controls.Add(titleLabel);
            titleBar.Dock = DockStyle.Top;
            titleBar.Location = new Point(0, 0);
            titleBar.Name = "titleBar";
            titleBar.Size = new Size(1267, 43);
            titleBar.TabIndex = 17;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeButton.BackColor = Color.FromArgb(44, 62, 80);
            closeButton.BackgroundImageLayout = ImageLayout.None;
            closeButton.Cursor = Cursors.Hand;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(231, 76, 60);
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.ForeColor = Color.White;
            closeButton.Location = new Point(1226, 0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(41, 43);
            closeButton.TabIndex = 17;
            closeButton.Text = " X";
            closeButton.UseVisualStyleBackColor = false;
            // 
            // lblDoctorName
            // 
            lblDoctorName.AutoSize = true;
            lblDoctorName.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDoctorName.ForeColor = Color.Black;
            lblDoctorName.Location = new Point(13, 21);
            lblDoctorName.Name = "lblDoctorName";
            lblDoctorName.Size = new Size(111, 21);
            lblDoctorName.TabIndex = 20;
            lblDoctorName.Text = "doctorName";
            lblDoctorName.Click += lblCashierName_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(12, 10);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(148, 21);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "MediTrack System";
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.SteelBlue;
            btnLogOut.BorderColor = Color.Transparent;
            btnLogOut.BorderRadius = 10;
            btnLogOut.BorderSize = 0;
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.ForeColor = Color.White;
            btnLogOut.Location = new Point(750, 121);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(144, 40);
            btnLogOut.TabIndex = 21;
            btnLogOut.Text = "LOGOUT";
            btnLogOut.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(txtPatientName);
            panel1.Controls.Add(txtPatientNumber);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(44, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(680, 162);
            panel1.TabIndex = 18;
            // 
            // txtPatientName
            // 
            txtPatientName.BorderColor = SystemColors.ButtonFace;
            txtPatientName.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtPatientName.BorderRadius = 8;
            txtPatientName.BorderThickness = 2;
            txtPatientName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPatientName.ForeColor = Color.Black;
            txtPatientName.InnerBackColor = SystemColors.InactiveCaption;
            txtPatientName.InnerForeColor = Color.Black;
            txtPatientName.IsPasswordField = false;
            txtPatientName.Location = new Point(459, 34);
            txtPatientName.Name = "txtPatientName";
            txtPatientName.PasswordChar = '\0';
            txtPatientName.PlaceholderColor = Color.Black;
            txtPatientName.PlaceholderText = "";
            txtPatientName.Size = new Size(194, 39);
            txtPatientName.TabIndex = 31;
            // 
            // txtPatientNumber
            // 
            txtPatientNumber.BorderColor = SystemColors.ButtonFace;
            txtPatientNumber.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtPatientNumber.BorderRadius = 8;
            txtPatientNumber.BorderThickness = 2;
            txtPatientNumber.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPatientNumber.ForeColor = Color.Black;
            txtPatientNumber.InnerBackColor = SystemColors.InactiveCaption;
            txtPatientNumber.InnerForeColor = Color.Black;
            txtPatientNumber.IsPasswordField = false;
            txtPatientNumber.Location = new Point(143, 34);
            txtPatientNumber.Name = "txtPatientNumber";
            txtPatientNumber.PasswordChar = '\0';
            txtPatientNumber.PlaceholderColor = Color.Black;
            txtPatientNumber.PlaceholderText = "";
            txtPatientNumber.Size = new Size(194, 39);
            txtPatientNumber.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.Control;
            label6.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(343, 44);
            label6.Name = "label6";
            label6.Size = new Size(110, 18);
            label6.TabIndex = 25;
            label6.Text = "Patient Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(13, 44);
            label3.Name = "label3";
            label3.Size = new Size(124, 18);
            label3.TabIndex = 22;
            label3.Text = "Patient Number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightSteelBlue;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(44, 63);
            label2.Name = "label2";
            label2.Size = new Size(180, 19);
            label2.TabIndex = 21;
            label2.Text = "PATIENT INFORMATION";
            // 
            // lblNoOfPatients
            // 
            lblNoOfPatients.AutoSize = true;
            lblNoOfPatients.BackColor = SystemColors.Control;
            lblNoOfPatients.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoOfPatients.ForeColor = Color.Black;
            lblNoOfPatients.Location = new Point(32, 23);
            lblNoOfPatients.Name = "lblNoOfPatients";
            lblNoOfPatients.Size = new Size(18, 19);
            lblNoOfPatients.TabIndex = 22;
            lblNoOfPatients.Text = "0";
            lblNoOfPatients.TextAlign = ContentAlignment.MiddleCenter;
            lblNoOfPatients.Click += lblTotalPrice_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(lblNoOfPatients);
            panel2.Location = new Point(153, 86);
            panel2.Name = "panel2";
            panel2.Size = new Size(82, 66);
            panel2.TabIndex = 26;
            panel2.Paint += panel2_Paint;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.Control;
            label8.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(13, 109);
            label8.Name = "label8";
            label8.Size = new Size(115, 19);
            label8.TabIndex = 27;
            label8.Text = "No. of Patients";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            label8.Click += label8_Click;
            // 
            // lblProducts
            // 
            lblProducts.AutoSize = true;
            lblProducts.BackColor = Color.LightSteelBlue;
            lblProducts.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProducts.ForeColor = Color.Black;
            lblProducts.Location = new Point(44, 232);
            lblProducts.Name = "lblProducts";
            lblProducts.Size = new Size(142, 19);
            lblProducts.TabIndex = 37;
            lblProducts.Text = "PATIENT RECORDS";
            // 
            // dgvPatientRecords
            // 
            dgvPatientRecords.AllowUserToAddRows = false;
            dgvPatientRecords.AllowUserToDeleteRows = false;
            dgvPatientRecords.AllowUserToOrderColumns = true;
            dgvPatientRecords.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dgvPatientRecords.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPatientRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatientRecords.BackgroundColor = Color.White;
            dgvPatientRecords.BorderStyle = BorderStyle.None;
            dgvPatientRecords.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPatientRecords.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 5, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPatientRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPatientRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatientRecords.EnableHeadersVisualStyles = false;
            dgvPatientRecords.GridColor = Color.FromArgb(230, 230, 230);
            dgvPatientRecords.Location = new Point(44, 254);
            dgvPatientRecords.Name = "dgvPatientRecords";
            dgvPatientRecords.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPatientRecords.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPatientRecords.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.InactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dgvPatientRecords.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvPatientRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatientRecords.Size = new Size(1183, 456);
            dgvPatientRecords.TabIndex = 58;
            // 
            // btnEditProfile
            // 
            btnEditProfile.BackColor = Color.SteelBlue;
            btnEditProfile.BorderColor = Color.Transparent;
            btnEditProfile.BorderRadius = 10;
            btnEditProfile.BorderSize = 0;
            btnEditProfile.FlatAppearance.BorderSize = 0;
            btnEditProfile.FlatStyle = FlatStyle.Flat;
            btnEditProfile.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditProfile.ForeColor = Color.White;
            btnEditProfile.Location = new Point(750, 73);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(144, 42);
            btnEditProfile.TabIndex = 59;
            btnEditProfile.Text = "EDIT PROFILE";
            btnEditProfile.UseVisualStyleBackColor = false;
            btnEditProfile.Click += btnEditProfile_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblContactNo);
            panel3.Controls.Add(lblEmail);
            panel3.Controls.Add(lblSpecialization);
            panel3.Controls.Add(lblDoctorName);
            panel3.Location = new Point(915, 73);
            panel3.Name = "panel3";
            panel3.Size = new Size(312, 162);
            panel3.TabIndex = 60;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightSteelBlue;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(915, 63);
            label1.Name = "label1";
            label1.Size = new Size(67, 19);
            label1.TabIndex = 61;
            label1.Text = "PROFILE";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSpecialization
            // 
            lblSpecialization.AutoSize = true;
            lblSpecialization.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSpecialization.ForeColor = Color.Black;
            lblSpecialization.Location = new Point(13, 52);
            lblSpecialization.Name = "lblSpecialization";
            lblSpecialization.Size = new Size(104, 21);
            lblSpecialization.TabIndex = 21;
            lblSpecialization.Text = "specializtion";
            // 
            // btnDoctorAvailability
            // 
            btnDoctorAvailability.BackColor = Color.Firebrick;
            btnDoctorAvailability.BorderColor = Color.Transparent;
            btnDoctorAvailability.BorderRadius = 10;
            btnDoctorAvailability.BorderSize = 0;
            btnDoctorAvailability.FlatAppearance.BorderSize = 0;
            btnDoctorAvailability.FlatStyle = FlatStyle.Flat;
            btnDoctorAvailability.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDoctorAvailability.ForeColor = Color.White;
            btnDoctorAvailability.Location = new Point(750, 197);
            btnDoctorAvailability.Name = "btnDoctorAvailability";
            btnDoctorAvailability.Size = new Size(144, 31);
            btnDoctorAvailability.TabIndex = 60;
            btnDoctorAvailability.Text = "Unavailable";
            btnDoctorAvailability.TextAlign = ContentAlignment.TopCenter;
            btnDoctorAvailability.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightSteelBlue;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(779, 175);
            label4.Name = "label4";
            label4.Size = new Size(89, 19);
            label4.TabIndex = 62;
            label4.Text = "MY STATUS";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(13, 119);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(52, 21);
            lblEmail.TabIndex = 22;
            lblEmail.Text = "email";
            // 
            // lblContactNo
            // 
            lblContactNo.AutoSize = true;
            lblContactNo.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContactNo.ForeColor = Color.Black;
            lblContactNo.Location = new Point(14, 86);
            lblContactNo.Name = "lblContactNo";
            lblContactNo.Size = new Size(97, 21);
            lblContactNo.TabIndex = 23;
            lblContactNo.Text = "contactNo";
            // 
            // DoctorDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1267, 749);
            Controls.Add(label4);
            Controls.Add(btnEditProfile);
            Controls.Add(btnDoctorAvailability);
            Controls.Add(btnLogOut);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(dgvPatientRecords);
            Controls.Add(lblProducts);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(titleBar);
            Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DoctorDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)usersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPatientRecords).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel titleBar;
        private Button closeButton;
        private Label titleLabel;
        private ContextMenuStrip contextMenuStrip1;
        private Label lblDoctorName;
        private Panel panel1;
        private Label label2;
        private Label label6;
        private Label label3;
        private Label lblNoOfPatients;
        private Panel panel2;
        private Label label8;
        private CustomControls.CustomTextBox txtPatientName;
        private CustomControls.CustomTextBox txtPatientNumber;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn baseUrlDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn requestClientOptionsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tableNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn primaryKeyDataGridViewTextBoxColumn;
        private BindingSource usersBindingSource;
        private RoundedButton btnLogOut;
        private Label lblProducts;
        private DataGridView dgvPatientRecords;
        private RoundedButton btnEditProfile;
        private Panel panel3;
        private Label label1;
        private Label lblSpecialization;
        private RoundedButton btnDoctorAvailability;
        private Label label4;
        private Label lblContactNo;
        private Label lblEmail;
    }
}
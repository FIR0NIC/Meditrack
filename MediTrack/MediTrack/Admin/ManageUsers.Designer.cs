namespace MediTrack.Admin
{
    partial class ManageUsers
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            titleBar = new Panel();
            lblAdminName = new Label();
            closeButton = new Button();
            titleLabel = new Label();
            btnAdd = new RoundedButton();
            btnEdit = new RoundedButton();
            btnDelete = new RoundedButton();
            label2 = new Label();
            panel1 = new Panel();
            lblPasswordStrength = new Label();
            label1 = new Label();
            dtpBirthdate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            cmbUserLevel = new Guna.UI2.WinForms.Guna2ComboBox();
            label11 = new Label();
            txtContact = new CustomControls.CustomTextBox();
            label10 = new Label();
            txtMiddleName = new CustomControls.CustomTextBox();
            txtFirstName = new CustomControls.CustomTextBox();
            txtLastName = new CustomControls.CustomTextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            txtPassword = new CustomControls.CustomTextBox();
            txtAge = new CustomControls.CustomTextBox();
            txtUsername = new CustomControls.CustomTextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            dgvUsers = new DataGridView();
            btnClear = new RoundedButton();
            txtSearch = new CustomControls.CustomTextBox();
            label12 = new Label();
            btnBack = new RoundedButton();
            titleBar.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // titleBar
            // 
            titleBar.BackColor = Color.FromArgb(44, 62, 80);
            titleBar.Controls.Add(lblAdminName);
            titleBar.Controls.Add(closeButton);
            titleBar.Controls.Add(titleLabel);
            titleBar.Dock = DockStyle.Top;
            titleBar.Location = new Point(0, 0);
            titleBar.Name = "titleBar";
            titleBar.Size = new Size(1266, 48);
            titleBar.TabIndex = 18;
            // 
            // lblAdminName
            // 
            lblAdminName.AutoSize = true;
            lblAdminName.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdminName.ForeColor = Color.White;
            lblAdminName.Location = new Point(1012, 12);
            lblAdminName.Name = "lblAdminName";
            lblAdminName.Size = new Size(179, 21);
            lblAdminName.TabIndex = 21;
            lblAdminName.Text = "adminName | Admin";
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.FromArgb(44, 62, 80);
            closeButton.BackgroundImageLayout = ImageLayout.None;
            closeButton.Cursor = Cursors.Hand;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(231, 76, 60);
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.ForeColor = Color.White;
            closeButton.Location = new Point(1216, 0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(48, 48);
            closeButton.TabIndex = 17;
            closeButton.Text = " X";
            closeButton.UseVisualStyleBackColor = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(12, 12);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(148, 21);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "MediTrack System";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SteelBlue;
            btnAdd.BorderColor = Color.Transparent;
            btnAdd.BorderRadius = 10;
            btnAdd.BorderSize = 0;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Dubai", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(363, 742);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 42);
            btnAdd.TabIndex = 23;
            btnAdd.Text = "Add";
            btnAdd.TextAlign = ContentAlignment.TopCenter;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.SteelBlue;
            btnEdit.BorderColor = Color.Transparent;
            btnEdit.BorderRadius = 10;
            btnEdit.BorderSize = 0;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Dubai", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(499, 742);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 42);
            btnEdit.TabIndex = 24;
            btnEdit.Text = "Edit";
            btnEdit.TextAlign = ContentAlignment.TopCenter;
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.SteelBlue;
            btnDelete.BorderColor = Color.Transparent;
            btnDelete.BorderRadius = 10;
            btnDelete.BorderSize = 0;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Dubai", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(648, 742);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 42);
            btnDelete.TabIndex = 25;
            btnDelete.Text = "Delete";
            btnDelete.TextAlign = ContentAlignment.TopCenter;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightSteelBlue;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(0, -3);
            label2.Name = "label2";
            label2.Size = new Size(210, 19);
            label2.TabIndex = 27;
            label2.Text = "EMPLOYEE'S INFORMATION";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblPasswordStrength);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dtpBirthdate);
            panel1.Controls.Add(cmbUserLevel);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(txtContact);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(txtMiddleName);
            panel1.Controls.Add(txtFirstName);
            panel1.Controls.Add(txtLastName);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtAge);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(37, 419);
            panel1.Name = "panel1";
            panel1.Size = new Size(1201, 306);
            panel1.TabIndex = 26;
            // 
            // lblPasswordStrength
            // 
            lblPasswordStrength.AutoSize = true;
            lblPasswordStrength.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPasswordStrength.Location = new Point(209, 119);
            lblPasswordStrength.Name = "lblPasswordStrength";
            lblPasswordStrength.Size = new Size(0, 17);
            lblPasswordStrength.TabIndex = 59;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(384, 86);
            label1.Name = "label1";
            label1.Size = new Size(0, 19);
            label1.TabIndex = 58;
            // 
            // dtpBirthdate
            // 
            dtpBirthdate.Checked = true;
            dtpBirthdate.CustomizableEdges = customizableEdges1;
            dtpBirthdate.FillColor = SystemColors.InactiveCaption;
            dtpBirthdate.Font = new Font("Segoe UI", 9F);
            dtpBirthdate.Format = DateTimePickerFormat.Long;
            dtpBirthdate.Location = new Point(865, 132);
            dtpBirthdate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpBirthdate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpBirthdate.Name = "dtpBirthdate";
            dtpBirthdate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dtpBirthdate.Size = new Size(247, 36);
            dtpBirthdate.TabIndex = 57;
            dtpBirthdate.Value = new DateTime(2026, 5, 12, 18, 57, 31, 485);
            // 
            // cmbUserLevel
            // 
            cmbUserLevel.BackColor = Color.Transparent;
            cmbUserLevel.BorderColor = Color.White;
            cmbUserLevel.CustomizableEdges = customizableEdges3;
            cmbUserLevel.DrawMode = DrawMode.OwnerDrawFixed;
            cmbUserLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUserLevel.FillColor = SystemColors.InactiveCaption;
            cmbUserLevel.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbUserLevel.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbUserLevel.Font = new Font("Segoe UI", 10F);
            cmbUserLevel.ForeColor = Color.FromArgb(68, 88, 112);
            cmbUserLevel.ItemHeight = 30;
            cmbUserLevel.Location = new Point(865, 186);
            cmbUserLevel.Name = "cmbUserLevel";
            cmbUserLevel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmbUserLevel.Size = new Size(247, 36);
            cmbUserLevel.TabIndex = 55;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.Control;
            label11.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(773, 192);
            label11.Name = "label11";
            label11.Size = new Size(86, 18);
            label11.TabIndex = 40;
            label11.Text = "User Level:";
            // 
            // txtContact
            // 
            txtContact.BorderColor = SystemColors.ButtonFace;
            txtContact.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtContact.BorderRadius = 8;
            txtContact.BorderThickness = 2;
            txtContact.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtContact.ForeColor = SystemColors.GrayText;
            txtContact.InnerBackColor = SystemColors.InactiveCaption;
            txtContact.InnerForeColor = Color.Black;
            txtContact.IsPasswordField = false;
            txtContact.Location = new Point(865, 23);
            txtContact.Name = "txtContact";
            txtContact.PasswordChar = '\0';
            txtContact.PlaceholderColor = Color.Gray;
            txtContact.PlaceholderText = "";
            txtContact.Size = new Size(247, 39);
            txtContact.TabIndex = 39;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.Control;
            label10.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(773, 32);
            label10.Name = "label10";
            label10.Size = new Size(84, 18);
            label10.TabIndex = 38;
            label10.Text = "Contact #:";
            // 
            // txtMiddleName
            // 
            txtMiddleName.BorderColor = SystemColors.ButtonFace;
            txtMiddleName.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtMiddleName.BorderRadius = 8;
            txtMiddleName.BorderThickness = 2;
            txtMiddleName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMiddleName.ForeColor = SystemColors.GrayText;
            txtMiddleName.InnerBackColor = SystemColors.InactiveCaption;
            txtMiddleName.InnerForeColor = Color.Black;
            txtMiddleName.IsPasswordField = false;
            txtMiddleName.Location = new Point(198, 247);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.PasswordChar = '\0';
            txtMiddleName.PlaceholderColor = Color.Gray;
            txtMiddleName.PlaceholderText = "";
            txtMiddleName.Size = new Size(326, 39);
            txtMiddleName.TabIndex = 37;
            // 
            // txtFirstName
            // 
            txtFirstName.BorderColor = SystemColors.ButtonFace;
            txtFirstName.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtFirstName.BorderRadius = 8;
            txtFirstName.BorderThickness = 2;
            txtFirstName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFirstName.ForeColor = SystemColors.GrayText;
            txtFirstName.InnerBackColor = SystemColors.InactiveCaption;
            txtFirstName.InnerForeColor = Color.Black;
            txtFirstName.IsPasswordField = false;
            txtFirstName.Location = new Point(198, 202);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PasswordChar = '\0';
            txtFirstName.PlaceholderColor = Color.Gray;
            txtFirstName.PlaceholderText = "";
            txtFirstName.Size = new Size(326, 39);
            txtFirstName.TabIndex = 36;
            // 
            // txtLastName
            // 
            txtLastName.BorderColor = SystemColors.ButtonFace;
            txtLastName.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtLastName.BorderRadius = 8;
            txtLastName.BorderThickness = 2;
            txtLastName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtLastName.ForeColor = SystemColors.GrayText;
            txtLastName.InnerBackColor = SystemColors.InactiveCaption;
            txtLastName.InnerForeColor = Color.Black;
            txtLastName.IsPasswordField = false;
            txtLastName.Location = new Point(198, 148);
            txtLastName.Name = "txtLastName";
            txtLastName.PasswordChar = '\0';
            txtLastName.PlaceholderColor = Color.Gray;
            txtLastName.PlaceholderText = "";
            txtLastName.Size = new Size(326, 39);
            txtLastName.TabIndex = 35;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.Control;
            label9.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(78, 258);
            label9.Name = "label9";
            label9.Size = new Size(113, 18);
            label9.TabIndex = 34;
            label9.Text = "Middle Name:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.Control;
            label8.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(78, 211);
            label8.Name = "label8";
            label8.Size = new Size(87, 18);
            label8.TabIndex = 33;
            label8.Text = "First Name:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.Control;
            label7.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(78, 157);
            label7.Name = "label7";
            label7.Size = new Size(88, 18);
            label7.TabIndex = 32;
            label7.Text = "Last Name:";
            // 
            // txtPassword
            // 
            txtPassword.BorderColor = SystemColors.ButtonFace;
            txtPassword.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtPassword.BorderRadius = 8;
            txtPassword.BorderThickness = 2;
            txtPassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = SystemColors.GrayText;
            txtPassword.InnerBackColor = SystemColors.InactiveCaption;
            txtPassword.InnerForeColor = Color.Black;
            txtPassword.IsPasswordField = false;
            txtPassword.Location = new Point(198, 77);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '\0';
            txtPassword.PlaceholderColor = Color.Gray;
            txtPassword.PlaceholderText = "";
            txtPassword.Size = new Size(326, 39);
            txtPassword.TabIndex = 31;
            txtPassword.Text = "asdg";
            // 
            // txtAge
            // 
            txtAge.BorderColor = SystemColors.ButtonFace;
            txtAge.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtAge.BorderRadius = 8;
            txtAge.BorderThickness = 2;
            txtAge.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAge.ForeColor = SystemColors.GrayText;
            txtAge.InnerBackColor = SystemColors.InactiveCaption;
            txtAge.InnerForeColor = Color.Black;
            txtAge.IsPasswordField = false;
            txtAge.Location = new Point(865, 77);
            txtAge.Name = "txtAge";
            txtAge.PasswordChar = '\0';
            txtAge.PlaceholderColor = Color.Gray;
            txtAge.PlaceholderText = "";
            txtAge.Size = new Size(247, 39);
            txtAge.TabIndex = 29;
            // 
            // txtUsername
            // 
            txtUsername.BorderColor = SystemColors.ButtonFace;
            txtUsername.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtUsername.BorderRadius = 8;
            txtUsername.BorderThickness = 2;
            txtUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = SystemColors.GrayText;
            txtUsername.InnerBackColor = SystemColors.InactiveCaption;
            txtUsername.InnerForeColor = Color.Black;
            txtUsername.IsPasswordField = false;
            txtUsername.Location = new Point(198, 23);
            txtUsername.Name = "txtUsername";
            txtUsername.PasswordChar = '\0';
            txtUsername.PlaceholderColor = Color.Gray;
            txtUsername.PlaceholderText = "";
            txtUsername.Size = new Size(326, 39);
            txtUsername.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.Control;
            label6.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(78, 86);
            label6.Name = "label6";
            label6.Size = new Size(79, 18);
            label6.TabIndex = 25;
            label6.Text = "Password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(773, 138);
            label5.Name = "label5";
            label5.Size = new Size(77, 18);
            label5.TabIndex = 24;
            label5.Text = "Birthdate:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(773, 87);
            label4.Name = "label4";
            label4.Size = new Size(43, 18);
            label4.TabIndex = 23;
            label4.Text = "Age:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(78, 33);
            label3.Name = "label3";
            label3.Size = new Size(86, 18);
            label3.TabIndex = 22;
            label3.Text = "Username:";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToOrderColumns = true;
            dgvUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 5, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.FromArgb(230, 230, 230);
            dgvUsers.Location = new Point(37, 149);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.InactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dgvUsers.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1201, 240);
            dgvUsers.TabIndex = 27;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.SteelBlue;
            btnClear.BorderColor = Color.Transparent;
            btnClear.BorderRadius = 10;
            btnClear.BorderSize = 0;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Dubai", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(784, 742);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(149, 42);
            btnClear.TabIndex = 28;
            btnClear.Text = "Clear Text Fields";
            btnClear.TextAlign = ContentAlignment.TopCenter;
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = SystemColors.ButtonFace;
            txtSearch.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtSearch.BorderRadius = 8;
            txtSearch.BorderThickness = 2;
            txtSearch.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = SystemColors.GrayText;
            txtSearch.InnerBackColor = SystemColors.InactiveCaption;
            txtSearch.InnerForeColor = Color.Black;
            txtSearch.IsPasswordField = false;
            txtSearch.Location = new Point(127, 86);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderColor = Color.Gray;
            txtSearch.PlaceholderText = "";
            txtSearch.Size = new Size(434, 39);
            txtSearch.TabIndex = 29;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = SystemColors.Control;
            label12.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(38, 86);
            label12.Name = "label12";
            label12.Size = new Size(83, 25);
            label12.TabIndex = 30;
            label12.Text = "Search";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.SteelBlue;
            btnBack.BorderColor = Color.Transparent;
            btnBack.BorderRadius = 10;
            btnBack.BorderSize = 0;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Dubai", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(37, 742);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 42);
            btnBack.TabIndex = 31;
            btnBack.Text = "Back";
            btnBack.TextAlign = ContentAlignment.TopCenter;
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // ManageUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 821);
            Controls.Add(btnBack);
            Controls.Add(label12);
            Controls.Add(txtSearch);
            Controls.Add(btnClear);
            Controls.Add(dgvUsers);
            Controls.Add(panel1);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(titleBar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManageUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManageUsers";
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel titleBar;
        private Label lblAdminName;
        private Button closeButton;
        private Label titleLabel;
        private RoundedButton btnAdd;
        private RoundedButton btnEdit;
        private RoundedButton btnDelete;
        private Label label2;
        private Panel panel1;
        private Label lblPasswordStrength;
        private Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpBirthdate;
        private Guna.UI2.WinForms.Guna2ComboBox cmbUserLevel;
        private Label label11;
        private CustomControls.CustomTextBox txtContact;
        private Label label10;
        private CustomControls.CustomTextBox txtMiddleName;
        private CustomControls.CustomTextBox txtFirstName;
        private CustomControls.CustomTextBox txtLastName;
        private Label label9;
        private Label label8;
        private Label label7;
        private CustomControls.CustomTextBox txtPassword;
        private CustomControls.CustomTextBox txtAge;
        private CustomControls.CustomTextBox txtUsername;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private DataGridView dgvUsers;
        private RoundedButton btnClear;
        private CustomControls.CustomTextBox txtSearch;
        private Label label12;
        private RoundedButton btnBack;
    }
}
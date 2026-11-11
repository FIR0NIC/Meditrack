namespace MediTrack
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            titleBar = new Panel();
            lblAdminName = new Label();
            closeButton = new Button();
            titleLabel = new Label();
            btnLogOut = new RoundedButton();
            btnManageUsers = new RoundedButton();
            btnSalesReport = new RoundedButton();
            btnSettings = new RoundedButton();
            btnAudit = new RoundedButton();
            label1 = new Label();
            titleBar.SuspendLayout();
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
            titleBar.Size = new Size(1264, 48);
            titleBar.TabIndex = 17;
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
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.SteelBlue;
            btnLogOut.BorderColor = Color.Transparent;
            btnLogOut.BorderRadius = 10;
            btnLogOut.BorderSize = 0;
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Dubai", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.ForeColor = Color.White;
            btnLogOut.Location = new Point(26, 622);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(86, 37);
            btnLogOut.TabIndex = 22;
            btnLogOut.Text = "Logout";
            btnLogOut.TextAlign = ContentAlignment.TopCenter;
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnManageUsers
            // 
            btnManageUsers.BackColor = Color.SteelBlue;
            btnManageUsers.BorderColor = Color.Transparent;
            btnManageUsers.BorderRadius = 20;
            btnManageUsers.BorderSize = 0;
            btnManageUsers.FlatAppearance.BorderSize = 0;
            btnManageUsers.FlatStyle = FlatStyle.Flat;
            btnManageUsers.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageUsers.ForeColor = Color.White;
            btnManageUsers.Image = (Image)resources.GetObject("btnManageUsers.Image");
            btnManageUsers.Location = new Point(258, 174);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.Size = new Size(180, 180);
            btnManageUsers.TabIndex = 51;
            btnManageUsers.Text = "USERS";
            btnManageUsers.TextAlign = ContentAlignment.BottomCenter;
            btnManageUsers.UseVisualStyleBackColor = false;
            btnManageUsers.Click += btnManageUsers_Click;
            // 
            // btnSalesReport
            // 
            btnSalesReport.BackColor = Color.SteelBlue;
            btnSalesReport.BorderColor = Color.Transparent;
            btnSalesReport.BorderRadius = 20;
            btnSalesReport.BorderSize = 0;
            btnSalesReport.FlatAppearance.BorderSize = 0;
            btnSalesReport.FlatStyle = FlatStyle.Flat;
            btnSalesReport.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalesReport.ForeColor = Color.White;
            btnSalesReport.Image = (Image)resources.GetObject("btnSalesReport.Image");
            btnSalesReport.Location = new Point(553, 174);
            btnSalesReport.Name = "btnSalesReport";
            btnSalesReport.Size = new Size(180, 180);
            btnSalesReport.TabIndex = 58;
            btnSalesReport.Text = "SALES REPORTS";
            btnSalesReport.TextAlign = ContentAlignment.BottomCenter;
            btnSalesReport.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.SteelBlue;
            btnSettings.BorderColor = Color.Transparent;
            btnSettings.BorderRadius = 20;
            btnSettings.BorderSize = 0;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSettings.ForeColor = Color.White;
            btnSettings.Image = (Image)resources.GetObject("btnSettings.Image");
            btnSettings.Location = new Point(1157, 579);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(80, 80);
            btnSettings.TabIndex = 59;
            btnSettings.TextAlign = ContentAlignment.BottomCenter;
            btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnAudit
            // 
            btnAudit.BackColor = Color.SteelBlue;
            btnAudit.BorderColor = Color.Transparent;
            btnAudit.BorderRadius = 20;
            btnAudit.BorderSize = 0;
            btnAudit.FlatAppearance.BorderSize = 0;
            btnAudit.FlatStyle = FlatStyle.Flat;
            btnAudit.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAudit.ForeColor = Color.White;
            btnAudit.Image = (Image)resources.GetObject("btnAudit.Image");
            btnAudit.Location = new Point(837, 174);
            btnAudit.Name = "btnAudit";
            btnAudit.Size = new Size(180, 180);
            btnAudit.TabIndex = 60;
            btnAudit.Text = "EMPLOYEE LOGS";
            btnAudit.TextAlign = ContentAlignment.BottomCenter;
            btnAudit.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(418, 642);
            label1.Name = "label1";
            label1.Size = new Size(426, 17);
            label1.TabIndex = 62;
            label1.Text = "TIP: Press H to show  shortcut keys or Hover on top of the buttons!";
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(label1);
            Controls.Add(btnAudit);
            Controls.Add(btnSettings);
            Controls.Add(btnSalesReport);
            Controls.Add(btnLogOut);
            Controls.Add(btnManageUsers);
            Controls.Add(titleBar);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminDashboard";
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();


        }


        #endregion

        private Panel titleBar;
        private Button closeButton;
        private Label titleLabel;
        private Label lblAdminName;
        private RoundedButton btnLogOut;
        private RoundedButton btnManageUsers;
        private RoundedButton btnSalesReport;
        private RoundedButton btnSettings;
        private RoundedButton btnAudit;
        private Label label1;
    }
}
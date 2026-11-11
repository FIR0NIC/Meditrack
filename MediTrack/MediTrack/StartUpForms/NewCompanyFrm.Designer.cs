namespace MediTrack
{
    partial class NewCompanyFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCompanyFrm));
            titleBar = new Panel();
            closeButton = new Button();
            titleLabel = new Label();
            label4 = new Label();
            txtCompanyName = new CustomControls.CustomTextBox();
            btnCreateCompany = new RoundedButton();
            txtEmailAdd = new CustomControls.CustomTextBox();
            label1 = new Label();
            label2 = new Label();
            txtContactNum = new CustomControls.CustomTextBox();
            roundedButton1 = new RoundedButton();
            titleBar.SuspendLayout();
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
            titleBar.Size = new Size(680, 40);
            titleBar.TabIndex = 17;
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
            closeButton.Location = new Point(639, 0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(41, 40);
            closeButton.TabIndex = 17;
            closeButton.Text = " X";
            closeButton.UseVisualStyleBackColor = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(12, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(247, 21);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "MediTrack (Company Creation)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(90, 99);
            label4.Name = "label4";
            label4.Size = new Size(185, 24);
            label4.TabIndex = 18;
            label4.Text = "Company Name";
            // 
            // txtCompanyName
            // 
            txtCompanyName.BorderColor = SystemColors.ButtonFace;
            txtCompanyName.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtCompanyName.BorderRadius = 8;
            txtCompanyName.BorderThickness = 2;
            txtCompanyName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCompanyName.ForeColor = Color.Black;
            txtCompanyName.InnerBackColor = SystemColors.InactiveCaption;
            txtCompanyName.InnerForeColor = Color.Black;
            txtCompanyName.IsPasswordField = false;
            txtCompanyName.Location = new Point(281, 88);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.PasswordChar = '\0';
            txtCompanyName.PlaceholderColor = Color.Black;
            txtCompanyName.PlaceholderText = "";
            txtCompanyName.Size = new Size(220, 45);
            txtCompanyName.TabIndex = 19;
            // 
            // btnCreateCompany
            // 
            btnCreateCompany.BackColor = Color.SteelBlue;
            btnCreateCompany.BorderColor = Color.Transparent;
            btnCreateCompany.BorderRadius = 20;
            btnCreateCompany.BorderSize = 0;
            btnCreateCompany.FlatAppearance.BorderSize = 0;
            btnCreateCompany.FlatStyle = FlatStyle.Flat;
            btnCreateCompany.Font = new Font("Dubai", 13.75F, FontStyle.Bold);
            btnCreateCompany.ForeColor = Color.White;
            btnCreateCompany.Location = new Point(281, 285);
            btnCreateCompany.Name = "btnCreateCompany";
            btnCreateCompany.Size = new Size(220, 46);
            btnCreateCompany.TabIndex = 20;
            btnCreateCompany.Text = "Create Company";
            btnCreateCompany.UseVisualStyleBackColor = false;
            // 
            // txtEmailAdd
            // 
            txtEmailAdd.BorderColor = SystemColors.ButtonFace;
            txtEmailAdd.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtEmailAdd.BorderRadius = 8;
            txtEmailAdd.BorderThickness = 2;
            txtEmailAdd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEmailAdd.ForeColor = Color.Black;
            txtEmailAdd.InnerBackColor = SystemColors.InactiveCaption;
            txtEmailAdd.InnerForeColor = Color.Black;
            txtEmailAdd.IsPasswordField = false;
            txtEmailAdd.Location = new Point(282, 139);
            txtEmailAdd.Name = "txtEmailAdd";
            txtEmailAdd.PasswordChar = '\0';
            txtEmailAdd.PlaceholderColor = Color.Black;
            txtEmailAdd.PlaceholderText = "";
            txtEmailAdd.Size = new Size(220, 45);
            txtEmailAdd.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(91, 149);
            label1.Name = "label1";
            label1.Size = new Size(149, 24);
            label1.TabIndex = 22;
            label1.Text = "Email Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(90, 203);
            label2.Name = "label2";
            label2.Size = new Size(186, 24);
            label2.TabIndex = 23;
            label2.Text = "Contact Number";
            // 
            // txtContactNum
            // 
            txtContactNum.BorderColor = SystemColors.ButtonFace;
            txtContactNum.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtContactNum.BorderRadius = 8;
            txtContactNum.BorderThickness = 2;
            txtContactNum.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtContactNum.ForeColor = Color.Black;
            txtContactNum.InnerBackColor = SystemColors.InactiveCaption;
            txtContactNum.InnerForeColor = Color.Black;
            txtContactNum.IsPasswordField = false;
            txtContactNum.Location = new Point(282, 190);
            txtContactNum.Name = "txtContactNum";
            txtContactNum.PasswordChar = '\0';
            txtContactNum.PlaceholderColor = Color.Black;
            txtContactNum.PlaceholderText = "";
            txtContactNum.Size = new Size(220, 45);
            txtContactNum.TabIndex = 24;
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = SystemColors.ActiveCaption;
            roundedButton1.BorderColor = Color.Transparent;
            roundedButton1.BorderRadius = 20;
            roundedButton1.BorderSize = 0;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Dubai", 13.75F, FontStyle.Bold);
            roundedButton1.ForeColor = Color.White;
            roundedButton1.Location = new Point(282, 337);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(220, 46);
            roundedButton1.TabIndex = 25;
            roundedButton1.Text = "Cancel";
            roundedButton1.UseVisualStyleBackColor = false;
            // 
            // NewCompanyFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 431);
            Controls.Add(roundedButton1);
            Controls.Add(txtContactNum);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmailAdd);
            Controls.Add(btnCreateCompany);
            Controls.Add(txtCompanyName);
            Controls.Add(label4);
            Controls.Add(titleBar);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NewCompanyFrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NewCompanyFrm";
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel titleBar;
        private Button closeButton;
        private Label titleLabel;
        private Label label4;
        private CustomControls.CustomTextBox txtCompanyName;
        private RoundedButton btnCreateCompany;
        private CustomControls.CustomTextBox txtEmailAdd;
        private Label label1;
        private Label label2;
        private CustomControls.CustomTextBox txtContactNum;
        private RoundedButton roundedButton1;
    }
}
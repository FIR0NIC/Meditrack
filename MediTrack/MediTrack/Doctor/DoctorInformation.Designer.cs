namespace MediTrack
{
    partial class DoctorInformation
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
            titleBar = new Panel();
            closeButton = new Button();
            titleLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtDoctorName = new CustomControls.CustomTextBox();
            txtContactNo = new CustomControls.CustomTextBox();
            txtSpeciality = new CustomControls.CustomTextBox();
            txtEmail = new CustomControls.CustomTextBox();
            btnSaveAndReturn = new RoundedButton();
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
            titleBar.Size = new Size(1267, 43);
            titleBar.TabIndex = 18;
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
            closeButton.Location = new Point(2293, 0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(41, 43);
            closeButton.TabIndex = 17;
            closeButton.Text = " X";
            closeButton.UseVisualStyleBackColor = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(25, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(169, 21);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Doctor's Information";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(88, 110);
            label1.Name = "label1";
            label1.Size = new Size(62, 21);
            label1.TabIndex = 19;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(62, 261);
            label2.Name = "label2";
            label2.Size = new Size(88, 21);
            label2.TabIndex = 20;
            label2.Text = "Speciality:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(38, 188);
            label3.Name = "label3";
            label3.Size = new Size(112, 21);
            label3.TabIndex = 21;
            label3.Text = "Contact No.:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(90, 339);
            label4.Name = "label4";
            label4.Size = new Size(60, 21);
            label4.TabIndex = 22;
            label4.Text = "E-Mail:";
            // 
            // txtDoctorName
            // 
            txtDoctorName.BorderColor = SystemColors.ButtonFace;
            txtDoctorName.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtDoctorName.BorderRadius = 8;
            txtDoctorName.BorderThickness = 2;
            txtDoctorName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDoctorName.ForeColor = Color.Black;
            txtDoctorName.InnerBackColor = SystemColors.InactiveCaption;
            txtDoctorName.InnerForeColor = Color.Black;
            txtDoctorName.IsPasswordField = false;
            txtDoctorName.Location = new Point(156, 101);
            txtDoctorName.Name = "txtDoctorName";
            txtDoctorName.PasswordChar = '\0';
            txtDoctorName.PlaceholderColor = Color.Black;
            txtDoctorName.PlaceholderText = "";
            txtDoctorName.Size = new Size(237, 39);
            txtDoctorName.TabIndex = 29;
            // 
            // txtContactNo
            // 
            txtContactNo.BorderColor = SystemColors.ButtonFace;
            txtContactNo.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtContactNo.BorderRadius = 8;
            txtContactNo.BorderThickness = 2;
            txtContactNo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtContactNo.ForeColor = Color.Black;
            txtContactNo.InnerBackColor = SystemColors.InactiveCaption;
            txtContactNo.InnerForeColor = Color.Black;
            txtContactNo.IsPasswordField = false;
            txtContactNo.Location = new Point(156, 179);
            txtContactNo.Name = "txtContactNo";
            txtContactNo.PasswordChar = '\0';
            txtContactNo.PlaceholderColor = Color.Black;
            txtContactNo.PlaceholderText = "";
            txtContactNo.Size = new Size(237, 39);
            txtContactNo.TabIndex = 30;
            // 
            // txtSpeciality
            // 
            txtSpeciality.BorderColor = SystemColors.ButtonFace;
            txtSpeciality.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtSpeciality.BorderRadius = 8;
            txtSpeciality.BorderThickness = 2;
            txtSpeciality.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSpeciality.ForeColor = Color.Black;
            txtSpeciality.InnerBackColor = SystemColors.InactiveCaption;
            txtSpeciality.InnerForeColor = Color.Black;
            txtSpeciality.IsPasswordField = false;
            txtSpeciality.Location = new Point(156, 252);
            txtSpeciality.Name = "txtSpeciality";
            txtSpeciality.PasswordChar = '\0';
            txtSpeciality.PlaceholderColor = Color.Black;
            txtSpeciality.PlaceholderText = "";
            txtSpeciality.Size = new Size(237, 39);
            txtSpeciality.TabIndex = 31;
            // 
            // txtEmail
            // 
            txtEmail.BorderColor = SystemColors.ButtonFace;
            txtEmail.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtEmail.BorderRadius = 8;
            txtEmail.BorderThickness = 2;
            txtEmail.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.Black;
            txtEmail.InnerBackColor = SystemColors.InactiveCaption;
            txtEmail.InnerForeColor = Color.Black;
            txtEmail.IsPasswordField = false;
            txtEmail.Location = new Point(156, 330);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PlaceholderColor = Color.Black;
            txtEmail.PlaceholderText = "";
            txtEmail.Size = new Size(237, 39);
            txtEmail.TabIndex = 32;
            // 
            // btnSaveAndReturn
            // 
            btnSaveAndReturn.BackColor = Color.SteelBlue;
            btnSaveAndReturn.BorderColor = Color.Transparent;
            btnSaveAndReturn.BorderRadius = 10;
            btnSaveAndReturn.BorderSize = 0;
            btnSaveAndReturn.FlatAppearance.BorderSize = 0;
            btnSaveAndReturn.FlatStyle = FlatStyle.Flat;
            btnSaveAndReturn.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveAndReturn.ForeColor = Color.White;
            btnSaveAndReturn.Location = new Point(188, 401);
            btnSaveAndReturn.Name = "btnSaveAndReturn";
            btnSaveAndReturn.Size = new Size(156, 40);
            btnSaveAndReturn.TabIndex = 33;
            btnSaveAndReturn.Text = "Save and Return";
            btnSaveAndReturn.UseVisualStyleBackColor = false;
            btnSaveAndReturn.Click += this.btnSaveAndReturn_Click;
            // 
            // DoctorInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1267, 749);
            Controls.Add(btnSaveAndReturn);
            Controls.Add(txtEmail);
            Controls.Add(txtSpeciality);
            Controls.Add(txtContactNo);
            Controls.Add(txtDoctorName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(titleBar);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DoctorInformation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel titleBar;
        private Button closeButton;
        private Label titleLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private CustomControls.CustomTextBox txtDoctorName;
        private CustomControls.CustomTextBox txtContactNo;
        private CustomControls.CustomTextBox txtSpeciality;
        private CustomControls.CustomTextBox txtEmail;
        private RoundedButton btnSaveAndReturn;
    }
}
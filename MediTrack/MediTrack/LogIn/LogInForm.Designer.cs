namespace MediTrack
{
    partial class LogInForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            pictureBox1 = new PictureBox();
            btnSignIn = new RoundedButton();
            panel1 = new Panel();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtUsername = new CustomControls.CustomTextBox();
            txtPassword = new CustomControls.CustomTextBox();
            label1 = new Label();
            titleBar = new Panel();
            closeButton = new Button();
            titleLabel = new Label();
            txtCompany = new CustomControls.CustomTextBox();
            chckUserComp = new CheckBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            titleBar.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(453, 72);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(113, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btnSignIn
            // 
            btnSignIn.BackColor = Color.SteelBlue;
            btnSignIn.BorderColor = Color.Transparent;
            btnSignIn.BorderRadius = 20;
            btnSignIn.BorderSize = 0;
            btnSignIn.FlatAppearance.BorderSize = 0;
            btnSignIn.FlatStyle = FlatStyle.Flat;
            btnSignIn.Font = new Font("Microsoft Sans Serif", 13.75F, FontStyle.Bold);
            btnSignIn.ForeColor = Color.White;
            btnSignIn.Location = new Point(397, 422);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(220, 46);
            btnSignIn.TabIndex = 9;
            btnSignIn.Text = "Login";
            btnSignIn.UseVisualStyleBackColor = false;
            btnSignIn.Click += btnSignInClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(0, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(324, 574);
            panel1.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ButtonFace;
            label8.Location = new Point(115, 526);
            label8.Name = "label8";
            label8.Size = new Size(103, 17);
            label8.TabIndex = 4;
            label8.Text = "Developed by ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 15.75F);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(7, 227);
            label6.Name = "label6";
            label6.Size = new Size(317, 24);
            label6.TabIndex = 2;
            label6.Text = "Your Clinic Information System";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(115, 543);
            label5.Name = "label5";
            label5.Size = new Size(88, 21);
            label5.TabIndex = 1;
            label5.Text = "MedTech ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 15.75F);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(7, 203);
            label4.Name = "label4";
            label4.Size = new Size(247, 24);
            label4.TabIndex = 0;
            label4.Text = "Welcome to MediTrack";
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
            txtUsername.InnerForeColor = Color.Gray;
            txtUsername.IsPasswordField = false;
            txtUsername.Location = new Point(397, 291);
            txtUsername.Name = "txtUsername";
            txtUsername.PasswordChar = '\0';
            txtUsername.PlaceholderColor = Color.Gray;
            txtUsername.PlaceholderText = "";
            txtUsername.Size = new Size(220, 45);
            txtUsername.TabIndex = 13;
            txtUsername.Text = "Username";
            txtUsername.Enter += txtUsername_Enter;
            txtUsername.KeyDown += txt_KeyDown;
            txtUsername.Leave += txtUsername_Leave;
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
            txtPassword.InnerForeColor = Color.Gray;
            txtPassword.IsPasswordField = false;
            txtPassword.Location = new Point(397, 342);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '\0';
            txtPassword.PlaceholderColor = Color.Gray;
            txtPassword.PlaceholderText = "";
            txtPassword.Size = new Size(220, 45);
            txtPassword.TabIndex = 14;
            txtPassword.Text = "Password";
            txtPassword.TextChanged += txtPassword_TextChanged;
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.KeyDown += txt_KeyDown;
            txtPassword.Leave += txtPassword_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gill Sans Ultra Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(30, 45, 61);
            label1.Location = new Point(462, 187);
            label1.Name = "label1";
            label1.Size = new Size(93, 26);
            label1.TabIndex = 15;
            label1.Text = "Sign In";
            // 
            // titleBar
            // 
            titleBar.BackColor = Color.FromArgb(44, 62, 80);
            titleBar.Controls.Add(closeButton);
            titleBar.Controls.Add(titleLabel);
            titleBar.Dock = DockStyle.Top;
            titleBar.Location = new Point(0, 0);
            titleBar.Name = "titleBar";
            titleBar.Size = new Size(679, 40);
            titleBar.TabIndex = 16;
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
            closeButton.Location = new Point(638, 0);
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
            titleLabel.Size = new Size(89, 21);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "MediTrack";
            // 
            // txtCompany
            // 
            txtCompany.BorderColor = SystemColors.ButtonFace;
            txtCompany.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtCompany.BorderRadius = 8;
            txtCompany.BorderThickness = 2;
            txtCompany.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCompany.ForeColor = SystemColors.Desktop;
            txtCompany.InnerBackColor = SystemColors.InactiveCaption;
            txtCompany.InnerForeColor = Color.Gray;
            txtCompany.IsPasswordField = false;
            txtCompany.Location = new Point(397, 240);
            txtCompany.Name = "txtCompany";
            txtCompany.PasswordChar = '\0';
            txtCompany.PlaceholderColor = Color.Gray;
            txtCompany.PlaceholderText = "";
            txtCompany.Size = new Size(220, 45);
            txtCompany.TabIndex = 22;
            txtCompany.Text = "Company Name";
            txtCompany.Enter += txtCompany_Enter;
            txtCompany.KeyDown += txt_KeyDown;
            txtCompany.Leave += txtCompany_Leave;
            // 
            // chckUserComp
            // 
            chckUserComp.AutoSize = true;
            chckUserComp.ForeColor = SystemColors.ActiveCaptionText;
            chckUserComp.Location = new Point(453, 397);
            chckUserComp.Name = "chckUserComp";
            chckUserComp.Size = new Size(104, 19);
            chckUserComp.TabIndex = 23;
            chckUserComp.Text = "Remember Me";
            chckUserComp.UseVisualStyleBackColor = true;
            chckUserComp.CheckedChanged += chckUserComp_CheckedChanged;
            chckUserComp.KeyDown += txt_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.MenuHighlight;
            label2.Location = new Point(563, 578);
            label2.Name = "label2";
            label2.Size = new Size(114, 17);
            label2.TabIndex = 5;
            label2.Text = "ver 1.0.0 [DEMO]";
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(679, 604);
            ControlBox = false;
            Controls.Add(label2);
            Controls.Add(chckUserComp);
            Controls.Add(txtCompany);
            Controls.Add(titleBar);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(panel1);
            Controls.Add(btnSignIn);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ActiveCaption;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LogInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LogIn Form";
            Load += LogInForm_Load;
            Shown += LogInForm_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.CustomTextBox txtUsername;
        private PictureBox pictureBox1;
        private RoundedButton btnSignIn;
        private Panel panel1;
        private Label label5;
        private Label label4;
        private Label label8;
        private Label label6;
        private CustomControls.CustomTextBox txtPassword;
        private Label label1;
        private Panel titleBar;
        private Label titleLabel;
        private Button closeButton;
        private CustomControls.CustomTextBox txtCompany;
        private CheckBox chckUserComp;
        private Label label2;
    }
}
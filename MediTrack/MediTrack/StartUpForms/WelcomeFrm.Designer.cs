namespace MediTrack.StartUpForms
{
    partial class WelcomeFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeFrm));
            titleBar = new Panel();
            closeButton = new Button();
            titleLabel = new Label();
            label4 = new Label();
            label1 = new Label();
            btnNewUser = new RoundedButton();
            btnOldUser = new RoundedButton();
            chckDontShow = new CheckBox();
            label8 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            titleBar.Size = new Size(682, 40);
            titleBar.TabIndex = 18;
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
            closeButton.Location = new Point(641, 0);
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
            titleLabel.Size = new Size(186, 21);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "MediTrack Initial Setup";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.SteelBlue;
            label4.Location = new Point(146, 238);
            label4.Name = "label4";
            label4.Size = new Size(382, 38);
            label4.TabIndex = 19;
            label4.Text = "Welcome to MediTrack!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(236, 286);
            label1.Name = "label1";
            label1.Size = new Size(200, 24);
            label1.TabIndex = 20;
            label1.Text = "Let's set things up...";
            // 
            // btnNewUser
            // 
            btnNewUser.BackColor = Color.SteelBlue;
            btnNewUser.BorderColor = Color.Transparent;
            btnNewUser.BorderRadius = 20;
            btnNewUser.BorderSize = 0;
            btnNewUser.FlatAppearance.BorderSize = 0;
            btnNewUser.FlatStyle = FlatStyle.Flat;
            btnNewUser.Font = new Font("Dubai", 13.75F, FontStyle.Bold);
            btnNewUser.ForeColor = Color.White;
            btnNewUser.Location = new Point(210, 344);
            btnNewUser.Name = "btnNewUser";
            btnNewUser.Size = new Size(249, 57);
            btnNewUser.TabIndex = 22;
            btnNewUser.Text = "REGISTER HERE";
            btnNewUser.UseVisualStyleBackColor = false;
            btnNewUser.Click += btnNewUser_Click;
            // 
            // btnOldUser
            // 
            btnOldUser.BackColor = Color.SteelBlue;
            btnOldUser.BorderColor = Color.Transparent;
            btnOldUser.BorderRadius = 20;
            btnOldUser.BorderSize = 0;
            btnOldUser.FlatAppearance.BorderSize = 0;
            btnOldUser.FlatStyle = FlatStyle.Flat;
            btnOldUser.Font = new Font("Dubai", 13.75F, FontStyle.Bold);
            btnOldUser.ForeColor = Color.White;
            btnOldUser.Location = new Point(210, 407);
            btnOldUser.Name = "btnOldUser";
            btnOldUser.Size = new Size(249, 55);
            btnOldUser.TabIndex = 23;
            btnOldUser.Text = "SIGN IN";
            btnOldUser.UseVisualStyleBackColor = false;
            btnOldUser.Click += btnOldUser_Click;
            // 
            // chckDontShow
            // 
            chckDontShow.AutoSize = true;
            chckDontShow.Location = new Point(249, 479);
            chckDontShow.Name = "chckDontShow";
            chckDontShow.Size = new Size(173, 19);
            chckDontShow.TabIndex = 24;
            chckDontShow.Text = "DO NOT SHOW THIS AGAIN";
            chckDontShow.UseVisualStyleBackColor = true;
            chckDontShow.CheckedChanged += chckDontShow_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(283, 533);
            label8.Name = "label8";
            label8.Size = new Size(103, 17);
            label8.TabIndex = 26;
            label8.Text = "Developed by ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(283, 550);
            label5.Name = "label5";
            label5.Size = new Size(84, 21);
            label5.TabIndex = 25;
            label5.Text = "MedTech";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(258, 66);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(162, 153);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 27;
            pictureBox1.TabStop = false;
            // 
            // WelcomeFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 594);
            Controls.Add(pictureBox1);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(chckDontShow);
            Controls.Add(btnOldUser);
            Controls.Add(btnNewUser);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(titleBar);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "WelcomeFrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WelcomeFrm";
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel titleBar;
        private Button closeButton;
        private Label titleLabel;
        private Label label4;
        private Label label1;
        private RoundedButton btnNewUser;
        private RoundedButton btnOldUser;
        private CheckBox chckDontShow;
        private Label label8;
        private Label label5;
        private PictureBox pictureBox1;
    }
}
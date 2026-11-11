namespace MediTrack.Receptionist
{
    partial class ReceptionistDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceptionistDashboard));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            titleBar = new Panel();
            lblInventoryName = new Label();
            closeButton = new Button();
            titleLabel = new Label();
            btnManageStocks = new RoundedButton();
            btnManageProducts = new RoundedButton();
            dgvInventStatus = new DataGridView();
            btnLogOut = new RoundedButton();
            btnRefresh = new RoundedButton();
            label12 = new Label();
            titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventStatus).BeginInit();
            SuspendLayout();
            // 
            // titleBar
            // 
            titleBar.BackColor = Color.FromArgb(44, 62, 80);
            titleBar.Controls.Add(lblInventoryName);
            titleBar.Controls.Add(closeButton);
            titleBar.Controls.Add(titleLabel);
            titleBar.Dock = DockStyle.Top;
            titleBar.Location = new Point(0, 0);
            titleBar.Name = "titleBar";
            titleBar.Size = new Size(909, 48);
            titleBar.TabIndex = 18;
            // 
            // lblInventoryName
            // 
            lblInventoryName.AutoSize = true;
            lblInventoryName.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInventoryName.ForeColor = Color.White;
            lblInventoryName.Location = new Point(611, 12);
            lblInventoryName.Name = "lblInventoryName";
            lblInventoryName.Size = new Size(229, 21);
            lblInventoryName.TabIndex = 21;
            lblInventoryName.Text = "Name | Inventory Manager";
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
            closeButton.Location = new Point(861, 0);
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
            titleLabel.Size = new Size(100, 21);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "MediTrack System";
            // 
            // btnManageStocks
            // 
            btnManageStocks.BackColor = Color.SteelBlue;
            btnManageStocks.BorderColor = Color.Transparent;
            btnManageStocks.BorderRadius = 20;
            btnManageStocks.BorderSize = 0;
            btnManageStocks.FlatAppearance.BorderSize = 0;
            btnManageStocks.FlatStyle = FlatStyle.Flat;
            btnManageStocks.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageStocks.ForeColor = Color.White;
            btnManageStocks.Image = (Image)resources.GetObject("btnManageStocks.Image");
            btnManageStocks.Location = new Point(487, 449);
            btnManageStocks.Name = "btnManageStocks";
            btnManageStocks.Size = new Size(180, 180);
            btnManageStocks.TabIndex = 56;
            btnManageStocks.Text = "INVENTORY ";
            btnManageStocks.TextAlign = ContentAlignment.BottomCenter;
            btnManageStocks.UseVisualStyleBackColor = false;
            //btnManageStocks.Click += btnManageStocks_Click;
            // 
            // btnManageProducts
            // 
            btnManageProducts.BackColor = Color.SteelBlue;
            btnManageProducts.BorderColor = Color.Transparent;
            btnManageProducts.BorderRadius = 20;
            btnManageProducts.BorderSize = 0;
            btnManageProducts.FlatAppearance.BorderSize = 0;
            btnManageProducts.FlatStyle = FlatStyle.Flat;
            btnManageProducts.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageProducts.ForeColor = Color.White;
            btnManageProducts.Image = (Image)resources.GetObject("btnManageProducts.Image");
            btnManageProducts.Location = new Point(264, 449);
            btnManageProducts.Name = "btnManageProducts";
            btnManageProducts.Size = new Size(180, 180);
            btnManageProducts.TabIndex = 55;
            btnManageProducts.Text = "PRODUCTS";
            btnManageProducts.TextAlign = ContentAlignment.BottomCenter;
            btnManageProducts.UseVisualStyleBackColor = false;
            //btnManageProducts.Click += btnManageProducts_Click;
            // 
            // dgvInventStatus
            // 
            dgvInventStatus.AllowUserToAddRows = false;
            dgvInventStatus.AllowUserToDeleteRows = false;
            dgvInventStatus.AllowUserToOrderColumns = true;
            dgvInventStatus.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dgvInventStatus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvInventStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventStatus.BackgroundColor = Color.White;
            dgvInventStatus.BorderStyle = BorderStyle.None;
            dgvInventStatus.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInventStatus.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 5, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvInventStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvInventStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventStatus.EnableHeadersVisualStyles = false;
            dgvInventStatus.GridColor = Color.FromArgb(230, 230, 230);
            dgvInventStatus.Location = new Point(24, 123);
            dgvInventStatus.Name = "dgvInventStatus";
            dgvInventStatus.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvInventStatus.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvInventStatus.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.InactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dgvInventStatus.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvInventStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventStatus.Size = new Size(858, 269);
            dgvInventStatus.TabIndex = 58;
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
            btnLogOut.Location = new Point(37, 592);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(86, 37);
            btnLogOut.TabIndex = 59;
            btnLogOut.Text = "Logout";
            btnLogOut.TextAlign = ContentAlignment.TopCenter;
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.SteelBlue;
            btnRefresh.BorderColor = Color.Transparent;
            btnRefresh.BorderRadius = 10;
            btnRefresh.BorderSize = 0;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Dubai", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(789, 589);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(93, 37);
            btnRefresh.TabIndex = 60;
            btnRefresh.Text = "REFRESH";
            btnRefresh.TextAlign = ContentAlignment.TopCenter;
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.LightSteelBlue;
            label12.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(24, 87);
            label12.Name = "label12";
            label12.Size = new Size(162, 19);
            label12.TabIndex = 62;
            label12.Text = "INVENTORY PREVIEW";
            // 
            // InventoryManagerDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 648);
            Controls.Add(label12);
            Controls.Add(btnRefresh);
            Controls.Add(btnLogOut);
            Controls.Add(dgvInventStatus);
            Controls.Add(btnManageStocks);
            Controls.Add(btnManageProducts);
            Controls.Add(titleBar);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InventoryManagerDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InventoryManagerDashboard";
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventStatus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel titleBar;
        private Label lblInventoryName;
        private Button closeButton;
        private Label titleLabel;
        private RoundedButton btnManageStocks;
        private RoundedButton btnManageProducts;
        private DataGridView dgvInventStatus;
        private RoundedButton btnLogOut;
        private RoundedButton btnRefresh;
        private Label label12;
    }
}
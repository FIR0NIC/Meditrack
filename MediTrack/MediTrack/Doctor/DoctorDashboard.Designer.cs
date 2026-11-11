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
            lblCashierName = new Label();
            titleLabel = new Label();
            btnLogOut = new RoundedButton();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1 = new Panel();
            txtProductName = new CustomControls.CustomTextBox();
            txtPrice = new CustomControls.CustomTextBox();
            txtQuan = new CustomControls.CustomTextBox();
            txtProductCode = new CustomControls.CustomTextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblTotalPrice = new Label();
            panel2 = new Panel();
            label8 = new Label();
            usersBindingSource = new BindingSource(components);
            panel3 = new Panel();
            btnRemoveItems = new RoundedButton();
            btnClearSelection = new RoundedButton();
            lblVAT = new CustomControls.CustomTextBox();
            lblVATable = new CustomControls.CustomTextBox();
            txtTransNo = new CustomControls.CustomTextBox();
            btnClearCart = new RoundedButton();
            btnPayment = new RoundedButton();
            btnAddToCart = new RoundedButton();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            btnCart = new RoundedButton();
            lblProducts = new Label();
            dgvProducts = new DataGridView();
            label1 = new Label();
            titleBar.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usersBindingSource).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // titleBar
            // 
            titleBar.BackColor = Color.FromArgb(44, 62, 80);
            titleBar.Controls.Add(closeButton);
            titleBar.Controls.Add(lblCashierName);
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
            // lblCashierName
            // 
            lblCashierName.AutoSize = true;
            lblCashierName.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCashierName.ForeColor = Color.White;
            lblCashierName.Location = new Point(1003, 10);
            lblCashierName.Name = "lblCashierName";
            lblCashierName.Size = new Size(212, 21);
            lblCashierName.TabIndex = 20;
            lblCashierName.Text = "employeeName | Cashier";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(12, 10);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(100, 21);
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
            btnLogOut.Location = new Point(44, 717);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(82, 34);
            btnLogOut.TabIndex = 21;
            btnLogOut.Text = "Logout";
            btnLogOut.TextAlign = ContentAlignment.TopCenter;
            btnLogOut.UseVisualStyleBackColor = false;
            //btnLogOut.Click += btnLogOut_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(txtProductName);
            panel1.Controls.Add(txtPrice);
            panel1.Controls.Add(txtQuan);
            panel1.Controls.Add(txtProductCode);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(44, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(843, 162);
            panel1.TabIndex = 18;
            // 
            // txtProductName
            // 
            txtProductName.BorderColor = SystemColors.ButtonFace;
            txtProductName.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtProductName.BorderRadius = 8;
            txtProductName.BorderThickness = 2;
            txtProductName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtProductName.ForeColor = Color.Black;
            txtProductName.InnerBackColor = SystemColors.InactiveCaption;
            txtProductName.InnerForeColor = Color.Black;
            txtProductName.IsPasswordField = false;
            txtProductName.Location = new Point(133, 88);
            txtProductName.Name = "txtProductName";
            txtProductName.PasswordChar = '\0';
            txtProductName.PlaceholderColor = Color.Black;
            txtProductName.PlaceholderText = "";
            txtProductName.Size = new Size(194, 39);
            txtProductName.TabIndex = 31;
            // 
            // txtPrice
            // 
            txtPrice.BorderColor = SystemColors.ButtonFace;
            txtPrice.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtPrice.BorderRadius = 8;
            txtPrice.BorderThickness = 2;
            txtPrice.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPrice.ForeColor = Color.Black;
            txtPrice.InnerBackColor = SystemColors.InactiveCaption;
            txtPrice.InnerForeColor = Color.Black;
            txtPrice.IsPasswordField = false;
            txtPrice.Location = new Point(479, 87);
            txtPrice.Name = "txtPrice";
            txtPrice.PasswordChar = '\0';
            txtPrice.PlaceholderColor = Color.Black;
            txtPrice.PlaceholderText = "";
            txtPrice.Size = new Size(95, 39);
            txtPrice.TabIndex = 30;
            // 
            // txtQuan
            // 
            txtQuan.BorderColor = SystemColors.ButtonFace;
            txtQuan.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtQuan.BorderRadius = 8;
            txtQuan.BorderThickness = 2;
            txtQuan.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtQuan.ForeColor = Color.Black;
            txtQuan.InnerBackColor = SystemColors.InactiveCaption;
            txtQuan.InnerForeColor = Color.Black;
            txtQuan.IsPasswordField = false;
            txtQuan.Location = new Point(479, 34);
            txtQuan.Name = "txtQuan";
            txtQuan.PasswordChar = '\0';
            txtQuan.PlaceholderColor = Color.Black;
            txtQuan.PlaceholderText = "";
            txtQuan.Size = new Size(95, 39);
            txtQuan.TabIndex = 29;
            // 
            // txtProductCode
            // 
            txtProductCode.BorderColor = SystemColors.ButtonFace;
            txtProductCode.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtProductCode.BorderRadius = 8;
            txtProductCode.BorderThickness = 2;
            txtProductCode.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtProductCode.ForeColor = Color.Black;
            txtProductCode.InnerBackColor = SystemColors.InactiveCaption;
            txtProductCode.InnerForeColor = Color.Black;
            txtProductCode.IsPasswordField = false;
            txtProductCode.Location = new Point(133, 34);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.PasswordChar = '\0';
            txtProductCode.PlaceholderColor = Color.Black;
            txtProductCode.PlaceholderText = "";
            txtProductCode.Size = new Size(194, 39);
            txtProductCode.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.Control;
            label6.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(13, 97);
            label6.Name = "label6";
            label6.Size = new Size(117, 18);
            label6.TabIndex = 25;
            label6.Text = "Product Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(399, 97);
            label5.Name = "label5";
            label5.Size = new Size(49, 18);
            label5.TabIndex = 24;
            label5.Text = "Price:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(399, 44);
            label4.Name = "label4";
            label4.Size = new Size(74, 18);
            label4.TabIndex = 23;
            label4.Text = "Quantity:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(13, 44);
            label3.Name = "label3";
            label3.Size = new Size(114, 18);
            label3.TabIndex = 22;
            label3.Text = "Product Code:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightSteelBlue;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(44, 63);
            label2.Name = "label2";
            label2.Size = new Size(154, 19);
            label2.TabIndex = 21;
            label2.Text = "ITEM INFORMATION";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.BackColor = SystemColors.Control;
            lblTotalPrice.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPrice.ForeColor = Color.Black;
            lblTotalPrice.Location = new Point(108, 66);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(40, 19);
            lblTotalPrice.TabIndex = 22;
            lblTotalPrice.Text = "0.00";
            lblTotalPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(lblTotalPrice);
            panel2.Location = new Point(953, 73);
            panel2.Name = "panel2";
            panel2.Size = new Size(274, 162);
            panel2.TabIndex = 26;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.LightSteelBlue;
            label8.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(953, 63);
            label8.Name = "label8";
            label8.Size = new Size(101, 19);
            label8.TabIndex = 27;
            label8.Text = "TOTAL PRICE";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(btnRemoveItems);
            panel3.Controls.Add(btnClearSelection);
            panel3.Controls.Add(lblVAT);
            panel3.Controls.Add(lblVATable);
            panel3.Controls.Add(txtTransNo);
            panel3.Controls.Add(btnClearCart);
            panel3.Controls.Add(btnPayment);
            panel3.Controls.Add(btnAddToCart);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Location = new Point(953, 254);
            panel3.Name = "panel3";
            panel3.Size = new Size(274, 493);
            panel3.TabIndex = 27;
            // 
            // btnRemoveItems
            // 
            btnRemoveItems.BackColor = Color.FromArgb(229, 115, 115);
            btnRemoveItems.BorderColor = Color.Transparent;
            btnRemoveItems.BorderRadius = 20;
            btnRemoveItems.BorderSize = 0;
            btnRemoveItems.FlatAppearance.BorderSize = 0;
            btnRemoveItems.FlatStyle = FlatStyle.Flat;
            btnRemoveItems.ForeColor = Color.White;
            btnRemoveItems.Location = new Point(40, 275);
            btnRemoveItems.Name = "btnRemoveItems";
            btnRemoveItems.Size = new Size(201, 45);
            btnRemoveItems.TabIndex = 37;
            btnRemoveItems.Text = "REMOVE FROM CART";
            btnRemoveItems.UseVisualStyleBackColor = false;
            //btnRemoveItems.Click += btnRemoveItems_Click;
            // 
            // btnClearSelection
            // 
            btnClearSelection.BackColor = Color.FromArgb(156, 163, 175);
            btnClearSelection.BorderColor = Color.Transparent;
            btnClearSelection.BorderRadius = 20;
            btnClearSelection.BorderSize = 0;
            btnClearSelection.FlatAppearance.BorderSize = 0;
            btnClearSelection.FlatStyle = FlatStyle.Flat;
            btnClearSelection.ForeColor = Color.White;
            btnClearSelection.Location = new Point(40, 379);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(201, 45);
            btnClearSelection.TabIndex = 36;
            btnClearSelection.Text = "CLEAR SELECTION";
            btnClearSelection.UseVisualStyleBackColor = false;
            //btnClearSelection.Click += btnClearSelection_Click;
            // 
            // lblVAT
            // 
            lblVAT.BorderColor = Color.Transparent;
            lblVAT.BorderFocusColor = Color.FromArgb(30, 45, 61);
            lblVAT.BorderRadius = 8;
            lblVAT.BorderThickness = 1;
            lblVAT.Enabled = false;
            lblVAT.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVAT.ForeColor = SystemColors.GrayText;
            lblVAT.InnerBackColor = SystemColors.InactiveCaption;
            lblVAT.InnerForeColor = Color.Gray;
            lblVAT.IsPasswordField = false;
            lblVAT.Location = new Point(108, 21);
            lblVAT.Name = "lblVAT";
            lblVAT.PasswordChar = '\0';
            lblVAT.PlaceholderColor = Color.Gray;
            lblVAT.PlaceholderText = "";
            lblVAT.Size = new Size(133, 30);
            lblVAT.TabIndex = 34;
            lblVAT.Text = "0.00";
            // 
            // lblVATable
            // 
            lblVATable.BorderColor = Color.Transparent;
            lblVATable.BorderFocusColor = Color.FromArgb(30, 45, 61);
            lblVATable.BorderRadius = 8;
            lblVATable.BorderThickness = 1;
            lblVATable.Enabled = false;
            lblVATable.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVATable.ForeColor = SystemColors.GrayText;
            lblVATable.InnerBackColor = SystemColors.InactiveCaption;
            lblVATable.InnerForeColor = Color.Gray;
            lblVATable.IsPasswordField = false;
            lblVATable.Location = new Point(108, 56);
            lblVATable.Name = "lblVATable";
            lblVATable.PasswordChar = '\0';
            lblVATable.PlaceholderColor = Color.Gray;
            lblVATable.PlaceholderText = "";
            lblVATable.Size = new Size(133, 30);
            lblVATable.TabIndex = 33;
            lblVATable.Text = "0.00";
            // 
            // txtTransNo
            // 
            txtTransNo.BorderColor = Color.Transparent;
            txtTransNo.BorderFocusColor = Color.FromArgb(30, 45, 61);
            txtTransNo.BorderRadius = 8;
            txtTransNo.BorderThickness = 1;
            txtTransNo.Enabled = false;
            txtTransNo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTransNo.ForeColor = SystemColors.GrayText;
            txtTransNo.InnerBackColor = SystemColors.InactiveCaption;
            txtTransNo.InnerForeColor = Color.Gray;
            txtTransNo.IsPasswordField = false;
            txtTransNo.Location = new Point(12, 143);
            txtTransNo.Name = "txtTransNo";
            txtTransNo.PasswordChar = '\0';
            txtTransNo.PlaceholderColor = Color.Gray;
            txtTransNo.PlaceholderText = "";
            txtTransNo.Size = new Size(250, 39);
            txtTransNo.TabIndex = 32;
            txtTransNo.Text = "177013";
            // 
            // btnClearCart
            // 
            btnClearCart.BackColor = Color.FromArgb(229, 115, 115);
            btnClearCart.BorderColor = Color.Transparent;
            btnClearCart.BorderRadius = 20;
            btnClearCart.BorderSize = 0;
            btnClearCart.FlatAppearance.BorderSize = 0;
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.ForeColor = Color.White;
            btnClearCart.Location = new Point(40, 328);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(201, 45);
            btnClearCart.TabIndex = 29;
            btnClearCart.Text = "CLEAR CART";
            btnClearCart.UseVisualStyleBackColor = false;
            //btnClearCart.Click += btnClearCart_Click;
            // 
            // btnPayment
            // 
            btnPayment.BackColor = Color.FromArgb(129, 199, 132);
            btnPayment.BorderColor = Color.Transparent;
            btnPayment.BorderRadius = 20;
            btnPayment.BorderSize = 0;
            btnPayment.FlatAppearance.BorderSize = 0;
            btnPayment.FlatStyle = FlatStyle.Flat;
            btnPayment.ForeColor = Color.White;
            btnPayment.Location = new Point(40, 430);
            btnPayment.Name = "btnPayment";
            btnPayment.Size = new Size(201, 45);
            btnPayment.TabIndex = 28;
            btnPayment.Text = "PROCEED TO PAYMENT";
            btnPayment.UseVisualStyleBackColor = false;
           //btnPayment.Click += btnPayment_Click;
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.FromArgb(129, 199, 132);
            btnAddToCart.BorderColor = Color.Transparent;
            btnAddToCart.BorderRadius = 20;
            btnAddToCart.BorderSize = 0;
            btnAddToCart.FlatAppearance.BorderSize = 0;
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(40, 224);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(201, 45);
            btnAddToCart.TabIndex = 26;
            btnAddToCart.Text = "ADD TO CART";
            btnAddToCart.UseVisualStyleBackColor = false;
            //btnAddToCart.Click += btnAddToCart_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = SystemColors.Control;
            label12.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(12, 109);
            label12.Name = "label12";
            label12.Size = new Size(169, 19);
            label12.TabIndex = 25;
            label12.Text = "TRANSACTION CODE:";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.Control;
            label11.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(12, 67);
            label11.Name = "label11";
            label11.Size = new Size(79, 19);
            label11.TabIndex = 24;
            label11.Text = "VATABLE:";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.Control;
            label10.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(12, 32);
            label10.Name = "label10";
            label10.Size = new Size(43, 19);
            label10.TabIndex = 23;
            label10.Text = "VAT:";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCart
            // 
            btnCart.BackColor = Color.SteelBlue;
            btnCart.BorderColor = Color.Transparent;
            btnCart.BorderRadius = 20;
            btnCart.BorderSize = 0;
            btnCart.FlatAppearance.BorderSize = 0;
            btnCart.FlatStyle = FlatStyle.Flat;
            btnCart.ForeColor = Color.White;
            btnCart.Location = new Point(737, 716);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(150, 40);
            btnCart.TabIndex = 36;
            btnCart.Text = "CART TABLE >";
            btnCart.UseVisualStyleBackColor = false;
            //btnCart.Click += btnCart_Click;
            // 
            // lblProducts
            // 
            lblProducts.AutoSize = true;
            lblProducts.BackColor = Color.LightSteelBlue;
            lblProducts.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProducts.ForeColor = Color.Black;
            lblProducts.Location = new Point(44, 232);
            lblProducts.Name = "lblProducts";
            lblProducts.Size = new Size(74, 19);
            lblProducts.TabIndex = 37;
            lblProducts.Text = "Products";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToOrderColumns = true;
            dgvProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 5, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.GridColor = Color.FromArgb(230, 230, 230);
            dgvProducts.Location = new Point(44, 254);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvProducts.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.InactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dgvProducts.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(843, 456);
            dgvProducts.TabIndex = 58;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(212, 730);
            label1.Name = "label1";
            label1.Size = new Size(426, 17);
            label1.TabIndex = 63;
            label1.Text = "TIP: Press H to show  shortcut keys or Hover on top of the buttons!";
            // 
            // CashierDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1267, 768);
            Controls.Add(label1);
            Controls.Add(btnLogOut);
            Controls.Add(dgvProducts);
            Controls.Add(lblProducts);
            Controls.Add(btnCart);
            Controls.Add(panel3);
            Controls.Add(label8);
            Controls.Add(panel2);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(titleBar);
            Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CashierDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)usersBindingSource).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel titleBar;
        private Button closeButton;
        private Label titleLabel;
        private ContextMenuStrip contextMenuStrip1;
        private Label lblCashierName;
        private Panel panel1;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label lblTotalPrice;
        private Panel panel2;
        private Label label8;
        private CustomControls.CustomTextBox txtProductName;
        private CustomControls.CustomTextBox txtPrice;
        private CustomControls.CustomTextBox txtQuan;
        private CustomControls.CustomTextBox txtProductCode;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn baseUrlDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn requestClientOptionsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tableNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn primaryKeyDataGridViewTextBoxColumn;
        private BindingSource usersBindingSource;
        private Panel panel3;
        private Label label12;
        private Label label11;
        private Label label10;
        private CustomControls.CustomTextBox txtTransNo;
        private RoundedButton btnClearCart;
        private RoundedButton btnPayment;
        private RoundedButton btnAddToCart;
        private CustomControls.CustomTextBox lblVAT;
        private CustomControls.CustomTextBox lblVATable;
        private RoundedButton btnLogOut;
        private RoundedButton btnCart;
        private Label lblProducts;
        private RoundedButton btnClearSelection;
        private RoundedButton btnRemoveItems;
        private DataGridView dgvProducts;
        private Label label1;
    }
}
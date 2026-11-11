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
        //private readonly CashierProductService _productService;
        //private readonly CartManager _cartManager;
        //private readonly TransactionCalculator _calculator;
        private DataTable _productsTable;
        private bool _isCartView = false;
        private bool _suppressSelectionChanged = false;
        private bool _isSearching = false;
        private readonly LoginService _loginService = new LoginService();
        private decimal _vatRate = 12m; // loaded from DB on startup

        public DoctorDashboard(string username, string companyName, string userId, string sessionToken)
        {
            InitializeComponent();
            InitializeTitleBar(closeButton, titleBar, titleLabel);

            _username = username;
            _companyName = companyName;
           // _companyId = GetCompanyId(companyName);
            //_productService = new CashierProductService(_companyId);
            // _cartManager = new CartManager();
            /// _calculator = new TransactionCalculator();
            _userId = userId;
            _sessionToken = sessionToken;

            lblCashierName.Text = $"{_username} | Cashier";
            titleLabel.Text = $"{_companyName}";
            SetUserContext(_username, _userId, _sessionToken);
            SetUserContext(_username, _companyId);

           // SetupDataGridView();
           // WireUpEvents();
           // InitializeShortcuts();
            //SetupKeyboardNavigation();

           // this.Load += async (s, e) => await LoadProductsAsync();
        }

        /* private string GetCompanyId(string companyName)
         {
             try
             {
                // using var conn = DatabaseService.GetConnection();
                 conn.Open();
                 using var cmd = new NpgsqlCommand("SELECT id FROM public.companies WHERE LOWER(name) = LOWER(@name) LIMIT 1", conn);
                 cmd.Parameters.AddWithValue("@name", companyName);
                 return cmd.ExecuteScalar()?.ToString();
             }
             catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
         }

         private async Task LoadVatRateAsync()
         {
             if (string.IsNullOrEmpty(_companyId)) return;
             try
             {
                 await using var conn = DatabaseService.GetConnection();
                 await conn.OpenAsync();
                 await using var cmd = new NpgsqlCommand(
                     "SELECT vat_rate FROM companies WHERE id = @id", conn);
                 cmd.Parameters.AddWithValue("id", Guid.Parse(_companyId));
                 var result = await cmd.ExecuteScalarAsync();
                 if (result != null && result != DBNull.Value)
                     _vatRate = Convert.ToDecimal(result);
             }
             catch
             {
                 _vatRate = 12m; // fallback to default
             }
         }

         private void SetupDataGridView()
         {
             dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
             dgvProducts.MultiSelect = false;
             dgvProducts.ReadOnly = true;
             dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
             dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
             dgvProducts.AllowUserToAddRows = false;
         }

         private void WireUpEvents()
         {
             txtProductCode.TextChanged += (s, e) => SearchTable(txtProductCode.Text.Trim(), "product_code");
             txtProductName.TextChanged += (s, e) => SearchTable(txtProductName.Text.Trim(), "product_name");
             txtQuan.TextChanged += (s, e) => SearchTable(txtQuan.Text.Trim(), "quantity");
             txtPrice.TextChanged += (s, e) => SearchTable(txtPrice.Text.Trim(), "price");
         }

         private void txt_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Down)
             {
                 if (sender == txtProductCode) txtProductName.FocusInner();
                 else if (sender == txtProductName) txtQuan.FocusInner();
                 else if (sender == txtQuan) txtPrice.FocusInner();
                 else if (sender == txtPrice) txtProductCode.FocusInner();
                 e.Handled = true;
             }
             else if (e.KeyCode == Keys.Up)
             {
                 if (sender == txtProductName) txtProductCode.FocusInner();
                 else if (sender == txtQuan) txtProductName.FocusInner();
                 else if (sender == txtPrice) txtQuan.FocusInner();
                 else if (sender == txtProductCode) txtPrice.FocusInner();
                 e.Handled = true;
             }
         }

         private void SetupKeyboardNavigation()
         {
             var controls = new Control[] { txtProductCode, txtProductName, txtPrice, txtQuan };
             foreach (var control in controls)
             {
                 CashierShortcutHelper.AttachCustomKeyNavigation(control, txt_KeyDown);
             }
         }

         private async Task LoadProductsAsync()
         {
             if (string.IsNullOrEmpty(_companyId)) return;
             try
             {
                 await LoadVatRateAsync(); // load VAT rate from DB first
                 _productsTable = await _productService.LoadProductsAsync();
                 ShowProductsView();
             }
             catch (Exception ex) { MessageBox.Show($"Failed to load products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
         }

         private void UpdateFinancialDisplay()
         {
             lblVATable.Text = $"₱ {_calculator.VatableAmount:N2}";
             lblVAT.Text = $"₱ {_calculator.VatAmount:N2}";
             lblTotalPrice.Text = _calculator.TotalAmount.ToString("F2");
         }

         private void ShowProductsView()
         {
             _suppressSelectionChanged = true;
             _isCartView = false;
             dgvProducts.DataSource = _productsTable;
             RenameProductColumns();
             _suppressSelectionChanged = false;
             lblProducts.Text = "Products";
             btnCart.Text = "CART TABLE >";
             dgvProducts.ClearSelection();
         }

         private void ShowCartView()
         {
             _suppressSelectionChanged = true;
             _isCartView = true;
             dgvProducts.DataSource = _cartManager.CartTable;
             RenameCartColumns();
             _suppressSelectionChanged = false;
             lblProducts.Text = "Cart";
             btnCart.Text = "< PRODUCTS TABLE";
             dgvProducts.ClearSelection();
         }

         private void RenameProductColumns()
         {
             if (dgvProducts.Columns.Contains("product_code")) dgvProducts.Columns["product_code"].HeaderText = "Product Code";
             if (dgvProducts.Columns.Contains("product_name")) dgvProducts.Columns["product_name"].HeaderText = "Product Name";
             if (dgvProducts.Columns.Contains("price")) dgvProducts.Columns["price"].HeaderText = "Price";
             if (dgvProducts.Columns.Contains("quantity")) dgvProducts.Columns["quantity"].HeaderText = "Quantity";
         }

         private void RenameCartColumns()
         {
             if (dgvProducts.Columns.Contains("product_code")) dgvProducts.Columns["product_code"].HeaderText = "Product Code";
             if (dgvProducts.Columns.Contains("product_name")) dgvProducts.Columns["product_name"].HeaderText = "Product Name";
             if (dgvProducts.Columns.Contains("price")) dgvProducts.Columns["price"].HeaderText = "Price";
             if (dgvProducts.Columns.Contains("quantity")) dgvProducts.Columns["quantity"].HeaderText = "Qty";
             if (dgvProducts.Columns.Contains("subtotal")) dgvProducts.Columns["subtotal"].HeaderText = "Subtotal";
         }

         private void SearchTable(string keyword, string column)
         {
             if (_suppressSelectionChanged) return;

             _isSearching = true;

             try
             {
                 DataTable source = _isCartView ? _cartManager.CartTable : _productsTable;
                 if (string.IsNullOrEmpty(keyword))
                 {
                     dgvProducts.DataSource = source;
                     if (_isCartView) RenameCartColumns(); else RenameProductColumns();
                     dgvProducts.ClearSelection();
                     ClearSearchFields();
                     return;
                 }

                 var filtered = source.AsEnumerable()
                     .Where(r => r[column]?.ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                     .ToList();

                 var result = filtered.Count > 0 ? filtered.CopyToDataTable() : source.Clone();
                 dgvProducts.DataSource = result;
                 if (_isCartView) RenameCartColumns(); else RenameProductColumns();

                 dgvProducts.ClearSelection();
             }
             finally
             {
                 _isSearching = false;
             }
         }

         private void btnAddToCart_Click(object sender, EventArgs e)
         {
             string typedCode = txtProductCode.Text.Trim();
             if (string.IsNullOrEmpty(typedCode))
             { MessageBox.Show("Please select or enter a product code.", "No Product", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

             var product = _productService.FindProductByCode(_productsTable, typedCode);
             if (product == null)
             { MessageBox.Show("Product code not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

             int alreadyInCart = _cartManager.CartTable.AsEnumerable()
                 .FirstOrDefault(r => r["product_code"].ToString() == typedCode)?["quantity"] as int? ?? 0;
             int remainingStock = _productService.GetAvailableStock(_productsTable, typedCode, alreadyInCart);

             if (remainingStock < 1)
             { MessageBox.Show($"No more stock available.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

             using var qtyDialog = new QuantityDialog($"{product["product_name"]}\nAvailable: {remainingStock}", remainingStock);
             if (qtyDialog.ShowDialog() != DialogResult.OK) return;

             if (!_cartManager.IsTransactionStarted)
                 txtTransNo.Text = TransactionNumberGenerator.Generate();

             _cartManager.AddItem(typedCode, product["product_name"].ToString(), Convert.ToDecimal(product["price"]), qtyDialog.Quantity);
             _calculator.CalculateAmounts(_cartManager.CartTable, 0, _vatRate); // pass dynamic VAT rate
             UpdateFinancialDisplay();
             ShowCartView();
             ClearSearchFields();
         }

         private void btnRemoveItems_Click(object sender, EventArgs e)
         {
             if (!_isCartView)
             { MessageBox.Show("Please switch to cart view to remove items.", "Not in Cart", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
             if (dgvProducts.SelectedRows.Count == 0)
             { MessageBox.Show("Please select an item to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

             var row = dgvProducts.SelectedRows[0];
             string productCode = row.Cells["product_code"].Value?.ToString();
             string productName = row.Cells["product_name"].Value?.ToString();
             int currentQty = Convert.ToInt32(row.Cells["quantity"].Value);
             decimal price = Convert.ToDecimal(row.Cells["price"].Value);

             using var qtyDialog = new QuantityDialog($"Remove: {productName}\nIn cart: {currentQty}", currentQty, "Remove Item");
             if (qtyDialog.ShowDialog() != DialogResult.OK) return;

             _cartManager.RemoveItem(productCode, qtyDialog.Quantity, price);
             _calculator.CalculateAmounts(_cartManager.CartTable, 0, _vatRate); // pass dynamic VAT rate
             UpdateFinancialDisplay();
             ShowCartView();
         }

         private void btnPayment_Click(object sender, EventArgs e)
         {
             if (_cartManager.IsEmpty)
             { MessageBox.Show("Cart is empty.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

             if (string.IsNullOrEmpty(txtTransNo.Text))
                 txtTransNo.Text = TransactionNumberGenerator.Generate();

             var payment = new PaymentFrm(_username, _companyName, txtTransNo.Text, _cartManager.CartTable.Copy(),
                 _calculator.Subtotal, _calculator.DiscountPercentage, _calculator.DiscountAmount,
                 _calculator.VatableAmount, _calculator.VatAmount, _calculator.TotalAmount, _vatRate);

             if (payment.ShowDialog() == DialogResult.OK)
             {
                 _cartManager.ResetTransaction();
                 _calculator.Reset();
                 UpdateFinancialDisplay();
                 txtTransNo.Text = "";
                 _ = LoadProductsAsync();
                 MessageBox.Show("Transaction completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
         }

         private void btnClearCart_Click(object sender, EventArgs e)
         {
             if (_cartManager.IsEmpty) return;
             if (MessageBox.Show("Clear all items from cart?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 _cartManager.ClearCart();
                 _calculator.Reset();
                 UpdateFinancialDisplay();
                 txtTransNo.Text = "";
                 if (_isCartView) ShowCartView();
             }
         }

         private void btnClearSelection_Click(object sender, EventArgs e)
         {
             _suppressSelectionChanged = true;
             ClearSearchFields();
             ShowProductsView();
             _suppressSelectionChanged = false;
         }

         private void ClearSearchFields()
         {
             txtProductCode.Clear();
             txtProductName.Clear();
             txtQuan.Clear();
             txtPrice.Clear();
         }

         private void dgvProducts_SelectionChanged(object sender, EventArgs e)
         {
             if (_isSearching || _suppressSelectionChanged || _isCartView || dgvProducts.SelectedRows.Count == 0) return;

             var row = dgvProducts.SelectedRows[0];
             if (row.IsNewRow) return;

             _suppressSelectionChanged = true;
             txtProductCode.Text = row.Cells["product_code"]?.Value?.ToString() ?? "";
             txtProductName.Text = row.Cells["product_name"]?.Value?.ToString() ?? "";
             txtQuan.Text = row.Cells["quantity"]?.Value?.ToString() ?? "";
             txtPrice.Text = row.Cells["price"]?.Value?.ToString() ?? "";
             _suppressSelectionChanged = false;
         }

         private void btnCart_Click(object sender, EventArgs e)
         {
             if (_isCartView) ShowProductsView(); else ShowCartView();
         }

         private async Task LogLogoutAsync()
         {
             try
             {
                 if (!string.IsNullOrEmpty(_companyId))
                     await AuditService.LogLogoutAsync(_username, _companyId, Environment.MachineName);
             }
             catch (Exception ex)
             {
                 System.Diagnostics.Debug.WriteLine($"Logout audit failed: {ex.Message}");
             }
         }

         private async void btnLogOut_Click(object sender, EventArgs e)
         {
             if (MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                 return;

             BaseForm.SetAppExiting(true);
             StopSessionMonitoring();

             try
             {
                 await _loginService.LogoutSessionAsync(_userId, _sessionToken);
                 await LogLogoutAsync();
             }
             catch (Exception ex)
             {
                 System.Diagnostics.Debug.WriteLine($"Logout error: {ex.Message}");
             }

             new LogInForm().Show();
             this.Close();
         }

         private void InitializeShortcuts()
         {
             var controls = new Control[] { txtProductCode, txtProductName, txtQuan, txtPrice };
             foreach (var control in controls)
                 CashierShortcutHelper.AttachCustomKeyNavigation(control, txt_KeyDown);

             CashierShortcutHelper.AttachFunctionShortcuts(this,
                 onEnter: (s, ev) => btnAddToCart_Click(s, ev),
                 onDelete: (s, ev) => btnRemoveItems_Click(s, ev),
                 onClearCart: (s, ev) => btnClearCart_Click(s, ev),
                 onEscape: (s, ev) =>
                 {
                     if (dgvProducts.SelectedRows.Count > 0) btnClearSelection_Click(s, ev);
                     else btnLogOut_Click(s, ev);
                 },
                 onPayment: (s, ev) => btnPayment_Click(s, ev),
                 onToggleCart: (s, ev) => btnCart_Click(s, ev),
                 onShowCheatSheet: (s, ev) => ShortcutCheatSheet()
             );

             CashierShortcutHelper.SetupTooltips(this,
                 (btnAddToCart, "Enter"),
                 (btnRemoveItems, "Delete"),
                 (btnClearCart, "Ctrl+Shift+C"),
                 (btnClearSelection, "Esc"),
                 (btnPayment, "F2"),
                 (btnLogOut, "Esc"),
                 (btnCart, "F1")
             );

             CashierShortcutHelper.AttachHoverEffect(btnAddToCart, "ADD TO CART", "Enter");
             CashierShortcutHelper.AttachHoverEffect(btnRemoveItems, "REMOVE FROM CART", "Delete");
             CashierShortcutHelper.AttachHoverEffect(btnClearCart, "CLEAR CART", "Ctrl+Shift+C");
             CashierShortcutHelper.AttachHoverEffect(btnClearSelection, "CLEAR SELECTION", "Esc");
             CashierShortcutHelper.AttachHoverEffect(btnPayment, "PROCEED TO PAYMENT", "F2");
             CashierShortcutHelper.AttachHoverEffect(btnLogOut, "Logout", "Esc");
             CashierShortcutHelper.AttachHoverEffect(btnCart, "Switch Table", "F1");
         }

         private void ShortcutCheatSheet()
         {
             string cheatSheet =
                 @"Shortcuts: 
 ENTER - Add to Cart
 DELETE - Remove Items
 CTRL+SHIFT+C - Clear Cart
 ESC - Clear Selection/Logout
 F2 - Payment
 F1 - Cart";

             MessageBox.Show(cheatSheet, "Shortcuts:",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
     } */
    }
}

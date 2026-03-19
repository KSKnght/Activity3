using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string _productName;
        private decimal _price;
        private DatabaseHelper _dbHelper = new DatabaseHelper();
        private List<OrderItem> _orderItems = new List<OrderItem>();
        private List<Product> products = new List<Product>();
        private int _loggedInUserId;

        public Form1(int userId)
        {
            InitializeComponent();
            _loggedInUserId = userId;
            Form1_Load();
        }

        public Form1(int userId, string username)
        {
            InitializeComponent();
            _loggedInUserId = userId;
            lblUsername.Text = $"User: {username}";
            Form1_Load();
        }

        public Form1(int userId, string username, string role)
        {
            InitializeComponent();
            _loggedInUserId = userId;
            lblUsername.Text = $"User: {username}";

            // Hide add product button if user is cashier
            if (role == "cashier")
            {
                btnAddProduct.Visible = false;
            }

            Form1_Load();
        }

        private void Form1_Load()
        {
            // Load products from database
            products = _dbHelper.GetAllProducts();

            foreach (var product in products)
            {
                ProductCard card = new ProductCard();

                card.ItemName = product.Name;
                card.Price = product.Price;
                card.Dock = DockStyle.Bottom;

                if (System.IO.File.Exists(product.ImagePath))
                    card.ProductImage = Image.FromFile(product.ImagePath);

                card.ProductClicked += ProductCard_ProductClicked;

                ProductPanel.Controls.Add(card);
            }

            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void ProductCard_ProductClicked(object sender, EventArgs e)
        {
            ProductCard card = sender as ProductCard;
            if (card == null)
                return;

            string sizeSelection = ShowSizeSelectionPopup();
            string itemName = card.ItemName;
            decimal priceModifier = 0;

            if (sizeSelection == "Grande")
            {
                itemName = $"(Grande) {itemName}";
                priceModifier = 20.00m;
            }
            else if (sizeSelection == "Venti")
            {
                itemName = $"(Venti) {itemName}";
                priceModifier = 30.00m;
            }

            decimal totalPrice = card.Price + priceModifier;

            // Check if item already exists in order
            OrderItem existingItem = _orderItems.FirstOrDefault(x => x.ProductName == itemName);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                // Get product from database to get Id
                Product product = _dbHelper.GetProductByName(card.ItemName);

                OrderItem newItem = new OrderItem
                {
                    ProductName = itemName,
                    Quantity = 1,
                    UnitPrice = totalPrice,
                    BasePrice = totalPrice,  // Save the price at time of order
                    Size = sizeSelection,
                    ProductId = product?.Id ?? 0
                };
                _orderItems.Add(newItem);
            }

            RefreshDataGrid();
            UpdateTotalAmount();
        }

        private void RefreshDataGrid()
        {
            dgvOrders.Rows.Clear();

            foreach (var item in _orderItems)
            {
                dgvOrders.Rows.Add(
                    item.ProductName,
                    item.Quantity,
                    item.UnitPrice.ToString("C2"),
                    item.TotalPrice.ToString("C2")
                );
            }

            // Deselect all rows
            dgvOrders.ClearSelection();
            dgvOrders.CurrentCell = null;
        }

        private void UpdateTotalAmount()
        {
            decimal totalAmount = _orderItems.Sum(x => x.TotalPrice);
            label5.Text = totalAmount.ToString("C2");
            CalculateChange();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateChange()
        {
            // Extract numeric value from label5 (Total Amount)
            if (!decimal.TryParse(label5.Text.Replace("$", "").Replace(",", ""), out decimal totalAmount))
                totalAmount = 0;

            // Get the amount tendered from textBox1
            if (!decimal.TryParse(textBox1.Text, out decimal amountTendered))
                amountTendered = 0;

            // Calculate change
            decimal change = amountTendered - totalAmount;

            // Display change in label6, show 0 if negative
            label6.Text = (change >= 0 ? change : 0).ToString("C2");
        }

        public string ShowSizeSelectionPopup()
        {
            var result = MessageBox.Show(
                "Choose Cup Size:\n\n" +
                "Yes for Grande (+20.00)\n" +
                "No for Venti (+30.00)\n" +
                "Cancel for Regular",
                "Select Cup Size",
                MessageBoxButtons.YesNoCancel
            );

            if (result == DialogResult.Yes)
                return "Grande";
            if (result == DialogResult.No)
                return "Venti";
            return "Regular";
        }

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            // Validate order items
            if (_orderItems.Count == 0)
            {
                MessageBox.Show("Please add items to the order before saving.", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate amount tendered
            if (!decimal.TryParse(textBox1.Text, out decimal amountTendered) || amountTendered == 0)
            {
                MessageBox.Show("Please enter the amount tendered.", "Missing Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalAmount = _orderItems.Sum(x => x.TotalPrice);

            // Validate sufficient payment
            if (amountTendered < totalAmount)
            {
                MessageBox.Show("Insufficient payment amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(label6.Text.Replace("$", "").Replace(",", ""), out decimal change);

            // Create order object
            Order order = new Order
            {
                TotalAmount = totalAmount,
                AmountTendered = amountTendered,
                Change = change,
                OrderItems = new List<OrderItem>(_orderItems)
            };

            // Save to database with logged-in user ID
            if (_dbHelper.SaveCompleteTransaction(order, _loggedInUserId))
            {
                MessageBox.Show($"Transaction saved successfully!\nOrder ID: {order.Id}\nTotal: {order.TotalAmount:C2}\nChange: {order.Change:C2}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear UI
                ClearTransaction();
            }
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            // Validate order items
            if (_orderItems.Count == 0)
            {
                MessageBox.Show("Please add items to the order before saving.", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate amount tendered
            if (!decimal.TryParse(textBox1.Text, out decimal amountTendered) || amountTendered == 0)
            {
                MessageBox.Show("Please enter the amount tendered.", "Missing Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalAmount = _orderItems.Sum(x => x.TotalPrice);

            // Validate sufficient payment
            if (amountTendered < totalAmount)
            {
                MessageBox.Show("Insufficient payment amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(label6.Text.Replace("$", "").Replace(",", ""), out decimal change);

            // Create order object
            Order order = new Order
            {
                TotalAmount = totalAmount,
                AmountTendered = amountTendered,
                Change = change,
                OrderItems = new List<OrderItem>(_orderItems)
            };

            // Save to database with logged-in user ID
            if (_dbHelper.SaveCompleteTransaction(order, _loggedInUserId))
            {
                MessageBox.Show($"Transaction saved successfully!\nOrder ID: {order.Id}\nTotal: {order.TotalAmount:C2}\nChange: {order.Change:C2}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear UI
                ClearTransaction();
            }
        }

        private void ClearTransaction()
        {
            _orderItems.Clear();
            dgvOrders.Rows.Clear();
            label5.Text = "$0.00";
            label6.Text = "$0.00";
            textBox1.Clear();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard(_loggedInUserId, lblUsername.Text.Replace("User: ", ""));
            adminDashboard.ShowDialog();
        }
    }
}

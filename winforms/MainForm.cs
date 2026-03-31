using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp1.DTOs;
using WindowsFormsApp1.winforms;

namespace WindowsFormsApp1.winforms
{
    public partial class MainForm : Form
    {
        private DatabaseHelper _dbHelper = new DatabaseHelper();
        private int _loggedInUserId;
        private string _loggedInUsername;
        private string _loggedInRole;

        // Transaction variables
        private List<OrderItem> _orderItems = new List<OrderItem>();
        private List<ProductDTO> _transactionProducts = new List<ProductDTO>();

        // Admin variables
        private List<ProductDTO> _adminProducts = new List<ProductDTO>();
        private List<UserDTO> _adminUsers = new List<UserDTO>();

        public MainForm(int userId, string username, string role)
        {
            InitializeComponent();
            _loggedInUserId = userId;
            _loggedInUsername = username;
            _loggedInRole = role;

            lblUsername.Text = $"User: {_loggedInUsername}";
            pHeader.BackColor = Color.FromArgb(3, 53, 44);
            fpTabs.BackColor = Color.FromArgb(3, 53, 44);
            pContent.BackColor = Color.FromArgb(3, 53, 44);

            // Wire up tab button events
            btnTransaction.Click += BtnTransaction_Click;
            btnUsers.Click += BtnUsers_Click;
            btnProducts.Click += BtnProducts_Click;
            btnLogOut.Click += BtnLogOut_Click;

            // Wire up transaction panel events
            btnNewTransaction.Click += btnNewTransaction_Click;
            btnAddTransaction.Click += btnAddTransaction_Click;
            textBox1.TextChanged += textBox1_TextChanged;
            btnAddUser.Click += btnAddUser_Click;
            btnAddProduct.Click += btnAddProduct_Click;

            // Set up role-based visibility
            if (_loggedInRole == "cashier")
            {
                btnUsers.Visible = false;
                btnProducts.Visible = false;
                pnlUserProducts.Visible = false;
            }
            else
            {
                pnlUserProducts.Visible = true;
            }

            // Load initial tab
            LoadTransactionTab();
        }

        private void LoadTransactionTab()
        {
            pnlTransaction.Visible = true;
            pnlUserProducts.Visible = false;

            UpdateTabHighlight(btnTransaction);

            // Convert Products to ProductDTOs
            var products = _dbHelper.GetAllProducts();
            _transactionProducts = DTOMapper.ToDTO(products);
            ProductPanel.Controls.Clear();

            foreach (var productDTO in _transactionProducts)
            {
                ProductCard card = new ProductCard
                {
                    ItemName = productDTO.Name,
                    Price = productDTO.Price,
                    Dock = DockStyle.Bottom
                };

                if (System.IO.File.Exists(productDTO.ImagePath))
                    card.ProductImage = Image.FromFile(productDTO.ImagePath);

                card.ProductClicked += ProductCard_ProductClicked;
                card.Tag = productDTO; // Store DTO in Tag
                ProductPanel.Controls.Add(card);
            }
        }

        private void LoadUsersTab()
        {
            pnlTransaction.Visible = false;
            pnlUserProducts.Visible = true;
            tabUsers.Visible = true;
            tabProducts.Visible = false;
            btnAddUser.Visible = true;
            btnAddProduct.Visible = false;

            UpdateTabHighlight(btnUsers);

            LoadUsers();
        }

        private void LoadProductsTab()
        {
            pnlTransaction.Visible = false;
            pnlUserProducts.Visible = true;
            tabUsers.Visible = false;
            tabProducts.Visible = true;
            btnAddUser.Visible = false;
            btnAddProduct.Visible = true;

            UpdateTabHighlight(btnProducts);

            LoadProducts();
        }

        private void LoadUsers()
        {
            flowLayoutPanelUsers.Controls.Clear();
            var users = _dbHelper.GetAllUsers();
            _adminUsers = DTOMapper.ToDTO(users);

            foreach (var userDTO in _adminUsers)
            {
                UserCard card = new UserCard
                {
                    UserName = userDTO.Name,
                    UserRole = userDTO.Role,
                    Size = new System.Drawing.Size(200, 100),
                    Margin = new Padding(5)
                };

                card.Tag = userDTO;
                card.UserClicked += (s, e) => UserCard_UserClicked(s, userDTO);

                flowLayoutPanelUsers.Controls.Add(card);
            }
        }

        private void LoadProducts()
        {
            flowLayoutPanel1.Controls.Clear();
            var products = _dbHelper.GetAllProductsForAdmin();
            _adminProducts = DTOMapper.ToDTO(products);

            foreach (var productDTO in _adminProducts)
            {
                ProductCard card = new ProductCard
                {
                    ItemName = productDTO.Name,
                    Price = productDTO.Price,
                    Size = new System.Drawing.Size(233, 100),
                    Margin = new Padding(5)
                };

                if (System.IO.File.Exists(productDTO.ImagePath))
                    card.ProductImage = Image.FromFile(productDTO.ImagePath);

                card.Tag = productDTO;
                card.ProductClicked += (s, e) => ProductCard_AdminClicked(s, productDTO);

                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void UserCard_UserClicked(object sender, UserDTO userDTO)
        {
            UserForm userForm = new UserForm(userDTO.Id, userDTO.Name, userDTO.Role);
            if (userForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void ProductCard_ProductClicked(object sender, EventArgs e)
        {
            ProductCard card = sender as ProductCard;
            if (card == null) return;

            ProductDTO productDTO = card.Tag as ProductDTO;
            if (productDTO == null) return;

            string sizeSelection = ShowSizeSelectionPopup();
            string itemName = productDTO.Name;
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

            decimal totalPrice = productDTO.Price + priceModifier;

            OrderItem existingItem = _orderItems.FirstOrDefault(x => x.ProductName == itemName);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                OrderItem newItem = new OrderItem
                {
                    ProductName = itemName,
                    Quantity = 1,
                    UnitPrice = totalPrice,
                    BasePrice = totalPrice,
                    Size = sizeSelection,
                    ProductId = productDTO.Id
                };
                _orderItems.Add(newItem);
            }

            RefreshDataGrid();
            UpdateTotalAmount();
        }

        private void ProductCard_AdminClicked(object sender, ProductDTO productDTO)
        {
            ProductForm productForm = new ProductForm(productDTO.Id, productDTO.Name, productDTO.Price, productDTO.ImagePath);
            if (productForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
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

            dgvOrders.ClearSelection();
            dgvOrders.CurrentCell = null;
        }

        private void UpdateTotalAmount()
        {
            decimal totalAmount = _orderItems.Sum(x => x.TotalPrice);
            label5.Text = totalAmount.ToString("C2");
            CalculateChange();
        }

        private void CalculateChange()
        {
            if (!decimal.TryParse(label5.Text.Replace("$", "").Replace(",", ""), out decimal totalAmount))
                totalAmount = 0;

            if (!decimal.TryParse(textBox1.Text, out decimal amountTendered))
                amountTendered = 0;

            decimal change = amountTendered - totalAmount;
            label6.Text = (change >= 0 ? change : 0).ToString("C2");
        }

        public string ShowSizeSelectionPopup()
        {
            var result = MessageBox.Show(
                "Choose Cup Size:\n\n" +
                "Yes for Grande (+₱20.00)\n" +
                "No for Venti (+₱30.00)\n" +
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
            ClearTransaction();
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            if (_orderItems.Count == 0)
            {
                MessageBox.Show("Please add items to the order before saving.", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBox1.Text, out decimal amountTendered) || amountTendered == 0)
            {
                MessageBox.Show("Please enter the amount tendered.", "Missing Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalAmount = _orderItems.Sum(x => x.TotalPrice);

            if (amountTendered < totalAmount)
            {
                MessageBox.Show("Insufficient payment amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(label6.Text.Replace("$", "").Replace(",", ""), out decimal change);

            Order order = new Order
            {
                TotalAmount = totalAmount,
                AmountTendered = amountTendered,
                Change = change,
                OrderItems = new List<OrderItem>(_orderItems)
            };

            if (_dbHelper.SaveCompleteTransaction(order, _loggedInUserId))
            {
                MessageBox.Show($"Transaction saved successfully!\nOrder ID: {order.Id}\nTotal: {order.TotalAmount:C2}\nChange: {order.Change:C2}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            if (userForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            if (productForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void UpdateTabHighlight(Button activeTab)
        {
            btnTransaction.BackColor = Color.FromArgb(3, 53, 44);
            btnUsers.BackColor = Color.FromArgb(3, 53, 44);
            btnProducts.BackColor = Color.FromArgb(3, 53, 44);

            activeTab.BackColor = Color.FromArgb(50, 120, 100);
        }

        private void BtnTransaction_Click(object sender, EventArgs e)
        {
            LoadTransactionTab();
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            if (_loggedInRole == "admin")
                LoadUsersTab();
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            if (_loggedInRole == "admin")
                LoadProductsTab();
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminDashboard : Form
    {
        private DatabaseHelper _dbHelper = new DatabaseHelper();
        private int _loggedInUserId;
        private string _loggedInUsername;
        private List<Product> _products = new List<Product>();
        private List<User> _users = new List<User>();

        public AdminDashboard(int userId, string username)
        {
            InitializeComponent();
            _loggedInUserId = userId;
            _loggedInUsername = username;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            lblUsername.Text = $"Admin: {_loggedInUsername}";
            LoadUsers();
            LoadProducts();
        }

        private void LoadUsers()
        {
            flowLayoutPanelUsers.Controls.Clear();
            _users = _dbHelper.GetAllUsers();

            foreach (var user in _users)
            {
                UserCard card = new UserCard();
                card.UserName = user.Name;
                card.UserRole = user.Role;
                card.Size = new System.Drawing.Size(200, 100);
                card.Margin = new Padding(5);

                // Store user reference in Tag for later access
                card.Tag = user;
                card.UserClicked += UserCard_UserClicked;

                flowLayoutPanelUsers.Controls.Add(card);
            }
        }

        private void UserCard_UserClicked(object sender, EventArgs e)
        {
            UserCard card = sender as UserCard;
            if (card == null)
                return;

            User user = card.Tag as User;
            if (user == null)
                return;

            EditUserForm editUserForm = new EditUserForm(user.Id, user.Name, user.Role);
            if (editUserForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void LoadProducts()
        {
            flowLayoutPanel1.Controls.Clear();
            _products = _dbHelper.GetAllProductsForAdmin();

            foreach (var product in _products)
            {
                ProductCard card = new ProductCard();
                card.ItemName = product.Name;
                card.Price = product.Price;
                card.Size = new System.Drawing.Size(233, 100);
                card.Margin = new Padding(5);

                if (System.IO.File.Exists(product.ImagePath))
                    card.ProductImage = System.Drawing.Image.FromFile(product.ImagePath);

                // Store product reference in Tag for later access
                card.Tag = product;
                card.ProductClicked += ProductCard_ProductClicked;

                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void ProductCard_ProductClicked(object sender, EventArgs e)
        {
            ProductCard card = sender as ProductCard;
            if (card == null)
                return;

            Product product = card.Tag as Product;
            if (product == null)
                return;

            EditProductForm editProductForm = new EditProductForm(product.Id, product.Name, product.Price, product.ImagePath);
            if (editProductForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            if (addUserForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
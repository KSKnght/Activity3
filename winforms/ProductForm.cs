using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.winforms
{
    public partial class ProductForm : Form
    {
        private DatabaseHelper _dbHelper = new DatabaseHelper();
        private int _productId;
        private bool _isEditMode;

        // Constructor for adding a new product
        public ProductForm()
        {
            InitializeComponent();
            _productId = 0;
            _isEditMode = false;
        }

        // Constructor for editing an existing product
        public ProductForm(int productId, string productName, decimal price, string imagePath)
        {
            InitializeComponent();
            _productId = productId;
            _isEditMode = true;
            txtProductName.Text = productName;
            txtPrice.Text = price.ToString();
            txtImagePath.Text = imagePath;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                this.Text = "Edit Product";
                label1.Text = "Edit Product";
                btnSave.Text = "Update";
            }
            else
            {
                this.Text = "Add Product";
                label1.Text = "Add New Product";
                btnSave.Text = "Add Product";
                txtProductName.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text.Trim();
            string priceText = txtPrice.Text.Trim();
            string imagePath = txtImagePath.Text.Trim();

            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Please enter a product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Please enter an image path.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isEditMode)
            {
                // Edit mode
                if (_dbHelper.UpdateProduct(_productId, productName, price, imagePath))
                {
                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Add mode
                if (_dbHelper.AddProduct(productName, price, imagePath))
                {
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

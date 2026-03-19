using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EditProductForm : Form
    {
        private DatabaseHelper _dbHelper = new DatabaseHelper();
        private int _productId;

        public EditProductForm(int productId, string productName, decimal price, string imagePath)
        {
            InitializeComponent();
            _productId = productId;
            txtProductName.Text = productName;
            txtPrice.Text = price.ToString();
            txtImagePath.Text = imagePath;
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

        private void btnUpdate_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
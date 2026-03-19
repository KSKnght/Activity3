using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddProductForm : Form
    {
        private DatabaseHelper _dbHelper = new DatabaseHelper();

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
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

            if (_dbHelper.AddProduct(productName, price, imagePath))
            {
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
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

        private void ClearForm()
        {
            txtProductName.Clear();
            txtPrice.Clear();
            txtImagePath.Clear();
            txtProductName.Focus();
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            txtProductName.Focus();
        }
    }
}
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddUserForm : Form
    {
        private DatabaseHelper _dbHelper = new DatabaseHelper();

        public AddUserForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString() ?? "cashier";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_dbHelper.RegisterUser(username, password))
            {
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Add("cashier");
            cmbRole.Items.Add("admin");
            cmbRole.SelectedIndex = 0;
            txtUsername.Focus();
        }
    }
}
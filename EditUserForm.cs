using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EditUserForm : Form
    {
        private DatabaseHelper _dbHelper = new DatabaseHelper();
        private int _userId;

        public EditUserForm(int userId, string userName, string role)
        {
            InitializeComponent();
            _userId = userId;
            txtUsername.Text = userName;
            cmbRole.Text = role;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString() ?? "cashier";

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_dbHelper.UpdateUser(_userId, username, role))
            {
                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Add("cashier");
            cmbRole.Items.Add("admin");
        }
    }
}
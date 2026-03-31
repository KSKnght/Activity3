using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserForm : Form
    {
        private DatabaseHelper _dbHelper = new DatabaseHelper();
        private int _userId;
        private bool _isEditMode;

        // Constructor for adding a new user
        public UserForm()
        {
            InitializeComponent();
            _userId = 0;
            _isEditMode = false;
        }

        // Constructor for editing an existing user
        public UserForm(int userId, string userName, string role)
        {
            InitializeComponent();
            _userId = userId;
            _isEditMode = true;
            txtUsername.Text = userName;
            cmbRole.Text = role;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Add("cashier");
            cmbRole.Items.Add("admin");

            if (_isEditMode)
            {
                label1.Text = "Edit User";
                btnSave.Text = "Update";
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                cmbRole.SelectedIndex = cmbRole.FindString(cmbRole.Text);
            }
            else
            {
                label1.Text = "Add User";
                btnSave.Text = "Add";
                cmbRole.SelectedIndex = 0;
                txtUsername.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString() ?? "cashier";

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isEditMode)
            {
                // Edit mode
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
            else
            {
                // Add mode
                string password = txtPassword.Text;

                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Pass the selected role to RegisterUser
                if (_dbHelper.RegisterUser(username, password, role))
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

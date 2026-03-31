using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        private DatabaseHelper _dbHelper = new DatabaseHelper();
        public int LoggedInUserId { get; private set; }
        public string LoggedInUsername { get; private set; }
        public string LoggedInUserRole { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = _dbHelper.AuthenticateUser(username, password);

            if (userId > 0)
            {
                LoggedInUserId = userId;
                LoggedInUsername = username;
                LoggedInUserRole = _dbHelper.GetUserRole(userId);
                
                // Show welcome message
                MessageBox.Show($"Welcome back, {username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
    }
}
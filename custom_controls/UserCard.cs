using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserCard : UserControl
    {
        private string _userName;
        private string _userRole;

        public event EventHandler UserClicked;

        public UserCard()
        {
            InitializeComponent();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            this.Click += (s, e) => OnUserClicked(e);
            WireUpControlsRecursive(this);
        }

        private void WireUpControlsRecursive(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.Click += (s, e) => OnUserClicked(e);
                WireUpControlsRecursive(control);
            }
        }

        protected virtual void OnUserClicked(EventArgs e)
        {
            UserClicked?.Invoke(this, e);
        }

        public string UserName
        {
            get => _userName;
            set { _userName = value; lblUserName.Text = value; }
        }

        public string UserRole
        {
            get => _userRole;
            set { _userRole = value; lblRole.Text = value; }
        }
    }
}
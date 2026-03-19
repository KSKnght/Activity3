using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                LoginForm loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    if (loginForm.LoggedInUserRole == "admin")
                    {
                        AdminDashboard adminDashboard = new AdminDashboard(loginForm.LoggedInUserId, loginForm.LoggedInUsername);
                        adminDashboard.ShowDialog();
                    }
                    else
                    {
                        Form1 form1 = new Form1(loginForm.LoggedInUserId, loginForm.LoggedInUsername, loginForm.LoggedInUserRole);
                        Application.Run(form1);
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}

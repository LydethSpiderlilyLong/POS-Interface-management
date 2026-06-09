using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_System_Interface_FinalGroupProject.Model;
using POS_System_Interface_FinalGroupProject.View;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace POS_System_Interface_FinalGroupProject.View
{
    public partial class logInForm : Form
    {
        public logInForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void btnlogIn_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            User user = UsersForm.userList.FirstOrDefault(u =>
                u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)
                && u.Password == password);

            if (user != null)
            {
                MessageBox.Show("Login Successful!");

                DashboardForm dashboard = new DashboardForm(user);

                this.Hide();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!");
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Show password
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Hide password
            }
        }

        private void txtUserName_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

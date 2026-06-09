using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using POS_System_Interface_FinalGroupProject.Model;
using POS_System_Interface_FinalGroupProject.View;

namespace POS_System_Interface_FinalGroupProject
{
    public partial class UsersForm : Form
    {
        public static List<User> userList = new List<User>()
        {
            new User()
            {
                UserId = 1,
                UserName = "Admin",
                Password = "123",
                Gender = "Female",
                Status = "Active",
                Email = "admin@gmail.com"
            }
        };

        public UsersForm()
        {
            InitializeComponent();
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtPassword.PasswordChar = '*';
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            comboStatus.Items.Clear();
            comboStatus.Items.Add("Active");
            comboStatus.Items.Add("Inactive");

            lblNotFound.Width = dgUser.Width;
            lblNotFound.TextAlign = ContentAlignment.MiddleCenter;
            lblNotFound.ForeColor = Color.Red;
            lblNotFound.Visible = false;

            RefreshGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "" ||
                txtUserName.Text == "" ||
                txtPassword.Text == "" ||
                txtEmail.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            int userId;

            if (!int.TryParse(txtUserId.Text, out userId))
            {
                MessageBox.Show("User ID must be a number.");
                return;
            }

            if (userList.Any(u => u.UserId == userId))
            {
                MessageBox.Show("User ID already exists.");
                return;
            }

            try
            {
                MailAddress email = new MailAddress(txtEmail.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Email Address.");
                return;
            }

            User user = new User();

            user.UserId = userId;
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.Email = txtEmail.Text;
            user.Gender = radioMale.Checked ? "Male" : "Female";
            user.Status = comboStatus.Text;

            userList.Add(user);

            RefreshGrid();

            MessageBox.Show("User added successfully!");

            ClearData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            int selectedId =
                Convert.ToInt32(dgUser.SelectedRows[0].Cells[0].Value);

            User user =
                userList.FirstOrDefault(u => u.UserId == selectedId);

            if (user != null)
            {
                int userId;

                if (!int.TryParse(txtUserId.Text, out userId))
                {
                    MessageBox.Show("User ID must be a number.");
                    return;
                }

                try
                {
                    MailAddress email = new MailAddress(txtEmail.Text);
                }
                catch
                {
                    MessageBox.Show("Invalid Email Address.");
                    return;
                }

                user.UserId = userId;
                user.UserName = txtUserName.Text;
                user.Password = txtPassword.Text;
                user.Email = txtEmail.Text;
                user.Gender = radioMale.Checked ? "Male" : "Female";
                user.Status = comboStatus.Text;

                RefreshGrid();

                MessageBox.Show("User updated successfully!");

                ClearData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Do you want to delete this user?",
                "Delete User",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int selectedId =
                    Convert.ToInt32(dgUser.SelectedRows[0].Cells[0].Value);

                User user =
                    userList.FirstOrDefault(u => u.UserId == selectedId);

                if (user != null)
                {
                    userList.Remove(user);

                    RefreshGrid();

                    MessageBox.Show("User deleted successfully!");

                    ClearData();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText =
                txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                lblNotFound.Visible = false;
                RefreshGrid();
                return;
            }

            dgUser.Rows.Clear();

            bool found = false;

            foreach (User user in userList)
            {
                if (user.UserId.ToString().Contains(searchText) ||
                    user.UserName.ToLower().Contains(searchText))
                {
                    dgUser.Rows.Add(
                        user.UserId,
                        user.UserName,
                        user.Gender,
                        user.Status,
                        user.Email);

                    found = true;
                }
            }

            lblNotFound.Visible = !found;
        }

        private void RefreshGrid()
        {
            dgUser.Rows.Clear();

            foreach (User user in userList)
            {
                dgUser.Rows.Add(
                    user.UserId,
                    user.UserName,
                    user.Gender,
                    user.Status,
                    user.Email);
            }
        }

        private void ClearData()
        {
            txtUserId.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtEmail.Clear();

            radioMale.Checked = false;
            radioFemale.Checked = false;

            comboStatus.SelectedIndex = -1;

            txtUserId.Focus();
        }

        private void dgUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgUser.Rows[e.RowIndex];

                txtUserId.Text = row.Cells[0].Value?.ToString();
                txtUserName.Text = row.Cells[1].Value?.ToString();

                string gender = row.Cells[2].Value?.ToString();

                radioMale.Checked = gender == "Male";
                radioFemale.Checked = gender == "Female";

                comboStatus.Text = row.Cells[3].Value?.ToString();
                txtEmail.Text = row.Cells[4].Value?.ToString();
            }
        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
        }

        private void dgUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lblNotFound_Click(object sender, EventArgs e)
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

        /*public void logIn(string inputName, string inputPassword)
        {
            bool isCheck = false;

            foreach (User user in userList)
            {
                if (user.UserName == inputName &&
                    user.Password == inputPassword)
                {
                    isCheck = true;
                    break;
                }
            }

            if (isCheck)
            {
                DashboardForm dashboard = new DashboardForm();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("User and Password invalid!");
            }
        }*/
    }
}
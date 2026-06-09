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

namespace POS_System_Interface_FinalGroupProject
{
    public partial class RolesForm : Form
    {
        public static List<Roles> roleList = new List<Roles>();
        public RolesForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            int selectedId =
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            Roles role =
                roleList.FirstOrDefault(r => r.RoleId == selectedId);

            if (role != null)
            {
                role.RoleId = Convert.ToInt32(txtRoleId.Text);
                role.RoleName = txtRoleName.Text;

                RefreshGrid();

                MessageBox.Show("Role updated successfully.");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int roleId;

            if (!int.TryParse(txtRoleId.Text, out roleId))
            {
                MessageBox.Show("Role ID must be numeric.");
                return;
            }

            if (roleList.Any(r => r.RoleId == roleId))
            {
                MessageBox.Show("Role ID already exists.");
                return;
            }

            Roles role = new Roles();

            role.RoleId = roleId;
            role.RoleName = txtRoleName.Text;

            roleList.Add(role);

            RefreshGrid();

            MessageBox.Show("Role created successfully.");

            ClearData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            int selectedId =
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            Roles role =
                roleList.FirstOrDefault(r => r.RoleId == selectedId);

            if (role != null)
            {
                roleList.Remove(role);

                RefreshGrid();

                MessageBox.Show("Role deleted successfully.");
            }
        }

        private void txtRoleId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRoleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();

            dataGridView1.Rows.Clear();

            foreach (Roles role in roleList)
            {
                if (role.RoleId.ToString().Contains(search) ||
                    role.RoleName.ToLower().Contains(search))
                {
                    dataGridView1.Rows.Add(
                        role.RoleId,
                        role.RoleName
                    );
                }
            }
        }
        private void RolesForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtRoleId.Text = row.Cells[0].Value.ToString();
                txtRoleName.Text = row.Cells[1].Value.ToString();
            }
        }
        private void ClearData()
        {
            txtRoleId.Clear();
            txtRoleName.Clear();

            txtRoleId.Focus();
        }
        private void RefreshGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (Roles role in roleList)
            {
                dataGridView1.Rows.Add(
                    role.RoleId,
                    role.RoleName
                );
            }
        }
    }
}

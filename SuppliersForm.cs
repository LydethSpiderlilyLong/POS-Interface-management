using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_System_Interface_FinalGroupProject.Model;

namespace POS_System_Interface_FinalGroupProject
{
    public partial class SuppliersForm : Form
    {
        public SuppliersForm()
        {
            InitializeComponent();
        }
        public static int Id = 1;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Suppliers_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        //create
        private void btnCreate_Click(object sender, EventArgs e)
        {
            dgViewSuppliers.Rows.Add(
                txtSupplierID.Text,
                txtSupplierName.Text,
                txtPhoneNumber.Text
            );

            MessageBox.Show("Supplier Created Successfully!");

            ClearData();
        }
        //delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgViewSuppliers.SelectedRows.Count > 0)
            {
                dgViewSuppliers.Rows.RemoveAt(
                    dgViewSuppliers.SelectedRows[0].Index);

                MessageBox.Show("Supplier Deleted Successfully!");
            }
            else
            {
                MessageBox.Show("Please select a supplier to delete.");
            }
        }
        //update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgViewSuppliers.CurrentRow != null)
            {
                dgViewSuppliers.CurrentRow.Cells[0].Value = txtSupplierID.Text;
                dgViewSuppliers.CurrentRow.Cells[1].Value = txtSupplierName.Text;
                dgViewSuppliers.CurrentRow.Cells[2].Value = txtPhoneNumber.Text;
                MessageBox.Show("Supplier Updated Successfully!");
            }
            else
            {
                MessageBox.Show("Please select a supplier to update.");
            }
        }
        //dgViewSupplier
        private void dgViewSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSupplierID.Text =
                    dgViewSuppliers.Rows[e.RowIndex].Cells[0].Value?.ToString();

                txtSupplierName.Text =
                    dgViewSuppliers.Rows[e.RowIndex].Cells[1].Value?.ToString();

                txtPhoneNumber.Text =
                    dgViewSuppliers.Rows[e.RowIndex].Cells[2].Value?.ToString();
            }
        }


        //search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToString();
            foreach (DataGridViewRow row in dgViewSuppliers.Rows)
            {
                if (row.Cells[0].Value != null &&
                    row.Cells[1].Value != null)
                {
                    bool found =
                        row.Cells[0].Value.ToString().ToLower().Contains(search) ||
                        row.Cells[1].Value.ToString().ToLower().Contains(search);
                    row.Visible = found;
                }
            }
        }
        private void ClearData()
        {
            txtSupplierID.Clear();
            txtSupplierName.Clear();
            txtPhoneNumber.Clear();

            txtSupplierID.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}

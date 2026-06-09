using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using POS_System_Interface_FinalGroupProject.Model;
using POS_System_Interface_FinalGroupProject.View;

namespace POS_System_Interface_FinalGroupProject
{
    public partial class CategoriesForm : Form
    {
        public static List<Categories> categoryList =
            new List<Categories>();

        public CategoriesForm()
        {
            InitializeComponent();

            txtSearch.TextChanged += txtSearch_TextChanged;
            dgViewCategory.CellClick += dgViewCategories_CellClick;
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtCategoryId.Text == "" ||
                txtCategoryName.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            int categoryId;

            if (!int.TryParse(txtCategoryId.Text, out categoryId))
            {
                MessageBox.Show("Category ID must be a number.");
                return;
            }

            if (categoryList.Any(c => c.CategoryId == categoryId))
            {
                MessageBox.Show("Category ID already exists.");
                return;
            }

            Categories category = new Categories();

            category.CategoryId = categoryId;
            category.CategoryName = txtCategoryName.Text;

            categoryList.Add(category);

            RefreshGrid();

            MessageBox.Show("Category added successfully!");

            ClearData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgViewCategory  .SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            int selectedId =
                Convert.ToInt32(
                    dgViewCategory.SelectedRows[0].Cells[0].Value);

            Categories category =
                categoryList.FirstOrDefault(
                    c => c.CategoryId == selectedId);

            if (category != null)
            {
                category.CategoryId =
                    Convert.ToInt32(txtCategoryId.Text);

                category.CategoryName =
                    txtCategoryName.Text;

                RefreshGrid();

                MessageBox.Show("Category updated successfully!");

                ClearData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgViewCategory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            int selectedId =
                Convert.ToInt32(
                    dgViewCategory.SelectedRows[0].Cells[0].Value);

            Categories category =
                categoryList.FirstOrDefault(
                    c => c.CategoryId == selectedId);

            if (category != null)
            {
                categoryList.Remove(category);

                RefreshGrid();

                MessageBox.Show("Category deleted successfully!");

                ClearData();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void RefreshGrid()
        {
            dgViewCategory.Rows.Clear();

            foreach (Categories category in categoryList)
            {
                dgViewCategory.Rows.Add(
                    category.CategoryId,
                    category.CategoryName);
            }
        }

        private void ClearData()
        {
            txtCategoryId.Clear();
            txtCategoryName.Clear();

            txtCategoryId.Focus();
        }

        private void dgViewCategories_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgViewCategory.Rows[e.RowIndex];

                txtCategoryId.Text =
                    row.Cells[0].Value.ToString();

                txtCategoryName.Text =
                    row.Cells[1].Value.ToString();
            }
        }

        private void txtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            string search =
                txtSearch.Text.Trim().ToLower();

            dgViewCategory.Rows.Clear();

            foreach (Categories category in categoryList)
            {
                if (category.CategoryId.ToString().Contains(search) ||
                    category.CategoryName.ToLower().Contains(search))
                {
                    dgViewCategory.Rows.Add(
                        category.CategoryId,
                        category.CategoryName);
                }
            }
        }

        private void txtCategoryId_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
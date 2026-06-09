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
    public partial class ProductsForm : Form
    {
        public static List<Products> productList = new List<Products>();

        string photoPath = "";
        public ProductsForm()
        {
            InitializeComponent();
            dgViewProducts.CellClick += dgViewProducts_CellClick;
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtProductId.Text == "" ||
                txtProductName.Text == "" ||
                txtBarcode.Text == "" ||
                txtSellPrice.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            int productId;
            double sellPrice;

            if (!int.TryParse(txtProductId.Text, out productId))
            {
                MessageBox.Show("Product ID must be numeric.");
                return;
            }

            if (!double.TryParse(txtSellPrice.Text, out sellPrice))
            {
                MessageBox.Show("Sell Price must be numeric.");
                return;
            }

            if (productList.Any(p => p.ProductId == productId))
            {
                MessageBox.Show("Product ID already exists.");
                return;
            }

            Products product = new Products();

            product.ProductId = productId;
            product.ProductName = txtProductName.Text;
            product.Barcode = txtBarcode.Text;
            product.SellPrice = sellPrice;
            product.Photo = photoPath;

            productList.Add(product);

            RefreshGrid();

            MessageBox.Show("Product added successfully!");

            ClearData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            int selectedId =
                Convert.ToInt32(
                    dgViewProducts.SelectedRows[0].Cells[0].Value);

            Products product =
                productList.FirstOrDefault(
                    p => p.ProductId == selectedId);

            if (product != null)
            {
                product.ProductId =
                    Convert.ToInt32(txtProductId.Text);

                product.ProductName =
                    txtProductName.Text;

                product.Barcode =
                    txtBarcode.Text;

                product.SellPrice =
                    Convert.ToDouble(txtSellPrice.Text);

                product.Photo = photoPath;

                RefreshGrid();

                MessageBox.Show("Product updated successfully!");

                ClearData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            int selectedId =
                Convert.ToInt32(
                    dgViewProducts.SelectedRows[0].Cells[0].Value);

            Products product =
                productList.FirstOrDefault(
                    p => p.ProductId == selectedId);

            if (product != null)
            {
                productList.Remove(product);

                RefreshGrid();

                MessageBox.Show("Product deleted successfully!");

                ClearData();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                photoPath = open.FileName;

                picPhoto.Image =
                    Image.FromFile(photoPath);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search =
                txtSearch.Text.Trim().ToLower();

            dgViewProducts.Rows.Clear();

            foreach (Products product in productList)
            {
                if (product.ProductId.ToString().Contains(search) ||
                    product.ProductName.ToLower().Contains(search))
                {
                    dgViewProducts.Rows.Add(
                        product.ProductId,
                        product.ProductName,
                        product.Barcode,
                        product.SellPrice);
                }
            }
        }

        private void dgViewProducts_CellClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgViewProducts.Rows[e.RowIndex];

                txtProductId.Text =
                    row.Cells[0].Value.ToString();

                txtProductName.Text =
                    row.Cells[1].Value.ToString();

                txtBarcode.Text =
                    row.Cells[2].Value.ToString();

                txtSellPrice.Text =
                    row.Cells[3].Value.ToString();
            }
        }
        private void RefreshGrid()
        {
            dgViewProducts.Rows.Clear();

            foreach (Products product in productList)
            {
                dgViewProducts.Rows.Add(
                    product.ProductId,
                    product.ProductName,
                    product.Barcode,
                    product.SellPrice);
            }
        }

        private void ClearData()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtBarcode.Clear();
            txtSellPrice.Clear();

            picPhoto.Image = null;

            photoPath = "";

            txtProductId.Focus();
        }
    }
}

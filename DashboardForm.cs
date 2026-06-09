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

namespace POS_System_Interface_FinalGroupProject.View
{

    public partial class DashboardForm : Form
    {
        private User currentUser;
        private int childFormNumber = 0;

        public DashboardForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                toolStripStatusLabel.Text =
                    "Welcome, " + currentUser.UserName;
            }
        }

        private void securityToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm frm = new UsersForm();

            frm.MdiParent = this;
            frm.Show();
        }
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is ProductsForm)
                {
                    form.Activate();
                    return;
                }
            }

            ProductsForm frm = new ProductsForm();
            frm.MdiParent = this;
            frm.Show();
        }

        /*private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm frm = new UsersForm();

            frm.MdiParent = this;
            frm.Show();
        }*/

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriesForm frm = new CategoriesForm();

            frm.MdiParent = this;
            frm.Show();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuppliersForm frm = new SuppliersForm();

            frm.MdiParent = this;
            frm.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RolesForm frm = new RolesForm();

            frm.MdiParent = this;
            frm.Show();
        }
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked");

            UsersForm frm = new UsersForm();
            frm.MdiParent = this;
            frm.Show();
        }

    }
}

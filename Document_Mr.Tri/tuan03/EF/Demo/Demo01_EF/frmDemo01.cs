using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo01_EF
{
    public partial class frmDemo01 : Form
    {
        public frmDemo01()
        {
            InitializeComponent();
        }

        private DataDemoEntities _model = new DataDemoEntities();

        private void frmDemo01_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            tvData.Nodes.Clear();
            var query = from c in _model.Categories
                        where c.ParentID == null
                        select c;
            foreach (var item in query)
            {
                TreeNode node = new TreeNode();
                node.Tag = item.CategoryID;
                node.Text = item.CategoryName;
                GetCategoryChilds(item, node);
                tvData.Nodes.Add(node);
            }
        }

        private void GetCategoryChilds(Category parent, TreeNode nodeParent)
        {
            foreach (var child in parent.CategoriesChilds)
            {
                TreeNode node = new TreeNode();
                node.Tag = child.CategoryID;
                node.Text = child.CategoryName;
                GetCategoryChilds(child, node);
                nodeParent.Nodes.Add(node);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDemo01_Edit frm = new frmDemo01_Edit();
            frm.ItemID = -1;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _model = new DataDemoEntities();
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tvData.SelectedNode != null)
            {
                frmDemo01_Edit frm = new frmDemo01_Edit();
                frm.ItemID = Convert.ToInt32(tvData.SelectedNode.Tag);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _model = new DataDemoEntities();
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tvData.SelectedNode != null)
            {
                if (MessageBox.Show("Do you want delete this item ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(tvData.SelectedNode.Tag);
                    Category obj = _model.Categories.FirstOrDefault(c => c.CategoryID == id);
                    _model.DeleteObject(obj);
                    _model.SaveChanges();
                    LoadData();
                }
            }
        }
    }
}

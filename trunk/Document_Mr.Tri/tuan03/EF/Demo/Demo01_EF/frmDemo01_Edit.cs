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
    public partial class frmDemo01_Edit : Form
    {
        public frmDemo01_Edit()
        {
            InitializeComponent();
        }

        private DataDemoEntities _model = new DataDemoEntities();
        public int ItemID { get; set; }
        private Category _itemEdit;

        private void frmDemo01_Edit_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadData();
            LoadInit();
        }

        private void LoadInit()
        {
            txtCategoryName.Text = _itemEdit.CategoryName;
            if (_itemEdit.ParentID != null)
                cboParent.SelectedValue = _itemEdit.ParentID.Value;
            else
                cboParent.SelectedIndex = 0;
        }

        private void LoadCategory()
        {
            var query = from c in _model.Categories
                        where c.ParentID == null
                        select c;
            List<Category> lst = query.ToList();
            lst.Insert(0, new Category { CategoryID = -1, CategoryName = "--- Choose category ---" });

            cboParent.DisplayMember = "CategoryName";
            cboParent.ValueMember = "CategoryID";
            cboParent.DataSource = lst;
        }

        private void LoadData()
        {
            if (ItemID == -1)
            {
                _itemEdit = new Category();
                _itemEdit.CategoryID = ItemID;
                _itemEdit.CategoryName = string.Empty;
            }
            else
            {
                _itemEdit = _model.Categories.FirstOrDefault(c => c.CategoryID == ItemID);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckError())
            {
                GetData();
                if (_itemEdit.CategoryID == -1)
                {
                    _model.AddToCategories(_itemEdit);
                }
                _model.SaveChanges();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void GetData()
        {
            _itemEdit.CategoryName = txtCategoryName.Text;
            if ((cboParent.SelectedItem as Category).CategoryID == -1)
                _itemEdit.CategoryParent = null;
            else
                _itemEdit.CategoryParent = cboParent.SelectedItem as Category;
        }

        private bool CheckError()
        {
            bool flag = true;
            ClearError();
            if (txtCategoryName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtCategoryName, "Input category name");
                flag = false;
            }
            return flag;
        }

        private void ClearError()
        {
            errorProvider1.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

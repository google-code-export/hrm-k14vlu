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
    public partial class frmDemo02 : Form
    {
        public frmDemo02()
        {
            InitializeComponent();
        }

        private DataDemoEntities _model = new DataDemoEntities();
        private List<int> _listCategoryID = new List<int>();
        private int _currentPage = 0;
        private int _totalPage = 0;
        const int pageSize = 5;

        private void frmDemo02_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void LoadCategory()
        {
            List<Category> lst = new List<Category>();
            foreach (var item in _model.Categories.Where(c => c.ParentID == null))
            {
                lst.Add(new Category { CategoryID = item.CategoryID, CategoryName = item.CategoryName });
                GetCategoryChilds(item, lst);
            }
            lst.Insert(0, new Category { CategoryID = -1, CategoryName = "--- Choose category ---" });
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryID";
            cboCategory.DataSource = lst;
        }

        private void GetCategoryChilds(Category parent, List<Category> lst)
        {
            foreach (var child in parent.CategoriesChilds)
            {
                lst.Add(new Category { CategoryID = child.CategoryID, CategoryName = "..." + child.CategoryName });
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex > 0)
                LoadCategoryChange();
            else
                dgvData.DataSource = null;
        }

        private void LoadCategoryChange()
        {
            int id = (cboCategory.SelectedItem as Category).CategoryID;
            _listCategoryID.Clear();
            _listCategoryID.Add(id);
            _listCategoryID.AddRange(_model.Categories.Where(c => c.ParentID == id).Select(c => c.CategoryID));

            var query = from c in _model.Products
                        where _listCategoryID.Contains(c.CategoryID)
                        select c;
            int totalProduct = query.Count();
            _totalPage = totalProduct / pageSize;
            _totalPage += (totalProduct % pageSize == 0) ? 0 : 1;
            _currentPage = 0;
            LoadProduct();
        }

        private void LoadProduct()
        {
            var query = from c in _model.Products
                        where _listCategoryID.Contains(c.CategoryID)
                        select new
                        {
                            c.ProductID,
                            c.ProductName,
                            c.Quantity,
                            c.Price,
                            c.Category.CategoryName
                        };

            dgvData.DataSource = query.OrderBy(c => c.ProductID).Skip(_currentPage * pageSize).Take(pageSize);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPage - 1)
            {
                _currentPage++;
                LoadProduct();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 0)
            {
                _currentPage--;
                LoadProduct();
            }
        }

    }
}

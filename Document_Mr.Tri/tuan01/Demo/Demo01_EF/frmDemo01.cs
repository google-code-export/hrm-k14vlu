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

        private DataDemoEntities model = new DataDemoEntities();

        private void frmDemo01_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var query = from c in model.Categories
                        select c;
            dataGridView1.DataSource = query.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category obj = new Category();
            obj.CategoryName = txtCategoryName.Text;

            model.AddToCategories(obj);
            model.SaveChanges();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Category obj = dataGridView1.SelectedRows[0].DataBoundItem as Category;
                obj.CategoryName = txtCategoryName.Text;

                model.SaveChanges();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Category obj = dataGridView1.SelectedRows[0].DataBoundItem as Category;

                model.DeleteObject(obj);
                model.SaveChanges();
                LoadData();
            }
        }
    }
}

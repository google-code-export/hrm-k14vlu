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
    public partial class frmDemo02_Edit : Form
    {
        public frmDemo02_Edit()
        {
            InitializeComponent();
        }
        
        public int CategoryID { get; set; }
        private DataDemoEntities model = new DataDemoEntities();

        private void frmDemo02_Edit_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

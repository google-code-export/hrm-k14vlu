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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnDemo01_Click(object sender, EventArgs e)
        {
            frmDemo01 frm = new frmDemo01();
            frm.ShowDialog();
        }

        private void btnDemo02_Click(object sender, EventArgs e)
        {
            frmDemo02 frm = new frmDemo02();
            frm.ShowDialog();
        }
    }
}

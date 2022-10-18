using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hydee.Auto.Interface.Set
{
    public partial class frmNewSub : Form
    {
        public string strNewName = "";
        public string strTitle = "";
        public string strLbl = "";

        public frmNewSub()
        {
            InitializeComponent();
        }

        private void frmNewSub_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(strTitle))
            {
                this.Text = strTitle;
            }

            if (!string.IsNullOrEmpty(strLbl))
            {
                label1.Text = strLbl;
            }

            txtNewName.Focus();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            strNewName = txtNewName.Text.ToString().Trim();

            if (string.IsNullOrEmpty(strNewName))
            {
                MessageBox.Show("请输入新接口名称");
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}

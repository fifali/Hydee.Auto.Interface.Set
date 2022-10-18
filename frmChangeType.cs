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
    public partial class frmChangeType : Form
    {
        public frmChangeType()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strSetPass = "Hydee@sofT#" + DateTime.Now.ToString("yyyyMMddHH");
            string strPassWord = textBox1.Text.ToString().Trim();

            if (string.IsNullOrEmpty(strPassWord))
            {
                MessageBox.Show("请输入密码！");

                textBox1.Focus();

                return;
            }

            if (strPassWord == strSetPass)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("密码错误！");

                textBox1.Text = "";
                textBox1.Focus();

                return;
            }
        }
    }
}

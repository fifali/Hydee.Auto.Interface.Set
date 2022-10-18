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
    public partial class frmDllSelect : Form
    {
        public DataSet dsDll = null;

        public string dllnamespe = "";
        public string dllclassname = "";
        public string dllprocname = "";
        public string dllparanum = "";
        public frmDllSelect()
        {
            InitializeComponent();
        }

        private void frmDllSelect_Load(object sender, EventArgs e)
        {
            try
            {
                if (dsDll != null && dsDll.Tables.Count > 0 && dsDll.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDll.Tables[0].Rows.Count; i++)
                    {
                        lvDll.Invoke(new EventHandler(delegate
                        {
                            string[] strItem = { dsDll.Tables[0].Rows[i]["dllname"].ToString().Trim(), dsDll.Tables[0].Rows[i]["dllnamespe"].ToString().Trim(), dsDll.Tables[0].Rows[i]["dllclassname"].ToString().Trim(), dsDll.Tables[0].Rows[i]["dllprocname"].ToString().Trim(), dsDll.Tables[0].Rows[i]["dllparanum"].ToString().Trim() };

                            lvDll.Items.Insert(lvDll.Items.Count, new ListViewItem(strItem));
                            
                        }));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvDll_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvDll.SelectedItems.Count > 0)
            {
                dllnamespe = lvDll.SelectedItems[0].SubItems[1].Text.ToString().Trim();
                dllclassname = lvDll.SelectedItems[0].SubItems[2].Text.ToString().Trim();
                dllprocname = lvDll.SelectedItems[0].SubItems[3].Text.ToString().Trim();
                dllparanum = lvDll.SelectedItems[0].SubItems[4].Text.ToString().Trim();

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}

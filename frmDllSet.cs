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
    public partial class frmDllSet : Form
    {
        public string subName = "";
        public string paraName = "";
        public string chiName = "";

        public string xmlTitle = "";

        public string xmlParTitle = "";

        public frmDllSet()
        {
            InitializeComponent();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                gbMain.Focus();

                if (dgvDll.Rows.Count == 0)
                {
                    dgvDll.Rows.Add(1);

                    dgvDll.Rows[dgvDll.Rows.Count - 1].Cells[0].Value = "";
                    dgvDll.Rows[dgvDll.Rows.Count - 1].Cells[1].Value = "";
                    dgvDll.Rows[dgvDll.Rows.Count - 1].Cells[2].Value = "";
                    dgvDll.Rows[dgvDll.Rows.Count - 1].Cells[3].Value = "";
                    dgvDll.Rows[dgvDll.Rows.Count - 1].Cells[4].Value = "";

                    dgvDll.Rows[dgvDll.Rows.Count - 1].Selected = true;
                }

                dgvDll.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDll.Rows.Clear();

                dgvDllPara.Rows.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbDel_D_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dResult = MessageBox.Show("确定删除选中行？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (dResult == System.Windows.Forms.DialogResult.Yes)
                {
                    if (dgvDllPara.SelectedRows.Count > 0)
                    {
                        dgvDllPara.Rows.Remove(dgvDllPara.SelectedRows[0]);
                    }
                    else
                    {
                        MessageBox.Show("请选中一行后，再进行删除");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbAdd_D_Click(object sender, EventArgs e)
        {
            try
            {
                gbMain.Focus();

                if (dgvDll.Rows.Count == 0)
                {
                    MessageBox.Show("请先添加类库设置后再添加明细");
                }
                else
                {
                    string paraNum = (dgvDll.Rows[0].Cells["dllparanum"].Value == null ? "" : dgvDll.Rows[0].Cells["dllparanum"].Value.ToString().Trim().Replace("'", "''"));

                    if (paraNum == "")
                    {
                        MessageBox.Show("请先设置参数数量");
                    }
                    else
                    {
                        int iParaNum = Convert.ToInt32(paraNum);

                        if (dgvDllPara.Rows.Count < iParaNum)
                        {
                            dgvDllPara.Rows.Add(1);

                            dgvDllPara.Rows[dgvDllPara.Rows.Count - 1].Cells[0].Value = "";
                            dgvDllPara.Rows[dgvDllPara.Rows.Count - 1].Cells[1].Value = "";
                            dgvDllPara.Rows[dgvDllPara.Rows.Count - 1].Cells[2].Value = "";

                            dgvDllPara.Rows[dgvDllPara.Rows.Count - 1].Selected = true;
                        }
                    }
                }

                dgvDllPara.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                gbMain.Focus();

                List<string> listSql = new List<string>();

                listSql.Add("delete from hawi_dllset where subname='" + subName + "' and chiname='" + chiName + "' and paraname='" + paraName + "' and iif(IsNull(xmltitle), '', xmltitle)='" + xmlTitle + "' and iif(IsNull(xmlpartitle), '', xmlpartitle)='" + xmlParTitle + "'");
                listSql.Add("delete from hawi_dllparaset where subname='" + subName + "' and chiname='" + chiName + "' and paraname='" + paraName + "' and iif(IsNull(xmltitle), '', xmltitle)='" + xmlTitle + "' and iif(IsNull(xmlpartitle), '', xmlpartitle)='" + xmlParTitle + "'");

                if (dgvDll.Rows.Count > 0)
                {
                    string dllname = (dgvDll.Rows[0].Cells["dllname"].Value == null ? "" : dgvDll.Rows[0].Cells["dllname"].Value.ToString().Trim().Replace("'", "''"));
                    string dllnamespe = (dgvDll.Rows[0].Cells["dllnamespe"].Value == null ? "" : dgvDll.Rows[0].Cells["dllnamespe"].Value.ToString().Trim().Replace("'", "''"));
                    string dllclassname = (dgvDll.Rows[0].Cells["dllclassname"].Value == null ? "" : dgvDll.Rows[0].Cells["dllclassname"].Value.ToString().Trim().Replace("'", "''"));
                    string dllprocname = (dgvDll.Rows[0].Cells["dllprocname"].Value == null ? "" : dgvDll.Rows[0].Cells["dllprocname"].Value.ToString().Trim().Replace("'", "''"));
                    string dllparanum = (dgvDll.Rows[0].Cells["dllparanum"].Value == null ? "" : dgvDll.Rows[0].Cells["dllparanum"].Value.ToString().Trim().Replace("'", "''"));

                    int iparanum = Convert.ToInt32(dllparanum);

                    if (dgvDllPara.Rows.Count == iparanum)
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.Append("insert into hawi_dllset(subname,chiname,paraname,xmltitle,xmlpartitle,dllname,dllnamespe,dllclassname,dllprocname,dllparanum)");
                        sb.Append(" values(");
                        sb.Append("'");
                        sb.Append(subName);
                        sb.Append("','");
                        sb.Append(chiName);
                        sb.Append("','");
                        sb.Append(paraName);
                        sb.Append("','");
                        sb.Append(xmlTitle);
                        sb.Append("','");
                        sb.Append(xmlParTitle);
                        sb.Append("','");
                        sb.Append(dllname);
                        sb.Append("','");
                        sb.Append(dllnamespe);
                        sb.Append("','");
                        sb.Append(dllclassname);
                        sb.Append("','");
                        sb.Append(dllprocname);
                        sb.Append("','");
                        sb.Append(dllparanum);
                        sb.Append("')");

                        listSql.Add(sb.ToString());

                        for (int i = 0; i < dgvDllPara.Rows.Count; i++)
                        {
                            sb.Clear();

                            string dllparaname = (dgvDllPara.Rows[i].Cells["dllparaname"].Value == null ? "" : dgvDllPara.Rows[i].Cells["dllparaname"].Value.ToString().Trim().Replace("'", "''"));
                            string dllparavalue = (dgvDllPara.Rows[i].Cells["dllparavalue"].Value == null ? "" : dgvDllPara.Rows[i].Cells["dllparavalue"].Value.ToString().Trim().Replace("'", "''"));
                            string dllparasort = (dgvDllPara.Rows[i].Cells["dllparasort"].Value == null ? "0" : dgvDllPara.Rows[i].Cells["dllparasort"].Value.ToString().Trim().Replace("'", "''"));

                            sb.Append("insert into hawi_dllparaset(subname,chiname,paraname,xmltitle,xmlpartitle,dllparaname,dllparavalue,dllparasort)");
                            sb.Append(" values(");
                            sb.Append("'");
                            sb.Append(subName);
                            sb.Append("','");
                            sb.Append(chiName);
                            sb.Append("','");
                            sb.Append(paraName);
                            sb.Append("','");
                            sb.Append(xmlTitle);
                            sb.Append("','");
                            sb.Append(xmlParTitle);
                            sb.Append("','");
                            sb.Append(dllparaname);
                            sb.Append("','");
                            sb.Append(dllparavalue);
                            sb.Append("','");
                            sb.Append(dllparasort);
                            sb.Append("')");

                            listSql.Add(sb.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("参数数量不符");

                        return;
                    }

                }

                DAO.DAOAccess da = new DAO.DAOAccess();

                if (da.RunSql(listSql))
                {
                    MessageBox.Show("保存成功");
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDllSet_Load(object sender, EventArgs e)
        {
            if (subName == "" || paraName == "")
            {
                MessageBox.Show("方法或者参数为空，不能进行配置");

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }

            DAO.DAOAccess da = new DAO.DAOAccess();

            DataSet dsDll = da.GetDllSet(subName, chiName, paraName, xmlTitle, xmlParTitle);

            DataSet dsDllPara = da.GetDllParaSet(subName, chiName, paraName, xmlTitle, xmlParTitle);

            if (dsDll != null && dsDll.Tables.Count > 0 && dsDll.Tables[0].Rows.Count > 0)
            {
                dgvDll.Rows.Add(1);

                dgvDll.Rows[dgvDll.Rows.Count - 1].Cells["dllname"].Value = dsDll.Tables[0].Rows[0]["dllname"].ToString().Trim();
                dgvDll.Rows[dgvDll.Rows.Count - 1].Cells["dllnamespe"].Value = dsDll.Tables[0].Rows[0]["dllnamespe"].ToString().Trim();
                dgvDll.Rows[dgvDll.Rows.Count - 1].Cells["dllclassname"].Value = dsDll.Tables[0].Rows[0]["dllclassname"].ToString().Trim();
                dgvDll.Rows[dgvDll.Rows.Count - 1].Cells["dllprocname"].Value = dsDll.Tables[0].Rows[0]["dllprocname"].ToString().Trim();
                dgvDll.Rows[dgvDll.Rows.Count - 1].Cells["dllparanum"].Value = dsDll.Tables[0].Rows[0]["dllparanum"].ToString().Trim();

                dgvDll.Rows[dgvDll.Rows.Count - 1].Selected = true;
            }

            if (dsDllPara != null && dsDllPara.Tables.Count > 0 && dsDllPara.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsDllPara.Tables[0].Rows.Count; i++)
                {
                    dgvDllPara.Rows.Add(1);

                    dgvDllPara.Rows[dgvDllPara.Rows.Count - 1].Cells["dllparaname"].Value = dsDllPara.Tables[0].Rows[i]["dllparaname"].ToString().Trim();
                    dgvDllPara.Rows[dgvDllPara.Rows.Count - 1].Cells["dllparavalue"].Value = dsDllPara.Tables[0].Rows[i]["dllparavalue"].ToString().Trim();
                    dgvDllPara.Rows[dgvDllPara.Rows.Count - 1].Cells["dllparasort"].Value = dsDllPara.Tables[0].Rows[i]["dllparasort"].ToString().Trim();

                    dgvDllPara.Rows[dgvDllPara.Rows.Count - 1].Selected = true;
                }
            }
        }

        private void dgvDll_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && dgvDllPara.Rows.Count<=0)
            {
                string strDllName = dgvDll.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();

                if (!string.IsNullOrEmpty(strDllName))
                {
                    DAO.DAOAccess da = new DAO.DAOAccess();

                    DataSet dsDll = da.GetDllSet(strDllName);

                    if (dsDll != null && dsDll.Tables.Count > 0 && dsDll.Tables[0].Rows.Count > 0)
                    {
                        frmDllSelect frm = new frmDllSelect();

                        frm.dsDll = dsDll;

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            string dllnamespe = frm.dllnamespe;
                            string dllclassname = frm.dllclassname;
                            string dllprocname = frm.dllprocname;
                            string dllparanum = frm.dllparanum;

                            dgvDll.Rows[e.RowIndex].Cells[1].Value = dllnamespe;
                            dgvDll.Rows[e.RowIndex].Cells[2].Value = dllclassname;
                            dgvDll.Rows[e.RowIndex].Cells[3].Value = dllprocname;
                            dgvDll.Rows[e.RowIndex].Cells[4].Value = dllparanum;

                            DataSet dsDllPara = da.GetDllPara(strDllName, dllnamespe, dllclassname, dllprocname, dllparanum);

                            if (dsDllPara != null && dsDllPara.Tables.Count > 0 && dsDllPara.Tables[0].Rows.Count > 0)
                            {
                                //MessageBox.Show(dsDllPara.Tables[0].Rows[0]["dllparaname"].ToString().Trim());

                                for (int i = 0; i < dsDllPara.Tables[0].Rows.Count; i++)
                                {
                                    dgvDllPara.Rows.Add(1);

                                    dgvDllPara.Rows[dgvDllPara.Rows.Count - 1].Cells["dllparaname"].Value = dsDllPara.Tables[0].Rows[i]["dllparaname"].ToString().Trim();
                                    dgvDllPara.Rows[dgvDllPara.Rows.Count - 1].Cells["dllparavalue"].Value = dsDllPara.Tables[0].Rows[i]["dllparavalue"].ToString().Trim();
                                    dgvDllPara.Rows[dgvDllPara.Rows.Count - 1].Cells["dllparasort"].Value = dsDllPara.Tables[0].Rows[i]["dllparasort"].ToString().Trim();

                                }
                            }
                        }
                        
                    }
                }

            }
        }
    }
}

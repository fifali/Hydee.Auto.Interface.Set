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
    public partial class frmJudRec : Form
    {
        public string subName = "";
        public string chiName = "";
        public string strType = "";

        public frmJudRec()
        {
            InitializeComponent();
        }

        private void frmJudRec_Load(object sender, EventArgs e)
        {
            try
            {
                if (strType == "loop")
                {
                    this.Text = "自循环判断逻辑设置";
                }

                gbMain.Text = chiName;

                BindData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                dgvJud.Rows.Add(1);

                dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["sort"].Value = dgvJud.Rows.Count.ToString();
                dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["leftbra"].Value = "";
                dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["titname"].Value = "";
                dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["condition"].Value = "==";
                dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["titvalues"].Value = "";
                dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["rightbra"].Value = "";
                dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["datatype"].Value = "字符";
                dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["linktype"].Value = "并且";

                dgvJud.Rows[dgvJud.Rows.Count - 1].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvJud.SelectedRows.Count > 0)
            {
                dgvJud.Rows.Remove(dgvJud.SelectedRows[0]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gbMain.Focus();

                List<string> listSql = new List<string>();

                listSql.Add("delete from hawi_jud where subname='" + subName + "' and chiname='" + chiName + "' and judtype='" + strType + "'");

                if (dgvJud.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < dgvJud.Rows.Count; i++)
                    {
                        sb.Clear();

                        string sort = (dgvJud.Rows[i].Cells["sort"].Value == null ? "0" : dgvJud.Rows[i].Cells["sort"].Value.ToString().Trim().Replace("'", "''"));
                        string leftbra = (dgvJud.Rows[i].Cells["leftbra"].Value == null ? "" : dgvJud.Rows[i].Cells["leftbra"].Value.ToString().Trim().Replace("'", "''"));
                        string titname = (dgvJud.Rows[i].Cells["titname"].Value == null ? "" : dgvJud.Rows[i].Cells["titname"].Value.ToString().Trim().Replace("'", "''"));
                        string condition = (dgvJud.Rows[i].Cells["condition"].Value == null ? "" : dgvJud.Rows[i].Cells["condition"].Value.ToString().Trim().Replace("'", "''"));
                        string titvalues = (dgvJud.Rows[i].Cells["titvalues"].Value == null ? "" : dgvJud.Rows[i].Cells["titvalues"].Value.ToString().Trim().Replace("'", "''"));
                        string rightbra = (dgvJud.Rows[i].Cells["rightbra"].Value == null ? "" : dgvJud.Rows[i].Cells["rightbra"].Value.ToString().Trim().Replace("'", "''"));
                        string datatype = (dgvJud.Rows[i].Cells["datatype"].Value == null ? "" : dgvJud.Rows[i].Cells["datatype"].Value.ToString().Trim().Replace("'", "''"));
                        string linktype = (dgvJud.Rows[i].Cells["linktype"].Value == null ? "" : dgvJud.Rows[i].Cells["linktype"].Value.ToString().Trim().Replace("'", "''"));

                        sb.Append("insert into hawi_jud(subname,chiname,judtype,sort,leftbra,titname,condition,titvalues,rightbra,datatype,linktype)");
                        sb.Append(" values(");
                        sb.Append("'");
                        sb.Append(subName);
                        sb.Append("','");
                        sb.Append(chiName);
                        sb.Append("','");
                        sb.Append(strType);
                        sb.Append("',");
                        sb.Append(sort);
                        sb.Append(",'");
                        sb.Append(leftbra);
                        sb.Append("','");
                        sb.Append(titname);
                        sb.Append("','");
                        sb.Append(condition);
                        sb.Append("','");
                        sb.Append(titvalues);
                        sb.Append("','");
                        sb.Append(rightbra);
                        sb.Append("','");
                        sb.Append(datatype);
                        sb.Append("','");
                        sb.Append(linktype);
                        sb.Append("')");

                        listSql.Add(sb.ToString());
                    }
                }
                //else
                //{
                //    MessageBox.Show("参数数量不符");

                //    return;
                //}

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BindData()
        {
            try
            {
                DAO.DAOAccess da = new DAO.DAOAccess();

                DataSet ds = da.GetSubJudRec(subName, chiName, strType);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvJud.Rows.Clear();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgvJud.Rows.Add(1);

                        dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["sort"].Value = ds.Tables[0].Rows[i]["sort"].ToString().Trim();
                        dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["leftbra"].Value = ds.Tables[0].Rows[i]["leftbra"].ToString().Trim();
                        dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["titname"].Value = ds.Tables[0].Rows[i]["titname"].ToString().Trim();
                        dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["condition"].Value = ds.Tables[0].Rows[i]["condition"].ToString().Trim();
                        dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["titvalues"].Value = ds.Tables[0].Rows[i]["titvalues"].ToString().Trim();
                        dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["rightbra"].Value = ds.Tables[0].Rows[i]["rightbra"].ToString().Trim();
                        dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["datatype"].Value = ds.Tables[0].Rows[i]["datatype"].ToString().Trim();
                        dgvJud.Rows[dgvJud.Rows.Count - 1].Cells["linktype"].Value = ds.Tables[0].Rows[i]["linktype"].ToString().Trim();

                        dgvJud.Rows[0].Selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

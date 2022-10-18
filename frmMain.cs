using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hydee.Auto.Interface.Set.DAO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Hydee.Auto.Interface.Set
{
    public partial class frmMain : Form
    {
        bool bCustom = true;

        public frmMain()
        {
            InitializeComponent();
        }

        #region "获取软件版本信息"
        /// <summary>
        /// 获取版本信息
        /// </summary>
        public string AssemblyVersion
        {
            get
            {
                string ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                return ver;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            dgvSubList.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "海典软件第三方WEB接口调用配置程序-V" + AssemblyVersion;

            JudgeColumn();

            scFirst.Panel1Collapsed = false;
            scFirst.Panel2Collapsed = true;

            scSecond.Panel1Collapsed = false;
            scSecond.Panel2Collapsed = true;

            scThird.Panel2Collapsed = true;
            scThird.Panel1Collapsed = false;

            BindDgvSubList();

            dgvSubList.Focus();

            tsmPara.Visible = true;
            tsmBackSubList.Visible = false;
            tsmEditXml.Visible = false;
            tsmBackPara.Visible = false;

            if (bCustom)
            {
                dgvSubList.Columns["chiname"].ReadOnly = true;
                dgvSubList.Columns["subname"].ReadOnly = true;
                dgvSubList.Columns["subtype"].ReadOnly = true;
                dgvSubList.Columns["classname"].ReadOnly = true;
                dgvSubList.Columns["recdatadatil"].ReadOnly = true;
                dgvSubList.Columns["jsonadd"].ReadOnly = true;
                dgvSubList.Columns["reobject"].ReadOnly = true;
                dgvSubList.Columns["expdll"].ReadOnly = true;

                tsbAdd.Visible = false;
                tsbDele.Visible = false;
                tssOne.Visible = false;
                tsbCopy.Visible = false;
                tsbClear.Visible = false;
                tssTow.Visible = false;
                tssThr.Visible = false;
                tsbCopyReW.Visible = false;

                tsbCopyToFile.Visible = false;
                tsbAddByFile.Visible = false;

                tsmPara.Visible = false;
                tsmReSet.Visible = false;
                tsmDllSet.Visible = false;
                dgvSubList.Columns["webaddres"].ReadOnly = true;
                dgvSubList.Columns["basesql"].ReadOnly = true;
                //contextMenuStrip1.Visible = false;
                //contextMenuStrip1.Enabled = false;
            }

        }

        private void dgvSubList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (bCustom)
                {
                    if (dgvSubList.Columns[e.ColumnIndex].Name == "chiname"
                        || dgvSubList.Columns[e.ColumnIndex].Name == "subname"
                        || dgvSubList.Columns[e.ColumnIndex].Name == "subtype"
                        || dgvSubList.Columns[e.ColumnIndex].Name == "classname"
                        || dgvSubList.Columns[e.ColumnIndex].Name == "recdatadatil"
                        || dgvSubList.Columns[e.ColumnIndex].Name == "jsonadd"
                        || dgvSubList.Columns[e.ColumnIndex].Name == "reobject"
                        || dgvSubList.Columns[e.ColumnIndex].Name == "expdll"
                        || dgvSubList.Columns[e.ColumnIndex].Name == "webaddres"
                        || dgvSubList.Columns[e.ColumnIndex].Name == "basesql"
                        )
                    {
                        return;
                    }
                }

                string strCellValue = "";

                if (dgvSubList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    strCellValue = dgvSubList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                frmEdit fEdit = new frmEdit();

                fEdit.strValue = strCellValue;

                DialogResult dResult = fEdit.ShowDialog();

                if (dResult == System.Windows.Forms.DialogResult.OK)
                {
                    strCellValue = fEdit.strValue;

                    dgvSubList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = strCellValue;

                    gbMain.Focus();
                }
            }
        }

        private void dgvPara_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvPara.Columns[e.ColumnIndex].GetType().Name == "DataGridViewTextBoxColumn")
            {
                string strCellValue = "";

                if (dgvPara.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    strCellValue = dgvPara.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                frmEdit fEdit = new frmEdit();

                fEdit.strValue = strCellValue;

                DialogResult dResult = fEdit.ShowDialog();

                if (dResult == System.Windows.Forms.DialogResult.OK)
                {
                    strCellValue = fEdit.strValue;

                    dgvPara.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = strCellValue;

                    gbMain.Focus();
                }
            }
        }

        private void dgvXml_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvXml.Columns[e.ColumnIndex].GetType().Name == "DataGridViewTextBoxColumn")
            {
                string strCellValue = "";

                if (dgvXml.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    strCellValue = dgvXml.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                frmEdit fEdit = new frmEdit();

                fEdit.strValue = strCellValue;

                DialogResult dResult = fEdit.ShowDialog();

                if (dResult == System.Windows.Forms.DialogResult.OK)
                {
                    strCellValue = fEdit.strValue;

                    dgvXml.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = strCellValue;

                    gbMain.Focus();
                }
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (scFirst.Panel1Collapsed)
            {
                if (scSecond.Panel1Collapsed)
                {
                    dgvXml.Rows.Add(1);

                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[0].Value = "";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[1].Value = "";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[2].Value = "v";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[3].Value = "";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[4].Value = "";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[5].Value = "0";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[6].Value = "";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[7].Value = "";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[8].Value = "";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[9].Value = "";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[10].Value = "";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[11].Value = "";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[12].Value = "0";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[13].Value = "";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[14].Value = "0";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[15].Value = "1";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[16].Value = "0";
                    dgvXml.Rows[dgvXml.Rows.Count - 1].Cells[17].Value = (dgvXml.Rows.Count * 10).ToString();

                    dgvXml.Rows[dgvXml.Rows.Count - 1].Selected = true;
                }
                else
                {
                    dgvPara.Rows.Add(1);

                    dgvPara.Rows[dgvPara.Rows.Count - 1].Cells[0].Value = "";
                    dgvPara.Rows[dgvPara.Rows.Count - 1].Cells[1].Value = "0";
                    dgvPara.Rows[dgvPara.Rows.Count - 1].Cells[2].Value = "0";
                    dgvPara.Rows[dgvPara.Rows.Count - 1].Cells[3].Value = "地址";
                    dgvPara.Rows[dgvPara.Rows.Count - 1].Cells[4].Value = "字符";
                    dgvPara.Rows[dgvPara.Rows.Count - 1].Cells[5].Value = "";
                    dgvPara.Rows[dgvPara.Rows.Count - 1].Cells[6].Value = "";
                    dgvPara.Rows[dgvPara.Rows.Count - 1].Cells[7].Value = "";
                    dgvPara.Rows[dgvPara.Rows.Count - 1].Cells[8].Value = "0";
                    dgvPara.Rows[dgvPara.Rows.Count - 1].Cells[9].Value = "0";
                    dgvPara.Rows[dgvPara.Rows.Count - 1].Cells[10].Value = "0";
                    dgvPara.Rows[dgvPara.Rows.Count - 1].Cells[11].Value = (dgvPara.Rows.Count * 10).ToString();

                    dgvPara.Rows[dgvPara.Rows.Count - 1].Selected = true;
                }
            }
            else
            {
                if (scThird.Panel1Collapsed)
                {
                    if (scFourth.Panel1Collapsed)
                    {
                        dgvReTableSet.Rows.Add(1);

                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["colname"].Value = "";
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["iskey"].Value = "0";
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["canupdate"].Value = "0";
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["databy"].Value = "接收数据";
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["valuefrom"].Value = "";
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["staticvalue"].Value = "";
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["RtisDate"].Value = "字符";
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["dateType"].Value = "";
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["colsort"].Value = (dgvReTableSet.Rows.Count * 10).ToString();

                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Selected = true;
                    }
                    else
                    {
                        dgvReset.Rows.Add(1);
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["sqlname"].Value = "";
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["loopwith"].Value = "返回数据";
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["runtype"].Value = "insert";
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["ifhave"].Value = "0";
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["reorupdate"].Value = "跳过";
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["fathersql"].Value = "";
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["dbtablename"].Value = "";
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["isloop"].Value = "0";
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["looppoit"].Value = "";
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["resort"].Value = (dgvReset.Rows.Count * 10).ToString();
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["isDesc"].Value = "0";

                        dgvReset.Rows[dgvReset.Rows.Count - 1].Selected = true;
                    }
                }
                else
                {
                    dgvSubList.Rows.Add(1);

                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[0].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[1].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[2].Value = "webservice";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[3].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[4].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[5].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[6].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[7].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[8].Value = "0";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[9].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[10].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[11].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[12].Value = "0";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[13].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[14].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[15].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[16].Value = "0";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[17].Value = "0";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[18].Value = "0";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[19].Value = "0";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[20].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[21].Value = "";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[22].Value = "0";
                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells[23].Value = (dgvSubList.Rows.Count * 10).ToString();

                    dgvSubList.Rows[dgvSubList.Rows.Count - 1].Selected = true;
                }
            }
        }

        private void dgvSubList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int iSelect = e.RowIndex;

                string strChiName = "";
                string strSubName = "";

                if (dgvSubList.Rows[iSelect].Cells["chiname"].Value != null)
                {
                    strChiName = dgvSubList.Rows[iSelect].Cells["chiname"].Value.ToString().Trim().Replace(",", "");
                }

                if (dgvSubList.Rows[iSelect].Cells["subname"].Value != null)
                {
                    strSubName = dgvSubList.Rows[iSelect].Cells["subname"].Value.ToString().Trim().Replace(",", "");
                }

                gbMain.Text = strChiName;
                gbMain.Tag = strSubName;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmPara_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSubList.SelectedRows.Count > 0 && gbMain.Text.ToString().Trim().Length > 1)
                {
                    tsbAdd.Visible = true;
                    tsbDele.Visible = true;
                    tssOne.Visible = true;

                    tsmPara.Visible = false;
                    tsmBackSubList.Visible = true;
                    tsmEditXml.Visible = true;
                    tsmBackPara.Visible = false;
                    tsmReSet.Visible = false;
                    tsmDllSet.Visible = true;
                    tsmRecJud.Visible = false;
                    tsbCopyReW.Visible = false;
                    tsmAllNo.Visible = false;
                    tsmAllOK.Visible = false;

                    tsmLoopSelf.Visible = false;

                    scFirst.Panel1Collapsed = true;
                    scFirst.Panel2Collapsed = false;

                    scSecond.Panel1Collapsed = false;
                    scSecond.Panel2Collapsed = true;

                    BindDgvPara();
                }
                else
                {
                    MessageBox.Show("请选择一个函数后进行参数查看/编辑");
                }
            }
            catch (UserException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tsmSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dResult = MessageBox.Show("确定保存？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (dResult == System.Windows.Forms.DialogResult.Yes)
                {
                    gbMain.Focus();

                    if (scFirst.Panel1Collapsed)
                    {
                        if (scSecond.Panel1Collapsed)
                        {
                            List<string> listSql = SaveXml();

                            DAOAccess da = new DAOAccess();

                            if (da.RunSql(listSql))
                            {
                                MessageBox.Show("保存成功");
                                BindDgvXml();

                                gbMain.Focus();

                                dgvXml.Focus();
                            }
                        }
                        else
                        {
                            List<string> listSql = SavePara();

                            DAOAccess da = new DAOAccess();

                            if (da.RunSql(listSql))
                            {
                                MessageBox.Show("保存成功");
                                BindDgvPara();

                                gbMain.Focus();

                                dgvPara.Focus();
                            }
                        }
                    }
                    else
                    {
                        if (scThird.Panel1Collapsed)
                        {
                            if (scFourth.Panel1Collapsed)
                            {
                                List<string> listSql = SaveReTableSet();

                                DAOAccess da = new DAOAccess();

                                if (da.RunSql(listSql))
                                {
                                    MessageBox.Show("保存成功");
                                    //BindDgvSubList();
                                    BindDgvReTableSet();
                                    gbMain.Focus();

                                    dgvReTableSet.Focus();
                                }
                            }
                            else
                            {
                                List<string> listSql = SaveReSet();

                                DAOAccess da = new DAOAccess();

                                if (da.RunSql(listSql))
                                {
                                    MessageBox.Show("保存成功");
                                    //BindDgvSubList();
                                    BindDgvReset();

                                    gbMain.Focus();

                                    dgvReset.Focus();
                                }
                            }
                        }
                        else
                        {
                            List<string> listSql = SaveSubList();

                            DAOAccess da = new DAOAccess();

                            if (da.RunSql(listSql))
                            {
                                MessageBox.Show("保存成功");
                                BindDgvSubList();

                                gbMain.Focus();

                                dgvSubList.Focus();
                            }
                        }
                    }
                }
            }
            catch (UserException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<string> SaveSubList()
        {
            try
            {
                List<string> listSql = new List<string>();

                listSql.Add("delete from hawi_sublist");

                for (int i = 0; i < dgvSubList.Rows.Count; i++)
                {
                    string subName = (dgvSubList.Rows[i].Cells["subname"].Value == null ? "" : dgvSubList.Rows[i].Cells["subname"].Value.ToString().Trim().Replace("'", "''").Replace(",", ""));
                    string chiName = (dgvSubList.Rows[i].Cells["chiname"].Value == null ? "" : dgvSubList.Rows[i].Cells["chiname"].Value.ToString().Trim().Replace("'", "''").Replace(",", ""));
                    string webAddres = (dgvSubList.Rows[i].Cells["webaddres"].Value == null ? "" : dgvSubList.Rows[i].Cells["webaddres"].Value.ToString().Trim().Replace("'", "''"));
                    string className = (dgvSubList.Rows[i].Cells["classname"].Value == null ? "" : dgvSubList.Rows[i].Cells["classname"].Value.ToString().Trim().Replace("'", "''"));
                    string inParaNum = (dgvSubList.Rows[i].Cells["inparanum"].Value == null ? "" : dgvSubList.Rows[i].Cells["inparanum"].Value.ToString().Trim().Replace("'", "''"));
                    //string outParaNum = (dgvSubList.Rows[i].Cells["outparanum"].Value == null ? "" : dgvSubList.Rows[i].Cells["outparanum"].Value.ToString().Trim().Replace("'", "''"));
                    string Sort = (dgvSubList.Rows[i].Cells["sort"].Value == null ? "0" : dgvSubList.Rows[i].Cells["sort"].Value.ToString().Trim().Replace("'", "''"));
                    string isUsed = (dgvSubList.Rows[i].Cells["isused"].Value == null ? "0" : dgvSubList.Rows[i].Cells["isused"].Value.ToString().Trim().Replace("'", "''"));
                    //string rewSql = (dgvSubList.Rows[i].Cells["rewsql"].Value == null ? "" : dgvSubList.Rows[i].Cells["rewsql"].Value.ToString().Trim().Replace("'", "''"));
                    string baseSql = (dgvSubList.Rows[i].Cells["basesql"].Value == null ? "" : dgvSubList.Rows[i].Cells["basesql"].Value.ToString().Trim().Replace("'", "''"));
                    string bTableName = (dgvSubList.Rows[i].Cells["btablename"].Value == null ? "" : dgvSubList.Rows[i].Cells["btablename"].Value.ToString().Trim().Replace("'", "''"));
                    string chkReSign = (dgvSubList.Rows[i].Cells["chkReSign"].Value == null ? "0" : dgvSubList.Rows[i].Cells["chkReSign"].Value.ToString().Trim().Replace("'", "''"));
                    string reTrueValue = (dgvSubList.Rows[i].Cells["reTrueValue"].Value == null ? "" : dgvSubList.Rows[i].Cells["reTrueValue"].Value.ToString().Trim().Replace("'", "''"));
                    string reSignNode = (dgvSubList.Rows[i].Cells["reSignNode"].Value == null ? "" : dgvSubList.Rows[i].Cells["reSignNode"].Value.ToString().Trim().Replace("'", "''"));
                    string reErrorNode = (dgvSubList.Rows[i].Cells["reErrorNode"].Value == null ? "" : dgvSubList.Rows[i].Cells["reErrorNode"].Value.ToString().Trim().Replace("'", "''"));
                    string recdatadatil = (dgvSubList.Rows[i].Cells["recdatadatil"].Value == null ? "0" : dgvSubList.Rows[i].Cells["recdatadatil"].Value.ToString().Trim().Replace("'", "''"));
                    string subtype = (dgvSubList.Rows[i].Cells["subtype"].Value == null ? "webservice" : dgvSubList.Rows[i].Cells["subtype"].Value.ToString().Trim().Replace("'", "''"));
                    string jsonadd = (dgvSubList.Rows[i].Cells["jsonadd"].Value == null ? "" : dgvSubList.Rows[i].Cells["jsonadd"].Value.ToString().Trim().Replace("'", "''"));
                    string encodtype = (dgvSubList.Rows[i].Cells["encodtype"].Value == null ? "" : dgvSubList.Rows[i].Cells["encodtype"].Value.ToString().Trim().Replace("'", "''"));
                    string contenttype = (dgvSubList.Rows[i].Cells["contenttype"].Value == null ? "" : dgvSubList.Rows[i].Cells["contenttype"].Value.ToString().Trim().Replace("'", "''"));
                    string reObject = (dgvSubList.Rows[i].Cells["reobject"].Value == null ? "0" : dgvSubList.Rows[i].Cells["reobject"].Value.ToString().Trim().Replace("'", "''"));
                    string expDll = (dgvSubList.Rows[i].Cells["expdll"].Value == null ? "0" : dgvSubList.Rows[i].Cells["expdll"].Value.ToString().Trim().Replace("'", "''"));
                    string autoRun = (dgvSubList.Rows[i].Cells["autorun"].Value == null ? "0" : dgvSubList.Rows[i].Cells["autorun"].Value.ToString().Trim().Replace("'", "''"));
                    string loopbyself = (dgvSubList.Rows[i].Cells["loopself"].Value == null ? "0" : dgvSubList.Rows[i].Cells["loopself"].Value.ToString().Trim().Replace("'", "''"));
                    string followIF = (dgvSubList.Rows[i].Cells["followif"].Value == null ? "" : dgvSubList.Rows[i].Cells["followif"].Value.ToString().Trim().Replace("'", "''"));
                    string preIn = (dgvSubList.Rows[i].Cells["preInter"].Value == null ? "" : dgvSubList.Rows[i].Cells["preInter"].Value.ToString().Trim().Replace("'", "''"));

                    if (string.IsNullOrEmpty(subName))
                    {
                        throw new Exception("函数名称不能为空,第<" + (i + 1).ToString() + ">行数据");
                    }

                    if (string.IsNullOrEmpty(chiName))
                    {
                        throw new Exception("接口名称不能为空,第<" + (i + 1).ToString() + ">行数据");
                    }

                    if (string.IsNullOrEmpty(webAddres))
                    {
                        throw new Exception("接口地址不能为空,第<" + (i + 1).ToString() + ">行数据");
                    }

                    //if (string.IsNullOrEmpty(className))
                    //{
                    //    throw new Exception("类名称不能为空,第<" + (i + 1).ToString() + ">行数据");
                    //}

                    if (string.IsNullOrEmpty(inParaNum))
                    {
                        throw new Exception("参数个数不能为空,第<" + (i + 1).ToString() + ">行数据");
                    }
                    else
                    {
                        try
                        {
                            Convert.ToInt32(inParaNum);
                        }
                        catch
                        {
                            throw new Exception("参数个数请输入数值,第<" + (i + 1).ToString() + ">行数据");

                        }
                    }

                    if (subtype == "http-get" || subtype == "http-post" || subtype == "httpaysn")
                    {
                        if (string.IsNullOrEmpty(encodtype))
                        {
                            throw new Exception("HTTP接口，字符集不能为空,第<" + (i + 1).ToString() + ">行数据");
                        }

                        if (string.IsNullOrEmpty(contenttype))
                        {
                            throw new Exception("HTTP接口，contenttype不能为空,第<" + (i + 1).ToString() + ">行数据");
                        }
                    }

                    if (string.IsNullOrEmpty(Sort))
                    {
                        throw new Exception("排序不能为空,第<" + (i + 1).ToString() + ">行数据");
                    }

                    if (!string.IsNullOrEmpty(followIF))
                    {
                        string[] fi = followIF.Split(',');

                        if (fi.Length != 2)
                        {
                            throw new Exception("继调接口设置有误,第<" + (i + 1).ToString() + ">行数据");
                        }
                    }

                    string strSql = string.Format("");

                    StringBuilder sb = new StringBuilder();

                    sb.Append("insert into hawi_sublist(chiname,subname,subtype,classname");
                    sb.Append(",webaddres,basesql,btablename,inparanum,chkReSign,reTrueValue,reSignNode,reErrorNode,recdatadatil,jsonadd,encodtype,contenttype,reobject,expdll,autorun,loopbyself,followif,preInter,isused,sort)");
                    sb.Append(" values('");
                    sb.Append(chiName);
                    sb.Append("','");
                    sb.Append(subName);
                    sb.Append("','");
                    sb.Append(subtype);
                    sb.Append("','");
                    sb.Append(className);
                    sb.Append("','");
                    sb.Append(webAddres);
                    sb.Append("','");
                    sb.Append(baseSql);
                    sb.Append("','");
                    sb.Append(bTableName);
                    sb.Append("','");
                    sb.Append(inParaNum);
                    sb.Append("','");
                    sb.Append(chkReSign);
                    sb.Append("','");
                    sb.Append(reTrueValue);
                    sb.Append("','");
                    sb.Append(reSignNode);
                    sb.Append("','");
                    sb.Append(reErrorNode);
                    sb.Append("','");
                    sb.Append(recdatadatil);
                    sb.Append("','");
                    sb.Append(jsonadd);
                    sb.Append("','");
                    sb.Append(encodtype);
                    sb.Append("','");
                    sb.Append(contenttype);
                    sb.Append("','");
                    sb.Append(reObject);
                    sb.Append("','");
                    sb.Append(expDll);
                    sb.Append("','");
                    sb.Append(autoRun);
                    sb.Append("','");
                    sb.Append(loopbyself);
                    sb.Append("','");
                    sb.Append(followIF);
                    sb.Append("','");
                    sb.Append(preIn);
                    sb.Append("',");
                    sb.Append(isUsed);
                    sb.Append(",");
                    sb.Append(Sort);
                    sb.Append(")");

                    listSql.Add(sb.ToString());

                }

                return listSql;
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        private List<string> SavePara()
        {
            try
            {
                gbMain.Focus();

                List<string> listSql = new List<string>();

                string subName = gbMain.Tag.ToString().Trim();
                string chiName = gbMain.Text.ToString().Trim();

                if (string.IsNullOrEmpty(subName))
                {
                    throw new Exception("函数名称不能为空");
                }

                if (string.IsNullOrEmpty(chiName))
                {
                    throw new Exception("接口名称不能为空");
                }

                listSql.Add("delete from hawi_inpara where subname='" + subName + "' and chiname='" + chiName + "'");

                for (int i = 0; i < dgvPara.Rows.Count; i++)
                {
                    string paraName = (dgvPara.Rows[i].Cells["paraname"].Value == null ? "" : dgvPara.Rows[i].Cells["paraname"].Value.ToString().Trim().Replace("'", "''"));
                    string isXml = (dgvPara.Rows[i].Cells["isxml"].Value == null ? "0" : dgvPara.Rows[i].Cells["isxml"].Value.ToString().Trim().Replace("'", "''"));
                    string staticVal = (dgvPara.Rows[i].Cells["parastaticval"].Value == null ? "" : dgvPara.Rows[i].Cells["parastaticval"].Value.ToString().Trim().Replace("'", "''"));
                    string valSql = (dgvPara.Rows[i].Cells["getvalsql"].Value == null ? "" : dgvPara.Rows[i].Cells["getvalsql"].Value.ToString().Trim().Replace("'", "''"));
                    string valTitle = (dgvPara.Rows[i].Cells["valtitle"].Value == null ? "" : dgvPara.Rows[i].Cells["valtitle"].Value.ToString().Trim().Replace("'", "''"));
                    string paraSort = (dgvPara.Rows[i].Cells["parasort"].Value == null ? "0" : dgvPara.Rows[i].Cells["parasort"].Value.ToString().Trim().Replace("'", "''"));
                    string valByBase = (dgvPara.Rows[i].Cells["valbybase"].Value == null ? "0" : dgvPara.Rows[i].Cells["valbybase"].Value.ToString().Trim().Replace("'", "''"));
                    string datadlldetail = (dgvPara.Rows[i].Cells["datadlldetail"].Value == null ? "0" : dgvPara.Rows[i].Cells["datadlldetail"].Value.ToString().Trim().Replace("'", "''"));
                    string isJson = (dgvPara.Rows[i].Cells["isjson"].Value == null ? "0" : dgvPara.Rows[i].Cells["isjson"].Value.ToString().Trim().Replace("'", "''"));
                    string paType = (dgvPara.Rows[i].Cells["patype"].Value == null ? "地址" : dgvPara.Rows[i].Cells["patype"].Value.ToString().Trim().Replace("'", "''"));
                    string dataType = (dgvPara.Rows[i].Cells["datatype"].Value == null ? "字符" : dgvPara.Rows[i].Cells["datatype"].Value.ToString().Trim().Replace("'", "''"));
                    string withxml = (dgvPara.Rows[i].Cells["withxml"].Value == null ? "0" : dgvPara.Rows[i].Cells["withxml"].Value.ToString().Trim().Replace("'", "''"));

                    if (string.IsNullOrEmpty(paraName))
                    {
                        throw new Exception("参数名称不能为空,第<" + (i + 1).ToString() + ">行数据");
                    }

                    if (!string.IsNullOrEmpty(valSql) && string.IsNullOrEmpty(valTitle))
                    {
                        throw new Exception("通过查询获取数据时，对应取值列标题不能为空,第<" + (i + 1).ToString() + ">行数据");
                    }

                    if (string.IsNullOrEmpty(paraSort))
                    {
                        throw new Exception("排序不能为空,第<" + (i + 1).ToString() + ">行数据");
                    }
                    else
                    {
                        try
                        {
                            Convert.ToInt32(paraSort);
                        }
                        catch
                        {
                            throw new Exception("排序请输入数值,第<" + (i + 1).ToString() + ">行数据");
                        }
                    }

                    string strSql = string.Format("");

                    StringBuilder sb = new StringBuilder();

                    sb.Append("insert into hawi_inpara(subname,chiname,paraname,isxml,isjson,patype,parastaticval,getvalsql,valtitle,valbybase,datadlldetail,parasort,datatype,withxml)");
                    sb.Append(" values('");
                    sb.Append(subName);
                    sb.Append("','");
                    sb.Append(chiName);
                    sb.Append("','");
                    sb.Append(paraName);
                    sb.Append("','");
                    sb.Append(isXml);
                    sb.Append("','");
                    sb.Append(isJson);
                    sb.Append("','");
                    sb.Append(paType);
                    sb.Append("','");
                    sb.Append(staticVal);
                    sb.Append("','");
                    sb.Append(valSql);
                    sb.Append("','");
                    sb.Append(valTitle);
                    sb.Append("',");
                    sb.Append(valByBase);
                    sb.Append(",'");
                    sb.Append(datadlldetail);
                    sb.Append("',");
                    sb.Append(paraSort);
                    sb.Append(",'");
                    sb.Append(dataType);
                    sb.Append("',");
                    sb.Append(withxml);
                    sb.Append(")");

                    listSql.Add(sb.ToString());
                }

                return listSql;
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        private List<string> SaveXml()
        {
            try
            {
                List<string> listSql = new List<string>();

                string subName = gbMain.Tag.ToString().Trim();
                string paraName = gbXml.Text.ToString().Trim();
                string chiName = gbMain.Text.ToString().Trim();

                if (string.IsNullOrEmpty(subName))
                {
                    throw new Exception("函数名称不能为空");
                }

                if (string.IsNullOrEmpty(chiName))
                {
                    throw new Exception("接口名称不能为空");
                }

                listSql.Add("delete from hawi_xmlform where subname='" + subName + "' and chiname='" + chiName + "' and paraname='" + paraName + "'");

                for (int i = 0; i < dgvXml.Rows.Count; i++)
                {
                    string xmlTitle = (dgvXml.Rows[i].Cells["xmltitle"].Value == null ? "" : dgvXml.Rows[i].Cells["xmltitle"].Value.ToString().Trim().Replace("'", "''"));
                    string paraType = (dgvXml.Rows[i].Cells["paratype"].Value == null ? "v" : dgvXml.Rows[i].Cells["paratype"].Value.ToString().Trim().Replace("'", "''"));
                    string xmlTitleLv = (dgvXml.Rows[i].Cells["xmltitlelv"].Value == null ? "1" : dgvXml.Rows[i].Cells["xmltitlelv"].Value.ToString().Trim().Replace("'", "''"));
                    string parTitle = (dgvXml.Rows[i].Cells["partitle"].Value == null ? "" : dgvXml.Rows[i].Cells["partitle"].Value.ToString().Trim().Replace("'", "''"));
                    string isLoop = (dgvXml.Rows[i].Cells["titleisloop"].Value == null ? "0" : dgvXml.Rows[i].Cells["titleisloop"].Value.ToString().Trim().Replace("'", "''"));
                    string valTitle = (dgvXml.Rows[i].Cells["xmlvaltitle"].Value == null ? "" : dgvXml.Rows[i].Cells["xmlvaltitle"].Value.ToString().Trim().Replace("'", "''"));
                    string xmlstaticval = (dgvXml.Rows[i].Cells["xmlstaticval"].Value == null ? "" : dgvXml.Rows[i].Cells["xmlstaticval"].Value.ToString().Trim().Replace("'", "''"));
                    string valSql = (dgvXml.Rows[i].Cells["getvaluesql"].Value == null ? "" : dgvXml.Rows[i].Cells["getvaluesql"].Value.ToString().Trim().Replace("'", "''"));
                    string loopTable = (dgvXml.Rows[i].Cells["looptable"].Value == null ? "" : dgvXml.Rows[i].Cells["looptable"].Value.ToString().Trim().Replace("'", "''"));
                    string valTable = (dgvXml.Rows[i].Cells["valtable"].Value == null ? "" : dgvXml.Rows[i].Cells["valtable"].Value.ToString().Trim().Replace("'", "''"));
                    string tableName = (dgvXml.Rows[i].Cells["tablename"].Value == null ? "" : dgvXml.Rows[i].Cells["tablename"].Value.ToString().Trim().Replace("'", "''"));
                    string isDate = (dgvXml.Rows[i].Cells["isdate"].Value == null ? "0" : dgvXml.Rows[i].Cells["isdate"].Value.ToString().Trim().Replace("'", "''"));
                    string dateFormat = (dgvXml.Rows[i].Cells["dateformat"].Value == null ? "" : dgvXml.Rows[i].Cells["dateformat"].Value.ToString().Trim().Replace("'", "''"));
                    string Sort = (dgvXml.Rows[i].Cells["titlesort"].Value == null ? "0" : dgvXml.Rows[i].Cells["titlesort"].Value.ToString().Trim().Replace("'", "''"));
                    string datadatilbydll = (dgvXml.Rows[i].Cells["datadatilbydll"].Value == null ? "0" : dgvXml.Rows[i].Cells["datadatilbydll"].Value.ToString().Trim().Replace("'", "''"));
                    string injson = (dgvXml.Rows[i].Cells["inJson"].Value == null ? "0" : dgvXml.Rows[i].Cells["inJson"].Value.ToString().Trim().Replace("'", "''"));
                    string sortitle = (dgvXml.Rows[i].Cells["sortitle"].Value == null ? "" : dgvXml.Rows[i].Cells["sortitle"].Value.ToString().Trim().Replace("'", "''"));
                    string canempty = (dgvXml.Rows[i].Cells["canEmpty"].Value == null ? "0" : dgvXml.Rows[i].Cells["canEmpty"].Value.ToString().Trim().Replace("'", "''"));

                    if (string.IsNullOrEmpty(xmlTitle))
                    {
                        throw new Exception("标签名称不能为空,第<" + (i + 1).ToString() + ">行数据");
                    }

                    StringBuilder sb = new StringBuilder();

                    sb.Append("insert into hawi_xmlform(subname,chiname,paraname,xmltitle,sortitle,paratype,xmltitlelv,partitle,xmlstaticval,");
                    sb.Append("titleisloop,valtitle,getvaluesql,looptable,valtable,tablename,isdate,dateformat,datadatilbydll,injson,canempty,titlesort)");
                    sb.Append(" values('");
                    sb.Append(subName);
                    sb.Append("','");
                    sb.Append(chiName);
                    sb.Append("','");
                    sb.Append(paraName);
                    sb.Append("','");
                    sb.Append(xmlTitle);
                    sb.Append("','");
                    sb.Append(sortitle);
                    sb.Append("','");
                    sb.Append(paraType);
                    sb.Append("','");
                    sb.Append(xmlTitleLv);
                    sb.Append("','");
                    sb.Append(parTitle);
                    sb.Append("','");
                    sb.Append(xmlstaticval);
                    sb.Append("','");
                    sb.Append(isLoop);
                    sb.Append("','");
                    sb.Append(valTitle);
                    sb.Append("','");
                    sb.Append(valSql);
                    sb.Append("','");
                    sb.Append(loopTable);
                    sb.Append("','");
                    sb.Append(valTable);
                    sb.Append("','");
                    sb.Append(tableName);
                    sb.Append("','");
                    sb.Append(isDate);
                    sb.Append("','");
                    sb.Append(dateFormat);
                    sb.Append("','");
                    sb.Append(datadatilbydll);
                    sb.Append("','");
                    sb.Append(injson);
                    sb.Append("','");
                    sb.Append(canempty);
                    sb.Append("',");
                    sb.Append(Sort);
                    sb.Append(")");

                    listSql.Add(sb.ToString());
                }

                return listSql;
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        private List<string> SaveReSet()
        {
            try
            {
                gbMain.Focus();

                List<string> listSql = new List<string>();

                string subName = gbMain.Tag.ToString().Trim();
                string chiName = gbMain.Text.ToString().Trim();

                if (string.IsNullOrEmpty(subName))
                {
                    throw new Exception("函数名称不能为空");
                }

                if (string.IsNullOrEmpty(chiName))
                {
                    throw new Exception("接口名称不能为空");
                }

                listSql.Add("delete from hawi_reset where subname='" + subName + "' and chiname='" + chiName + "'");

                for (int i = 0; i < dgvReset.Rows.Count; i++)
                {

                    string sqlname = (dgvReset.Rows[i].Cells["sqlname"].Value == null ? "" : dgvReset.Rows[i].Cells["sqlname"].Value.ToString().Trim().Replace("'", "''"));
                    string sort = (dgvReset.Rows[i].Cells["resort"].Value == null ? "0" : dgvReset.Rows[i].Cells["resort"].Value.ToString().Trim().Replace("'", "''"));
                    string isloop = (dgvReset.Rows[i].Cells["isloop"].Value == null ? "0" : dgvReset.Rows[i].Cells["isloop"].Value.ToString().Trim().Replace("'", "''"));
                    string loopwith = (dgvReset.Rows[i].Cells["loopwith"].Value == null ? "" : dgvReset.Rows[i].Cells["loopwith"].Value.ToString().Trim().Replace("'", "''"));
                    string runtype = (dgvReset.Rows[i].Cells["runtype"].Value == null ? "" : dgvReset.Rows[i].Cells["runtype"].Value.ToString().Trim().Replace("'", "''"));
                    string ifhave = (dgvReset.Rows[i].Cells["ifhave"].Value == null ? "0" : dgvReset.Rows[i].Cells["ifhave"].Value.ToString().Trim().Replace("'", "''"));
                    string reorupdate = (dgvReset.Rows[i].Cells["reorupdate"].Value == null ? "" : dgvReset.Rows[i].Cells["reorupdate"].Value.ToString().Trim().Replace("'", "''"));
                    string tablename = (dgvReset.Rows[i].Cells["dbtablename"].Value == null ? "" : dgvReset.Rows[i].Cells["dbtablename"].Value.ToString().Trim().Replace("'", "''"));
                    string fathersql = (dgvReset.Rows[i].Cells["fathersql"].Value == null ? "" : dgvReset.Rows[i].Cells["fathersql"].Value.ToString().Trim().Replace("'", "''"));
                    string looppoit = (dgvReset.Rows[i].Cells["looppoit"].Value == null ? "" : dgvReset.Rows[i].Cells["looppoit"].Value.ToString().Trim().Replace("'", "''"));
                    string isDesc = (dgvReset.Rows[i].Cells["isDesc"].Value == null ? "0" : dgvReset.Rows[i].Cells["isDesc"].Value.ToString().Trim().Replace("'", "''"));

                    if (string.IsNullOrEmpty(sqlname))
                    {
                        throw new Exception("别名不能为空,第<" + (i + 1).ToString() + ">行数据");
                    }

                    if (string.IsNullOrEmpty(sort))
                    {
                        throw new Exception("排序不能为空,第<" + (i + 1).ToString() + ">行数据");
                    }
                    else
                    {
                        try
                        {
                            Convert.ToInt32(sort);
                        }
                        catch
                        {
                            throw new Exception("排序请输入数值,第<" + (i + 1).ToString() + ">行数据");
                        }
                    }

                    string strSql = string.Format("");

                    StringBuilder sb = new StringBuilder();

                    sb.Append("insert into hawi_reset(subname,chiname,sqlname,sort,isloop,loopwith,runtype,ifhave,reorupdate,tablename,fathersql,isDesc,looppoit)");
                    sb.Append(" values('");
                    sb.Append(subName);
                    sb.Append("','");
                    sb.Append(chiName);
                    sb.Append("','");
                    sb.Append(sqlname);
                    sb.Append("',");
                    sb.Append(sort);
                    sb.Append(",'");
                    sb.Append(isloop);
                    sb.Append("','");
                    sb.Append(loopwith);
                    sb.Append("','");
                    sb.Append(runtype);
                    sb.Append("','");
                    sb.Append(ifhave);
                    sb.Append("','");
                    sb.Append(reorupdate);
                    sb.Append("','");
                    sb.Append(tablename);
                    sb.Append("','");
                    sb.Append(fathersql);
                    sb.Append("','");
                    sb.Append(isDesc);
                    sb.Append("','");
                    sb.Append(looppoit);
                    sb.Append("')");

                    listSql.Add(sb.ToString());
                }

                return listSql;
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        private List<string> SaveReTableSet()
        {
            try
            {
                gbMain.Focus();

                List<string> listSql = new List<string>();

                string subName = gbMain.Tag.ToString().Trim();
                string strSqlName = gbReTableSet.Text.ToString().Trim();
                string chiName = gbMain.Text.ToString().Trim();

                if (string.IsNullOrEmpty(subName))
                {
                    throw new Exception("函数名称不能为空");
                }

                if (string.IsNullOrEmpty(chiName))
                {
                    throw new Exception("接口名称不能为空");
                }

                listSql.Add("delete from hawi_retableset where subname='" + subName + "' and chiname='" + chiName + "' and sqlname='" + strSqlName + "'");

                for (int i = 0; i < dgvReTableSet.Rows.Count; i++)
                {
                    string colname = (dgvReTableSet.Rows[i].Cells["colname"].Value == null ? "" : dgvReTableSet.Rows[i].Cells["colname"].Value.ToString().Trim().Replace("'", "''"));
                    string iskey = (dgvReTableSet.Rows[i].Cells["iskey"].Value == null ? "0" : dgvReTableSet.Rows[i].Cells["iskey"].Value.ToString().Trim().Replace("'", "''"));
                    string databy = (dgvReTableSet.Rows[i].Cells["databy"].Value == null ? "接收数据" : dgvReTableSet.Rows[i].Cells["databy"].Value.ToString().Trim().Replace("'", "''"));
                    string valuefrom = (dgvReTableSet.Rows[i].Cells["valuefrom"].Value == null ? "" : dgvReTableSet.Rows[i].Cells["valuefrom"].Value.ToString().Trim().Replace("'", "''"));
                    string staticvalue = (dgvReTableSet.Rows[i].Cells["staticvalue"].Value == null ? "" : dgvReTableSet.Rows[i].Cells["staticvalue"].Value.ToString().Trim().Replace("'", "''"));
                    string colsort = (dgvReTableSet.Rows[i].Cells["colsort"].Value == null ? "0" : dgvReTableSet.Rows[i].Cells["colsort"].Value.ToString().Trim().Replace("'", "''"));
                    string isDate = (dgvReTableSet.Rows[i].Cells["RtisDate"].Value == null ? "字符" : dgvReTableSet.Rows[i].Cells["RtisDate"].Value.ToString().Trim().Replace("'", "''"));
                    string dateType = (dgvReTableSet.Rows[i].Cells["dateType"].Value == null ? "" : dgvReTableSet.Rows[i].Cells["dateType"].Value.ToString().Trim().Replace("'", "''"));
                    string canUpdate = (dgvReTableSet.Rows[i].Cells["canupdate"].Value == null ? "0" : dgvReTableSet.Rows[i].Cells["canupdate"].Value.ToString().Trim().Replace("'", "''"));

                    if (string.IsNullOrEmpty(colname))
                    {
                        throw new Exception("字段名不能为空,第<" + (i + 1).ToString() + ">行数据");
                    }

                    if (string.IsNullOrEmpty(colsort))
                    {
                        throw new Exception("排序不能为空,第<" + (i + 1).ToString() + ">行数据");
                    }
                    else
                    {
                        try
                        {
                            Convert.ToInt32(colsort);
                        }
                        catch
                        {
                            throw new Exception("排序请输入数值,第<" + (i + 1).ToString() + ">行数据");
                        }
                    }

                    string strSql = string.Format("");

                    StringBuilder sb = new StringBuilder();

                    sb.Append("insert into hawi_retableset(subname,chiname,sqlname,colname,iskey,canupdate,databy,valuefrom,staticvalue,isDate,dateType,colsort)");
                    sb.Append(" values('");
                    sb.Append(subName);
                    sb.Append("','");
                    sb.Append(chiName);
                    sb.Append("','");
                    sb.Append(strSqlName);
                    sb.Append("','");
                    sb.Append(colname);
                    sb.Append("','");
                    sb.Append(iskey);
                    sb.Append("','");
                    sb.Append(canUpdate);
                    sb.Append("','");
                    sb.Append(databy);
                    sb.Append("','");
                    sb.Append(valuefrom);
                    sb.Append("','");
                    sb.Append(staticvalue);
                    sb.Append("','");
                    sb.Append(isDate);
                    sb.Append("','");
                    sb.Append(dateType);
                    sb.Append("',");
                    sb.Append(colsort);
                    sb.Append(")");

                    listSql.Add(sb.ToString());
                }

                return listSql;
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        private void tsmCancel_Click(object sender, EventArgs e)
        {
            DialogResult dResult = MessageBox.Show("确定取消修改？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (dResult == System.Windows.Forms.DialogResult.Yes)
            {
                if (scFirst.Panel1Collapsed)
                {
                    if (scSecond.Panel1Collapsed)
                    {
                        BindDgvXml();

                        gbMain.Focus();
                    }
                    else
                    {
                        BindDgvPara();

                        gbMain.Focus();
                    }
                }
                else
                {
                    if (scThird.Panel1Collapsed)
                    {
                        if (scFourth.Panel1Collapsed)
                        {
                            BindDgvReTableSet();

                            gbMain.Focus();
                        }
                        else
                        {
                            BindDgvReset();

                            gbMain.Focus();
                        }
                    }
                    else
                    {
                        BindDgvSubList();

                        gbMain.Focus();
                    }

                }
            }
        }

        private void BindDgvSubList()
        {
            try
            {
                DAOAccess da = new DAOAccess();

                DataSet ds = da.GetInterfaceSub();

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvSubList.Rows.Clear();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgvSubList.Rows.Add(1);

                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["chiname"].Value = ds.Tables[0].Rows[i]["chiname"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["subname"].Value = ds.Tables[0].Rows[i]["subname"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["classname"].Value = ds.Tables[0].Rows[i]["classname"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["webaddres"].Value = ds.Tables[0].Rows[i]["webaddres"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["basesql"].Value = ds.Tables[0].Rows[i]["basesql"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["btablename"].Value = ds.Tables[0].Rows[i]["btablename"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["inparanum"].Value = ds.Tables[0].Rows[i]["inparanum"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["isused"].Value = ds.Tables[0].Rows[i]["isused"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["sort"].Value = ds.Tables[0].Rows[i]["sort"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["chkReSign"].Value = ds.Tables[0].Rows[i]["chkReSign"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["reTrueValue"].Value = ds.Tables[0].Rows[i]["reTrueValue"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["reSignNode"].Value = ds.Tables[0].Rows[i]["reSignNode"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["reErrorNode"].Value = ds.Tables[0].Rows[i]["reErrorNode"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["recdatadatil"].Value = ds.Tables[0].Rows[i]["recdatadatil"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["subtype"].Value = ds.Tables[0].Rows[i]["subtype"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["jsonadd"].Value = ds.Tables[0].Rows[i]["jsonadd"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["encodtype"].Value = ds.Tables[0].Rows[i]["encodtype"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["contenttype"].Value = ds.Tables[0].Rows[i]["contenttype"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["expdll"].Value = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["expdll"].ToString()) ? "0" : ds.Tables[0].Rows[i]["expdll"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["reobject"].Value = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["reobject"].ToString()) ? "0" : ds.Tables[0].Rows[i]["reobject"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["autorun"].Value = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["autorun"].ToString()) ? "0" : ds.Tables[0].Rows[i]["autorun"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["loopself"].Value = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["loopbyself"].ToString()) ? "0" : ds.Tables[0].Rows[i]["loopbyself"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["followif"].Value = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["followif"].ToString()) ? "" : ds.Tables[0].Rows[i]["followif"].ToString().Trim();
                        dgvSubList.Rows[dgvSubList.Rows.Count - 1].Cells["preInter"].Value = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["preInter"].ToString()) ? "" : ds.Tables[0].Rows[i]["preInter"].ToString().Trim();

                        dgvSubList.Rows[0].Selected = false;
                    }

                    gbMain.Text = "";
                    gbMain.Tag = "";
                }
            }
            catch (UserException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindDgvPara()
        {
            try
            {
                string subName = gbMain.Tag.ToString().Trim();
                string chiName = gbMain.Text.ToString().Trim();

                DAOAccess da = new DAOAccess();

                DataSet ds = da.GetSubPara(subName, chiName);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvPara.Rows.Clear();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgvPara.Rows.Add(1);

                        dgvPara.Rows[dgvPara.Rows.Count - 1].Cells["paraname"].Value = ds.Tables[0].Rows[i]["paraname"].ToString().Trim();
                        dgvPara.Rows[dgvPara.Rows.Count - 1].Cells["isxml"].Value = ds.Tables[0].Rows[i]["isxml"].ToString().Trim();
                        dgvPara.Rows[dgvPara.Rows.Count - 1].Cells["parastaticval"].Value = ds.Tables[0].Rows[i]["parastaticval"].ToString().Trim();
                        dgvPara.Rows[dgvPara.Rows.Count - 1].Cells["getvalsql"].Value = ds.Tables[0].Rows[i]["getvalsql"].ToString().Trim();
                        dgvPara.Rows[dgvPara.Rows.Count - 1].Cells["valtitle"].Value = ds.Tables[0].Rows[i]["valtitle"].ToString().Trim();
                        dgvPara.Rows[dgvPara.Rows.Count - 1].Cells["valbybase"].Value = ds.Tables[0].Rows[i]["valbybase"].ToString().Trim();
                        dgvPara.Rows[dgvPara.Rows.Count - 1].Cells["parasort"].Value = ds.Tables[0].Rows[i]["parasort"].ToString().Trim();
                        dgvPara.Rows[dgvPara.Rows.Count - 1].Cells["datadlldetail"].Value = ds.Tables[0].Rows[i]["datadlldetail"].ToString().Trim();
                        dgvPara.Rows[dgvPara.Rows.Count - 1].Cells["isjson"].Value = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["isjson"].ToString()) ? "0" : ds.Tables[0].Rows[i]["isjson"].ToString().Trim();
                        dgvPara.Rows[dgvPara.Rows.Count - 1].Cells["patype"].Value = ds.Tables[0].Rows[i]["patype"].ToString().Trim();
                        dgvPara.Rows[dgvPara.Rows.Count - 1].Cells["datatype"].Value = ds.Tables[0].Rows[i]["datatype"].ToString().Trim();
                        dgvPara.Rows[dgvPara.Rows.Count - 1].Cells["withxml"].Value = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["withxml"].ToString()) ? "0" : ds.Tables[0].Rows[i]["withxml"].ToString().Trim();

                        dgvPara.Rows[0].Selected = false;

                        gbSubList.Tag = "";
                        gbXml.Text = "";
                    }
                }
            }
            catch (UserException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindDgvXml()
        {
            try
            {
                string subName = gbMain.Tag.ToString().Trim();
                string paraName = gbXml.Text.ToString().Trim();
                string chiName = gbMain.Text.ToString().Trim();

                DAOAccess da = new DAOAccess();

                DataSet ds = da.GetXmlSet(subName, chiName, paraName);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvXml.Rows.Clear();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgvXml.Rows.Add(1);

                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["xmltitle"].Value = ds.Tables[0].Rows[i]["xmltitle"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["paratype"].Value = ds.Tables[0].Rows[i]["paratype"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["xmltitlelv"].Value = ds.Tables[0].Rows[i]["xmltitlelv"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["partitle"].Value = ds.Tables[0].Rows[i]["partitle"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["titleisloop"].Value = ds.Tables[0].Rows[i]["titleisloop"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["xmlvaltitle"].Value = ds.Tables[0].Rows[i]["valtitle"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["getvaluesql"].Value = ds.Tables[0].Rows[i]["getvaluesql"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["looptable"].Value = ds.Tables[0].Rows[i]["looptable"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["titlesort"].Value = ds.Tables[0].Rows[i]["titlesort"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["valtable"].Value = ds.Tables[0].Rows[i]["valtable"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["tablename"].Value = ds.Tables[0].Rows[i]["tablename"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["isdate"].Value = ds.Tables[0].Rows[i]["isdate"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["dateformat"].Value = ds.Tables[0].Rows[i]["dateformat"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["xmlstaticval"].Value = ds.Tables[0].Rows[i]["xmlstaticval"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["datadatilbydll"].Value = ds.Tables[0].Rows[i]["datadatilbydll"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["inJson"].Value = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["injson"].ToString()) ? "0" : ds.Tables[0].Rows[i]["injson"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["canEmpty"].Value = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["canempty"].ToString()) ? "0" : ds.Tables[0].Rows[i]["canempty"].ToString().Trim();
                        dgvXml.Rows[dgvXml.Rows.Count - 1].Cells["sortitle"].Value = ds.Tables[0].Rows[i]["sortitle"].ToString().Trim();

                        dgvXml.Rows[0].Selected = false;

                    }
                }
            }
            catch (UserException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindDgvReset()
        {
            try
            {
                string subName = gbMain.Tag.ToString().Trim();
                string chiName = gbMain.Text.ToString().Trim();

                DAOAccess da = new DAOAccess();

                DataSet ds = da.GetReset(subName, chiName);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvReset.Rows.Clear();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgvReset.Rows.Add(1);

                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["sqlname"].Value = ds.Tables[0].Rows[i]["sqlname"].ToString().Trim();
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["loopwith"].Value = ds.Tables[0].Rows[i]["loopwith"].ToString().Trim();
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["runtype"].Value = ds.Tables[0].Rows[i]["runtype"].ToString().Trim();
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["ifhave"].Value = ds.Tables[0].Rows[i]["ifhave"].ToString().Trim();
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["reorupdate"].Value = ds.Tables[0].Rows[i]["reorupdate"].ToString().Trim();
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["fathersql"].Value = ds.Tables[0].Rows[i]["fathersql"].ToString().Trim();
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["dbtablename"].Value = ds.Tables[0].Rows[i]["tablename"].ToString().Trim();
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["isloop"].Value = ds.Tables[0].Rows[i]["isloop"].ToString().Trim();
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["looppoit"].Value = ds.Tables[0].Rows[i]["looppoit"].ToString().Trim();
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["resort"].Value = ds.Tables[0].Rows[i]["sort"].ToString().Trim();
                        dgvReset.Rows[dgvReset.Rows.Count - 1].Cells["isDesc"].Value = ds.Tables[0].Rows[i]["isDesc"].ToString().Trim();

                        dgvReset.Rows[0].Selected = false;

                        //gbSubList.Tag = "";
                        //gbXml.Text = "";
                    }
                }
            }
            catch (UserException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindDgvReTableSet()
        {
            try
            {
                string subName = gbMain.Tag.ToString().Trim();
                string chiName = gbMain.Text.ToString().Trim();

                string strSqlName = gbReTableSet.Text.ToString().Trim();

                DAOAccess da = new DAOAccess();

                DataSet ds = da.GetReTableSet(subName, chiName, strSqlName);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvReTableSet.Rows.Clear();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgvReTableSet.Rows.Add(1);

                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["colname"].Value = ds.Tables[0].Rows[i]["colname"].ToString().Trim();
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["iskey"].Value = ds.Tables[0].Rows[i]["iskey"].ToString().Trim();
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["databy"].Value = ds.Tables[0].Rows[i]["databy"].ToString().Trim();
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["valuefrom"].Value = ds.Tables[0].Rows[i]["valuefrom"].ToString().Trim();
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["staticvalue"].Value = ds.Tables[0].Rows[i]["staticvalue"].ToString().Trim();
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["RtisDate"].Value = ds.Tables[0].Rows[i]["isDate"].ToString().Trim();
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["dateType"].Value = ds.Tables[0].Rows[i]["dateType"].ToString().Trim();
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["colsort"].Value = ds.Tables[0].Rows[i]["colsort"].ToString().Trim();
                        dgvReTableSet.Rows[dgvReTableSet.Rows.Count - 1].Cells["canupdate"].Value = (string.IsNullOrEmpty(ds.Tables[0].Rows[i]["canupdate"].ToString()) ? "0" : ds.Tables[0].Rows[i]["canupdate"].ToString().Trim());

                        dgvReTableSet.Rows[0].Selected = false;

                    }
                }
            }
            catch (UserException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmEditXml_Click(object sender, EventArgs e)
        {
            if (dgvPara.SelectedRows.Count > 0)
            {
                if (dgvPara.SelectedRows[0].Cells[1].Value != null && dgvPara.SelectedRows[0].Cells[1].Value.ToString() == "1")
                {
                    tsmPara.Visible = false;
                    tsmBackSubList.Visible = false;
                    tsmEditXml.Visible = false;
                    tsmBackPara.Visible = true;
                    tsmDllSet.Visible = true;

                    scFirst.Panel1Collapsed = true;
                    scFirst.Panel2Collapsed = false;

                    scSecond.Panel1Collapsed = true;
                    scSecond.Panel2Collapsed = false;

                    BindDgvXml();
                }
                else
                {
                    MessageBox.Show("只有XML参数可以进行XML结构编辑");
                }
            }
            else
            {
                MessageBox.Show("请选择一个参数后进行编辑");
            }
        }

        private void tsmBackPara_Click(object sender, EventArgs e)
        {
            tsmPara.Visible = false;
            tsmBackSubList.Visible = true;
            tsmEditXml.Visible = true;
            tsmBackPara.Visible = false;
            tsmDllSet.Visible = true;

            scFirst.Panel1Collapsed = true;
            scFirst.Panel2Collapsed = false;

            scSecond.Panel1Collapsed = false;
            scSecond.Panel2Collapsed = true;
        }

        private void tsmBackSubList_Click(object sender, EventArgs e)
        {
            if (bCustom)
            {
                tsbAdd.Visible = false;
                tsbDele.Visible = false;
                tssOne.Visible = false;
            }
            else
            {
                tsbCopyReW.Visible = true;
            }

            tsmLoopSelf.Visible = true;
            tsmPara.Visible = true;
            tsmBackSubList.Visible = false;
            tsmEditXml.Visible = false;
            tsmBackPara.Visible = false;
            tsmReSet.Visible = true;
            tsmReTableSet.Visible = false;
            tsmDllSet.Visible = true;
            tsmRecJud.Visible = true;

            tsmAllNo.Visible = true;
            tsmAllOK.Visible = true;

            scFirst.Panel1Collapsed = false;
            scFirst.Panel2Collapsed = true;

            scSecond.Panel1Collapsed = false;
            scSecond.Panel2Collapsed = true;

            scThird.Panel2Collapsed = true;
            scThird.Panel1Collapsed = false;
        }

        private void dgvPara_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int iSelect = e.RowIndex;

                string paraNmae = "";

                if (dgvPara.Rows[iSelect].Cells["paraname"].Value != null)
                {
                    paraNmae = dgvPara.Rows[iSelect].Cells["paraname"].Value.ToString().Trim();
                }

                gbXml.Text = paraNmae;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbDele_Click(object sender, EventArgs e)
        {
            DialogResult dResult = MessageBox.Show("确定删除选中行？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (dResult == System.Windows.Forms.DialogResult.Yes)
            {
                if (scFirst.Panel1Collapsed)
                {
                    if (scSecond.Panel1Collapsed)
                    {
                        if (dgvXml.SelectedRows.Count > 0)
                        {
                            dgvXml.Rows.Remove(dgvXml.SelectedRows[0]);
                        }
                    }
                    else
                    {
                        if (dgvPara.SelectedRows.Count > 0)
                        {
                            dgvPara.Rows.Remove(dgvPara.SelectedRows[0]);
                        }
                    }
                }
                else
                {
                    if (scThird.Panel1Collapsed)
                    {
                        if (scFourth.Panel1Collapsed)
                        {
                            if (dgvReTableSet.SelectedRows.Count > 0)
                            {
                                dgvReTableSet.Rows.Remove(dgvReTableSet.SelectedRows[0]);
                            }
                        }
                        else
                        {
                            if (dgvReset.SelectedRows.Count > 0)
                            {
                                dgvReset.Rows.Remove(dgvReset.SelectedRows[0]);
                            }
                        }
                    }
                    else
                    {
                        if (dgvSubList.SelectedRows.Count > 0)
                        {
                            dgvSubList.Rows.Remove(dgvSubList.SelectedRows[0]);
                        }
                    }
                }
            }
        }

        private void tsmBackReSet_Click(object sender, EventArgs e)
        {
            tsmReTableSet.Visible = true;
            tsmBackReSet.Visible = false;
            tsmBackSubList.Visible = true;
            tsmDllSet.Visible = false;

            scFourth.Panel1Collapsed = false;
            scFourth.Panel2Collapsed = true;
        }

        private void tsmReSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSubList.SelectedRows.Count > 0 && gbMain.Text.ToString().Trim().Length > 1)
                {
                    tsbAdd.Visible = true;
                    tsbDele.Visible = true;
                    tssOne.Visible = true;

                    tsmPara.Visible = false;
                    tsmBackSubList.Visible = true;
                    tsmEditXml.Visible = false;
                    tsmBackPara.Visible = false;
                    tsmReSet.Visible = false;
                    tsmBackReSet.Visible = false;
                    tsmReTableSet.Visible = true;
                    tsmDllSet.Visible = false;
                    tsmRecJud.Visible = false;
                    tsbCopyReW.Visible = false;

                    tsmAllNo.Visible = false;
                    tsmAllOK.Visible = false;

                    tsmLoopSelf.Visible = false;

                    scThird.Panel1Collapsed = true;
                    scThird.Panel2Collapsed = false;

                    scFourth.Panel1Collapsed = false;
                    scFourth.Panel2Collapsed = true;
                    //scFirst.Panel1Collapsed = true;
                    //scFirst.Panel2Collapsed = false;


                    //scSecond.Panel1Collapsed = false;
                    //scSecond.Panel2Collapsed = true;

                    //BindDgvPara();
                    BindDgvReset();
                }
                else
                {
                    MessageBox.Show("请选择一个函数后进行参数查看/编辑");
                }
            }
            catch (UserException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmReTableSet_Click(object sender, EventArgs e)
        {
            if (dgvReset.SelectedRows.Count > 0)
            {
                scFourth.Panel1Collapsed = true;
                scFourth.Panel2Collapsed = false;

                tsmReTableSet.Visible = false;
                tsmBackReSet.Visible = true;
                tsmBackSubList.Visible = false;
                tsmDllSet.Visible = false;

                gbReTableSet.Text = dgvReset.SelectedRows[0].Cells["sqlname"].Value.ToString();

                BindDgvReTableSet();

            }
            else
            {
                MessageBox.Show("请选择一个回写设置查看/编辑");
            }

        }

        private void tsmDllSet_Click(object sender, EventArgs e)
        {
            if (scFirst.Panel1Collapsed)
            {
                if (scSecond.Panel1Collapsed)
                {
                    if (dgvXml.SelectedRows.Count > 0)
                    {
                        string subName = gbMain.Tag.ToString().Trim();
                        string chiName = gbMain.Text.ToString().Trim();
                        string paraName = gbXml.Text.ToString().Trim();

                        string title = (dgvXml.SelectedRows[0].Cells["xmltitle"].Value == null ? "" : dgvXml.SelectedRows[0].Cells["xmltitle"].Value.ToString().Trim());
                        string partitle = (dgvXml.SelectedRows[0].Cells["partitle"].Value == null ? "" : dgvXml.SelectedRows[0].Cells["partitle"].Value.ToString().Trim());

                        if (string.IsNullOrEmpty(title))
                        {
                            MessageBox.Show("请填写标签名称并保存后再进行设置!");

                            return;
                        }

                        frmDllSet frm = new frmDllSet();

                        frm.subName = subName;
                        frm.chiName = chiName;
                        frm.paraName = paraName;
                        frm.xmlTitle = title;
                        frm.xmlParTitle = partitle;

                        frm.ShowDialog();
                    }
                }
                else
                {
                    if (dgvPara.SelectedRows.Count > 0)
                    {
                        string subName = gbMain.Tag.ToString().Trim();
                        string chiName = gbMain.Text.ToString().Trim();
                        string paraName = dgvPara.SelectedRows[0].Cells["paraname"].Value.ToString().Trim();

                        frmDllSet frm = new frmDllSet();

                        frm.subName = subName;
                        frm.chiName = chiName;
                        frm.paraName = paraName;

                        frm.ShowDialog();
                    }
                }
            }
            else
            {
                if (scThird.Panel1Collapsed)
                {
                }
                else
                {
                    if (dgvSubList.SelectedRows.Count > 0)
                    {
                        string subName = dgvSubList.SelectedRows[0].Cells["subname"].Value.ToString().Trim();
                        string chiName = dgvSubList.SelectedRows[0].Cells["chiname"].Value.ToString().Trim();
                        string paraName = "WEBRECEIVE";

                        frmDllSet frm = new frmDllSet();

                        frm.subName = subName;
                        frm.chiName = chiName;
                        frm.paraName = paraName;

                        frm.ShowDialog();
                    }
                }
            }
        }

        private void dgvReset_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvReset.Columns[e.ColumnIndex].GetType().Name == "DataGridViewTextBoxColumn")
            {
                string strCellValue = "";

                if (dgvReset.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    strCellValue = dgvReset.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                frmEdit fEdit = new frmEdit();

                fEdit.strValue = strCellValue;

                DialogResult dResult = fEdit.ShowDialog();

                if (dResult == System.Windows.Forms.DialogResult.OK)
                {
                    strCellValue = fEdit.strValue;

                    dgvReset.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = strCellValue;

                    gbMain.Focus();
                }
            }
        }

        private void dgvReTableSet_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvReTableSet.Columns[e.ColumnIndex].GetType().Name == "DataGridViewTextBoxColumn")
            {
                string strCellValue = "";

                if (dgvReTableSet.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    strCellValue = dgvReTableSet.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                frmEdit fEdit = new frmEdit();

                fEdit.strValue = strCellValue;

                DialogResult dResult = fEdit.ShowDialog();

                if (dResult == System.Windows.Forms.DialogResult.OK)
                {
                    strCellValue = fEdit.strValue;

                    dgvReTableSet.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = strCellValue;

                    gbMain.Focus();
                }
            }
        }

        private void tsmRecJud_Click(object sender, EventArgs e)
        {
            if (dgvSubList.SelectedRows.Count > 0)
            {
                string subName = dgvSubList.SelectedRows[0].Cells["subname"].Value.ToString().Trim();
                string chiName = dgvSubList.SelectedRows[0].Cells["chiname"].Value.ToString().Trim();

                frmJudRec frm = new frmJudRec();

                frm.subName = subName;
                frm.chiName = chiName;
                frm.strType = "sub";

                frm.ShowDialog();
            }
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSubList.SelectedRows.Count > 0)
                {
                    string strSubName = dgvSubList.SelectedRows[0].Cells["subname"].Value.ToString().Trim();
                    string strChiName = dgvSubList.SelectedRows[0].Cells["chiname"].Value.ToString().Trim();

                    DialogResult dResult = MessageBox.Show("确定将>>" + strChiName + "<<复制为一个新的接口？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                    if (dResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmNewSub frm = new frmNewSub();

                        dResult = frm.ShowDialog();

                        if (dResult == System.Windows.Forms.DialogResult.OK)
                        {
                            string strNewName = frm.strNewName;

                            List<string> listSql = new List<string>();

                            DAOAccess da = new DAOAccess();
                            //复制接口
                            string strSql = "";

                            strSql = "select max(sort) from hawi_sublist";

                            DataSet ds = da.GetDataSet(strSql);

                            int iSort = 10;

                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                iSort = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                                if (iSort > 10)
                                {
                                    iSort = (iSort / 10 + 1) * 10;
                                }
                            }

                            strSql = "insert into hawi_sublist(subname,chiname,classname,inparanum,webaddres,rewsql,isused,basesql,btablename,chkReSign,reTrueValue,reSignNode,reErrorNode,recdatadatil,subtype,encodtype,contenttype,jsonadd,reobject,expdll,autorun,followif,preInter,loopbyself,sort)";
                            strSql = strSql + " select subname,'" + strNewName + "',classname,inparanum,webaddres,rewsql,isused,basesql,btablename,chkReSign,reTrueValue,reSignNode,reErrorNode,recdatadatil,subtype,encodtype,contenttype,jsonadd,reobject,expdll,autorun,followif,preInter,loopbyself," + iSort.ToString();
                            strSql = strSql + " from hawi_sublist where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            listSql.Add(strSql);

                            //复制参数
                            strSql = "";
                            strSql = "insert into hawi_inpara(subname,chiname,paraname,isxml,getvalsql,valtitle,parastaticval,allorloop,valbybase,datadlldetail,parasort,isjson,patype,datatype)";
                            strSql = strSql + " select subname,'" + strNewName + "',paraname,isxml,getvalsql,valtitle,parastaticval,allorloop,valbybase,datadlldetail,parasort,isjson,patype,datatype";
                            strSql = strSql + " from hawi_inpara where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            listSql.Add(strSql);

                            //复制XML结构
                            strSql = "";
                            strSql = "insert into hawi_xmlform(subname,chiname,paraname,paratype,xmltitle,xmltitlelv,partitle,titleisloop,valtitle,titlesort,getvaluesql,looptable,tablename,valtable,isdate,dateformat,xmlstaticval,datadatilbydll,injson,canempty)";
                            strSql = strSql + " select subname,'" + strNewName + "',paraname,paratype,xmltitle,xmltitlelv,partitle,titleisloop,valtitle,titlesort,getvaluesql,looptable,tablename,valtable,isdate,dateformat,xmlstaticval,datadatilbydll,injson,canempty";
                            strSql = strSql + " from hawi_xmlform where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            listSql.Add(strSql);

                            //复制回写
                            strSql = "";
                            strSql = "insert into hawi_reset(subname,chiname,sqlname,sort,isloop,loopwith,runtype,ifhave,reorupdate,tablename,fathersql,looppoit,isdesc)";
                            strSql = strSql + " select subname,'" + strNewName + "',sqlname,sort,isloop,loopwith,runtype,ifhave,reorupdate,tablename,fathersql,looppoit,isdesc";
                            strSql = strSql + " from hawi_reset where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            listSql.Add(strSql);

                            //复制回写字段设置
                            strSql = "";
                            strSql = "insert into hawi_retableset(subname,chiname,sqlname,colname,iskey,databy,staticvalue,valuefrom,colsort,isdate,datetype,canupdate)";
                            strSql = strSql + " select subname,'" + strNewName + "',sqlname,colname,iskey,databy,staticvalue,valuefrom,colsort,isdate,datetype,canupdate";
                            strSql = strSql + " from hawi_retableset where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            listSql.Add(strSql);

                            //复制类库设置
                            strSql = "";
                            strSql = "insert into hawi_dllset(subname,chiname,paraname,dllname,dllnamespe,dllclassname,dllprocname,dllparanum,xmltitle,xmlpartitle)";
                            strSql = strSql + " select subname,'" + strNewName + "',paraname,dllname,dllnamespe,dllclassname,dllprocname,dllparanum,xmltitle,xmlpartitle";
                            strSql = strSql + " from hawi_dllset where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            listSql.Add(strSql);

                            //复制类库参数设置
                            strSql = "";
                            strSql = "insert into hawi_dllparaset(subname,chiname,paraname,dllparaname,dllparavalue,dllparasort,xmltitle,xmlpartitle)";
                            strSql = strSql + " select subname,'" + strNewName + "',paraname,dllparaname,dllparavalue,dllparasort,xmltitle,xmlpartitle";
                            strSql = strSql + " from hawi_dllparaset where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            listSql.Add(strSql);

                            //复制返回结果判断设置
                            strSql = "";
                            strSql = "insert into hawi_jud(subname,chiname,titname,condition,titvalues,linktype,sort,leftbra,rightbra,datatype,judtype)";
                            strSql = strSql + " select subname,'" + strNewName + "',titname,condition,titvalues,linktype,sort,leftbra,rightbra,datatype,judtype";
                            strSql = strSql + " from hawi_jud where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            listSql.Add(strSql);

                            if (da.RunSql(listSql))
                            {
                                MessageBox.Show("复制成功");

                                BindDgvSubList();

                                gbMain.Focus();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选中一个要复制的接口后再进行操作");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dResult = MessageBox.Show("确定要清理冗余数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (dResult == System.Windows.Forms.DialogResult.Yes)
                {
                    List<string> listSql = new List<string>();

                    string strSql = "";

                    strSql = "delete a from hawi_inpara a where not exists(select 1 from hawi_sublist b where a.subname=b.subname and a.chiname=b.chiname)";

                    listSql.Add(strSql);

                    strSql = "delete a from hawi_xmlform a where not exists(select 1 from hawi_sublist b where a.subname=b.subname and a.chiname=b.chiname)";

                    listSql.Add(strSql);

                    strSql = "delete a from hawi_reset a where not exists(select 1 from hawi_sublist b where a.subname=b.subname and a.chiname=b.chiname)";

                    listSql.Add(strSql);

                    strSql = "delete a from hawi_retableset a where not exists(select 1 from hawi_sublist b where a.subname=b.subname and a.chiname=b.chiname)";

                    listSql.Add(strSql);

                    strSql = "delete a from hawi_dllset a where not exists(select 1 from hawi_sublist b where a.subname=b.subname and a.chiname=b.chiname)";

                    listSql.Add(strSql);

                    strSql = "delete a from hawi_dllparaset a where not exists(select 1 from hawi_sublist b where a.subname=b.subname and a.chiname=b.chiname)";

                    listSql.Add(strSql);

                    strSql = "delete a from hawi_jud a where not exists(select 1 from hawi_sublist b where a.subname=b.subname and a.chiname=b.chiname)";

                    listSql.Add(strSql);

                    DAOAccess da = new DAOAccess();

                    if (da.RunSql(listSql))
                    {
                        MessageBox.Show("清理成功");

                        BindDgvSubList();

                        gbMain.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmAllOK_Click(object sender, EventArgs e)
        {
            if (dgvSubList.Rows.Count > 0)
            {
                for (int i = 0; i < dgvSubList.Rows.Count; i++)
                {
                    dgvSubList.Rows[i].Cells["isused"].Value = "1";
                }
            }
        }

        private void tsmAllNo_Click(object sender, EventArgs e)
        {
            if (dgvSubList.Rows.Count > 0)
            {
                for (int i = 0; i < dgvSubList.Rows.Count; i++)
                {
                    dgvSubList.Rows[i].Cells["isused"].Value = "0";
                }
            }
        }

        private void dgvXml_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void JudgeColumn()
        {
            try
            {
                DAOAccess da = new DAOAccess();

                List<string> listSql = new List<string>();
                listSql.Add("alter table hawi_sublist alter basesql text");
                da.RunSql(listSql);

                DataSet ds = da.GetDataSet("select * from hawi_sublist where 1=2");

                if (ds != null && ds.Tables.Count > 0)
                {
                    bool bHave = false;

                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        if (ds.Tables[0].Columns[i].ColumnName.ToString() == "autorun")
                        {
                            bHave = true;

                            break;
                        }
                    }

                    if (!bHave)
                    {
                        listSql = new List<string>();
                        listSql.Add("alter table hawi_sublist  add autorun char(10)");

                        listSql.Add("update hawi_sublist set autorun='0'");

                        da.RunSql(listSql);
                    }

                    bHave = false;
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        if (ds.Tables[0].Columns[i].ColumnName.ToString() == "loopbyself")
                        {
                            bHave = true;

                            break;
                        }
                    }

                    if (!bHave)
                    {
                        listSql = new List<string>();
                        listSql.Add("alter table hawi_sublist add loopbyself char(10)");

                        listSql.Add("update hawi_sublist set loopbyself='0'");

                        da.RunSql(listSql);
                    }

                    bHave = false;
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        if (ds.Tables[0].Columns[i].ColumnName.ToString() == "followif")
                        {
                            bHave = true;

                            break;
                        }
                    }

                    if (!bHave)
                    {
                        listSql = new List<string>();
                        listSql.Add("alter table hawi_sublist add followif char(255)");

                        listSql.Add("update hawi_sublist set followif=''");

                        da.RunSql(listSql);
                    }

                    bHave = false;
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        if (ds.Tables[0].Columns[i].ColumnName.ToString() == "preInter")
                        {
                            bHave = true;

                            break;
                        }
                    }

                    if (!bHave)
                    {
                        listSql = new List<string>();
                        listSql.Add("alter table hawi_sublist add preInter char(255)");

                        listSql.Add("update hawi_sublist set preInter=''");

                        da.RunSql(listSql);
                    }

                }

                DataSet dsJ = da.GetDataSet("select * from hawi_jud where 1=2");

                if (dsJ != null && dsJ.Tables.Count > 0)
                {
                    bool bHave = false;

                    for (int i = 0; i < dsJ.Tables[0].Columns.Count; i++)
                    {
                        if (dsJ.Tables[0].Columns[i].ColumnName.ToString() == "judtype")
                        {
                            bHave = true;

                            break;
                        }
                    }

                    if (!bHave)
                    {
                        listSql = new List<string>();
                        listSql.Add("alter table hawi_jud add judtype char(10)");

                        listSql.Add("update hawi_jud set judtype='sub'");

                        da.RunSql(listSql);
                    }
                }

                DataSet dsX = da.GetDataSet("select * from hawi_xmlform where 1=2");

                if (dsX != null && dsX.Tables.Count > 0)
                {
                    bool bHave = false;

                    for (int i = 0; i < dsX.Tables[0].Columns.Count; i++)
                    {
                        if (dsX.Tables[0].Columns[i].ColumnName.ToString() == "sortitle")
                        {
                            bHave = true;

                            break;
                        }
                    }

                    if (!bHave)
                    {
                        listSql = new List<string>();
                        listSql.Add("alter table hawi_xmlform add sortitle char(255)");

                        da.RunSql(listSql);
                    }

                    bHave = false;

                    for (int i = 0; i < dsX.Tables[0].Columns.Count; i++)
                    {
                        if (dsX.Tables[0].Columns[i].ColumnName.ToString() == "canempty")
                        {
                            bHave = true;

                            break;
                        }
                    }

                    if (!bHave)
                    {
                        listSql = new List<string>();
                        listSql.Add("alter table hawi_xmlform add canempty char(10)");

                        da.RunSql(listSql);
                    }
                }

                DataSet dsPara = da.GetDataSet("select * from hawi_inpara where 1=2");

                if (dsPara != null && dsPara.Tables.Count > 0)
                {
                    bool bHave = false;

                    for (int i = 0; i < dsPara.Tables[0].Columns.Count; i++)
                    {
                        if (dsPara.Tables[0].Columns[i].ColumnName.ToString() == "withxml")
                        {
                            bHave = true;

                            break;
                        }
                    }

                    if (!bHave)
                    {
                        listSql = new List<string>();
                        listSql.Add("alter table hawi_inpara add withxml int");

                        listSql.Add("update hawi_inpara set withxml=1");

                        da.RunSql(listSql);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void JudgeUp()
        {
            try
            {
                DAOAccess da = new DAOAccess();

                List<string> listSql = new List<string>();

                listSql.Add("update hawi_jud set titname='#H#'&titname&'#H#',titvalues=iif(datatype='字符','\"'&titvalues&'\"',titvalues)");

                da.RunSql(listSql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmLoopSelf_Click(object sender, EventArgs e)
        {
            if (dgvSubList.SelectedRows.Count > 0)
            {
                string subName = dgvSubList.SelectedRows[0].Cells["subname"].Value.ToString().Trim();
                string chiName = dgvSubList.SelectedRows[0].Cells["chiname"].Value.ToString().Trim();

                frmJudRec frm = new frmJudRec();

                frm.subName = subName;
                frm.chiName = chiName;
                frm.strType = "loop";

                frm.ShowDialog();
            }
        }

        private void tsbUp_Click(object sender, EventArgs e)
        {
            JudgeUp();
        }

        private void tsbCopyReW_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSubList.SelectedRows.Count > 0)
                {
                    string strSubName = dgvSubList.SelectedRows[0].Cells["subname"].Value.ToString().Trim();
                    string strChiName = dgvSubList.SelectedRows[0].Cells["chiname"].Value.ToString().Trim();

                    DialogResult dResult = MessageBox.Show("确定复制其它接口的回写设置？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                    if (dResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmNewSub frm = new frmNewSub();

                        frm.strTitle = "复制其它接口的回写设置";

                        frm.strLbl = "请输入接口中文名,函数名:";

                        dResult = frm.ShowDialog();

                        if (dResult == System.Windows.Forms.DialogResult.OK)
                        {
                            string strNewName = frm.strNewName;

                            string[] si = strNewName.Split(',');

                            List<string> listSql = new List<string>();

                            DAOAccess da = new DAOAccess();
                            //复制接口
                            string strSql = "";


                            //复制回写
                            strSql = "";
                            strSql = "insert into hawi_reset(subname,chiname,sqlname,sort,isloop,loopwith,runtype,ifhave,reorupdate,tablename,fathersql,looppoit,isdesc)";
                            strSql = strSql + " select '" + strSubName + "','" + strChiName + "',sqlname,sort,isloop,loopwith,runtype,ifhave,reorupdate,tablename,fathersql,looppoit,isdesc";
                            strSql = strSql + " from hawi_reset where subname='" + si[1] + "' and chiname='" + si[0] + "'";

                            listSql.Add(strSql);

                            //复制回写字段设置
                            strSql = "";
                            strSql = "insert into hawi_retableset(subname,chiname,sqlname,colname,iskey,databy,staticvalue,valuefrom,colsort,isdate,datetype,canupdate)";
                            strSql = strSql + " select '" + strSubName + "','" + strChiName + "',sqlname,colname,iskey,databy,staticvalue,valuefrom,colsort,isdate,datetype,canupdate";
                            strSql = strSql + " from hawi_retableset where subname='" + si[1] + "' and chiname='" + si[0] + "'";

                            listSql.Add(strSql);

                            if (da.RunSql(listSql))
                            {
                                MessageBox.Show("复制成功");

                                BindDgvSubList();

                                gbMain.Focus();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选中一个要复制的接口后再进行操作");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStrip1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (scFirst.Panel1Collapsed == false && scFirst.Panel2Collapsed == true && scSecond.Panel1Collapsed == false && scSecond.Panel2Collapsed == true && scThird.Panel2Collapsed == true && scThird.Panel1Collapsed == false)
            {
                if (e.Button == MouseButtons.Right)
                {
                    frmChangeType frm = new frmChangeType();

                    DialogResult dr = frm.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        bCustom = false;

                        dgvSubList.Columns["chiname"].ReadOnly = false;
                        dgvSubList.Columns["subname"].ReadOnly = false;
                        dgvSubList.Columns["subtype"].ReadOnly = false;
                        dgvSubList.Columns["classname"].ReadOnly = false;
                        dgvSubList.Columns["recdatadatil"].ReadOnly = false;
                        dgvSubList.Columns["jsonadd"].ReadOnly = false;
                        dgvSubList.Columns["reobject"].ReadOnly = false;
                        dgvSubList.Columns["expdll"].ReadOnly = false;

                        tsbAdd.Visible = true;
                        tsbDele.Visible = true;
                        tssOne.Visible = true;
                        tsbCopy.Visible = true;
                        tsbClear.Visible = true;
                        tssTow.Visible = true;
                        tssThr.Visible = true;
                        tsbCopyReW.Visible = true;

                        tsbCopyToFile.Visible = true;
                        tsbAddByFile.Visible = true;

                        tsmPara.Visible = true;
                        tsmReSet.Visible = true;
                        tsmDllSet.Visible = true;
                        dgvSubList.Columns["webaddres"].ReadOnly = false;
                        dgvSubList.Columns["basesql"].ReadOnly = false;
                    }
                }
            }
        }

        private void tsbCopyToFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSubList.SelectedRows.Count > 0)
                {
                    string strSubName = dgvSubList.SelectedRows[0].Cells["subname"].Value.ToString().Trim();
                    string strChiName = dgvSubList.SelectedRows[0].Cells["chiname"].Value.ToString().Trim();

                    DialogResult dResult = MessageBox.Show("确定将>>" + strChiName + "<<复制导出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                    if (dResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmNewSub frm = new frmNewSub();

                        dResult = frm.ShowDialog();

                        if (dResult == System.Windows.Forms.DialogResult.OK)
                        {
                            string strNewName = frm.strNewName;

                            List<string> listSql = new List<string>();

                            DAOAccess da = new DAOAccess();
                            //复制接口
                            string strSql = "";

                            strSql = "select max(sort) from hawi_sublist";

                            DataSet ds = da.GetDataSet(strSql);

                            int iSort = 10;

                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                iSort = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                                if (iSort > 10)
                                {
                                    iSort = (iSort / 10 + 1) * 10;
                                }
                            }

                            strSql = "";
                            strSql = strSql + " select subname,'" + strNewName + "' as chiname,classname,inparanum,webaddres,rewsql,isused,basesql,btablename,chkReSign,reTrueValue,reSignNode,reErrorNode,recdatadatil,subtype,encodtype,contenttype,jsonadd,reobject,expdll,autorun,loopbyself,followif,preInter,isused," + iSort.ToString();
                            strSql = strSql + " from hawi_sublist where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            DataSet dsSub = da.GetDataSet(strSql);

                            if (dsSub != null && dsSub.Tables.Count > 0 && dsSub.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsSub.Tables[0].Rows.Count; i++)
                                {
                                    StringBuilder sb = new StringBuilder();

                                    sb.Append("insert into hawi_sublist(chiname,subname,subtype,classname");
                                    sb.Append(",webaddres,basesql,btablename,inparanum,chkReSign,reTrueValue,reSignNode,reErrorNode,");
                                    sb.Append("recdatadatil,jsonadd,encodtype,contenttype,reobject,expdll,autorun,loopbyself,followif,preInter,isused,sort)");
                                    sb.Append(" values('");
                                    sb.Append(dsSub.Tables[0].Rows[i]["chiname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["subname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["subtype"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["classname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["webaddres"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["basesql"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["btablename"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["inparanum"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["chkReSign"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["reTrueValue"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["reSignNode"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["reErrorNode"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["recdatadatil"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["jsonadd"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["encodtype"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["contenttype"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["reobject"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["expdll"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["autorun"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["loopbyself"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["followif"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsSub.Tables[0].Rows[i]["preInter"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("',");
                                    sb.Append(dsSub.Tables[0].Rows[i]["isused"].ToString().Trim().Replace("'", "''"));
                                    sb.Append(",");
                                    sb.Append(iSort.ToString());
                                    sb.Append(")");

                                    listSql.Add(sb.ToString());
                                }
                            }

                            //listSql.Add(strSql);

                            //复制参数
                            strSql = "";
                            strSql = strSql + " select subname,'" + strNewName + "' as chiname,paraname,isxml,getvalsql,valtitle,parastaticval,allorloop,valbybase,datadlldetail,parasort,isjson,patype,datatype";
                            strSql = strSql + " from hawi_inpara where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            DataSet dsPara = da.GetDataSet(strSql);

                            if (dsPara != null && dsPara.Tables.Count > 0 && dsPara.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsPara.Tables[0].Rows.Count; i++)
                                {
                                    StringBuilder sb = new StringBuilder();

                                    sb.Append("insert into hawi_inpara(subname,chiname,paraname,isxml,isjson,patype,parastaticval,getvalsql,valtitle,valbybase,datadlldetail,parasort,datatype)");
                                    sb.Append(" values('");
                                    sb.Append(dsPara.Tables[0].Rows[i]["subname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsPara.Tables[0].Rows[i]["chiname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsPara.Tables[0].Rows[i]["paraname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsPara.Tables[0].Rows[i]["isxml"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsPara.Tables[0].Rows[i]["isjson"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsPara.Tables[0].Rows[i]["patype"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsPara.Tables[0].Rows[i]["parastaticval"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsPara.Tables[0].Rows[i]["getvalsql"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsPara.Tables[0].Rows[i]["valtitle"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("',");
                                    sb.Append(dsPara.Tables[0].Rows[i]["valbybase"].ToString().Trim().Replace("'", "''"));
                                    sb.Append(",'");
                                    sb.Append(dsPara.Tables[0].Rows[i]["datadlldetail"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("',");
                                    sb.Append(dsPara.Tables[0].Rows[i]["parasort"].ToString().Trim().Replace("'", "''"));
                                    sb.Append(",'");
                                    sb.Append(dsPara.Tables[0].Rows[i]["datatype"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("')");

                                    listSql.Add(sb.ToString());
                                }
                            }

                            //复制XML结构
                            strSql = "";
                            strSql = strSql + " select subname,'" + strNewName + "' as chiname,paraname,xmltitle,sortitle,paratype,xmltitlelv,partitle,xmlstaticval,titleisloop,valtitle,getvaluesql,looptable,valtable,tablename,isdate,dateformat,datadatilbydll,injson,canempty,titlesort";
                            strSql = strSql + " from hawi_xmlform where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            DataSet dsXML = da.GetDataSet(strSql);

                            if (dsXML != null && dsXML.Tables.Count > 0 && dsXML.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsXML.Tables[0].Rows.Count; i++)
                                {
                                    StringBuilder sb = new StringBuilder();

                                    sb.Append("insert into hawi_xmlform(subname,chiname,paraname,xmltitle,sortitle,paratype,xmltitlelv,partitle,xmlstaticval,");
                                    sb.Append("titleisloop,valtitle,getvaluesql,looptable,valtable,tablename,isdate,dateformat,datadatilbydll,injson,canempty,titlesort)");
                                    sb.Append(" values('");
                                    sb.Append(dsXML.Tables[0].Rows[i]["subname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["chiname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["paraname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["xmltitle"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["sortitle"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["paratype"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["xmltitlelv"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["partitle"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["xmlstaticval"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["titleisloop"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["valtitle"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["getvaluesql"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["looptable"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["valtable"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["tablename"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["isdate"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["dateformat"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["datadatilbydll"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["injson"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsXML.Tables[0].Rows[i]["canempty"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("',");
                                    sb.Append(dsXML.Tables[0].Rows[i]["titlesort"].ToString().Trim().Replace("'", "''"));
                                    sb.Append(")");

                                    listSql.Add(sb.ToString());
                                }
                            }

                            //复制回写
                            strSql = "";
                            strSql = strSql + " select subname,'" + strNewName + "' as chiname,sqlname,sort,isloop,loopwith,runtype,ifhave,reorupdate,tablename,fathersql,looppoit,isdesc";
                            strSql = strSql + " from hawi_reset where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            DataSet dsReSet = da.GetDataSet(strSql);

                            if (dsReSet != null && dsReSet.Tables.Count > 0 && dsReSet.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsReSet.Tables[0].Rows.Count; i++)
                                {
                                    StringBuilder sb = new StringBuilder();

                                    sb.Append("insert into hawi_reset(subname,chiname,sqlname,sort,isloop,loopwith,runtype,ifhave,reorupdate,tablename,fathersql,isDesc,looppoit)");
                                    sb.Append(" values('");
                                    sb.Append(dsReSet.Tables[0].Rows[i]["subname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSet.Tables[0].Rows[i]["chiname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSet.Tables[0].Rows[i]["sqlname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("',");
                                    sb.Append(dsReSet.Tables[0].Rows[i]["sort"].ToString().Trim().Replace("'", "''"));
                                    sb.Append(",'");
                                    sb.Append(dsReSet.Tables[0].Rows[i]["isloop"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSet.Tables[0].Rows[i]["loopwith"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSet.Tables[0].Rows[i]["runtype"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSet.Tables[0].Rows[i]["ifhave"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSet.Tables[0].Rows[i]["reorupdate"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSet.Tables[0].Rows[i]["tablename"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSet.Tables[0].Rows[i]["fathersql"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSet.Tables[0].Rows[i]["isDesc"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSet.Tables[0].Rows[i]["looppoit"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("')");

                                    listSql.Add(sb.ToString());
                                }
                            }

                            //复制回写字段设置
                            strSql = "";
                            strSql = strSql + " select subname,'" + strNewName + "' as chiname,sqlname,colname,iskey,databy,staticvalue,valuefrom,colsort,isdate,datetype,canupdate";
                            strSql = strSql + " from hawi_retableset where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            DataSet dsReSetT = da.GetDataSet(strSql);

                            if (dsReSetT != null && dsReSetT.Tables.Count > 0 && dsReSetT.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsReSetT.Tables[0].Rows.Count; i++)
                                {
                                    StringBuilder sb = new StringBuilder();

                                    sb.Append("insert into hawi_retableset(subname,chiname,sqlname,colname,iskey,canupdate,databy,valuefrom,staticvalue,isDate,dateType,colsort)");
                                    sb.Append(" values('");
                                    sb.Append(dsReSetT.Tables[0].Rows[i]["subname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSetT.Tables[0].Rows[i]["chiname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSetT.Tables[0].Rows[i]["sqlname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSetT.Tables[0].Rows[i]["colname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSetT.Tables[0].Rows[i]["iskey"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSetT.Tables[0].Rows[i]["canupdate"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSetT.Tables[0].Rows[i]["databy"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSetT.Tables[0].Rows[i]["valuefrom"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSetT.Tables[0].Rows[i]["staticvalue"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSetT.Tables[0].Rows[i]["isDate"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsReSetT.Tables[0].Rows[i]["dateType"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("',");
                                    sb.Append(dsReSetT.Tables[0].Rows[i]["colsort"].ToString().Trim().Replace("'", "''"));
                                    sb.Append(")");

                                    listSql.Add(sb.ToString());
                                }
                            }

                            //复制类库设置
                            strSql = "";
                            strSql = strSql + " select subname,'" + strNewName + "' as chiname,paraname,dllname,dllnamespe,dllclassname,dllprocname,dllparanum,xmltitle,xmlpartitle";
                            strSql = strSql + " from hawi_dllset where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            DataSet dsDll = da.GetDataSet(strSql);

                            if (dsDll != null && dsDll.Tables.Count > 0 && dsDll.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsDll.Tables[0].Rows.Count; i++)
                                {
                                    StringBuilder sb = new StringBuilder();

                                    sb.Append("insert into hawi_dllset(subname,chiname,paraname,xmltitle,xmlpartitle,dllname,dllnamespe,dllclassname,dllprocname,dllparanum)");
                                    sb.Append(" values(");
                                    sb.Append("'");
                                    sb.Append(dsDll.Tables[0].Rows[i]["subname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDll.Tables[0].Rows[i]["chiname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDll.Tables[0].Rows[i]["paraname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDll.Tables[0].Rows[i]["xmltitle"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDll.Tables[0].Rows[i]["xmlpartitle"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDll.Tables[0].Rows[i]["dllname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDll.Tables[0].Rows[i]["dllnamespe"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDll.Tables[0].Rows[i]["dllclassname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDll.Tables[0].Rows[i]["dllprocname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDll.Tables[0].Rows[i]["dllparanum"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("')");

                                    listSql.Add(sb.ToString());
                                }
                            }

                            //复制类库参数设置
                            strSql = "";
                            strSql = strSql + " select subname,'" + strNewName + "' as chiname,paraname,dllparaname,dllparavalue,dllparasort,xmltitle,xmlpartitle";
                            strSql = strSql + " from hawi_dllparaset where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            DataSet dsDllPara = da.GetDataSet(strSql);

                            if (dsDllPara != null && dsDllPara.Tables.Count > 0 && dsDllPara.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsDllPara.Tables[0].Rows.Count; i++)
                                {
                                    StringBuilder sb = new StringBuilder();

                                    sb.Append("insert into hawi_dllparaset(subname,chiname,paraname,xmltitle,xmlpartitle,dllparaname,dllparavalue,dllparasort)");
                                    sb.Append(" values(");
                                    sb.Append("'");
                                    sb.Append(dsDllPara.Tables[0].Rows[i]["subname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDllPara.Tables[0].Rows[i]["chiname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDllPara.Tables[0].Rows[i]["paraname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDllPara.Tables[0].Rows[i]["xmltitle"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDllPara.Tables[0].Rows[i]["xmlpartitle"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDllPara.Tables[0].Rows[i]["dllparaname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDllPara.Tables[0].Rows[i]["dllparavalue"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsDllPara.Tables[0].Rows[i]["dllparasort"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("')");

                                    listSql.Add(sb.ToString());
                                }
                            }

                            //复制返回结果判断设置
                            strSql = "";
                            strSql = strSql + " select subname,'" + strNewName + "' as chiname,titname,condition,titvalues,linktype,sort,leftbra,rightbra,datatype,judtype";
                            strSql = strSql + " from hawi_jud where subname='" + strSubName + "' and chiname='" + strChiName + "'";

                            DataSet dsJud = da.GetDataSet(strSql);

                            if (dsJud != null && dsJud.Tables.Count > 0 && dsJud.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsJud.Tables[0].Rows.Count; i++)
                                {
                                    StringBuilder sb = new StringBuilder();

                                    sb.Append("insert into hawi_jud(subname,chiname,judtype,sort,leftbra,titname,condition,titvalues,rightbra,datatype,linktype)");
                                    sb.Append(" values(");
                                    sb.Append("'");
                                    sb.Append(dsJud.Tables[0].Rows[i]["subname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsJud.Tables[0].Rows[i]["chiname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsJud.Tables[0].Rows[i]["judtype"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("',");
                                    sb.Append(dsJud.Tables[0].Rows[i]["sort"].ToString().Trim().Replace("'", "''"));
                                    sb.Append(",'");
                                    sb.Append(dsJud.Tables[0].Rows[i]["leftbra"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsJud.Tables[0].Rows[i]["titname"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsJud.Tables[0].Rows[i]["condition"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsJud.Tables[0].Rows[i]["titvalues"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsJud.Tables[0].Rows[i]["rightbra"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsJud.Tables[0].Rows[i]["datatype"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("','");
                                    sb.Append(dsJud.Tables[0].Rows[i]["linktype"].ToString().Trim().Replace("'", "''"));
                                    sb.Append("')");

                                    listSql.Add(sb.ToString());
                                }
                            }

                            string json = ObjectToString(listSql);

                            byte[] b = System.Text.Encoding.UTF8.GetBytes(json);

                            using (FileStream fs = new FileStream(strNewName + ".dll", FileMode.Create, FileAccess.Write))
                            {
                                fs.Write(b, 0, b.Length);
                            }

                            MessageBox.Show("保存完成");
                            //FileStream stream = new FileInfo(txtAdd.Text).OpenRead();
                            //byte[] buffer = new byte[stream.Length + 1];

                            //stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选中一个要复制的接口后再进行操作");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public String ObjectToString(List<string> t)
        {
            if (t == null) return null;

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<string>));
            string result = string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, t);
                result = Encoding.UTF8.GetString(ms.ToArray());
            }
            return result;
        }

        public List<string> StringToObject(string jsonStr)
        {
            //List<string> obj = Activator.CreateInstance<List<string>>();

            if (jsonStr == null) return new List<string>();

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonStr)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<string>));

                return (List<string>)serializer.ReadObject(ms);
            }
        }

        private void tsbAddByFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;//该值确定是否可以选择多个文件
                dialog.Title = "请选择文件";
                dialog.Filter = "选择文件(*.dll)|*.dll";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (dialog.FileNames.Length > 0)
                    {
                        for (int i = 0; i < dialog.FileNames.Length; i++)
                        {
                            string file = dialog.FileNames[i].ToString();

                            FileStream stream = new FileInfo(file).OpenRead();
                            byte[] buffer = new byte[stream.Length + 1];

                            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));

                            string json = System.Text.Encoding.UTF8.GetString(buffer);

                            List<string> listSql = StringToObject(json);

                            DAOAccess da = new DAOAccess();

                            da.RunSql(listSql);

                        }

                        MessageBox.Show("导入成功");

                        BindDgvSubList();

                        gbMain.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {

        }

        private void dgvSubList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbModify_Click(object sender, EventArgs e)
        {

        }

        private void tsbSave_Click(object sender, EventArgs e)
        {

        }

        private void gbMain_Enter(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace Hydee.Auto.Interface.Set.DAO
{
    public class DAOAccess
    {
        #region "获取数据库连接"
        public string GetDBConn()
        {
            try
            {
                string promPath = Directory.GetCurrentDirectory();
                string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + promPath + "\\HAWI.dll";

                return strConnection;
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }
        #endregion

        public DataSet GetInterfaceSub()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetDBConn()))
                {
                    conn.Open();


                    string strSql = "select * from hawi_sublist order by sort";

                    using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                            {
                                adp.Fill(ds);

                                return ds;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        public DataSet GetSubPara(string subName,string chiName)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetDBConn()))
                {
                    conn.Open();

                    string strSql = "select * from hawi_inpara where subname='" + subName + "' and chiname='" + chiName + "' order by parasort";

                    using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                            {
                                adp.Fill(ds);

                                return ds;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        public DataSet GetReset(string subName, string chiName)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetDBConn()))
                {
                    conn.Open();

                    string strSql = "select * from hawi_reset where subname='" + subName + "' and chiname='" + chiName + "' order by sort";

                    using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                            {
                                adp.Fill(ds);

                                return ds;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        public DataSet GetReTableSet(string subName, string chiName, string sqlName)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetDBConn()))
                {
                    conn.Open();

                    string strSql = "select * from hawi_retableset where subname='" + subName + "' and chiname='" + chiName + "' and sqlname='" + sqlName + "' order by colsort";

                    using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                            {
                                adp.Fill(ds);

                                return ds;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        public DataSet GetXmlSet(string subName, string chiName, string paraName)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetDBConn()))
                {
                    conn.Open();

                    string strSql = "select * from hawi_xmlform where subname='" + subName + "' and chiname='" + chiName + "' and paraname='" + paraName + "' order by titlesort";

                    using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                            {
                                adp.Fill(ds);

                                return ds;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        public DataSet GetDllSet(string subName, string chiName, string paraName, string xmlTitle, string xmlParTitle)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetDBConn()))
                {
                    conn.Open();

                    string strSql = "select * from hawi_dllset where subname='" + subName + "' and chiname='" + chiName + "' and paraname='" + paraName + "' and iif(IsNull(xmltitle), '', xmltitle)='" + xmlTitle + "' and iif(IsNull(xmlpartitle), '', xmlpartitle)='" + xmlParTitle + "'";

                    using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                            {
                                adp.Fill(ds);

                                return ds;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserException("配置类库中读取回写字段设置：" + ex.Message);
            }
        }

        public DataSet GetDllParaSet(string subName, string chiName, string paraName, string xmlTitle, string xmlParTitle)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetDBConn()))
                {
                    conn.Open();

                    string strSql = "select * from hawi_dllparaset where subname='" + subName + "' and chiname='" + chiName + "' and paraname='" + paraName + "' and iif(IsNull(xmltitle), '', xmltitle)='" + xmlTitle + "' and iif(IsNull(xmlpartitle), '', xmlpartitle)='" + xmlParTitle + "' order by dllparasort";

                    using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                            {
                                adp.Fill(ds);

                                return ds;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserException("配置类库中读取回写字段设置：" + ex.Message);
            }
        }

        public DataSet GetSubJudRec(string subName, string chiName,string strType)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetDBConn()))
                {
                    conn.Open();

                    string strSql = "select * from hawi_jud where subname='" + subName + "' and chiname='" + chiName + "' and judtype='" + strType + "' order by sort";

                    using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                            {
                                adp.Fill(ds);

                                return ds;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        public DataSet GetDllSet(string strDllName)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetDBConn()))
                {
                    conn.Open();

                    string strSql = "select distinct dllname,dllnamespe,dllclassname,dllprocname,dllparanum from hawi_dllset where dllname='" + strDllName + "'";

                    using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                            {
                                adp.Fill(ds);

                                return ds;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserException("配置类库中读取回写字段设置：" + ex.Message);
            }
        }

        public DataSet GetDllPara(string dllname, string dllnamespe, string dllclassname, string dllprocname, string dllparanum)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetDBConn()))
                {
                    conn.Open();

                    //string strSql = "select * from hawi_dllset where 
                    string strSql = string.Format("select top 1 subname,paraname,chiname,xmltitle,xmlpartitle from hawi_dllset where dllname='{0}' and dllnamespe='{1}' and dllclassname='{2}' and dllprocname='{3}' and dllparanum='{4}'", dllname, dllnamespe, dllclassname, dllprocname, dllparanum);
                    //string strSql = "select * from hawi_dllparaset where subname='" + subName + "' and chiname='" + chiName + "' and paraname='" + paraName + "' and iif(IsNull(xmltitle), '', xmltitle)='" + xmlTitle + "' and iif(IsNull(xmlpartitle), '', xmlpartitle)='" + xmlParTitle + "' order by dllparasort";

                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = strSql;

                        using (DataSet ds = new DataSet())
                        {
                            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                            {
                                adp.Fill(ds);

                                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    strSql = "select * from hawi_dllparaset where subname='" + ds.Tables[0].Rows[0]["subname"].ToString().Trim() + "' and chiname='" + ds.Tables[0].Rows[0]["chiname"].ToString().Trim() + "' and paraname='" + ds.Tables[0].Rows[0]["paraname"].ToString().Trim() + "' and iif(IsNull(xmltitle), '', xmltitle)='" + ds.Tables[0].Rows[0]["xmltitle"].ToString().Trim() + "' and iif(IsNull(xmlpartitle), '', xmlpartitle)='" + ds.Tables[0].Rows[0]["xmlpartitle"].ToString().Trim() + "' order by dllparasort";

                                    cmd.CommandText = strSql;

                                    using (DataSet dss = new DataSet())
                                    {
                                        using (OleDbDataAdapter adps = new OleDbDataAdapter(cmd))
                                        {
                                            adps.Fill(dss);

                                            return dss;
                                        }
                                    }
                                }
                                else
                                {
                                    throw new UserException("没有查询到DLL参数设置信息");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserException("配置类库中读取回写字段设置：" + ex.Message);
            }
        }

        public bool RunSql(List<string> listSql)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;

            try
            {
                conn = new OleDbConnection(GetDBConn());

                conn.Open();

                cmd = new OleDbCommand();

                cmd.Connection = conn;

                OleDbTransaction trans = conn.BeginTransaction();

                cmd.Transaction = trans;

                cmd.CommandType = CommandType.Text;

                for (int i = 0; i < listSql.Count; i++)
                {
                    cmd.CommandText = listSql[i];

                    cmd.ExecuteNonQuery();
                }

                cmd.Transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                if (conn != null && cmd != null && cmd.Transaction != null && cmd.Transaction.Connection != null)
                {
                    cmd.Transaction.Rollback();
                }

                throw new UserException(ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                conn.Dispose();
                cmd.Dispose();
            }
        }

        public DataSet GetDataSet(string strSql)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetDBConn()))
                {
                    conn.Open();

                    using (OleDbCommand cmd = new OleDbCommand(strSql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                            {
                                adp.Fill(ds);

                                return ds;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }
    }
}

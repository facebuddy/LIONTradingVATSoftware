using Npgsql;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class DBUtility
    {
        public static NpgsqlConnection npgConn;

        public static NpgsqlDataAdapter npgDa;

        public static NpgsqlCommand npgCmd;

        private static DataSet npgDataSet;

        private NpgsqlConnection oConn = new NpgsqlConnection();

        private static string strconnString;

        static DBUtility()
        {
            DBUtility.strconnString = DBUtility.GetConnString();
        }

        public DBUtility()
        {
        }

        private static string CheckConString()
        {
            string connectionString;
            try
            {
                string str = "=#!6#jyKHgHPHVak";
                NpgsqlConnectionStringBuilder npgsqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["NBR_POS_ConnString"].ConnectionString);
                string str1 = npgsqlConnectionStringBuilder["USER ID"].ToString();
                string str2 = npgsqlConnectionStringBuilder["PASSWORD"].ToString();
                string str3 = Utilities.DecryptString(str1, str);
                string str4 = Utilities.DecryptString(str2, str);
                npgsqlConnectionStringBuilder.UserName=str3;
                npgsqlConnectionStringBuilder.Password=str4;
                connectionString = npgsqlConnectionStringBuilder.ConnectionString;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
                connectionString = string.Empty;
            }
            return connectionString;
        }

        public static void CloseDBConnection()
        {
            if (DBUtility.npgConn.State == ConnectionState.Open)
            {
                DBUtility.npgConn.Close();
            }
        }

        public string DecryptPassword(string strEncryptPw)
        {
            string str;
            try
            {
                string str1 = "";
                string str2 = strEncryptPw;
                for (int i = 0; i < str2.Length; i++)
                {
                    uint num = Convert.ToUInt32(str2[i]);
                    int num1 = Convert.ToInt32(num) - 112;
                    str1 = string.Concat(str1, char.ConvertFromUtf32(num1));
                }
                str = str1;
            }
            catch (Exception exception)
            {
                str = strEncryptPw;
            }
            return str;
        }

        public string EncryptPassword(string strPassword)
        {
            string str;
            try
            {
                string str1 = "";
                string str2 = strPassword;
                for (int i = 0; i < str2.Length; i++)
                {
                    uint num = Convert.ToUInt32(str2[i]);
                    int num1 = Convert.ToInt32(num) + 112;
                    str1 = string.Concat(str1, char.ConvertFromUtf32(num1));
                }
                str = str1;
            }
            catch (Exception exception)
            {
                str = "";
            }
            return str;
        }

        public bool ExecuteBatchDML(ArrayList arrSQL)
        {
            bool flag;
            DBUtility.OpenDBConnection();
            NpgsqlTransaction npgsqlTransaction = null;
            try
            {
                try
                {
                    int i = 0;
                    npgsqlTransaction = DBUtility.npgConn.BeginTransaction();
                    for (i = 0; i < arrSQL.Count; i++)
                    {
                        DBUtility.npgCmd = new NpgsqlCommand(arrSQL[i].ToString(), DBUtility.npgConn, npgsqlTransaction)
                        {
                            CommandTimeout = 7200
                        };
                        DBUtility.npgCmd.ExecuteNonQuery();
                    }
                    npgsqlTransaction.Commit();
                    flag = true;
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    ReallySimpleLog.WriteLog(DBUtility.npgCmd.CommandText);
                    npgsqlTransaction.Rollback();
                    flag = false;
                }
            }
            finally
            {
                DBUtility.CloseDBConnection();
            }
            return flag;
        }

        public bool ExecuteBatchDmlAsBatch(ArrayList arrQuery)
        {
            bool flag;
            try
            {
                try
                {
                    string str = "";
                    for (int i = 0; i < arrQuery.Count; i++)
                    {
                        str = string.Concat(str, arrQuery[i].ToString(), ";");
                    }
                    DBUtility.OpenDBConnection();
                    DBUtility.npgCmd = new NpgsqlCommand(str, DBUtility.npgConn);
                    DBUtility.npgCmd.ExecuteNonQuery();
                    flag = true;
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    ReallySimpleLog.WriteLog(DBUtility.npgCmd.CommandText);
                    flag = false;
                }
            }
            finally
            {
                DBUtility.CloseDBConnection();
            }
            return flag;
        }

        public bool ExecuteBatchDMLWithFunction(ArrayList arrSQL, ArrayList arrUpdateSQL)
        {
            bool flag;
            DBUtility.OpenDBConnection();
            NpgsqlTransaction npgsqlTransaction = null;
            try
            {
                try
                {
                    int i = 0;
                    npgsqlTransaction = DBUtility.npgConn.BeginTransaction();
                    for (i = 0; i < arrSQL.Count; i++)
                    {
                        string str = arrSQL[i].ToString();
                        str = str.Replace("'", "\\'");
                        string str1 = arrUpdateSQL[i].ToString();
                        str1 = str1.Replace("'", "\\'");
                        string[] strArrays = new string[] { "select execute_query(E'", str, "','", str1, "')" };
                        string str2 = string.Concat(strArrays);
                        DBUtility.npgCmd = new NpgsqlCommand(str2, DBUtility.npgConn, npgsqlTransaction)
                        {
                            CommandTimeout = 7200
                        };
                        DBUtility.npgCmd.ExecuteNonQuery();
                    }
                    npgsqlTransaction.Commit();
                    flag = true;
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    ReallySimpleLog.WriteLog(DBUtility.npgCmd.CommandText);
                    npgsqlTransaction.Rollback();
                    flag = false;
                }
            }
            finally
            {
                DBUtility.CloseDBConnection();
            }
            return flag;
        }

        public bool ExecuteDML(string strSql)
        {
            bool flag;
            try
            {
                try
                {
                    DBUtility.OpenDBConnection();
                    DBUtility.npgCmd = new NpgsqlCommand(strSql, DBUtility.npgConn);
                    DBUtility.npgCmd.ExecuteNonQuery();
                    flag = true;
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    ReallySimpleLog.WriteLog(DBUtility.npgCmd.CommandText);
                    flag = false;
                }
            }
            finally
            {
                DBUtility.CloseDBConnection();
            }
            return flag;
        }

        public string ExecuteDMLGetId(string strSql)
        {
            string str;
            string str1 = "1";
            try
            {
                try
                {
                    DBUtility.OpenDBConnection();
                    DBUtility.npgCmd = new NpgsqlCommand(strSql, DBUtility.npgConn);
                    str1 = DBUtility.npgCmd.ExecuteScalar().ToString();
                    DBUtility.npgCmd = null;
                    str = str1;
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    str = str1;
                }
            }
            finally
            {
                DBUtility.CloseDBConnection();
            }
            return str;
        }

        public bool ExecuteDMLWithOnlyQuery(string strSql)
        {
            bool flag;
            try
            {
                try
                {
                    DBUtility.OpenDBConnection();
                    DBUtility.npgCmd = new NpgsqlCommand(strSql, DBUtility.npgConn);
                    DBUtility.npgCmd.ExecuteNonQuery();
                    flag = true;
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    ReallySimpleLog.WriteLog(DBUtility.npgCmd.CommandText);
                    flag = false;
                }
            }
            finally
            {
                DBUtility.CloseDBConnection();
            }
            return flag;
        }

        public bool ExecuteDMLWithOnlyQueryNotlog(string strSql)
        {
            bool flag;
            try
            {
                try
                {
                    DBUtility.OpenDBConnection();
                    DBUtility.npgCmd = new NpgsqlCommand(strSql, DBUtility.npgConn);
                    DBUtility.npgCmd.ExecuteNonQuery();
                    DBUtility.npgCmd = null;
                    flag = true;
                }
                catch (Exception exception)
                {
                    flag = false;
                }
            }
            finally
            {
                DBUtility.CloseDBConnection();
            }
            return flag;
        }

        public DataTable GetArrayDataTable(ArrayList strSQL)
        {
            DataTable item;
            try
            {
                try
                {
                    DBUtility.OpenDBConnection();
                    for (int i = 0; i < strSQL.Count; i++)
                    {
                        string str = strSQL[i].ToString();
                        DBUtility.npgDa = new NpgsqlDataAdapter(str, DBUtility.npgConn);
                    }
                    DBUtility.npgDataSet = new DataSet();
                    DBUtility.npgCmd = new NpgsqlCommand()
                    {
                        CommandTimeout = 7200
                    };
                    DBUtility.npgDa.SelectCommand.CommandTimeout = 7200;
                    DBUtility.npgDa.Fill(DBUtility.npgDataSet, "DataTable");
                    item = DBUtility.npgDataSet.Tables[0];
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    item = null;
                }
            }
            finally
            {
                DBUtility.CloseDBConnection();
            }
            return item;
        }

        public static string GetConnString()
        {
            string empty = string.Empty;
            empty = (ConfigurationManager.ConnectionStrings["NBR_POS_ConnString"] != null ? DBUtility.CheckConString() : "Server=192.168.10.125;Port=5432;Userid=postgres;Password=142536;Protocol=3;SSL=false;Pooling=true;MinPoolSize=10;MaxPoolSize=50;Encoding=UNICODE;Timeout=300;SslMode=Disable;Database=TPOS");
            return empty;
        }

        public DataSet GetDataSet(string strSql, string strDataTblName)
        {
            DataSet dataSet;
            try
            {
                try
                {
                    DBUtility.OpenDBConnection();
                    DBUtility.npgDa = new NpgsqlDataAdapter(strSql, DBUtility.npgConn);
                    DBUtility.npgDataSet = new DataSet();
                    DBUtility.npgCmd = new NpgsqlCommand()
                    {
                        CommandTimeout = 7200
                    };
                    // DBUtility.npgDa.get_SelectCommand().CommandTimeout = 7200;
                    DBUtility.npgDa.SelectCommand.CommandTimeout = 7200;
                    DBUtility.npgDa.Fill(DBUtility.npgDataSet, strDataTblName);
                    dataSet = DBUtility.npgDataSet;
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    ReallySimpleLog.WriteLog(DBUtility.npgCmd.CommandText);
                    dataSet = null;
                }
            }
            finally
            {
                DBUtility.CloseDBConnection();
            }
            return dataSet;
        }

        public DataTable GetDataTable(string strSQL)
        {
            DataTable item;
            try
            {
                try
                {
                    DBUtility.OpenDBConnection();
                    DBUtility.npgDa = new NpgsqlDataAdapter(strSQL, DBUtility.npgConn);
                    DBUtility.npgDataSet = new DataSet();
                    DBUtility.npgCmd = new NpgsqlCommand()
                    {
                        CommandTimeout = 7200
                    };
                    DBUtility.npgDa.SelectCommand.CommandTimeout = 7200;
                    DBUtility.npgDa.Fill(DBUtility.npgDataSet, "DataTable");
                    item = DBUtility.npgDataSet.Tables[0];
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    item = null;
                }
            }
            finally
            {
                DBUtility.CloseDBConnection();
            }
            return item;
        }

        public static NpgsqlConnection getDBConnection()
        {
            if (DBUtility.npgConn == null)
            {
                DBUtility.npgConn = new NpgsqlConnection(DBUtility.strconnString);
            }
            if (DBUtility.npgConn.State == ConnectionState.Closed)
            {
                try
                {
                    DBUtility.npgConn.Open();
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    ReallySimpleLog.WriteLog(DBUtility.npgCmd.CommandText);
                }
            }
            return DBUtility.npgConn;
        }

        public object GetSingleValue(string query)
        {
            object obj;
            object obj1 = new object();
            try
            {
                try
                {
                    DBUtility.OpenDBConnection();
                    DBUtility.npgCmd = new NpgsqlCommand(query, DBUtility.npgConn);
                    obj = DBUtility.npgCmd.ExecuteScalar();
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    ReallySimpleLog.WriteLog(DBUtility.npgCmd.CommandText);
                    obj = null;
                }
            }
            finally
            {
                DBUtility.CloseDBConnection();
            }
            return obj;
        }

        public static void OpenDBConnection()
        {
            if (DBUtility.npgConn == null)
            {
                DBUtility.npgConn = new NpgsqlConnection(DBUtility.strconnString);
            }
            if (DBUtility.npgConn.State == ConnectionState.Closed)
            {
                try
                {
                    DBUtility.npgConn.Open();
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    ReallySimpleLog.WriteLog(DBUtility.npgCmd.CommandText);
                }
            }
        }












    }
}

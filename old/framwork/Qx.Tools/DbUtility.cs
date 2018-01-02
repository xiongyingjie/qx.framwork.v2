using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Tools.CommonExtendMethods;
using Oracle.ManagedDataAccess.Client;
namespace Qx.Tools
{
    public enum ClientType
    {
        MySql,
        SqlSever,
        Oracle
    }
    public static class DbUtility
    {
        public static string OracleConnString(string host, string serviceName, string user, string passWord, int port=1521)
        {
            return string.Format("Data Source=(description=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(FAILOVER=yes)(LOAD_BALANCE=yes)(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = {2})));Persist Security Info=True;User ID={3};Password={4};", host, port, serviceName, user, passWord
                );

        }
        public static List<List<string>> ExecuteReaderForSqlSever(string sql, string connStr)
        {
            using (var Con = new SqlConnection(connStr))
            {
                using (var Com = new SqlCommand(sql, Con))
                {
                    try
                    {
                        //打开连接
                        if (Con.State != ConnectionState.Open)
                        {
                            Con.Open();
                        }
                        using (var reader = Com.ExecuteReader())
                        {
                            var result = reader.ToTableList();
                            //关闭reader
                            reader.Close();
                            reader.Dispose();
                            return result;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("错误信息:" + ex.Message);
                    }
                    finally
                    {
                        Com.Dispose();
                        // 关闭连接
                        if (Con.State != ConnectionState.Closed)
                        { Con.Close(); }
                    }
                }
            }
        }
        public static int ExecuteNonQueryForSqlSever(string sql, string connStr)
        {
            var count = 0;
            using (var Con = new SqlConnection(connStr))
            {
                using (var Com = new SqlCommand(sql, Con))
                    try
                    {
                        //打开连接
                        if (Con.State != ConnectionState.Open)
                        { Con.Open(); }
                        count = Com.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("错误信息:" + ex.Message);
                    }
                    finally
                    {
                        if (Con.State == ConnectionState.Open)
                        {
                            Com.Dispose(); ;
                            Con.Close();
                            Con.Dispose();
                        }
                    }

            }
            return count;
        }
        public static List<List<string>> ExecuteReaderForOracle(string sql, string connStr)
        {
            using (var Con = new OracleConnection(connStr))
            {//  string connString = "Data Source=(description=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.18.170)(PORT=1521))(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.18.172)(PORT=1521)))(FAILOVER=yes)(LOAD_BALANCE=yes)(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = kfptdb)));Persist Security Info=True;User ID=usr_weixin;Password=xAaeS90D;";

                using (var Com = new OracleCommand(sql, Con))
                {
                    try
                    {
                        //打开连接
                        if (Con.State != ConnectionState.Open)
                        {
                            Con.Open();
                        }
                        using (var reader = Com.ExecuteReader())
                        {
                            var result = reader.ToTableList();
                            //关闭reader
                            reader.Close();
                            reader.Dispose();
                            return result;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("错误信息:" + ex.Message);
                    }
                    finally
                    {
                        Com.Dispose();
                        // 关闭连接
                        if (Con.State != ConnectionState.Closed)
                        { Con.Close(); }
                    }
                }
            }
        }
        public static int ExecuteNonQueryForOracle(string sql, string connStr)
        {
            var count = 0;
            using (var Con = new OracleConnection(connStr))
            {
                using (var Com = new OracleCommand(sql, Con))
                    try
                    {
                        //打开连接
                        if (Con.State != ConnectionState.Open)
                        { Con.Open(); }
                        count = Com.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("错误信息:" + ex.Message);
                    }
                    finally
                    {
                        if (Con.State == ConnectionState.Open)
                        {
                            Com.Dispose(); ;
                            Con.Close();
                            Con.Dispose();
                        }
                    }

            }
            return count;
        }

    }

}

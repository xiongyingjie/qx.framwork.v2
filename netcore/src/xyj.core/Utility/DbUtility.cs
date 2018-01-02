using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using xyj.core.Config;
using xyj.core.Extensions;


namespace xyj.core.Utility
{
    public enum ClientType
    {
        MySql,
        SqlSever,
        Oracle
    }
    public static class DbUtility
    {
        
        private static string CheckDb(this string srcDb)
        {
            srcDb = srcDb.CheckValue(Setting.SystemDbName).ToLower();
            return Setting.DbMapping.ContainsKey(srcDb) ? Setting.DbMapping[srcDb] : srcDb;
        }
        public static string MySqlConnString(string host, string database, string user, string passWord)
        {
            return string.Format("server={0};database={1};uid={2};pwd={3};charset='gbk';SslMode=None", host, database.CheckDb(), user, passWord );

        }
        public static string SqlSeverConnString(string database="", string host = "", string user = "", string passWord=""
            )
        {

            return string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                host, database.CheckDb(), user.CheckValue(Setting.DbUser), passWord.CheckValue(Setting.DbPassword));

        }
        public static string OracleConnString(string host, string serviceName, string user, string passWord, int port=1521)
        {
            return string.Format("Data Source=(description=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(FAILOVER=yes)(LOAD_BALANCE=yes)(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = {2})));Persist Security Info=True;User ID={3};Password={4};", 
                host, port, serviceName, user, passWord
                );

        }
        public static List<List<string>> ExecuteReaderForSqlSever(string sql, string connStr)
        {
            using (var con = new SqlConnection(connStr))
            {
                using (var com = new SqlCommand(sql, con))
                {
                    try
                    {
                        //打开连接
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (var reader = com.ExecuteReader())
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
                        com.Dispose();
                        // 关闭连接
                        if (con.State != ConnectionState.Closed)
                        { con.Close(); }
                    }
                }
            }
        }
        public static int ExecuteNonQueryForSqlSever(string sql, string connStr)
        {
            var count = 0;
            using (var con = new SqlConnection(connStr))
            {
                using (var com = new SqlCommand(sql, con))
                    try
                    {
                        //打开连接
                        if (con.State != ConnectionState.Open)
                        { con.Open(); }
                        count = com.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("错误信息:" + ex.Message);
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            com.Dispose(); ;
                            con.Close();
                            con.Dispose();
                        }
                    }

            }
            return count;
        }
        public static List<List<string>> ExecuteReaderForOracle(string sql, string connStr)
        {
            using (var con = new OracleConnection(connStr))
            {//  string connString = "Data Source=(description=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.18.170)(PORT=1521))(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.18.172)(PORT=1521)))(FAILOVER=yes)(LOAD_BALANCE=yes)(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = kfptdb)));Persist Security Info=True;User ID=usr_weixin;Password=xAaeS90D;";

                using (var com = new OracleCommand(sql, con))
                {
                    try
                    {
                        //打开连接
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (var reader = com.ExecuteReader())
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
                        com.Dispose();
                        // 关闭连接
                        if (con.State != ConnectionState.Closed)
                        { con.Close(); }
                    }
                }
            }
        }
        public static int ExecuteNonQueryForOracle(string sql, string connStr)
        {
            var count = 0;
            using (var con = new OracleConnection(connStr))
            {
                using (var com = new OracleCommand(sql, con))
                    try
                    {
                        //打开连接
                        if (con.State != ConnectionState.Open)
                        { con.Open(); }
                        count = com.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("错误信息:" + ex.Message);
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            com.Dispose(); ;
                            con.Close();
                            con.Dispose();
                        }
                    }

            }
            return count;
        }

        public static List<List<string>> ExecuteReaderForMySql(string sql, string connStr)
        {
            using (var con = new MySqlConnection(connStr))
            {//  string connString = "Data Source=(description=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.18.170)(PORT=1521))(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.18.172)(PORT=1521)))(FAILOVER=yes)(LOAD_BALANCE=yes)(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = kfptdb)));Persist Security Info=True;User ID=usr_weixin;Password=xAaeS90D;";

                using (var com = new MySqlCommand(sql, con))
                {
                    try
                    {
                        //打开连接
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (var reader = com.ExecuteReader())
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
                        com.Dispose();
                        // 关闭连接
                        if (con.State != ConnectionState.Closed)
                        { con.Close(); }
                    }
                }
            }
        }
        public static int ExecuteNonQueryForMySql(string sql, string connStr)
        {
            var count = 0;
            using (var con = new MySqlConnection(connStr))
            {
                using (var com = new MySqlCommand(sql, con))
                    try
                    {
                        //打开连接
                        if (con.State != ConnectionState.Open)
                        { con.Open(); }
                        count = com.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("错误信息:" + ex.Message);
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            com.Dispose(); ;
                            con.Close();
                            con.Dispose();
                        }
                    }

            }
            return count;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Oracle.ManagedDataAccess.Client;

namespace Qx.Tools.CommonExtendMethods
{
    public static class ListListStringExtension
    {
        public static List<List<string>> ToTableList(this SqlDataReader reader)
        {
            //所有行
            var rows = new List<List<string>>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //逐行添加内容
                    var cols = new List<string>();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var value = "";

                        #region 根据格式取值

                        var type = reader.GetDataTypeName(i).ToLower();
                        if (reader.IsDBNull(i))
                        {
                            value = "";
                        }
                        else if (type == ("smallint"))
                        {
                            value = reader.GetInt16(i) + "";
                        }
                        else if (type.Contains("int"))
                        {
                            value = reader.GetInt32(i) + "";
                            //
                            //var v = reader.GetInt32(i);
                            //if (v > 1000000000)
                            //{
                            //    value = reader.GetInt32(i).ToDateTime().ToStr();
                            //}
                            //else
                            //{
                            //    value = reader.GetInt32(i) + "";
                            //}
                        }
                        else if (type.Contains("float"))
                        {
                            value = reader.GetDouble(i) + "";
                        }
                        else if (type.Contains("datetime"))
                        {
                            value = reader.GetDateTime(i).ToString("yyyy-MM-dd HH:mm") + "";
                        }
                        else if (type.Contains("char")|| type.Contains("text"))
                        {
                            value = reader.GetString(i) + "";
                        }//
                        else if (type.Contains("sql_variant"))
                        {
                            value = reader.GetSqlValue(i) + "";
                        }
                        else
                        {
                            value = reader.GetString(i) + "";
                            // Replace("%", "");//2016-09-05 配合报表转义规则 2016-09-10 更新规则
                            //if (value.Contains("%"))
                            //    throw new Exception("替换不完全！");
                        }

                        #endregion

                        cols.Add(value);
                    }
                    rows.Add(cols);
                }
            }
            reader.Close();
            reader.Dispose();
            return rows;
        }
        public static List<List<string>> ToTableList(this OracleDataReader reader)
        {
            //所有行
            var rows = new List<List<string>>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //逐行添加内容
                    var cols = new List<string>();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var value = "";

                        #region 根据格式取值

                        var type = reader.GetDataTypeName(i).ToLower();
                        if (reader.IsDBNull(i))
                        {
                            value = "";
                        }
                        else if (type == ("smallint"))
                        {
                            value = reader.GetInt16(i) + "";
                        }
                        else if (type.Contains("int"))
                        {
                            value = reader.GetInt32(i) + "";
                            //
                            //var v = reader.GetInt32(i);
                            //if (v > 1000000000)
                            //{
                            //    value = reader.GetInt32(i).ToDateTime().ToStr();
                            //}
                            //else
                            //{
                            //    value = reader.GetInt32(i) + "";
                            //}
                        }
                        else if (type.Contains("float"))
                        {
                            value = reader.GetDouble(i) + "";
                        }
                        else if (type.Contains("datetime"))
                        {
                            value = reader.GetDateTime(i).ToString("yyyy-MM-dd HH:mm") + "";
                        }
                        else if (type.Contains("char") || type.Contains("text"))
                        {
                            value = reader.GetString(i) + "";
                        }
                        else if (type.Contains("decimal"))
                        {
                            value = reader.GetOracleDecimal(i) + "";
                        }
                        else if (type.Contains("date"))
                        {
                            var temp = reader.GetOracleDate(i);
                            if (!temp.IsNull)
                            {
                                value = temp.Value.FormatTime();
                            }
                           
                        }
                        else
                        {
                            value = reader.GetString(i) + "";
                            // Replace("%", "");//2016-09-05 配合报表转义规则 2016-09-10 更新规则
                            //if (value.Contains("%"))
                            //    throw new Exception("替换不完全！");
                        }

                        #endregion

                        cols.Add(value);
                    }
                    rows.Add(cols);
                }
            }
            reader.Close();
            reader.Dispose();
            return rows;
        }

        public static string ToJsonString(this List<List<string>> dataList, List<string> headerList)
        {
            //格式转换
            var json = "[";
            for (var i = 0; i < dataList.Count; i++)
            {
                var cols = dataList[i];
                json += "{";
                for (var j = 0; j < headerList.Count; j++)
                {
                    json += "\"" + headerList[j] + "\":\"" + cols[j] + "\""
                            + (j == headerList.Count - 1 ? "" : ",");
                }
                json += "}";
                json += (i == dataList.Count - 1 ? "" : ",");
            }
            json += "]";
            return json;
        }
      
    }
}
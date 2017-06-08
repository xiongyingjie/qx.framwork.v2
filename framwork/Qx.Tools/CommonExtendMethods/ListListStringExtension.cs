using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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

    }
}
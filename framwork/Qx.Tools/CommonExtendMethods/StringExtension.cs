using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace Qx.Tools.CommonExtendMethods
{
    public static class StringExtension
    {

        [Obsolete("请使用ExecuteReader2代替")]
        public static SqlDataReader ExecuteReader(this string sql, string connStr)
        {
            throw new Exception("方法已废弃,请使用ExecuteReader2代替!");
            SqlDataReader reader;
            var Con = new SqlConnection(connStr);

            var Com = new SqlCommand(sql, Con);
            try
            {
                Con.Open();
                reader = Com.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return reader;
        }
        public static List<List<string>> ExecuteReader2(this string sql, string connStr)
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
                        throw new Exception("执行数据库查询出错，错误信息:" + ex.Message);
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

        public static string AddSpace(this string src, char splitFlag = ' ')
        {
            return src + "&nbsp;" + splitFlag;
        }
        public static int ExecuteNonQuery(this string sql, string connStr)
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
                        throw new Exception("执行数据库查询失败，错误信息:" + ex.Message);
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

        public static List<string> UnPackString(this string srcString, char flag, bool removeEmpty = false)
        {
            //关于控制检测
            //若数据库 存在该行，但是该列为空，此时读出的字符串 ""
            //若数据库 不存在该行 此时读出的字符串 null

            if (!string.IsNullOrEmpty(srcString)) //是否为空 既然能传入肯定不是null
            {
                srcString.TrimString(); //清除空格
                var temp = srcString.Split(flag).ToList(); //拆分成数组  
                if (removeEmpty)
                {
                    if (temp[temp.Count - 1] == "")
                    {
                        temp.RemoveAt(temp.Count - 1);
                    }
                }

                return temp;
            }
            return new List<string>(0);
        }

        public static string PickUp(this string srcString, string startWith = "{#", string endWith = "#}")
        {
            if (!srcString.HasValue())
                return "";
            var startIndex = srcString.IndexOf(startWith, StringComparison.Ordinal);
            var endIndex = srcString.IndexOf(endWith, StringComparison.Ordinal);
            return startIndex > -1 && endIndex > -1 ? srcString.Substring(startIndex + startWith.Length, endIndex - (startIndex + endWith.Length)) : "";
        }

        public static bool IsValidate(this string srcString, string RegexString)
        {
            if (!RegexString.HasValue())
            {
                return true;
            }
            return Regex.IsMatch(srcString, RegexString);
        }
        public static string CheckValue(this string srcString, string deafultValue = "")
        {
            return srcString.HasValue() ? srcString :
                deafultValue.HasValue() ? deafultValue : DateTime.Now.Random();
        }
        public static string IsFixedParam(this string srcString, string deafultValue = "")
        {
            return srcString +
                (deafultValue.HasValue() ? deafultValue : QxConfigs.FixedParamFlag);
        }
        public static string GetFixedParam(this string srcString, string deafultValue = "")
        {
            return srcString.TrimString(QxConfigs.FixedParamFlag).CheckValue(deafultValue);
        }
        public static bool HasValue(this string srcString)
        {
            if (string.IsNullOrWhiteSpace(srcString) || srcString.TrimString() == ";")
            {
                return false;
            }
            return true;
        }
        public static string TrimString(this string srcString, string flag = " ")
        {
            return srcString?.Trim().Replace(flag, "") ?? "";
        }
        public static string ReplaceFirst(this string src, string oldValue, string newValue, string autoAddFlag = "")
        {
            oldValue = autoAddFlag + oldValue;
            var dest = src;
            var oldStringLenth = oldValue.Length;
            var index = src.IndexOf(oldValue, StringComparison.Ordinal);
            if (index > -1)
            {
                var startIndex = index + oldStringLenth;
                var front = src.Substring(0, index);
                var behind = src.Substring(startIndex, src.Length - startIndex);
                dest = front + newValue + behind;
            }
            return dest;
        }

        public static int ToInt(this string srcString)
        {
            if (srcString.HasValue())
            {
                return int.Parse(srcString);
            }
            return -1;
        }
        public static string SqlTableInfo(this string tableName)
        {
            /*
             
GUID	列名	说明	表	 不显示 	主键	字段类型	长度	允许空	默认值	外键列明	外键表名
  0	      1	      2	     3	    4	     5	        6	     7	      8       9        10          11

             */
            return string.Format(@"
declare @table_name varchar(100) --声明变量
set @table_name='{0}'   ---赋值
 SELECT 
'GUID' as GUID,--0
列名 = Rtrim(b.name),--1
说明 = Isnull(c.VALUE,'_'+b.name),@table_name as 表,'false'as 不显示,--2
主键 = CASE WHEN h.id IS NOT NULL THEN 'true'ELSE 'false'END,--3
字段类型 = Type_name(b.xusertype)--4
                + CASE 
                    WHEN b.colstat & 1 = 1 THEN '[ID('
                                                 + CONVERT(VARCHAR,Ident_seed(a.name))
                                                 + ','
                                                 + CONVERT(VARCHAR,Ident_incr(a.name))
                                                 + ')]'
                    ELSE ''
                  END,
长度 = b.length,--5
允许空 = CASE b.isnullable --6
                WHEN 0 THEN 'false'
                ELSE 'true'
              END,
默认值 = Isnull(e.TEXT,''),--7
外键列明 = (SELECT top 1 RC.name 被引用列名--8
					      FROM sys.foreign_key_columns 
						  JOIN sys.objects PT ON sys.foreign_key_columns.parent_object_id=PT.object_id
						  JOIN sys.objects RT ON sys.foreign_key_columns.referenced_object_id=RT.object_id
						  JOIN sys.columns PC ON sys.foreign_key_columns.parent_object_id=PC.object_id 
						       AND sys.foreign_key_columns.parent_column_id=PC.column_id
						  JOIN sys.columns RC ON sys.foreign_key_columns.referenced_object_id=RC.object_id 
							   AND sys.foreign_key_columns.referenced_column_id=RC.column_id
						  JOIN sys.foreign_keys FK ON sys.foreign_key_columns.constraint_object_id=FK.object_id where PT.name=@table_name and RC.name=Rtrim(b.name)),
外键表名 =(SELECT top 1 RT.name 被引用表名--9
					      FROM sys.foreign_key_columns 
						  JOIN sys.objects PT ON sys.foreign_key_columns.parent_object_id=PT.object_id
						  JOIN sys.objects RT ON sys.foreign_key_columns.referenced_object_id=RT.object_id
						  JOIN sys.columns PC ON sys.foreign_key_columns.parent_object_id=PC.object_id 
						       AND sys.foreign_key_columns.parent_column_id=PC.column_id
						  JOIN sys.columns RC ON sys.foreign_key_columns.referenced_object_id=RC.object_id 
							   AND sys.foreign_key_columns.referenced_column_id=RC.column_id
						  JOIN sys.foreign_keys FK ON sys.foreign_key_columns.constraint_object_id=FK.object_id where PT.name=@table_name and RC.name=Rtrim(b.name))
      
FROM     sysobjects a
         INNER JOIN  sys.all_objects aa ON a.id=aa.object_id 
              AND  schema_name(schema_id)='dbo' ,syscolumns b
         LEFT OUTER JOIN sys.extended_properties c ON b.id = c.major_id
              AND b.colid = c.minor_id
         LEFT OUTER JOIN syscomments e ON b.cdefault = e.id
         LEFT OUTER JOIN (SELECT g.id
                                 ,g.colid
                          FROM   sysindexes f
                                 ,sysindexkeys g
                          WHERE  (f.id = g.id)
                                 AND (f.indid = g.indid)
                                 AND (f.indid > 0)
                                 AND (f.indid < 255)
                                 AND (f.status & 2048) <> 0) h ON (b.id = h.id)
              AND (b.colid = h.colid)
WHERE    (a.id = b.id)
         AND (a.id = Object_id(@table_name))  --要查询的表改成你要查询表的名称
ORDER BY b.colid",
 tableName);
        }

        public static string GetConnectionString(this string dbKey)
        {
            return ConfigurationManager.ConnectionStrings[dbKey].ConnectionString;
        }
    }
}
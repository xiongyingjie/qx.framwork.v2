using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;

namespace Qx.Tools.CommonExtendMethods
{
    public static class StringExtension
    {

        //[Obsolete("请使用ExecuteReader2代替")]
        //public static SqlDataReader ExecuteReader(this string sql, string connStr)
        //{
        //    throw new Exception("方法已废弃,请使用ExecuteReader2代替!");
        //    SqlDataReader reader;
        //    var Con = new SqlConnection(connStr);

        //    var Com = new SqlCommand(sql, Con);
        //    try
        //    {
        //        Con.Open();
        //        reader = Com.ExecuteReader();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return reader;
        //}
        public static List<List<string>> ExecuteReader2(this string sql, string connStr)
        {
            return DbUtility.ExecuteReaderForSqlSever(sql, connStr);
        }
        public static int ExecuteNonQuery(this string sql, string connStr, ClientType type = ClientType.SqlSever)
        {
            var result = -1;
            switch (type)
            {
                case ClientType.SqlSever:
                    {
                        result= DbUtility.ExecuteNonQueryForSqlSever(sql, connStr);
                    }break;
                case ClientType.Oracle:
                    {
                        result= DbUtility.ExecuteNonQueryForOracle(sql, connStr);
                    }
                    break;
                case ClientType.MySql:
                    {
                      throw new NotImplementedException();
                    }
                   
            }
            return result;
        }
        public static List<List<string>> ExecuteReader(this string sql, string connStr,ClientType type=ClientType.SqlSever)
        {
            var result = new List<List<string>>();
            switch (type)
            {
                case ClientType.SqlSever:
                    {
                        result = DbUtility.ExecuteReaderForSqlSever(sql, connStr);
                    }
                    break;
                case ClientType.Oracle:
                    {
                        result = DbUtility.ExecuteReaderForOracle(sql, connStr);
                    }
                    break;
                case ClientType.MySql:
                    {
                        throw new NotImplementedException();
                    }

            }
            return result;

        }
      
        public static string AddSpace(this string src, char splitFlag = ' ')
        {
            return src + "&nbsp;" + splitFlag;
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
        /// <summary>
        /// 取出字符串中间的内容
        /// </summary>
        /// <param name="srcString">源字符串</param>
        /// <param name="startWith">开始标志串</param>
        /// <param name="endWith">结束标志串</param>
        /// <param name="frontStart">搜索增强：开始前标志串</param>
        /// <param name="afterEnd">搜索增强：结束后标志串</param>
        /// <returns></returns>
        public static string PickUp(this string srcString, 
            string startWith = "{#", string endWith = "#}",
            string frontStart="",string afterEnd="")
        {
            //存放目标结果
            var dest = "";
            //存放目标结果前面的部分(不含标志串)
            var frontDest = "";
            //存放目标结果后面的部分(不含标志串)
            var afterDest = "";
            var afterEndCutIndex = -1;
            //0 初始  1 找到标志串  2前置串匹配  3后置串匹配 
            var finish = 0;
            //终止循环的条件个数
            var conditionCount = 1;
            if (frontStart.HasValue()) conditionCount++;
            if (afterEnd.HasValue()) conditionCount++;
            //循环开始
            while (conditionCount != finish)
            { 
                //示例:
                //123{#haha#}444             123{#haha#}444{#qhraha#}   
                //长度：13  startIndex:3   startWith长度:2  endWith长度:2  startCutIndex：5   endCutIndex=endIndex：9  count: 4   afterEndCutIndex:11
                //   3+2   9-(3+2)  
                var startCutIndex = srcString.IndexOf(startWith, StringComparison.Ordinal) + startWith.Length;
                //只找开始标志串之后的
                var endCutIndex = srcString.Substring(startCutIndex).IndexOf(endWith, StringComparison.Ordinal)+ startCutIndex;
                var count = endCutIndex - startCutIndex;
                //没找到匹配的标志串组则直接终止
                if (startCutIndex<startWith.Length || count<0)
                {
                    break;
                }
                //否则抓取内容
                dest = srcString.Substring(startCutIndex, count);
                frontDest = srcString.Substring(0, startCutIndex - startWith.Length);
                //后置字符开始索引
                afterEndCutIndex = endCutIndex + endWith.Length;
                afterDest = srcString.Substring(afterEndCutIndex);
                //没有前置后置则终止
                if (!frontStart.HasValue() && !afterEnd.HasValue())
                {
                    break;
                }
                //条件累加
                finish++;

                //搜索增强：如果有前置字符且前置字符不匹配
                if (frontStart.HasValue())
                {
                    var tempIndex = frontDest.Length - frontStart.Length;
                    if (tempIndex >= 0 && frontDest.Substring(tempIndex) == frontStart)
                    {
                        //条件累加
                        finish++;
                    }
                }

                //搜索增强：如果有后置字符且后置字符不匹配
                if (afterEnd.HasValue())
                { 
                    if (afterDest.Length >= afterEnd.Length &&
                        afterDest.Substring(0, afterEnd.Length) == afterEnd)
                    {
                        //条件累加
                        finish++;
                    }
                }
                //终止判断
                if (conditionCount != finish)
                {
                    //重新搜索
                    srcString = srcString.Substring(afterEndCutIndex);
                    dest = "";
                    finish = 0;
                }

            }
            return dest;
        }

        public static string ToHtml(this string srcString)
        {
            if (!srcString.HasValue())
            {
                return "";
            }
            return srcString.Replace("\n", "<br/>").Replace(" ", "&nbsp;&nbsp;");
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
            if (string.IsNullOrWhiteSpace(srcString) || srcString.TrimString() == ";" || srcString.TrimString() == "#")
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
        public static string ReplaceLast(this string src, string oldValue, string newValue, string autoAddFlag = "")
        {
            oldValue = autoAddFlag + oldValue;
            var dest = src;
            var index = src.LastIndexOf(oldValue, StringComparison.Ordinal);
            if (index > -1)
            {
                dest = src.ReplaceAt( index, oldValue.Length, newValue);
            }
            return dest;
        }
        public static string ReplaceLastAt(this string src,int lastCount, string oldValue, string newValue)
        {
            var randoms =new List<string>();
            for (var i = 0; i < lastCount; i++)
            {
                if ((lastCount-1) != i)
                {
                    //生成标识
                    randoms.Add(DateTime.Now.Random());
                    //标识替换
                    src = src.ReplaceLast(oldValue, randoms[i]);
                }
                else
                {
                  
                    //真实替换
                    src = src.ReplaceLast(oldValue, newValue);
                    //清除标识
                    randoms.ForEach(r =>
                    {
                        src = src.Replace(r, oldValue);
                    });
                    //终止并返回
                  break;
                } 
            }
            return src;
        }
        public static string ReplaceAt(this string src,  int index, int oldValueLenth,
            string newValue)
        {
            var startIndex = index + oldValueLenth;
            var front = src.Substring(0, index);
            var behind = src.Substring(startIndex, src.Length - startIndex);
            return front + newValue + behind;
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
说明 = Isnull(c.VALUE,'#'),@table_name as 表,'false'as 不显示,--2
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

      
        public static string DeCode(this string str)
        {
            if (!str.HasValue()) return "";
            str =str.Replace("-Y-Y-Y-0-",",");
            str = str.Replace("-Y-Y-Y-1-","'");
            str = str.Replace("-Y-Y-Y-2-",";");
            str = str.Replace("-Y-Y-Y-3-",":");
            str = str.Replace("-Y-Y-Y-4-","/");
            str = str.Replace("-Y-Y-Y-5-","?" );
            str = str.Replace("-Y-Y-Y-6-","<");
            str = str.Replace("-Y-Y-Y-7-",">");
            str = str.Replace( "-Y-Y-Y-8-",".");
            str = str.Replace( "-Y-Y-Y-9-","#");
            str = str.Replace("-Y-Y-Y-10-","%");
            str = str.Replace("-Y-Y-Y-12-","%");
            str = str.Replace("-Y-Y-Y-13-","^");
            str = str.Replace("-Y-Y-Y-14-","//");
            str = str.Replace("-Y-Y-Y-15-","@" );
            str = str.Replace("-Y-Y-Y-16-","(");
            str = str.Replace("-Y-Y-Y-17-",")");
            str = str.Replace("-Y-Y-Y-18-","*");
            str = str.Replace("-Y-Y-Y-19-","~");
            str = str.Replace("-Y-Y-Y-20-","`");
            str = str.Replace("-Y-Y-Y-21-","$" );
            str = str.Replace("-Y-Y-Y-22-", "=");
            str = str.Replace("-Y-Y-Y-23-", "+");
            return str;
        }
        public static string EnCode(this string str)
        {
            if (!str.HasValue()) return "";
            str =  str.Replace(",", "-Y-Y-Y-0-");
            str = str.Replace("'", "-Y-Y-Y-1-");
            str = str.Replace(";", "-Y-Y-Y-2-");
            str = str.Replace(":", "-Y-Y-Y-3-");
            str = str.Replace("/", "-Y-Y-Y-4-");
            str = str.Replace("?", "-Y-Y-Y-5-");
            str = str.Replace("<", "-Y-Y-Y-6-");
            str = str.Replace(">", "-Y-Y-Y-7-");
            str = str.Replace(".", "-Y-Y-Y-8-");
            str = str.Replace("#", "-Y-Y-Y-9-");
            str = str.Replace("%", "-Y-Y-Y-10-");
            str = str.Replace("%", "-Y-Y-Y-12-");
            str = str.Replace("^", "-Y-Y-Y-13-");
            str = str.Replace("//", "-Y-Y-Y-14-");
            str = str.Replace("@", "-Y-Y-Y-15-");
            str = str.Replace("(", "-Y-Y-Y-16-");
            str = str.Replace(")", "-Y-Y-Y-17-");
            str = str.Replace("*", "-Y-Y-Y-18-");
            str = str.Replace("~", "-Y-Y-Y-19-");
            str = str.Replace("`", "-Y-Y-Y-20-");
            str = str.Replace("$", "-Y-Y-Y-21-");
            str = str.Replace("=", "-Y-Y-Y-22-");
            str = str.Replace("+", "-Y-Y-Y-23-");

            
            return str;
        }

        public static string Encrypt(this string src)
        {//编码后
            return EncryptUtility.Encode("" + src).EnCode(); //.Replace("=","-equl-").Replace("/", "-sprit-").Replace("+", "-add-"); 
        }
        public static string Decrypt(this string src)
        {//解码前
            return EncryptUtility.Decode(src.DeCode());//.Replace("-equl-", "=").Replace("-sprit-", "/").Replace("-add-", "+"));
        }

        public static string ToBigCamelCase(this string src,char flag='_')
        {         
            return StringUtility.ToCamelCase(src,flag, false );
        }
        public static string ToSmallCamelCase(this string src, char flag = '_')
        {
            return StringUtility.ToCamelCase(src, flag, true);
        }
        public static Dictionary<string, T>ToDictionary <T>(this string jsonString) where T : class
        {
            var dictionary = new Dictionary<string, T>();

            var obj = JsonUtility.Deserialize<dynamic>(jsonString);
            var t = obj.GetType();
            if (t != typeof (JObject))
            {
                throw new NotSupportedException("不支持转换该类型的数据" + t);
            }
            var jObj = (JObject) obj;
            var properties = jObj.Properties();
            foreach (var p in properties)
            {
                dictionary.Add(p.Name, (p.Value + "") as T);
            }
            return dictionary;
        }
    }
}
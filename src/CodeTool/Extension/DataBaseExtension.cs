using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Tools.CommonExtendMethods;
using System.Configuration;
using System.Data.SqlClient;

namespace CodeTool.Extension
{
   public static class DataBaseExtension
    {
       private static string connStr
       {
           get { return ConfigurationManager.ConnectionStrings["qx.system"].ConnectionString; }
       }
        /// <summary>
        /// 返回查询内容
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
       public static List<List<string>> ExecuteQuery(this string sql)
       {
           return sql.ExecuteReader2(connStr);

       }
    }
}

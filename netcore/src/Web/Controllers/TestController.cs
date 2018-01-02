using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xyj.core;
using xyj.core.Extensions;
using xyj.core.Utility;

namespace Web.Controllers
{
    public class TestController : Controller
    {

        #region 测试脚本
        private string sqlDropTable =
@"delete from Test_Persons";

        private string sqlCreateTable=
@"CREATE TABLE Test_Persons
(
Id_P int,
Name varchar(255),
Age varchar(255)
)";
        private string sqlInsertTable =@"insert into Test_Persons (Id_P,Name,Age) values( '1001', '小熊', '18')";
        private string sqlSelectTable = @"select * from Test_Persons";
        string  _Show(string tip,string connString, ClientType type)
        {
           var result = tip +"\n";
            var list = sqlSelectTable.ExecuteReader(connString, type);
            foreach (var item in list)
            {
                result += ($"Id_P：{item[0]} Name：{item[1]} Age：{item[2]} \n");
            }
            return result;
        }
        string Show(string connString, ClientType type)
        {
            string result = "";
            sqlDropTable.ExecuteNonQuery(connString, type);
            sqlCreateTable.ExecuteNonQuery(connString, type);
            result += _Show("写入前", connString, type);
            sqlInsertTable.ExecuteNonQuery(connString, type);
            result += _Show("写入后", connString, type);
            return result;
        }
        #endregion

        public IActionResult Db()
        {
            string result = "";
            var mySqlConnString = DbUtility.MySqlConnString("47.92.109.79", "test", "admin", "admin");
            var sqlSeverConnString = DbUtility.SqlSeverConnString();
            //var oracleConnString = DbUtility.OracleConnString("47.92.109.79", "orcl", "panda", "QxamoySQL666");

            result += Show(mySqlConnString, ClientType.MySql);
            result += "\n\n";
            result += Show(sqlSeverConnString, ClientType.SqlSever);
            result += "\n\n";
            //result += Show(oracleConnString, ClientType.Oracle);
            return Content(result);
        }

    
    }
}
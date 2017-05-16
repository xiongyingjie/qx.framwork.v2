using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qx.permmision.v2.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Exceptions.Form;

namespace Test
{
    class Program
    {
     
         static string Sql_Query_Template(string sql, int pageIndex, int perCount)
        {
            sql = sql.ToLower();
             sql = sql.ReplaceFirst("select", "select IDENTITY(INT,1,1) as 序号,").
                 ReplaceFirst("from", " into #TEMPTABLE from ", sql.Contains("#from") ? "#" : "");


            sql += string.Format(@"
                select top {0} * from #TEMPTABLE where 序号>(({1}-1)*{0})
                DROP TABLE #TEMPTABLE;", perCount, pageIndex);
            return sql;
          
        }
        static void Main(string[] args)
        {
            // Console.Write("角色ID#ll^[0-9]*$#rr".PickUp("#ll", "#rr"));
            try
            {
                var db = new MyContext();
                var role = (new role() {name = "test", role_id = DateTime.Now.Random()});
                db.SaveAdd(role);
            }
            catch (FormValitationException ex)
            {
                Console.Write(ex.ValidationErrors.FirstOrDefault().ErrorMessage);
            }
             
        }
    }
}

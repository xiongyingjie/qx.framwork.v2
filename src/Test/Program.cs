using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Tools.CommonExtendMethods;
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
            Console.Write(Sql_Query_Template(@"
select 
StuClass.StuClassID as 班级ID,
StuClassName as 班级名称,
BatchID as 迎新批次,
count(StuClass_NewStudent.StuClassID) as 总人数
from StuClass,StuClass_NewStudent 
where StuClass.StuClassID=StuClass_NewStudent.StuClassID
group by StuClass_NewStudent.StuClassID,StuClassName,BatchID,StuClass.StuClassID

", 1,10));
        }
    }
}

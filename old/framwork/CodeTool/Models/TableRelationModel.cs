using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyj.tool.Models
{
   public class TableRelationModel: TableModel
    {
        public string ColumName { get; set; }
        public string ColumNote { get; set; }
        public string ForeginColumName { get; set; }
        public string ForeginTableName { get; set; }
       public override string ToString()
       {
            return string.Format("{0}.{1}={2}.{3} and", TableName,
                 ColumName, ForeginTableName, ForeginColumName);
        }
        public  string ToJsString()
        {
            return string.Format(".jn('{0}.{1}','{2}.{3}')", TableName,
                 ColumName, ForeginTableName, ForeginColumName);
        }
    }
}

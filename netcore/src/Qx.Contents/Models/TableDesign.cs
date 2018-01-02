using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Qx.Contents.Models
{
    public class TableDesign
    {
        [Key]
        public string TableID { get; set; }

        public string TypeID { get; set; }
        public string TypeName { get; set; }
        public string TableName { get; set; }
        public IEnumerable<TableColumn> Columns { get; set; }
    }
}
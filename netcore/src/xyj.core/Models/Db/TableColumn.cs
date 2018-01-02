using System.Collections.Generic;

namespace xyj.core.Models.Db
{
    public class TableColumn
    {
        public TableColumn(List<string> item)
        {
            GUID = item[0];
            ColumName = item[1];
            ColumNote = item[2];
            TableName = item[3];
            IsPrimaryKey = bool.Parse(item[5]);
            Type = item[6]; ;
            Length = item[7]; ;
            CanNull = bool.Parse(item[8]);

        }
        public string GUID { get; set; }
        public string TableName { get; set; }
        public string Type { get; set; }
        public string Length { get; set; }
        public bool CanNull { get; set; }
        public string DefaultValue { get; set; }
        public string ForeignKey { get; set; }
        public string ForeignTable { get; set; }
        public string ColumName { get; set; }
        public bool IsPrimaryKey { get; set; }

        public string ColumNote { get; set; }
    }
}
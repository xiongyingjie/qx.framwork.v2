using System.ComponentModel.DataAnnotations;

namespace CodeTool.V2.Entity
{
    public partial class report_data
    {
        [Key]

        public string ReportID { get; set; }


        public string ReportName { get; set; }


        public string SqlStr { get; set; }

 
        public string HeadFields { get; set; }

        public int RecordsPerPage { get; set; }

        public string ParaNames { get; set; }

        public string ColunmToShow { get; set; }

        public string OperateColum { get; set; }

        public string ReportLog { get; set; }
    }
}

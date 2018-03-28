namespace xyj.tool.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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

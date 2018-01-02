using System.Collections.Generic;
using xyj.core.Exceptions.Report;

namespace xyj.core.Models.Report
{
    public class ReportModel
    {
        public string ReportID { get; set; }


        public string ReportName { get; set; }


        public string SqlStr { get; set; }
        public string FinalSqlStr { get; set; }


        public string HeadFields { get; set; }

        public int RecordsPerPage { get; set; }


        public string ParaNames { get; set; }


        public string ColunmToShow { get; set; }


        public string OperateColum { get; set; }
        public string ReportLog { get; set; }


        public static ReportModel ToReport(List<List<string>> list)
        {
            if (list.Count == 0)
            {
                throw new ReportNotFoundException("报表不存在");
            }
            var dest = new ReportModel();
            var cols = list[0];
            dest.ReportID = cols[0];
            dest.ReportName = cols[1];
            dest.SqlStr = cols[2];
            dest.HeadFields = cols[3];
            dest.RecordsPerPage = int.Parse(cols[4]);
            dest.ParaNames = cols[5];
            dest.ColunmToShow = cols[6];
            dest.OperateColum = cols[7];
            dest.ReportLog = cols[8];
            return dest;
        }
    }
}
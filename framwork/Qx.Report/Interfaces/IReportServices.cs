using System.Collections.Generic;
using Qx.Tools.Models.Report;

namespace Qx.Report.Interfaces
{
    public interface IReportServices
    {
        bool Add(ReportModel model);
        bool Update(ReportModel model);
        bool Delete(string id);
       ReportModel GetReprot(string id);

        string ToExcel(string id, string parms, string templateFileDir, string outputFileDir,
            List<List<string>> dataRows, int pageIndex = 1, int perCount = 10);

        List<List<string>> ToHtml(string id, string parms, List<List<string>> dataRows, int pageIndex = 1, int perCount = 10);
        List<List<string>> GetDbDataSource(string id, string parms, string dbConnStringKey, int pageIndex = 1, int perCount = 10);
        string ToExcel(string id, string parms, string templateFileDir, string outputFileDir, string dbConnStringKey, int pageIndex = 1, int perCount = 10);
        List<List<string>> ToHtml(string id, string parms, string dbConnStringKey, int pageIndex = 1, int perCount = 10);
        List<List<string>> CrossDb(string id, string parms, List<List<string>> dataRows, List<CrossDbParam> paramList, int pageIndex = 1, int perCount = 10);
        List<List<string>> Test(ReportModel report, string parms, string dbConnStringKey, int pageIndex = 1, int perCount = 10);
        ReportViewModel ToView(string id, string parms, string dbConnStringKey, int pageIndex = 1, int perCount = 10);

    }
}
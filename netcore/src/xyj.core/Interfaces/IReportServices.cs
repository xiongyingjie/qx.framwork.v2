using System.Collections.Generic;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.core.Interfaces
{
    public interface IReportServices : IAutoInject
    {
        bool Add(ReportModel model);
        bool Update(ReportModel model);
        bool Delete(string id);
       ReportModel GetReprot(string id);
        //导出excel
        string ToExcel(string id, string parms, string templateFileDir, string outputFileDir,
            List<List<string>> dataRows, int pageIndex = 1, int perCount = 10);
        #region old
        List<List<string>> ToHtml(string id, string parms, List<List<string>> dataRows, int pageIndex = 1, int perCount = 10);
        List<List<string>> GetDbDataSource(string id, string parms, string dbConnStringKey, int pageIndex = 1, int perCount = 10);
#endregion
        string ToExcel(string id, string parms, string templateFileDir, string outputFileDir, string dbConnStringKey, int pageIndex = 1, int perCount = 10);
        List<List<string>> ToHtml(string id, string parms, string dbConnStringKey, int pageIndex = 1, int perCount = 10);
        List<List<string>> CrossDb(string id, string parms, List<List<string>> dataRows, List<CrossDbParam> paramList, int pageIndex = 1, int perCount = 10);
        List<List<string>> Test(ReportModel report, string parms, string dbConnStringKey, int pageIndex = 1, int perCount = 10);
        ReportViewModel ToView(string id, string parms, string dbConnStringKey, int pageIndex = 1, int perCount = 10,string filterScript = "");
        ReportViewModel ToView(string id, string parms, List<List<string>> dataSource, int pageIndex = 1, int perCount = 10, string filterScript = "");

    }
}
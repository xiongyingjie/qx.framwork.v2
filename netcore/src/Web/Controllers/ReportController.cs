using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;
using xyj.acs.Interfaces;
using xyj.core;
using xyj.core.Exceptions.Upgrate;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Http;
using xyj.core.Utility;


namespace Web.Controllers
{
    public class ReportController : BaseController
    {
        // GET: Report
         private readonly IReportServices _reportServices;
        private readonly IAcsService _permmisionService;
        public ReportController( IAcsService permmisionService, IReportServices reportServices1)
        {
            _permmisionService = permmisionService;
            _reportServices = reportServices1;
        }

        //Report/Report2
        //[HttpPost]
        public IActionResult Report2(string ReportID, string Params,string dataSourceUrl,
         string dbConnStringKey,string filterId, int pageIndex= 1, int perCount = 10)
        { 
           
            //获取用户权限列表
            var list = _permmisionService.GetFilterByUserId(DataContext.UserId, ReportID);
            var filter = "#all";//未配置数据权限时 默认取所有数据
            if (list.Any())
            {
                filter = list[0].filter_script;
            }
            //过滤脚本
            //1=1
            //#self
            //unitid in 
            var filterScript = filter.Replace("#self", "uid='" + DataContext.UserId + "'").
                Replace("#all", "1=1").
                Replace("#unit", "unit_id in (" + _permmisionService.GetOrgIdByUserId(DataContext.UserId).Select(a => "'" + a + "'").ToList().PackString(',') + ")");
            var config = dataSourceUrl.HasValue() ?
                  _reportServices.ToView(ReportID, Params, new HttpClinetUtility(HttpContext) .HttpGet< List<List<string>>>(GeRootUrl(dataSourceUrl)), pageIndex, perCount, filterScript) :
                  _reportServices.ToView(ReportID, Params, dbConnStringKey, pageIndex, perCount, filterScript);
            config.DataFilter = list;
            config.pageParam.uid = DataContext.UserId;
            return Json(State.Success, config, false);
        }
        private string ToVirtualPath(string path)
        {
            throw new NotSupportedExceptionInCoreException();
            //string tmpRootDir = Server.MapPath(Request.ApplicationPath);//获取程序根目录  
            //string path2 = path.Replace(tmpRootDir, ""); //转换成相对路径  
            //path2 = path2.Replace(@"\", @"/");
            //return path2;
        }
        public IActionResult ReportToExcel2(string ReportID, string Params, string dataSourceUrl, string dbConnStringKey, int pageIndex = 1, int perCount = 99999)
        {
            //获取用户权限列表
            var list = _permmisionService.GetFilterByUserId(DataContext.UserId, ReportID);
            var filter = "#all";//未配置数据权限时 默认取所有数据
            if (list.Any())
            {
                filter = list[0].filter_script;
            }
            //过滤脚本
            //1=1
            //#self
            //unitid in 
            var filterScript = filter.Replace("#self", "uid='" + DataContext.UserId + "'").
                Replace("#all", "1=1").
                Replace("#unit", "unit_id in (" + _permmisionService.GetOrgIdByUserId(DataContext.UserId).Select(a => "'" + a + "'").ToList().PackString(',') + ")");
            var config = dataSourceUrl.HasValue() ?
                _reportServices.ToView(ReportID, Params, new HttpClinetUtility(HttpContext).HttpGet<List<List<string>>>(GeRootUrl(dataSourceUrl)), pageIndex, perCount, filterScript) :
                _reportServices.ToView(ReportID, Params, dbConnStringKey, pageIndex, perCount, filterScript);
            config.DataFilter = list;
            config.pageParam.uid = DataContext.UserId;

            return Json(State.Success, config.tableBody.AddRowToFirst(config.header), false);
        }

        //导入模板
        public IActionResult ExcelTemplate( string ReportID)
        {
            var report = _reportServices.GetReprot(ReportID);

            //var outputDir = GetProjectDir("UserFiles\\Report\\" + uid+"_template_" + report.ReportID+ "\\");
            //if (!Directory.Exists(outputDir))
            //{
            //    Directory.CreateDirectory(outputDir);
            //}
            //var excel = new ExcelUtility(new List<List<string>>().AddRowToFirst(report.HeadFields.UnPackString(';')),
            //    GetProjectDir("UserFiles\\Report\\Template.xlsx"),
            //   outputDir + report.ReportName + "_Template.xlsx").ToExcel();
            //return Json(State.Success, new { path = ToVirtualPath(excel.FullName) });

            return Json(State.Success, new List<List<string>>().AddRowToFirst(report.HeadFields.UnPackString(';')), false);
           
           // return File(ToVirtualPath(excel.FullName), "application/vnd.ms-excel", Url.Encode(report.ReportName + "_Template.xlsx"));
          
        }



        

    }
}
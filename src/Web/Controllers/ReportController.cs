using System.Collections.Generic;
using System.Web.Mvc;
using Qx.Report.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;
using Web.ViewModels.Report;

namespace Web.Controllers
{
    public class ReportController : BaseController
    {
        // GET: Report
         private readonly IReportServices reportServices;
         public ReportController(IReportServices reportServices)
        {
            this.reportServices = reportServices;
        }

         //Report/Index?ReportID=System&Params=;
        public ActionResult Index(string ReportID , string Params , int pageIndex=1, int perCount=10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Index", new { ReportID = "System", Params = ";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("报表ID");
            InitReport("报表引擎", "/Report/Add",  "", true, "Qx.System");
             return ReportView();
        }
        public ActionResult Add()
        {
            InitForm("添加报表");
            return View(new Add_M() {RecordsPerPage = 10});
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Add_M model)
        {
            if (ModelState.IsValid)
            {
                if (reportServices.Add(model.ToModel()))
                    return RedirectToAction("Index");
                else
                {
                    return Alert("添加失败", -1);
                }
            }
            else
            {
                InitForm("添加报表");
                return View(model);
            }
           
        }
        public ActionResult Edit(string id)
        {
            InitForm("编辑报表");
            return View(Edit_M.ToViewModel(reportServices.GetReprot(id)));
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Edit_M model)
        {
            if (ModelState.IsValid)
            {
                if (reportServices.Update(model.ToModel()))
                    return RedirectToAction("Index");
                else
                {
                    return Alert("保存失败", -1);
                }
            }
            else
            {
                InitForm("编辑报表");
                return View(model);
            }
                
        }
        public ActionResult Delete(string id,string key="")
        {
            if (string.IsNullOrEmpty(key))
            {
                return   Alert("请输入删除确认码！", -1);
            }
            if (reportServices.Delete(id)& key=="1")
            {
                return Alert("删除成功");
            }
            else
            {
                return Alert("删除失败:报表不存在");
            }
        }
      
        public ActionResult Report(string ReportID, string Params, string ExtraParam, string AddLink, string Title, 
            int pageIndex, int perCount, List<List<string>> dataSource,bool showDeafultButton)
        {
            ViewData["ReportID"] = ReportID; ViewData["Params"] = Params;
            ViewData["AddLink"] = AddLink; ViewData["ExtraParam"] = ExtraParam;
            ViewData["Title"] = Title; ViewData["showDeafultButton"] = showDeafultButton;
            var table = dataSource;
            //计算maxPage
            InitCutPage(table, pageIndex, perCount);
            //var header = new List<string>(table[0]);
            //table.Remove(table[0]);
            //table = InitCutPage(table, pageIndex, perCount);
            //table.Insert(0, header);
            return PartialView(table);
        }
        //Report/Report2
        [HttpPost]
        public ActionResult Report2(string ReportID, string Params, List<List<string>> dataSource,
         string dbConnStringKey, int pageIndex = 1, int perCount = 10)
        {
            var config = dataSource==null ? 
                reportServices.ToView(ReportID, Params, dbConnStringKey, pageIndex, perCount) :
                reportServices.ToView(ReportID, Params, dataSource, pageIndex, perCount);
            return Json(config, JsonRequestBehavior.AllowGet);        
        }
        private string ToVirtualPath(string path)
        {
            string tmpRootDir = Server.MapPath(Request.ApplicationPath);//获取程序根目录  
            string path2 = path.Replace(tmpRootDir, ""); //转换成相对路径  
            path2 = path2.Replace(@"\", @"/");
            return path2;
        }
        public ActionResult ReportToExcel2(string ReportID, string Params, string dbConnStringKey, int pageIndex = 1, int perCount = 99999)
        {
            var path = reportServices.ToExcel(
                ReportID,
                Params,
                GetProjectDir("UserFiles\\Report\\Template.xlsx"),
                GetProjectDir("UserFiles\\Report\\报表.xlsx"),
                dbConnStringKey);
           return Content("/"+ToVirtualPath(path));
            //return Content(path,
            //    "application/zip-x-compressed", "报表.xlsx"
            //    );
        }
        public ActionResult ReportToExcel(string ReportID, string Params, List<List<string>> dataSource)
        {
            return File((reportServices.ToExcel(
                ReportID, 
                Params,
                GetProjectDir("UserFiles\\Report\\Template.xlsx"), 
                GetProjectDir("UserFiles\\Report\\报表.xlsx"),
                dataSource)),
                "application/zip-x-compressed", "报表.xlsx"
                ) ;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Report.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Models;
using Web.Controllers.Base;
using Web.ViewModels.Demo;
using Qx.Tools.Models.Report;

namespace Web.Controllers
{
    public class F2DemoController : BaseController
    {
        private readonly IReportServices _reportServices;

        public F2DemoController(IReportServices reportServices)
        {
            this._reportServices = reportServices;
        }

        // GET: F2Demo/map
        public ActionResult Map()
        {
            InitLayout("地图展示");
            return View();
        }

        // GET: /F2Demo/FormView
        public ActionResult FormView()
        {
            InitFormView("查看页面");
            return View(Form_M.ToViewModel(1, "默认每行3个", DateTime.Now, 1.23f, 2.42343243432434d, 'a'));

        }

        // GET: /F2Demo/ReportDemo
        public ActionResult ReportDemo(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("ReportDemo",
                    new {ReportID = "demo", Params = ";", pageIndex = 1, perCount = 10});
            }
            Search.Add("在控制器中调用 Search.Add(测试提示, FormControlType.Tip); 可以显示我", FormControlType.Tip);
            Search.Add("点击去百度", FormControlType.Button, "http://baidu.com");
            Search.Add("用户id");
            Search.Add("性别", new List<DropDownListItem>()
            {
                new DropDownListItem() {text = "男", value = "1"},
                new DropDownListItem() {text = "女", value = "2"}
            });
            Search.Add("注册时间", FormControlType.DateTime);
            Search.Add("日志", FormControlType.TextArea,
                "我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志我是日志");
            Search.Add("注册时间2", FormControlType.DateTime, "2017-08-06 17:47");
            InitReport("ReportDemo(后端分页)", "#", "", true, "Qx.System");
            return View();
        }


       

      

    }
}
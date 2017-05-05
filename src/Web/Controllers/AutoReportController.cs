using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;


namespace Web.Controllers
{
     
    public class AutoReportController : BaseController
    {


        ///AutoReport/UserList
        public ActionResult UserList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserList",
                    new
                    {
                        reportId = "qx.permmision.v2.T3P.N2Y3V8SHWZ.ZNV.demo.demo.demo.demo.demo.用户列表",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            Search.Add("用户名称");
            InitReport("demo.用户列表", "#", "", true, "qx.permmision.v2");
            return ReportView();
        }

    }
}
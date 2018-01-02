using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;

namespace Web.Areas.Core.Controllers
{
    public class ReportController : BaseController
    {
        // GET: Core/Report
        ///Report/index
        public ActionResult index(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("index",
                    new
                    {
                        reportId = "qx.system.RDY.报表列表",
                        Params = ";;",
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            Search.Add("报表编号");
            Search.Add("报表名称");
            InitReport("报表列表", "/core/report/reportAdd", "", true, "qx.system");
            return ReportJson();
        }



    }
}
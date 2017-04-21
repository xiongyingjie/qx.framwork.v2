using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class TableController : AccountFilterController
    {
        // GET: Table
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Table(List<string> header, List<List<string>> body,string config,string colunmToShow)
        {
            var data = body.AddRowToFirst(header);
            return PartialView(data);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.WorkFlow.Controllers
{
    public class HomeController : BaseWorkFlowController
    {
        // GET: WorkFlow/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
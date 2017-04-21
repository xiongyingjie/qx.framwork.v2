using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.WorkFlow.Controllers
{
    public class AdminController : BaseWorkFlowController
    {
        // GET: WorkFlow/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Contents.Controllers;

namespace Web.Areas.Contents.Controllers
{
    public class AdminController : BaseContentsController
    {
        // GET: Member/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}
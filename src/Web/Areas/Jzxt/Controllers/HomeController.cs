using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Jzxt.Controllers
{
    public class HomeController : BaseJzxtController
    {
        // GET: Jzxt/Home
        public ActionResult Index()
        {
            InitForm("欢迎~");
            return View();
        }
    }
}
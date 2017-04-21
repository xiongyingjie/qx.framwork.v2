using Qx.Tools.CommonExtendMethods;
using System.Web.Mvc;
using Web.Areas.WeChat.Controllers;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class HomeController : AccountFilterController
    {
        
        //    /Home/Index
        public ActionResult Index()
        {
            InitAdminLayout("首页");
            //return RedirectToAction("Index", "Account");
             return View();
        }

        public ActionResult FlotCharts()
        {
            return View("FlotCharts");
        }

        public ActionResult MorrisCharts()
        {
            return View("MorrisCharts");
        }

        public ActionResult Tables()
        {
            return View("Tables");
        }

        public ActionResult Forms()
        {
            return View("Forms");
        }

        public ActionResult Panels()
        {
            return View("Panels");
        }

        public ActionResult Buttons()
        {
            return View("Buttons");
        }

        public ActionResult Notifications()
        {
            return View("Notifications");
        }

        public ActionResult Typography()
        {
            return View("Typography");
        }

        public ActionResult Icons()
        {
            return View("Icons");
        }

        public ActionResult Grid()
        {
            return View("Grid");
        }

        public ActionResult Blank()
        {
            return View("Blank");
        }

        public ActionResult Login()
        {
            return View("Login");
        }
        public ActionResult Error()
        {
            InitLayout("未授权！");
            return View();
        }
    }
}
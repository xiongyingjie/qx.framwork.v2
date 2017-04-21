using Qx.Msg.Interfaces;
using Qx.Tools.CommonExtendMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Web.Areas.Msg.ViewModels.AddContacter;

namespace Web.Areas.Msg.Controllers.Controllers
{
    public class MyContactsController : BaseMsgController
    {
        private IMsgService _service;
        public MyContactsController(IMsgService service)
        {
            _service = service;
        }
        // GET: Msg/MyContacts/MyContactsList
        public ActionResult MyContactsList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("MyContactsList", new { ReportID = "QX.Msg.我的联系人3", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport(_service.MyContacter(DataContext.UserID, Params), "我的联系人3", "AddContacter");
            return View();
        }
        public ActionResult AddContacter()
        {
            InitForm("添加联系人");
            return View();
        }

        // POST: Msg/MyContacts/AddContacter
        [HttpPost]
        public ActionResult AddContacter(string membersId)
        {
            var onwerId = DataContext.UserID;
            if (ModelState.IsValid)
            {
                _service.AddContacter(onwerId, membersId);
                return RedirectToAction("MyContactsList", "MyContacts", new { areas = "Msg" });
            }
            else
            {
                InitForm("添加联系人");
                return View();
            }


        }

    }
}
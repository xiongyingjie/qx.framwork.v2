using Qx.Msg.Interfaces;
using Qx.Tools.CommonExtendMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Msg.Controllers.Controllers
{
    public class MyOutBoxController : BaseMsgController
    {
        // GET: Msg/MyOutBox
        private IMsgService _repository;
        public MyOutBoxController(IMsgService repository)
        {
            _repository = repository;
        }
        // GET: Msg/MyOutBox/MyOutBoxMsgList
        public ActionResult MyOutBoxMsgList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("MyOutBoxMsgList", new { ReportID = "QX.Msg.我的发件箱3", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport(_repository.MyOutBoxMsg(DataContext.UserID, Params), "我的发件箱3", "ContacterAdd");
            return View();
        }
    }
}
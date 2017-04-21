using Qx.Msg.Interfaces;
using Qx.Msg.Services;
using Qx.Tools.CommonExtendMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Msg.Controllers
{
    public class MsgInterfaceTestController : BaseMsgController
    {
      
        private IMsgService _repository;
        public MsgInterfaceTestController(IMsgService repository)
        {
            _repository = repository;
        }
        // GET: Msg/MsgInterfaceTest/Index
        public ActionResult Index(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Index", new { ReportID = "QX.MSg.我的通讯录", Params = Params, pageIndex = 1, perCount = 10 });
            }
            InitReport(_repository.MyContacter(DataContext.UserID, Params), "我的通讯录", "ContacterAdd");
            return View();
        }

    }
}
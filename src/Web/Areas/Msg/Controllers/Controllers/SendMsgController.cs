using Qx.Msg.Entity;
using Qx.Msg.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Msg.ViewModels.SendMsg;

namespace Web.Areas.Msg.Controllers.Controllers
{
    public class SendMsgController : BaseMsgController
    {
        private IMsgService _service;
        public SendMsgController(IMsgService service)
        {
            _service = service;
        }
        // GET: Msg/SendMsg/SendMsg
        public ActionResult SendMsg()
        {
            InitForm("发送消息");
            return View();
        }

        // POST: Msg/SendMsg/SendMsg
        [HttpPost]
        public ActionResult SendMsg(string ReceiverID, string Subjects, string Contents, string SenderID)
        {
            SenderID = DataContext.UserID;

                if (ModelState.IsValid)
                {
                    _service.SendMsg( ReceiverID, Subjects,  Contents,  SenderID);
                    return RedirectToAction("MyOutBoxMsgList", "MyOutBox", new {areas= "Msg" });
                }
                else
                {
                    InitForm("发送消息");
                    return View();
                }


        }
    }
}
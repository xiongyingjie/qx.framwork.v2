using Qx.Msg.Exceptions;
using Qx.Msg.Interfaces;
using Qx.Tools.CommonExtendMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Areas.Msg.Controllers
{
    public class OpenController : BaseController
    {
        // GET: Msg/Open
        private IMsgService _service;
        private IMsgProvider _provider;
        public OpenController(IMsgProvider provider,IMsgService service)
        {
            _service = service;
            _provider = provider;
        }
        // GET: Msg/Open/MyInBoxMsgList1

        public ActionResult MyInBoxMsgList1(string uid)
        {
            if (!uid.HasValue())
            {
                return Json(new { data = "uid不能为空" }, JsonRequestBehavior.AllowGet);
            }
        
            var  msgs= _service.MyInBoxMsg(uid);
            return Json(new { data = msgs } ,JsonRequestBehavior.AllowGet);
        }
        // GET: Msg/Open/MsrkIsRead
        public ActionResult MsrkIsRead(string uid,string msgId)
        {
            if (!uid.HasValue()|| !msgId.HasValue())
            {
                return Json(new { data = "uid和msgId不能为空" }, JsonRequestBehavior.AllowGet);
            }
            var inboxMmsg = _service.ReadMyInboxMsg(uid, msgId);
               return Json(new { data = inboxMmsg }, JsonRequestBehavior.AllowGet);   
        }
        [HttpPost]
        public ActionResult SendSms(string mobile, string name)
        {

            if (!mobile.HasValue())
            {
                return Json(new
                {
                    state = "200",
                    msg = "请输入手机",
                    data = "",
                }, JsonRequestBehavior.AllowGet);
            }
            try
            {
                var result = _provider.SendSms(mobile, name);
                //注意:请勿随意发送，本接口每调用一次会被收费!
                return Json(new
                {
                    state = "200",
                    msg = "短信验证",
                    data = result,
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    state = "400",
                    msg = ex,
                    data = "",
                }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult CheckSms(string requestId, string code)
        {
            try
            {
                var codeIsTrue = _provider.CheckSms(requestId, code);
                return Json(new
                {
                    state = "200",
                    msg = "短信验证",
                    data = codeIsTrue,
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (ex is CodeOutOfDateException)
                {
                    return Json(new
                    {
                        state = "404",
                        msg = "验证码超时",
                        data = ex.Message,
                    }, JsonRequestBehavior.AllowGet);
                }
                else if (ex is ErrorTimeMoreThan3Exception)
                {
                    return Json(new
                    {
                        state = "404",
                        msg = "错误输入超过三次",
                        data = ex.Message,
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        state = "404",
                        msg = "requestId错误",
                        data = ex.Message,
                    }, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}
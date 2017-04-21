using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Qx.Wechat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.WeChat.Controllers;
using Web.Controllers.Base;

namespace Web.Areas.WeChat.Controllers
{
    public class AdminController : BaseWeChatController
    {
        private IRepository<ImageMsg> _ImageMsg;
        private IRepository<LinkMsg> _linkMsg;
        private IRepository<TextMsg> _TextMsg;
        private IRepository<LocationMsg> _locationMsg;
        private IRepository<ShortVideoMsg> _ShortVideoMsg;
        private IRepository<VideoMsg> _VideoMsg;
        private IRepository<VoiceMsg> _VoiceMsg;
        private IRepository<LocationEvent> _LocationEvent;
        private IRepository<MenuEvent> _MenuEvent;
        private IRepository<SubscribeEvent> _SubscribeEvent;
        public AdminController(IRepository<TextMsg> TextMsg, IRepository<VideoMsg> VideoMsg, IRepository<VoiceMsg> VoiceMsg, IRepository<ShortVideoMsg> ShortVideoMsg,
            IRepository<LocationMsg> locationMsg, IRepository<LinkMsg> linkMsg, IRepository<ImageMsg> ImageMsg, IRepository<LocationEvent> LocationEvent, IRepository<MenuEvent> MenuEvent, IRepository<SubscribeEvent> SubscribeEvent)
        {
            _TextMsg = TextMsg;
            _VideoMsg = VideoMsg;
            _ShortVideoMsg = ShortVideoMsg;
            _locationMsg = locationMsg;
            _linkMsg = linkMsg;
            _ImageMsg = ImageMsg;
            _VoiceMsg = VoiceMsg;
            _LocationEvent = LocationEvent;
            _MenuEvent = MenuEvent;
            _SubscribeEvent = SubscribeEvent;
        }
        // GET: /WeChat/Admin
        public ActionResult Index()
        {
            InitMenu(new Dictionary<string, string>() {
                {"图片消息", "/WeChat/Admin/ImageMsgs?ReportID=Qx.WeChat.图片消息&Params=;"},
                {"链接消息", "/WeChat/Admin/LinkMsgs?ReportID=Qx.WeChat.链接消息&Params=;"},
                {"位置事件", "/WeChat/Admin/LocationEvents?ReportID=Qx.WeChat.位置事件&Params=;"},
                {"位置消息", "/WeChat/Admin/LocationMsgs?ReportID=Qx.WeChat.位置消息&Params=;"},
                {"菜单事件", "/WeChat/Admin/MenuEvents?ReportID=Qx.WeChat.菜单事件&Params=;"},
                {"短视频消息", "/WeChat/Admin/ShortVideoMsgs?ReportID=Qx.WeChat.短视频消息&Params=;"},
                {"认购事件", "/WeChat/Admin/SubscribeEvents?ReportID=Qx.WeChat.认购事件&Params=;"},
                {"文本消息", "/WeChat/Admin/TextMsgs?ReportID=Qx.WeChat.文本消息&Params=;"},
                {"视频消息", "/WeChat/Admin/VideoMsgs?ReportID=Qx.WeChat.视频消息&Params=;"},
                {"语音消息", "/WeChat/Admin/VoiceMsgs?ReportID=Qx.WeChat.语音消息&Params=;"},
                {"回复图片消息", "/WeChat/ReplyImageMsg?ReportID=Qx.WeChat.回复图片消息&Params=;"},
                {"回复音乐消息", "/WeChat/ReplyMusicMsg?ReportID=Qx.WeChat.回复音乐消息&Params=;"},
                {"回复图文消息", "/WeChat/ReplyNewsMsg?ReportID=Qx.WeChat.回复图文消息&Params=;"},
                {"回复文本消息", "/WeChat/ReplyTextMsg?ReportID=Qx.WeChat.回复文本消息&Params=;"},
                {"回复视频消息", "/WeChat/ReplyVideoMsg?ReportID=Qx.WeChat.回复视频消息&Params=;"},
                {"回复语音消息", "/WeChat/ReplyVoiceMsg?ReportID=Qx.WeChat.回复语音消息&Params=;"},
                {"新图片消息", "/WeChat/NewsMsgItem?ReportID=Qx.WeChat.新图文消息&Params=;"},
                {"回复设置", "/WeChat/ReplySetup?ReportID=Qx.WeChat.回复设置&Params=;"}
            });
            return View();
        }
        public ActionResult ImageMsgs(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("ImageMsgs", new { reportId = "Qx.WeChat.图片消息", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("图片消息", "#");
            return View();
        }
        public ActionResult LinkMsgs(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("LinkMsgs", new { reportId = "Qx.WeChat.链接消息", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("链接消息", "#");
            return View();
        }
        public ActionResult LocationMsgs(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("LocationMsgs", new { reportId = "Qx.WeChat.位置消息", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("位置消息", "#");
            return View();
        }
        public ActionResult ShortVideoMsgs(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("ShortVideoMsgs", new { reportId = "Qx.WeChat.短视频消息", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("短视频消息", "#");
            return View();
        }
        public ActionResult TextMsgs(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("TextMsgs", new { reportId = "Qx.WeChat.文本消息", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("文本消息", "#");
            return View();
        }
        public ActionResult VideoMsgs(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("VideoMsgs", new { reportId = "Qx.WeChat.视频消息", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("视频消息", "#");
            return View();
        }
        public ActionResult VoiceMsgs(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("VoiceMsgs", new { reportId = "Qx.WeChat.语音消息", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("语音消息", "#");
            return View();
        }

        public ActionResult LocationEvents(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("LocationEvents", new { reportId = "Qx.WeChat.位置事件", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("位置事件", "#");
            return View();
        }
        public ActionResult MenuEvents(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("MenuEvents", new { reportId = "Qx.WeChat.菜单事件", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("菜单事件", "#");
            return View();
        }
        public ActionResult SubscribeEvents(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("SubscribeEvents", new { reportId = "Qx.WeChat.认购事件", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("认购事件", "#");
            return View();
        }

        public ActionResult ImageMsgDelete(string msgid)
        {
            var msg = _ImageMsg.Find(msgid);
            if (msg != null)
            {
                _ImageMsg.Delete(msgid);
                return Alert("删除成功");
            }
            else
            {
                return Alert("删除失败");
            }
        }
        public ActionResult LinkMsgDelete(string msgid)
        {
            var msg = _linkMsg.Find(msgid);
            if (msg != null)
            {
                _linkMsg.Delete(msgid);
                return Alert("删除成功!");
            }
            else
            {
                return Alert("删除失败!");
            }
        }
        public ActionResult LocationMsgDelete(string msgid)
        {
            var msg = _locationMsg.Find(msgid);
            if (msg != null)
            {
                _locationMsg.Delete(msgid);
                return Alert("删除成功!");
            }
            else
            {
                return Alert("删除失败!");
            }
        }
        public ActionResult ShortVideoMsgDelete(string msgid)
        {
            var msg = _ShortVideoMsg.Find(msgid);
            if (msg != null)
            {
                _ShortVideoMsg.Delete(msgid);
                return Alert("删除成功!");
            }
            else
            {
                return Alert("删除失败!");
            }
        }
        public ActionResult VideoMsgDelete(string msgid)
        {
            var msg = _VideoMsg.Find(msgid);
            if (msg != null)
            {
                _VideoMsg.Delete(msgid);
                return Alert("删除成功!");
            }
            else
            {
                return Alert("删除失败!");
            }
        }
        public ActionResult TextMsgDelete(string msgid)
        {
            var msg = _TextMsg.Find(msgid);
            if (msg != null)
            {
                _TextMsg.Delete(msgid);
                return Alert("删除成功!");
            }
            else
            {
                return Alert("删除失败!");
            }
        }
        public ActionResult VoiceMsgDelete(string msgid)
        {
            var msg = _VoiceMsg.Find(msgid);
            if (msg != null)
            {
                _VoiceMsg.Delete(msgid);
                return Alert("删除成功!");
            }
            else
            {
                return Alert("删除失败!");
            }
        }

        public ActionResult LocationEventDelete(string eventid)
        {
            var Event = _LocationEvent.Find(eventid);
            if (Event != null)
            {
                _LocationEvent.Delete(eventid);
                return Alert("删除成功!");
            }
            else
            {
                return Alert("删除失败!");
            }
        }
        public ActionResult MenuEventDelete(string eventid)
        {
            var Event = _MenuEvent.Find(eventid);
            if (Event != null)
            {
                _MenuEvent.Delete(eventid);
                return Alert("删除成功!");
            }
            else
            {
                return Alert("删除失败!");
            }
        }
        public ActionResult SubscribeEventDelete(string eventid)
        {
            var Event = _SubscribeEvent.Find(eventid);
            if (Event != null)
            {
                _SubscribeEvent.Delete(eventid);
                return Alert("删除成功!");
            }
            else
            {
                return Alert("删除失败!");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qx.wechat.Interfaces;
using Web.Controllers.Base;

namespace Web.Areas.WeChat.Controllers
{
    public class TestController : BaseController
    {
        private IEntWechatServices _entWechatServices;

        public TestController(IEntWechatServices entWechatServices)
        {
            _entWechatServices = entWechatServices;
        }

        // GET: /WeChat/Test/Index?id=
        public ActionResult Index(string id= "xiongyingjie")
        {
            return Content(""+_entWechatServices.Send_Card_Msg(id,
                "BAIDU.COM",
                "领奖通知",
                "<div class='gray'>2017年9月16日</div> <div class='normal'>恭喜你抽中iPhone X一台，领奖码：xxxx</div><div class='highlight'>请于2017年10月10日前联系行政同事领取</div>"));
        }
        /*
         灰色(gray)
         高亮(highlight)
         默认黑色(normal)
         */
    }
}
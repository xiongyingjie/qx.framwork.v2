using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Qx.Wechat.Interfaces;

namespace Web.Areas.WeChat.Controllers
{
    public class TestController : Controller
    {
        private IWechatServices _wechatServices;

        public TestController(IWechatServices wechatServices)
        {
            _wechatServices = wechatServices;
        }

        private string test_uid = "oksMlwPF5Y1KQvoi8AklF-lUwnYQ";
        private string test_url = "http://baidu.com";
        // GET: WeChat/Test
        public ActionResult Index()
        {
            _wechatServices.Send_Finished_Order_Msg(test_uid, test_url,
                "detal", "panda", "phone", DateTime.Now.ToStr(), "");
            _wechatServices.Send_Receved_Order_Msg(test_uid, test_url,
                "detal", "poamda", "15502342");
            return View();
        }
    }
}
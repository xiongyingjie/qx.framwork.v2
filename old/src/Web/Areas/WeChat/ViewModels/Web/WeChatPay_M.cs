using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Qx.Tools.CommonExtendMethods;

namespace Web.Areas.WeChat.ViewModels.Web
{
    public class WeChatPay_M
    {
        public string _debug { get; set; }
        public string _appId { get; set; }
        public string _timestamp { get; set; }
        public string _nonceStr { get; set; }
        public string _signature { get; set; }
        public string _jsApiList { get; set; }

        public static WeChatPay_M Init( string appId,
            string nonceStr, string signature, string jsApiList)
        {
            return new WeChatPay_M()
            {
                _debug = "true",
                _appId = appId,
                _timestamp = (DateTime.Now-DateTime.MinValue).TotalMilliseconds.ToString(),
                _nonceStr = DateTime.Now.Random(),
                _signature = signature,
                _jsApiList = jsApiList

            };
        }
    }
}
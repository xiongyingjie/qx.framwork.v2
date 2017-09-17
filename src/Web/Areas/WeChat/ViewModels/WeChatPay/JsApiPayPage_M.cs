using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels.WeChatPay
{
    public class JsApiPayPage_M
    {
        public string _return_url;
        public string _total_fee;
        public string _wxJsApiParam;
        public string _html;
        public string _po_id;
        public string _userId;
        public static JsApiPayPage_M Init(string wxEditAddrParam, string html,
            string total_fee,string po_id,string userID, string return_url)
        {
            return new JsApiPayPage_M()
            {
                _wxJsApiParam = wxEditAddrParam,
                _html = html,
                _total_fee = total_fee,
                _po_id=po_id,
                _userId=userID,
                _return_url = return_url,
            };
        }
    }
}
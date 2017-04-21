using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels.WeChatPay
{
    public class ResultNotifyPage_M
    {
      
        public string _html;
        public static ResultNotifyPage_M Init(string html)
        {
            return new ResultNotifyPage_M()
            {
            
                _html = html

            };
        }
    }
}
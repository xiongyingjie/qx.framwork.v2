using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels.WeChatPay
{
    public class ProductPage_M
    {
        public string _openid;
        
        public string _wxEditAddrParam;
        [Display(Name = "输入充值金额（单位:元）")]
        public string total_fee;

        internal static object Init(string wxEditAddrParam, string openid,string total_fee)
        {
            return new ProductPage_M()
            {
                _wxEditAddrParam = wxEditAddrParam,
                _openid = openid,
                total_fee= total_fee

            };
        }
    }
}
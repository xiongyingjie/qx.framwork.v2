using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels.Web
{
    public class Authorize_M
    {
        public string _Url;
        public static Authorize_M Init(string url)
        {
            return new Authorize_M()
            {
                _Url = url
            };
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.Models
{
    public class AccessTokenModel: ExceptionModel
    {
        public string access_token;
        public string expires_in;
        public string refresh_token;
        public string openid;
        public string scope;
        public string errcode;
        public string errmsg;
    }
}
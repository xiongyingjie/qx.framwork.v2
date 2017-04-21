using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.Models
{
    public class UserInfoModel: ExceptionModel
    {
        public string openid;
        public string nickname;
        public string sex;
        public string province;
        public string city;
        public string country;
        public string headimgurl;
        //public string privilege;
        public string unionid;
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;

namespace Web.Areas.WeChat.Controllers
{
    public class BaseWebWeChatController : BaseController
    {
        protected const string APP_ID = "wx9b6ef741694db0bd";
        protected const string APP_SECRET = "83a010bc685d45365d0b540d92965be9";

        protected const string URL_AUTHORIZE = "https://open.weixin.qq.com/connect/oauth2/authorize";
        protected const string URL_ACCESS_TOKEN = "https://api.weixin.qq.com/sns/oauth2/access_token";
        protected const string URL_REFRESH_TOKEN = "https://api.weixin.qq.com/sns/oauth2/refresh_token";
        protected const string URL_USERINFO = "https://api.weixin.qq.com/sns/userinfo";
       
        protected const string URL_RETURN_NOTIFY = "http://wx.52xyj.cn/wechat/web/return_notify";
        protected const string PLATE_WECHATPAY_ACCOUNT = "plate-wechat";  
    }
}
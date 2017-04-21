using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using HtmlAgilityPack;
using Qx.Tools.CommonExtendMethods;
using Qx.Wechat.Models;
using RestSharp;
using Web.Controllers.Base;

namespace Web.Areas.WeChat.Controllers
{

    #region 消息结构定义

    public enum MsgTypeEnum
    {
        Text,
        Image,
        Voice,
        Video,
        Shortvideo,
        Location,
        Link,
        Event,
        NotMsg
    }

    public enum EventTypeEnum
    {
        SUBSRIBE,
        UNSUBSRIBE,
        SCAN,
        CLICK,
        VIEW,
        EVENT,
        NotEvent
    }

    #endregion

    public class BaseWeChatController : WxServerFilterController
    {
        protected const string URL_WECHAT_HOST = "https://api.weixin.qq.com";
        protected const string APP_ID = "wx9b6ef741694db0bd";
        protected const string APP_SECRET = "83a010bc685d45365d0b540d92965be9";
        protected string _Token =
            "C2jxctz_SB65dj8HC6OTrjsriIKZ36OEOAru4YUhOv-BaP93pCD_p-BRpay9cxncLZvIarun_uF48tBpdv5SG5xSToNsh_OEIfDq8ZA-oxhbgJZWtulihrXS5Gh0FaHZRFTiABAUIW";
        protected void InitReport(string Title, string AddLink, bool showDeafultButton = true, string ExtraParam = "")
        {
            base.InitReport(Title, AddLink, ExtraParam, showDeafultButton, "Qx.WeChat");
        }
    }
}
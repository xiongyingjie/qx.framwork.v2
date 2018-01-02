using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qx.wechat.Configs;
using qx.wechat.Models;
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;

namespace Web.Areas.WeChat.Controllers
{
    public class BaseEntWebWeChatController : BaseController
    {
        //protected string Token
        //{
        //    get
        //    {
        //        if (Session[Setting.EntWxConfig.APP_SECRET] == null)
        //        {
        //            var m = HttpGet<AccessTokenModel>(Setting.EntWxConfig.URL_ACCESS_TOKEN);
        //            //缓存token
        //            Session[Setting.EntWxConfig.APP_SECRET] = m.access_token;
        //            Session.Timeout = 60;
        //        }
        //        return
        //            //"k8m4OTDNKRCkTNmKZxkj-N9uhJ6e2Wp5dpp5kqT5G4XOJdzI8ESd2gtsShk-QjkZuCaHiQn8AgmpkLfGdDNYcUPvuincnrau8E-2u3eOgkt2s4wBnjjBCEBbtSNcOysjdWIV_qWH2Zdxgo2Vkt_8f-vv6512Mub9sOyifL-zSAXsHnAOzi9Bv3z6yBX482ddmVdKmtgoWNj8sZmjQH3-G8AYhXXyFfQkgyxfRSd8aX3XztywDLapCf3HDLpCaagKFdmaJgwsSc9wPAVGDvye-Thn8VlKCjzN7TLxmGO4upc";
        //            ""+Session[Setting.EntWxConfig.APP_SECRET];
        //    }
        //}

      
    }
}
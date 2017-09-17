using System;
using qx.wechat.Configs;
using qx.wechat.Interfaces;
using qx.wechat.Models;
using Qx.Tools.CommonExtendMethods;
using RestSharp;

namespace Web.Areas.WeChat.Common
{
    public class AuthorizeHelper: Setting.WxConfig
    {
        private static T HttpGet<T>(string url)
        {
            var client = new RestClient(new Uri(url));
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            var content = response.Content.Deserialize<T>();
            return content;
        }


        // GET: /WeChat/Web/AuthorizeRouting
        //授权页中转 snsapi_base    snsapi_userinfo
        private static string AuthorizeRouting(string mode, string return_url)
        {
            var url = URL_AUTHORIZE +
               "?appid=" + APP_ID +
               "&redirect_uri=" + URL_RETURN_NOTIFY +
               "&response_type=code" +
               "&scope=" + mode +
               "&state=" + return_url;
            return url;
        }
        // GET: /WeChat/Web/Authorize
        //加载授权页面
        public static string Authorize(string return_url)
        {
            return BaseAuthorize(return_url);
        }
        // GET: /WeChat/Web/BaseAuthorize
        //加载授权页面(基本)
        private static string BaseAuthorize(string return_url)
        {
            return AuthorizeRouting("snsapi_base", return_url);
        }
        // GET: /WeChat/Web/FullAuthorize
        //加载授权页面(完全)
        private static string FullAuthorize(string return_url)
        {
            return AuthorizeRouting("snsapi_userinfo", return_url);
        }
        public static string Handle(string code, string state,  IWxAuthorize wxAuthorize )
        {
            var returnUrl = state;
            //获取令牌
            var url = URL_ACCESS_TOKEN +
              "?appid=" + APP_ID +
              "&secret=" + APP_SECRET +
              "&code=" + code +
              "&grant_type=authorization_code";
            var m = HttpGet<AccessTokenModel>(url);
            //-----------------判断授权模式

            //全新授权
            if (m.scope == "snsapi_userinfo")
            {
                var userinfoUrl = URL_USERINFO +
                 "?access_token=" + m.access_token +
                 "&openid=" + m.openid +
                 "&lang=zh_CN";
                    var userInfo = HttpGet<UserInfoModel>(userinfoUrl);
                    if (!userInfo.openid.HasValue()|| !wxAuthorize.Regist(userInfo))
                    {
                        throw new Exception("绑定失败，请重试：request fail to" + userinfoUrl + "\r\n" +
                            "AccessTokenModel=>" + m.Serialize() + "\r\n" +
                            "UserInfoModel=>" + userInfo.Serialize() + "\r\n"
                            );
                    }
                return BackToBll(m.openid, returnUrl, "恭喜绑定成功");
            }
            //静默授权
            else
            {
                if (wxAuthorize.CheckRegistInfo(m.openid))
                {//注册信息完整，返回业务代码
                    return BackToBll(m.openid, returnUrl, "老用户");
                }
                else
                {//注册信息不完整，回滚注册信息并重新授权
                    wxAuthorize.RollbackRegistInfo(m.openid);
                    //重定向到手动授权
                    return FullAuthorize(returnUrl);
                }
            }
        }
        public static string HandleDebug(string type, string returnUrl,string openid, IWxAuthorize wxAuthorize)
        {
           
            //-----------------判断授权模式

            //全新授权
            if (type == "snsapi_userinfo")
            {
                  if (!openid.HasValue() || !wxAuthorize.Regist(new UserInfoModel()
                  {
                      openid= openid,
                      nickname="test-debug"
                  }))
                {
                    throw new Exception("绑定失败");
                }
                return BackToBll(openid, returnUrl, "恭喜绑定成功");
            }
            //静默授权
            else
            {
                if (wxAuthorize.CheckRegistInfo(openid))
                {//注册信息完整，返回业务代码
                    return BackToBll(openid, returnUrl, "老用户");
                }
                else
                {//注册信息不完整，回滚注册信息并重新授权
                    wxAuthorize.RollbackRegistInfo(openid);
                    //重定向到手动授权
                    return FullAuthorize(returnUrl);
                }
            }
        }

        private static  string BackToBll(string uid, string return_url, string msg)
        {
            return "/F2/LoginOk?uid=" + uid.Encrypt() + "&return_url=" + return_url + "&msg=" + msg;
        }

    }
}
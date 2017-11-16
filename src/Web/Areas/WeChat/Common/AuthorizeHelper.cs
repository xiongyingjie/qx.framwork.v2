using System;
using qx.wechat.Configs;
using qx.wechat.Interfaces;
using qx.wechat.Models;
using Qx.Tools.CommonExtendMethods;
using RestSharp;

namespace Web.Areas.WeChat.Common
{
    public class AuthorizeHelper : Setting.WxConfig
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
        private static string AuthorizeRouting<APP>(string mode, string return_url) where APP : new()
        {
            var cfg = (IWxApp)new APP();
            var url = cfg.UrlAuthorize +
               "?appid=" + cfg.AppId +
               "&redirect_uri=" + cfg.HostReturnNotify +
               "&response_type=code" +
               "&scope=" + mode +
               "&state=" + return_url;
            return url;
        }
        // GET: /WeChat/Web/Authorize
        //加载授权页面
        public static string Authorize<APP>(string return_url) where APP : new()
        {
            return BaseAuthorize<APP>(return_url);
        }
        // GET: /WeChat/Web/BaseAuthorize
        //加载授权页面(基本)
        private static string BaseAuthorize<APP>(string return_url) where APP : new()
        {
            return AuthorizeRouting<APP>("snsapi_base", return_url);
        }
        // GET: /WeChat/Web/FullAuthorize
        //加载授权页面(完全)
        private static string FullAuthorize<APP>(string return_url) where APP : new()
        {
            return AuthorizeRouting<APP>("snsapi_userinfo", return_url);
        }
        public static string Handle<APP>(string code, string state, IWxAuthorize wxAuthorize) where APP : new()
        {
            var cfg = (IWxApp)new APP();
            var returnUrl = state;
            //获取令牌
            var url = cfg.UrlAccessToken +
              "?appid=" + cfg.AppId +
              "&secret=" + cfg.AppSecret +
              "&code=" + code +
              "&grant_type=authorization_code";
            var m = HttpGet<AccessTokenModel>(url);
            //-----------------判断授权模式
            if (!m.scope.HasValue())
            {
                return "";
            }
            //全新授权
            if (m.scope == "snsapi_userinfo")
            {
                var userinfoUrl = cfg.UrlUserinfo +
                 "?access_token=" + m.access_token +
                 "&openid=" + m.openid +
                 "&lang=zh_CN";
                var userInfo = HttpGet<UserInfoModel>(userinfoUrl);
                if (!userInfo.openid.HasValue() || !wxAuthorize.Regist(userInfo))
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
                    return FullAuthorize<APP>(returnUrl);
                }
            }
        }
        public static string HandleDebug<APP>(string type, string returnUrl, string openid, IWxAuthorize wxAuthorize) where APP : new()
        {

            //-----------------判断授权模式

            //全新授权
            if (type == "snsapi_userinfo")
            {
                if (!openid.HasValue() || !wxAuthorize.Regist(new UserInfoModel()
                {
                    openid = openid,
                    nickname = "test-debug"
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
                    return FullAuthorize<APP>(returnUrl);
                }
            }
        }

        private static string BackToBll(string uid, string return_url, string msg)
        {
            return "/F2/LoginOk?uid=" + uid.Encrypt() + "&return_url=" + return_url + "&msg=" + msg;
        }

    }
}
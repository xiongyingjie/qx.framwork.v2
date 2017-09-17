using System;
using qx.wechat.Configs;
using qx.wechat.Interfaces;
using qx.wechat.Models;
using Qx.Tools.CommonExtendMethods;
using RestSharp;

namespace Web.Areas.WeChat.Common
{
    public class EntAuthorizeHelper : Setting.EntWxConfig
    {
        private static T HttpGet<T>(string url)
        {
            var client = new RestClient(new Uri(url));
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            var content = response.Content.Deserialize<T>();
            return content;
        }

        protected static string JsonHttp(string host, string url, object objParam, Method method)
        {
            var request = new RestRequest(url, method);
            request.AddJsonBody(objParam);
            request.DateFormat = "application/json";
            return BaseHttp(request, host);
        }

        protected static string BaseHttp(RestRequest request, string host)
        {
            var client = new RestClient(new Uri(host));
            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }



        protected static string URL_USERINFO(string token, string code)
        {
            return "https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token=" + token + "&code=" + code;
        }

        protected static string URL_USER_DETAIL(string token)
        {

            return "https://qyapi.weixin.qq.com/cgi-bin/user/getuserdetail?access_token=" + token;

        }



        // GET: /WeChat/Web/AuthorizeRouting
        //授权页中转 snsapi_base    snsapi_userinfo
        private static string AuthorizeRouting(string mode, string return_url)
        {
            return URL_AUTHORIZE(return_url + "; " + mode, mode);
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
        public static string Handle(string code, string state,string token, IEntWxAuthorize wxAuthorize )
        {
            var t = state.UnPackString(';');
            var returnUrl = t[0];
            var scope = t[1];
            //获取令牌
            var m = HttpGet<EntAccessTokenModel>(URL_USERINFO(token,code));   
      
            //-----------------判断授权模式
            //全新授权
            if (scope.TrimString() == "snsapi_userinfo")
            {

                var json = JsonHttp(URL_HOST, URL_USER_DETAIL(token).Replace(URL_HOST, ""), new { user_ticket = m.user_ticket }, Method.POST);
                //-----------------这里编写绑定逻辑
                var userInfo = json.Deserialize<EntUserInfoModel>();

                 if (!userInfo.userid.HasValue()|| !wxAuthorize.Regist(userInfo))
                    {
                        throw new Exception("绑定失败，请重试：request fail to" + userInfo + "\r\n" +
                            "AccessTokenModel=>" + m.Serialize() + "\r\n" +
                            "UserInfoModel=>" + userInfo.Serialize() + "\r\n"
                            );
                    }
                return BackToBll(m.UserId, returnUrl, "恭喜绑定成功");
            }
            //静默授权
            else
            {
                if (wxAuthorize.CheckRegistInfo(m.UserId))
                {//注册信息完整，返回业务代码
                    return BackToBll(m.UserId, returnUrl, "老用户");
                }
                else
                {//注册信息不完整，回滚注册信息并重新授权
                    wxAuthorize.RollbackRegistInfo(m.UserId);
                    //重定向到手动授权
                    return FullAuthorize(returnUrl);
                }
            }
        }
        public static string HandleDebug(string type, string returnUrl,string userId, IEntWxAuthorize wxAuthorize)
        {
           
            //-----------------判断授权模式

            //全新授权
            if (type == "snsapi_userinfo")
            {
                  if (!userId.HasValue() || !wxAuthorize.Regist(new EntUserInfoModel()
                  {
                      userid= userId,
                      name= "test-debug"
                  }))
                {
                    throw new Exception("绑定失败");
                }
                return BackToBll(userId, returnUrl, "恭喜绑定成功");
            }
            //静默授权
            else
            {
                if (wxAuthorize.CheckRegistInfo(userId))
                {//注册信息完整，返回业务代码
                    return BackToBll(userId, returnUrl, "老用户");
                }
                else
                {//注册信息不完整，回滚注册信息并重新授权
                    wxAuthorize.RollbackRegistInfo(userId);
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
using System.Configuration;
using Qx.Tools;

namespace qx.wechat.Configs
{
    public static class Setting
   {
       public static readonly string ConnectionString = DbUtility.SqlSeverConnString("qx.wechat");

         public class EntWxConfig
        {
            public class Contact : IEntWxApp
            {
                public  string AppId { get; } = "1000003";
                public  string AppSecret { get; } = "5jkEZ_q8Yt4UV7OpVz8742124siJrZd5pI-ubupVM5c";
                public string Host { get; } = "http://qywx.xmmc.edu.cn:9988/sever";
                public string FrontHost { get; } = "http://qywx.xmmc.edu.cn:9988";
            }
            public class Announce: IEntWxApp
            {
                public string AppId { get; } = "1000007";
                public string AppSecret { get; } = "jfW3jqOZpaM-h0IKgK5YPT36-QOWofWFN5Sk4NjVofk";
                public string Host { get; } = "http://qywx.xmmc.edu.cn:9988/sever";
                public string FrontHost { get; } = "http://qywx.xmmc.edu.cn:9988";
            }
            public class Meeting : IEntWxApp
            {
                public string AppId { get; } = "1000008";
                public string AppSecret { get; } = "2A7-rBmakCE5-PfWuUakSglR3qJR77CqIw5d9SngS90";
                public string Host { get; } = "http://qywx.xmmc.edu.cn:9988/sever";
                public string FrontHost { get; } = "http://qywx.xmmc.edu.cn:9988";
            }
            public class Shop : IEntWxApp
            {
                public string AppId { get; } = "1000009";
                public string AppSecret { get; } = "Bz0EWS3ah4JZbkpk2dEUcUViozJ_7Ikxe19fUbtUy04";
                public  string Host { get; } = "http://qywx.xmmc.edu.cn:9988/sever";
                public string FrontHost { get; } = "http://qywx.xmmc.edu.cn:9988";
            }
            public static string URL_RETURN_NOTIFY = "http%3a%2f%2fqywx.xmmc.edu.cn%3a9988%2fsever%2fWeChat%2fEntWeb%2freturn_notify";

            public static string URL_HOST = "https://qyapi.weixin.qq.com";
            public static string CORP_ID = "wxd2293ff2cd5879d5";
            //public static string APP_ID = "1000007";
            //public static string APP_SECRET = "jfW3jqOZpaM-h0IKgK5YPT36-QOWofWFN5Sk4NjVofk";

            //public static string URL_ACCESS_TOKEN(string APP_SECRET)
            //{
            //    return "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + CORP_ID +
            //                                        "&corpsecret=" + APP_SECRET;
            //}

            public static string URL_AUTHORIZE<APP>(string state, string scope) where APP : new()
            {
                var cfg = (IEntWxApp)new APP();

                return "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + CORP_ID +
                       "&redirect_uri=" + URL_RETURN_NOTIFY + "&response_type=code&scope=" + scope + "&agentid=" + cfg.AppId + "&state=" + state + "#wechat_redirect";

            }

            public static string URL_REFRESH_TOKEN = "https://api.weixin.qq.com/sns/oauth2/refresh_token";
            //public static string URL_MSG(string access_token)
            //{
            //    return "/cgi-bin/message/send?access_token=" + access_token;
            //}
        }
    
        public  class WxConfig
        {
            public class QxSoft : IWxApp
            {
                //共享平台
                public string AppId { get; } = "wx9b6ef741694db0bd";
                public string AppSecret { get; } = "83a010bc685d45365d0b540d92965be9";
                public string Host { get; } = "https://api.weixin.qq.com";
                public string HostReturnNotify { get; } = "http://cloud.52xyj.cn/wechat/web/return_notify";
                public string FrontHost { get; }
                public string UrlAccessToken { get; } = "https://api.weixin.qq.com/sns/oauth2/access_token";
                public string UrlAuthorize { get; } = "https://open.weixin.qq.com/connect/oauth2/authorize";
                public string UrlRefreshToken { get; } = "https://api.weixin.qq.com/sns/oauth2/refresh_token";
                public string UrlUserinfo { get; } = "https://api.weixin.qq.com/sns/userinfo";

                public class TemplateMsg
                {
                    public class SendCourseTable : IWxTemplateMsg
                    {
                        public string TemplateId { get; } = "y_TnBc2Y8FM4_vVriEHgmWTN_uphsGcXyIQn80PMXKU";

                    }
                }
            }

        
          

          
        }


    }
}

using System.Configuration;

namespace qx.wechat.Configs
{
   public static class Setting
   {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Qx.Wechat"].ConnectionString;

       public class EntWxConfig
       {
           public static string URL_RETURN_NOTIFY = "http%3a%2f%2fent.wx.52xyj.cn%3a9999%2fWeChat%2fEntWeb%2freturn_notify";// "http://ent.wx.52xyj.cn/wechat/entweb/return_notify";

           public static string URL_HOST = "https://qyapi.weixin.qq.com";
           public static string CORP_ID = "wxd2293ff2cd5879d5";
           public static string APP_ID = "1000003";
           public static string APP_SECRET = "5jkEZ_q8Yt4UV7OpVz8742124siJrZd5pI-ubupVM5c";

           public static string URL_ACCESS_TOKEN = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + CORP_ID +
                                                   "&corpsecret=" + APP_SECRET;

           public static string URL_AUTHORIZE(string state, string scope)
           {
               return "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + CORP_ID +
                      "&redirect_uri=" + URL_RETURN_NOTIFY + "&response_type=code&scope=" + scope + "&agentid=" + APP_ID + "&state=" + state + "#wechat_redirect";

           }

           public static string URL_REFRESH_TOKEN = "https://api.weixin.qq.com/sns/oauth2/refresh_token";
            public static string URL_MSG(string access_token)
            {
                return "/cgi-bin/message/send?access_token=" + access_token;
            }
          
           

        }
        public  class WxConfig
       {
            //趣学
            public static readonly string APP_ID = "wx9b6ef741694db0bd";
            public static readonly string APP_SECRET = "83a010bc685d45365d0b540d92965be9";

            protected static readonly string URL_AUTHORIZE = "https://open.weixin.qq.com/connect/oauth2/authorize";
            protected static readonly string URL_ACCESS_TOKEN = "https://api.weixin.qq.com/sns/oauth2/access_token";
            protected static readonly string URL_REFRESH_TOKEN = "https://api.weixin.qq.com/sns/oauth2/refresh_token";
            protected static readonly string URL_USERINFO = "https://api.weixin.qq.com/sns/userinfo";
            protected static readonly  string URL_RETURN_NOTIFY = "http://wx.52xyj.cn/wechat/web/return_notify";
            public static  readonly string URL_WECHAT_HOST = "https://api.weixin.qq.com";


           public class TemplateMsg
            {
               public static readonly string Charge = "aP5WSx_hkcCEbDJSu1Takrch4tTB1-3YkpRI6ESjeeE";
               public static readonly string Expence = "ZPa0vf6Y42ylYg1SB_jLfGsUQBvS36HdzC8ykW3HK18";
               public static readonly string Exchanged = "o3XfITOBXgcQD5NXq5bs1C7mmWwZnWq__zpsoC1Vv2k";
               /// <summary> 
               ///{{first.DATA}}
               ///服务类型：{{keyword1.DATA}}
               ///服务内容：{{keyword2.DATA}}
               ///服务者：{{keyword3.DATA}}
               ///联系电话：{{keyword4.DATA}}
               ///{{remark.DATA}}
               /// </summary>
               /// 趣学  public static readonly string template_id_receved_order = "BN3GZZgJuEIkS1bDFL9TdtPw6ewfIlLP6ZSXQ1iRidc";
               public static readonly string RecevedOrder = "b4igfyjq7P7C4M0zNONzaEXIzvFGIGTmgTazkWy8dB8";
               /// <summary> 
               ///{{first.DATA}}
               /// 故障描述：{{keyword1.DATA}
               ///处理人员：{{keyword2.DATA}}
               ///联系电话：{{keyword3.DATA}}
               ///完成时间：{{keyword4.DATA}}
               ///备注说明：{{keyword5.DATA}}
               ///{{remark.DATA}}
               /// </summary>
               //趣学 public static readonly string template_id_finished_order = "JEnka422RCuROFonJt2MOf0NfrU78_rnVoiw2vXK1GM";
               public static readonly string FinishedOrder = "HmQ3SQOtK3Zf-hakhspWGEx0BrghUaHCceIb38TwO0w";
            }
       }


    }
}

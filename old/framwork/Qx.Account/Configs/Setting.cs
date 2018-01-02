using System.Configuration;

namespace Qx.Account.Configs
{
    public interface IWxPayApp
    {
        string APPID { get; }
      
        string MCHID { get; }
        string KEY { get; }
        string APPSECRET { get; }
        string SSLCERT_PATH { get; }
        string SSLCERT_PASSWORD { get; }
        string NOTIFY_URL { get; }
        string IP { get; }
        string PROXY_URL { get; }
        int REPORT_LEVENL { get; }
        int LOG_LEVENL { get; }



    }
    public static class Setting
   {
        public static readonly string PLATE_WECHAT_ACCOUNT = "plate-wechat";

        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["qx.Account"].ConnectionString;

        public class WxPayConfig
        {

            public class QxSoftWare: IWxPayApp
            {
                //=======【基本信息设置】=====================================
                /* 微信公众号信息配置
                * APPID：绑定支付的APPID（必须配置）
                * MCHID：商户号（必须配置）
                * KEY：商户支付密钥，参考开户邮件设置（必须配置）
                * APPSECRET：公众帐号secert（仅JSAPI支付的时候需要配置）
                */
                public string APPID { get; } = "wx9b6ef741694db0bd";
                public string MCHID { get; } = "1421487602";
                public string KEY { get; } = "01234567890123456789012345678901";
                public string APPSECRET { get; } = "83a010bc685d45365d0b540d92965be9";

                //=======【证书路径设置】===================================== 
                /* 证书路径,注意应该填写绝对路径（仅退款、撤销订单时需要）
                */
                public string SSLCERT_PATH { get; } = "/cert/apiclient_cert.p12";
                public string SSLCERT_PASSWORD { get; } = "1421487602";


                //=======【支付结果通知url】===================================== 
                /* 支付结果通知回调url，用于商户接收支付结果
                */
                public string NOTIFY_URL { get; } = "http://wx.52xyj.cn/WeChat/WeChatPay/ResultNotifyPage/";

                //=======【商户系统后台机器IP】===================================== 
                /* 此参数可手动配置也可在程序中自动获取
                */
                public string IP { get; } = "112.74.135.47";


                //=======【代理服务器设置】===================================
                /* 默认IP和端口号分别为0.0.0.0和0，此时不开启代理（如有需要才设置）
                */
                public string PROXY_URL { get; } = "http://10.152.18.220:8080";

                //=======【上报信息配置】===================================
                /* 测速上报等级，0.关闭上报; 1.仅错误时上报; 2.全量上报
                */
                public  int REPORT_LEVENL { get; } = 1;

                //=======【日志级别】===================================
                /* 日志等级，0.不输出日志；1.只输出错误信息; 2.输出错误和正常信息; 3.输出错误信息、正常信息和调试信息
                */
                public  int LOG_LEVENL { get; } = 2;
               
            }
            public class Sports : IWxPayApp
            {
                //=======【基本信息设置】=====================================
                /* 微信公众号信息配置
                * APPID：绑定支付的APPID（必须配置）
                * MCHID：商户号（必须配置）
                * KEY：商户支付密钥，参考开户邮件设置（必须配置）
                * APPSECRET：公众帐号secert（仅JSAPI支付的时候需要配置）
                */
                public string APPID { get; } = "wx582c7fb5287e27c0";
                public string MCHID { get; } = "1480995522";
                public string KEY { get; } = "6d8443553bcd6431a2b8e8be5e99ac8b";
                public string APPSECRET { get; } = "e228cdea11b55448ccd146fde9479d51";

                //=======【证书路径设置】===================================== 
                /* 证书路径,注意应该填写绝对路径（仅退款、撤销订单时需要）
                */
                public string SSLCERT_PATH { get; } = "/cert/apiclient_cert.p12";
                public string SSLCERT_PASSWORD { get; } = "1421487602";


                //=======【支付结果通知url】===================================== 
                /* 支付结果通知回调url，用于商户接收支付结果
                */
                public string NOTIFY_URL { get; } = "http://wx.52xyj.cn/WeChat/WeChatPay/ResultNotifyPage/";

                //=======【商户系统后台机器IP】===================================== 
                /* 此参数可手动配置也可在程序中自动获取
                */
                public string IP { get; } = "112.74.135.47";


                //=======【代理服务器设置】===================================
                /* 默认IP和端口号分别为0.0.0.0和0，此时不开启代理（如有需要才设置）
                */
                public string PROXY_URL { get; } = "http://10.152.18.220:8080";

                //=======【上报信息配置】===================================
                /* 测速上报等级，0.关闭上报; 1.仅错误时上报; 2.全量上报
                */
                public int REPORT_LEVENL { get; } = 1;

                //=======【日志级别】===================================
                /* 日志等级，0.不输出日志；1.只输出错误信息; 2.输出错误和正常信息; 3.输出错误信息、正常信息和调试信息
                */
                public int LOG_LEVENL { get; } = 2;

            }
        }
    }
}

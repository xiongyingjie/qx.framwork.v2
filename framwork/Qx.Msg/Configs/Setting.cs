using Qx.Tools;
using System.Configuration;

namespace Qx.Msg.Configs
{
   public static class Setting
   {
   
        public static  string ConnectionString {
            get
            {
                return QxConfigs.IsUnitTest ? "name=Qx.Msg" :
                    ConfigurationManager.ConnectionStrings["Qx.Msg"].ConnectionString;
            }
        }
        public static readonly int ExpireTimeSpan = 15;//过期时间
        public static readonly int ErrorCount = 3;//错误输入次数Qx.Msg

        public static readonly string RegionId = "cn-hangzhou";
        public static readonly string AccessKeyId = "LTAIsbIrRXX1PwSh";
        public static readonly string Secret = "bZaULvp7Smvd7uUOEvboBLtI1TbO16";
        //管理控制台中配置的短信签名（状态必须是验证通过）
        public static readonly string SignName = "短信服务";
        //管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）
        public static readonly string TemplateCode = "SMS_37655154";



    }
}

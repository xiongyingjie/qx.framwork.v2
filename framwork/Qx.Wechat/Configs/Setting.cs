using System.Configuration;

namespace Qx.Wechat.Configs
{
   public static class Setting
   {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Qx.Wechat"].ConnectionString;
        public static readonly string URL_WECHAT_HOST = "https://api.weixin.qq.com";
        public static readonly string APP_ID = "wx9b6ef741694db0bd";
        public static readonly string APP_SECRET = "83a010bc685d45365d0b540d92965be9";
        public static readonly string template_id_charge = "aP5WSx_hkcCEbDJSu1Takrch4tTB1-3YkpRI6ESjeeE";
        public static readonly string template_id_expence = "ZPa0vf6Y42ylYg1SB_jLfGsUQBvS36HdzC8ykW3HK18";
        public static readonly string template_id_exchanged = "o3XfITOBXgcQD5NXq5bs1C7mmWwZnWq__zpsoC1Vv2k";

    }
}

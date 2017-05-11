using System.Configuration;

namespace Qx.Wechat.Configs
{
   public static class Setting
   {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Qx.Wechat"].ConnectionString;
        public static readonly string URL_WECHAT_HOST = "https://api.weixin.qq.com";
        //趣学
        //public static readonly string APP_ID = "wx9b6ef741694db0bd";
        //public static readonly string APP_SECRET = "83a010bc685d45365d0b540d92965be9";
        public static readonly string APP_ID = "wx3a9ef21410237169";
        public static readonly string APP_SECRET = "6d8443553bcd6431a2b8e8be5e99ac8b";
        public static readonly string template_id_charge = "aP5WSx_hkcCEbDJSu1Takrch4tTB1-3YkpRI6ESjeeE";
        public static readonly string template_id_expence = "ZPa0vf6Y42ylYg1SB_jLfGsUQBvS36HdzC8ykW3HK18";

        public static readonly string template_id_exchanged = "o3XfITOBXgcQD5NXq5bs1C7mmWwZnWq__zpsoC1Vv2k";
        /// <summary> 
        ///{{first.DATA}}
        ///服务类型：{{keyword1.DATA}}
        ///服务内容：{{keyword2.DATA}}
        ///服务者：{{keyword3.DATA}}
        ///联系电话：{{keyword4.DATA}}
        ///{{remark.DATA}}
        /// </summary>
        /// 趣学  public static readonly string template_id_receved_order = "BN3GZZgJuEIkS1bDFL9TdtPw6ewfIlLP6ZSXQ1iRidc";

        public static readonly string template_id_receved_order = "b4igfyjq7P7C4M0zNONzaEXIzvFGIGTmgTazkWy8dB8";
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
        public static readonly string template_id_finished_order = "HmQ3SQOtK3Zf-hakhspWGEx0BrghUaHCceIb38TwO0w";
        
    }
}

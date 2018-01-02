using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LitJson;
using Qx.Tools.Exceptions.Upgrate;

namespace Qx.Account.WeixinPay.lib
{
  public  class WxConfigHelper
    {
         /**
     * @Dictionary格式化成Json
      * @return json串数据
     */
        public string ToJson(SortedDictionary<string, object> dictionary)
        {
            string jsonStr = JsonMapper.ToJson(dictionary);
            return jsonStr;
        }
        /**
* @Dictionary格式转化成url参数格式
* @ return url格式串, 该串不包含sign字段值
*/
        public string ToUrl(SortedDictionary<string, object> dictionary)
        {
            string buff = "";
            foreach (KeyValuePair<string, object> pair in dictionary)
            {
                if (pair.Value == null)
                {
                    // Log<T>.Error(this.GetType().ToString(), "WxPayData<T>内部含有值为null的字段!");
                    throw new WxPayException("WxPayData<T>内部含有值为null的字段!");
                }

                if (pair.Key != "sign" && pair.Value.ToString() != "")
                {
                    buff += pair.Key + "=" + pair.Value + "&";
                }
            }
            buff = buff.Trim('&');
            return buff;
        }

        /**
        * 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
         * @return 时间戳
        */
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /**
        * 生成随机串，随机串包含字母或数字
        * @return 随机串
        */
        public static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

      
        public class WxConfig
        {
            public string appId { get; set; }
            public string timestamp { get; set; }
            public string nonceStr { get; set; }
            public string signature { get; set; }

        }
        public WxConfig GetCfg(string key )
        {
               //采用排序的Dictionary的好处是方便对数据包进行签名，不用再签名之前再做一次排序
            var dic = new SortedDictionary<string, object>();
            var wxCfg = new qx.wechat.Configs.Setting.WxConfig.QxSoft();
            var appid = wxCfg.AppId;
            var timestamp = GenerateTimeStamp();
            var nonceStr = GenerateNonceStr();
           // var accesstoken = access_token;
           
            //构造需要用SHA1算法加密的数据
            dic["appid"]= appid;
            dic["timestamp"] = timestamp;
            dic["nonceStr"] = nonceStr;
           // dic["accesstoken"] = accesstoken;

            //SHA1加密

            var signature = FormsAuthentication.HashPasswordForStoringInConfigFile(ToUrl(dic), "SHA1");
            // Log<T>.Debug(this.GetType().ToString(), "SHA1 encrypt result : " + sign);


            return new WxConfig()
            {
                appId = appid,
                timestamp = timestamp,
                nonceStr = nonceStr,
                signature = signature,
            };
        }
    }
}

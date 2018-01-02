using System;
using System.Collections.Generic;

using LitJson;
using qx.wechat.Interfaces;
using qx.wechat.Models;
using Qx.Tools.Exceptions.Upgrate;

namespace qx.wechat.Services
{
    public  class WxConfigHelper : IWxConfigHelper
    {

        private IWechatServices _wechatServices;

        public WxConfigHelper(IWechatServices wechatServices)
        {
            _wechatServices = wechatServices;
        }

        /**
     * @Dictionary格式化成Json
      * @return json串数据
     */
        public string ToJson(SortedDictionary<string, object> dictionary)
        {
            var jsonStr = JsonMapper.ToJson(dictionary);
            return jsonStr;
        }
        /**
* @Dictionary格式转化成url参数格式
* @ return url格式串, 该串不包含sign字段值
*/
        public string ToUrl(SortedDictionary<string, object> dictionary)
        {
            var buff = "";
            foreach (KeyValuePair<string, object> pair in dictionary)
            {
                if (pair.Value == null)
                {
                     throw new Exception("SortedDictionary<string, object> dictionary内部含有值为null的字段!");
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
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
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

      
  
        public WxCfg GetCfg(string url, string key)
        {
               //采用排序的Dictionary的好处是方便对数据包进行签名，不用再签名之前再做一次排序
            var dic = new SortedDictionary<string, object>();
            var wxCfg = new Configs.Setting.WxConfig.QxSoft();
        
            var timestamp = GenerateTimeStamp();
            var noncestr = GenerateNonceStr();
            var jsapi_ticket = _wechatServices.GetTicket<Configs.Setting.WxConfig.QxSoft>();

            //构造需要用SHA1算法加密的数据
            dic["noncestr"] = noncestr;
            dic["jsapi_ticket"] = jsapi_ticket;
            dic["timestamp"] = timestamp;
            dic["url"] = url;
            var param = ToUrl(dic);
            //SHA1加密
            var signature = FormsAuthentication.HashPasswordForStoringInConfigFile(param, "SHA1");
            // Log<T>.Debug(this.GetType().ToString(), "SHA1 encrypt result : " + sign);


            return new WxCfg()
            {
                jsapi_ticket = jsapi_ticket,
                appId = wxCfg.AppId,
                url= url,
                param = param,
                timestamp = timestamp,
                noncestr = noncestr,
                signature = signature,
            };
        }
    }
}

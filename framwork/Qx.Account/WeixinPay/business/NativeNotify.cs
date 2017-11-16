using System;
using System.Web;
using Qx.Account.Configs;
using Qx.Account.WeixinPay.lib;

namespace Qx.Account.WeixinPay.business
{
    /// <summary>
    /// 扫码支付模式一回调处理类
    /// 接收微信支付后台发送的扫码结果，调用统一下单接口并将下单结果返回给微信支付后台
    /// </summary>
    public class NativeNotify<T> : Notify<T> where T : new()
    {
        private IWxPayApp cfg
        {
            get
            {
                return (IWxPayApp)new T();
            }
        }
        public NativeNotify(HttpContextBase page):base(page)
        {

        }

        public override void ProcessNotify()
        {
            WxPayData<T> notifyData = GetNotifyData();

            //检查openid和product_id是否返回
            if (!notifyData.IsSet("openid") || !notifyData.IsSet("product_id"))
            {
                WxPayData<T> res = new WxPayData<T>();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "回调数据异常");
                Log<T>.Info(this.GetType().ToString(), "The data WeChat post is error : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }

            //调统一下单接口，获得下单结果
            string openid = notifyData.GetValue("openid").ToString();
            string product_id = notifyData.GetValue("product_id").ToString();
            WxPayData<T> unifiedOrderResult = new WxPayData<T>();
            try
            {
                unifiedOrderResult = UnifiedOrder(openid, product_id);
            }
            catch(Exception ex)//若在调统一下单接口时抛异常，立即返回结果给微信支付后台
            {
                WxPayData<T> res = new WxPayData<T>();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "统一下单失败");
                Log<T>.Error(this.GetType().ToString(), "UnifiedOrder failure : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }

            //若下单失败，则立即返回结果给微信支付后台
            if (!unifiedOrderResult.IsSet("appid") || !unifiedOrderResult.IsSet("mch_id") || !unifiedOrderResult.IsSet("prepay_id"))
            {
                WxPayData<T> res = new WxPayData<T>();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "统一下单失败");
                Log<T>.Error(this.GetType().ToString(), "UnifiedOrder failure : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }

            //统一下单成功,则返回成功结果给微信支付后台
            WxPayData<T> data = new WxPayData<T>();
            data.SetValue("return_code", "SUCCESS");
            data.SetValue("return_msg", "OK");
            data.SetValue("appid", cfg.APPID);
            data.SetValue("mch_id", cfg.MCHID);
            data.SetValue("nonce_str", WxPayApi<T>.GenerateNonceStr());
            data.SetValue("prepay_id", unifiedOrderResult.GetValue("prepay_id"));
            data.SetValue("result_code", "SUCCESS");
            data.SetValue("err_code_des", "OK");
            data.SetValue("sign", data.MakeSign());

            Log<T>.Info(this.GetType().ToString(), "UnifiedOrder success , send data to WeChat : " + data.ToXml());
            page.Response.Write(data.ToXml());
            page.Response.End();
        }

        private WxPayData<T> UnifiedOrder(string openId,string productId)
        {
            //统一下单
            WxPayData<T> req = new WxPayData<T>();
            req.SetValue("body", "test");
            req.SetValue("attach", "test");
            req.SetValue("out_trade_no", WxPayApi<T>.GenerateOutTradeNo());
            req.SetValue("total_fee", 1);
            req.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            req.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));
            req.SetValue("goods_tag", "test");
            req.SetValue("trade_type", "NATIVE");
            req.SetValue("openid", openId);
            req.SetValue("product_id", productId);
            WxPayData<T> result = WxPayApi<T>.UnifiedOrder(req);
            return result;
        }
    }
}
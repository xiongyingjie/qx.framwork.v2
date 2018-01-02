using System.Web;
using Microsoft.AspNetCore.Http;
using Qx.Account.Configs;
using Qx.Account.WeixinPay.lib;

namespace Qx.Account.WeixinPay.business
{
    /// <summary>
    /// 支付结果通知回调处理类
    /// 负责接收微信支付后台发送的支付结果并对订单有效性进行验证，将验证结果反馈给微信支付后台
    /// </summary>
    public class ResultNotify<T> : Notify<T>
    where T : new()
    {
        private static IWxPayApp cfg
        {
            get
            {
                return (IWxPayApp)new T();
            }
        }
        public ResultNotify(HttpContext page):base(page)
        {
        }

        public override void ProcessNotify()
        {
           var notifyData = GetNotifyData();

            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id"))
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                WxPayData<T> res = new WxPayData<T>();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
                Log<T>.Error(this.GetType().ToString(), "The Pay result is error : " + res.ToXml());
                page.Response.WriteAsync(res.ToXml());
               
            }

            string transaction_id = notifyData.GetValue("transaction_id").ToString();

            //查询订单，判断订单真实性
            if (!QueryOrder(transaction_id))
            {
                //若订单查询失败，则立即返回结果给微信支付后台
                WxPayData<T> res = new WxPayData<T>();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
                Log<T>.Error(this.GetType().ToString(), "Order query failure : " + res.ToXml());
                page.Response.WriteAsync(res.ToXml());
               
            }
            //查询订单成功
            else
            {
                WxPayData<T> res = new WxPayData<T>();
                res.SetValue("return_code", "SUCCESS");
                res.SetValue("return_msg", "OK");
                Log<T>.Info(this.GetType().ToString(), "order query success : " + res.ToXml());
                page.Response.WriteAsync(res.ToXml());
               
            }
        }

        //查询订单
        public bool QueryOrder(string transaction_id)
        {
            WxPayData<T> req = new WxPayData<T>();
            req.SetValue("transaction_id", transaction_id);
            WxPayData<T> res = WxPayApi<T>.OrderQuery(req);
            if (res.GetValue("return_code").ToString() == "SUCCESS" &&
                res.GetValue("result_code").ToString() == "SUCCESS")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
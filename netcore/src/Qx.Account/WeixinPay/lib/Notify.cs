using System.IO;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;
using Qx.Account.Configs;

namespace Qx.Account.WeixinPay.lib
{
    /// <summary>
    /// 回调处理基类
    /// 主要负责接收微信支付后台发送过来的数据，对数据进行签名验证
    /// 子类在此类基础上进行派生并重写自己的回调处理过程
    /// </summary>
    public class Notify<T> where T : new()
    {
        private static IWxPayApp cfg
        {
            get
            {
                return (IWxPayApp)new T();
            }
        }
        public HttpContext page {get;set;}
        public Notify(HttpContext page)
        {
            this.page = page;
        }

        /// <summary>
        /// 接收从微信支付后台发送过来的数据并验证签名
        /// </summary>
        /// <returns>微信支付后台返回的数据</returns>
        public WxPayData<T> GetNotifyData()
        {
            //接收从微信后台POST过来的数据
            var memoryStream = new MemoryStream();
            page.Request.Body.CopyTo(memoryStream);

            System.IO.Stream s = memoryStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();

            Log<T>.Info(this.GetType().ToString(), "Receive data from WeChat : " + builder.ToString());

            //转换数据格式并验证签名
            WxPayData<T> data = new WxPayData<T>();
            try
            {
                data.FromXml(builder.ToString());
            }
            catch(WxPayException ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                WxPayData<T> res = new WxPayData<T>();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", ex.Message);
                Log<T>.Error(this.GetType().ToString(), "Sign check error : " + res.ToXml());
                page.Response.WriteAsync(res.ToXml());
             
            }

            Log<T>.Info(this.GetType().ToString(), "Check sign success");
            return data;
        }

        //派生类需要重写这个方法，进行不同的回调处理
        public virtual void ProcessNotify()
        {

        }
    }
}
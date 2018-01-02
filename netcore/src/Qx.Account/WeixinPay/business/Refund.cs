using Qx.Account.Configs;
using Qx.Account.WeixinPay.lib;

namespace Qx.Account.WeixinPay.business
{
    public class Refund<T> where T : new()
    {
        private static IWxPayApp cfg
        {
            get
            {
                return (IWxPayApp)new T();
            }
        }
        /***
        * 申请退款完整业务流程逻辑
        * @param transaction_id 微信订单号（优先使用）
        * @param out_trade_no 商户订单号
        * @param total_fee 订单总金额
        * @param refund_fee 退款金额
        * @return 退款结果（xml格式）
        */
        public static string Run(string transaction_id, string out_trade_no, string total_fee, string refund_fee)
        {
            Log<T>.Info("Refund", "Refund is processing...");

            WxPayData<T> data = new WxPayData<T>();
            if (!string.IsNullOrEmpty(transaction_id))//微信订单号存在的条件下，则已微信订单号为准
            {
                data.SetValue("transaction_id", transaction_id);
            }
            else//微信订单号不存在，才根据商户订单号去退款
            {
                data.SetValue("out_trade_no", out_trade_no);
            }

            data.SetValue("total_fee", int.Parse(total_fee));//订单总金额
            data.SetValue("refund_fee", int.Parse(refund_fee));//退款金额
            data.SetValue("out_refund_no", WxPayApi<T>.GenerateOutTradeNo());//随机生成商户退款单号
            data.SetValue("op_user_id", cfg.MCHID);//操作员，默认为商户号

            WxPayData<T> result = WxPayApi<T>.Refund(data);//提交退款申请给API，接收返回数据

            Log<T>.Info("Refund", "Refund process complete, result : " + result.ToXml());
            return result.ToPrintStr();
        }
    }
}
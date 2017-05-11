using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Wechat.Models;

namespace Qx.Wechat.Interfaces
{
    public interface IWechatServices
    {
        /// <summary>
        /// 发送兑换成功通知
        /// </summary>
        /// <param name="touser">接受者</param>
        /// <param name="click_url">跳转链接</param>
        /// <param name="good_name">商品名称</param>
        /// <param name="time">兑换时间</param>
        /// <returns></returns>
        bool Send_Exchange_Ok_Msg(string touser, string click_url,
            string good_name, string time);
        /// <summary>
        /// 发送消费成功通知
        /// </summary>
        /// <param name="touser">接受者</param>
        /// <param name="click_url">跳转链接</param>
        /// <param name="total_fee">消费金额</param>
        /// <param name="payment_type">支付方式</param>
        /// <param name="good_name">商品名称</param>
        /// <param name="trade_no">交易号</param>
        /// <param name="balance">账户余额</param>
        /// <returns>发送成功/失败</returns>
        bool Send_Expence_Ok_Msg(string touser, string click_url,
            string total_fee, string payment_type, string good_name, string trade_no, string balance);
        /// <summary>
        /// 发送充值成功通知
        /// </summary>
        /// <param name="touser">接受者</param>
        /// <param name="click_url">跳转链接</param>
        /// <param name="time">充值时间</param>
        /// <param name="total_fee">充值金额</param>
        /// <param name="balance">账户余额</param>
        /// <returns>发送成功/失败</returns>
        bool Send_Charge_Ok_Msg(string touser, string click_url, string time, string total_fee, string balance);
        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="toWho">接受者</param>
        /// <param name="templateId">模板ID</param>
        /// <param name="url">跳转链接</param>
        /// <param name="templateData">模板数据（对象）</param>
        /// <returns>发送成功/失败</returns>
        bool SendTemplateMsg(string toWho, string templateId, string click_url, object templateData);

        bool Send_Receved_Order_Msg(string touser, string click_url,
            string serve_detail, string server_name, string server_phone, 
            string arrange_serve_time, string order_id);
         bool Send_Finished_Order_Msg(string touser, string click_url,
            string serve_detail, string server_name, string server_phone, string finish_time, string note);
        string ApiHttpGet(string host, string url, Dictionary<string, string> param, string logFileName="");
       

        string ApiHttpPost(string host, string url, Dictionary<string, string> param, string logFileName="");
       

        string ApiJsonHttpPost(string host, string url, object param, string logFileName="", string extraParam = null);
      
        SystemSetup GetSetup();
        string GetToken();
        bool SaveToken(string tokenId, int expireTime);
        bool Log(string logString, bool hasError);
        string MsgHandle(string xmlBody);
        MsgTypeEnum ParseMsgType(string msgType);
        EventTypeEnum ParseEventType(string msgType);
    }
}

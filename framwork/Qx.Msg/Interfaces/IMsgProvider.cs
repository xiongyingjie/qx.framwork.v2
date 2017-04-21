using Qx.Msg.Entity;
using Qx.Tools.Interfaces;
using System.Collections.Generic;
using sms_send_record = Qx.Msg.Entity.sms_send_record;

namespace Qx.Msg.Interfaces
{
    public interface IMsgProvider
    {
        /// <summary>
        /// 发送手机验证码,注意:请勿随意发送，本接口每调用一次会被收费!
        /// </summary>
        /// <param name="phoneNumber">接收人手机号</param>
        /// <param name="receiverName">接收者姓名</param>
        /// <param name="sender">发送人，用于统计调用者</param>
        /// <returns></returns>
        sms_send_record SendSms(string phoneNumber, string receiverName, string sender = "");
        sms_send_record FindSms(string requestId);
        /// <summary>
        /// 比对验证码，注意:请使用try语句块捕获异常
        /// </summary>
        /// <param name="requestId">调用SendSms返回的Sms唯一标识符</param>
        /// <param name="code">用户输入的验证码</param>
        /// <returns>验证码是否正确</returns>
        bool CheckSms(string requestId, string code);
        List<contact> MyContacter(string memberid);
        bool ContactAdd(string memberid, string OnwerID);

        IRepository<contact> ContactRepository { get; set; }
        IRepository<group_member> GroupMemberRepository { get; set; }
        IRepository<msg_group> GroupRepository { get; set; }
        IRepository<msg_collection> MsgCollectionRepository { get; set; }
        IRepository<Qx.Msg.Entity.msg> MsgRepository { get; set; }
        IRepository<Qx.Msg.Entity.crew_limite_type> CrewLimiteTypeRepository { get; set; }
        List<msg_send_record> InBox(string userid);
        List<msg_send_record> OutBox(string userid);
        List<msg_send_record> UnReadMsg(string userid);
        List<msg_send_record> Drafts(string userid);
        List<msg_send_record> TimerSendRecords(string userid);
        List<msg_send_record> TimerTask(string userid);
    }
}

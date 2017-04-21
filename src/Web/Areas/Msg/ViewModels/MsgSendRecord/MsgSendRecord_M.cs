using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.MsgSendRecord
{
    public class MsgSendRecord_M
    {
        public msg_send_record ToModel()
        {
            return new msg_send_record()
            {
                MsgSendRecordID = MsgSendRecordID,
                MsgID = MsgID,
                ReceiverID= ReceiverID,
                SendTime= SendTime,
                ReadTime= ReadTime,
                OutStateID= OutStateID,
                InStateID= InStateID
            };

        }
        public static MsgSendRecord_M ToVoewModel(msg_send_record msgsendrecord)
        {
            return new MsgSendRecord_M()
            {
                MsgSendRecordID = msgsendrecord.MsgSendRecordID,
                MsgID = msgsendrecord.MsgID,
                ReceiverID = msgsendrecord.ReceiverID,
                SendTime = msgsendrecord.SendTime??DateTime.Now,
                ReadTime = msgsendrecord.ReadTime??DateTime.Now,
                OutStateID = msgsendrecord.OutStateID,
                InStateID = msgsendrecord.InStateID
            };
        }
        [Display(Name = "消息发送记录表ID")]
        [StringLength(50)]
        public string MsgSendRecordID { get; set; }

        [Display(Name = "消息ID")]
        [StringLength(50)]
        public string MsgID { get; set; }


        [Display(Name = "收件人ID")]
        [StringLength(50)]
        public string ReceiverID { get; set; }

        [Display(Name = "发送时间")]
        [Column(TypeName = "datetime2")]
        public DateTime SendTime { get; set; }

        [Display(Name = "阅读时间")]
        [Column(TypeName = "datetime2")]
        public DateTime ReadTime { get; set; }

        [Display(Name = "发送状态")]
        [StringLength(50)]
        public string OutStateID { get; set; }


        [Display(Name = "接收状态")]
        [StringLength(50)]
        public string InStateID { get; set; }
    }
}
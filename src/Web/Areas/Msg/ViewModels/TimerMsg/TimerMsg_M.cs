using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.TimerMsg
{
    public class TimerMsg_M
    {
        public timer_msg ToModel()
        {
            return new timer_msg()
            {
                TimerMsgID = TimerMsgID,
                MsgID = MsgID,
                SetSendTime = SetSendTime,
                RealSendTime= RealSendTime
            };
         }
        public static TimerMsg_M ToViewModel(timer_msg timermsg)
        {
            return new TimerMsg_M()
            {
                TimerMsgID = timermsg.TimerMsgID,
                MsgID = timermsg.MsgID,
                SetSendTime = timermsg.SetSendTime ?? DateTime.Now,
                RealSendTime = timermsg.RealSendTime ?? DateTime.Now,
            };
        }
        [Display(Name = "定是消息表ID")]
        [StringLength(50)]
        public string TimerMsgID { get; set; }

        [Display(Name = "定时消息ID")]
        [StringLength(50)]
        public string MsgID { get; set; }

        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime2")]
        public DateTime SetSendTime { get; set; }

        [Display(Name = "实际发送时间")]
        [Column(TypeName = "datetime2")]
        public DateTime RealSendTime { get; set; }
    }
}
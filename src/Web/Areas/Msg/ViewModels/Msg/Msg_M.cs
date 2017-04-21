using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.Msg
{
    public class Msg_M
    {
        public msg ToModel()
        {
            return new msg()
            {
                MsgID = MsgID,
                MsgTypeID = MsgTypeID,
                Subjects = Subjects,
                Contents = Contents,
                CreationTime = CreationTime,
                SenderID = SenderID
            };
        }
        public static Msg_M ToViewModel(msg Msg)
        {
            return new Msg_M()
            {
                MsgID = Msg.MsgID,
                MsgTypeID = Msg.MsgTypeID,
                Subjects = Msg.Subjects,
                Contents = Msg.Contents,
                CreationTime = Msg.CreationTime,
                SenderID = Msg.SenderID
            };
        }
        [Display(Name = "消息ID")]
        [StringLength(50)]
        public string MsgID { get; set; }

        [Display(Name = "消息类型ID")]
        [StringLength(50)]
        public string MsgTypeID { get; set; }

        [Display(Name = "主题")]
        [StringLength(50)]
        public string Subjects { get; set; }

        [Display(Name = "内容")]
        [StringLength(50)]
        public string Contents { get; set; }

        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime2")]
        public DateTime CreationTime { get; set; }

        [Display(Name = "发送者ID")]
        [StringLength(50)]
        public string SenderID { get; set; }
    }
}
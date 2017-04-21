using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.MsgCollection
{
    public class MsgCollection_M
    {
        public msg_collection ToModel()
        {
            return new msg_collection()
            {
                MsgCollectionID = MsgCollectionID,
                MsgID = MsgID,
                UserID = UserID,
                Time = Time,
                ReceiverID = ReceiverID
            };
        }
        public static MsgCollection_M ToViewModel(msg_collection msgcollection)
        {
            return new MsgCollection_M()
            {
                MsgCollectionID = msgcollection.MsgCollectionID,
                MsgID = msgcollection.MsgID,
                UserID = msgcollection. UserID,
                Time = msgcollection.Time??DateTime.Now,
                ReceiverID = msgcollection.ReceiverID
            };
        }
        [Display(Name = "收藏表ID")]
        [StringLength(50)]
        public String MsgCollectionID { get; set; }

        [Display(Name = "消息ID")]
        [StringLength(50)]
        public String MsgID { get; set; }

        [Display(Name = "收藏者")]
        [StringLength(50)]
        public String UserID { get; set; }

        [Display(Name = "收藏时间")]
        [Column(TypeName = "datetime2")]
        public DateTime Time { get; set; }

        [Display(Name = "收件人ID")]
        [StringLength(50)]
        public String ReceiverID { get; set; }
    }
}
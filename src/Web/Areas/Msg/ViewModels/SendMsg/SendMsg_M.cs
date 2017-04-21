using Qx.Msg.Entity;
using Qx.Contents.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Msg.ViewModels.SendMsg
{
    public class SendMsg_M
    {
        public Qx.Msg.Entity.msg ToModel()
        {
            return new Qx.Msg.Entity.msg()
            {
                MsgID = MsgID,
                MsgTypeID = MsgTypeID,
                Subjects = Subjects,
                Contents = Contents,
                CreationTime = CreationTime,
                SenderID = SenderID
            };
        }
        public static SendMsg_M ToViewModel(List<SelectListItem> MsgTypeselectItems)
        {
            return new SendMsg_M()
            {
                MsgTypeselectItems = MsgTypeselectItems,
            };
        }
        [Display(Name = "收件人")]
        [StringLength(50)]
        public string ReceiverID { get; set; }

        [Required]
        [Display(Name = "主题")]
        [StringLength(50)]
        public string Subjects { get; set; }

        [Required]
        [Display(Name = "正文")]
        public string Contents { get; set; }

        [Display(Name = "消息类型")]
        [StringLength(50)]
        public string MsgTypeID { get; set; }

        [StringLength(50)]
        public string MsgID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationTime { get; set; }

        [StringLength(50)]
        public string SenderID { get; set; }

        public List<SelectListItem> MsgTypeselectItems;
    }
}
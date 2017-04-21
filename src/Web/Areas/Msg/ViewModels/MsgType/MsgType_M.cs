using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.MsgType
{
    public class MsgType_M
    {
        public msg_type ToModel()
        {
            return new msg_type()
            {
                MsgTypeID = MsgTypeID ,
                TypeName= TypeName,
                TypeDescription= TypeDescription,
                Remarks= Remarks
            };
        }
        public static MsgType_M ToViewModel(msg_type msgtype)
        {
            return new MsgType_M()
            {
                MsgTypeID = msgtype.MsgTypeID,
                TypeName = msgtype.TypeName,
                TypeDescription = msgtype.TypeDescription,
                Remarks = msgtype.Remarks
            };
        }
        [Display(Name = "消息类型ID")]
        [StringLength(50)]
        public string MsgTypeID { get; set; }

        [Display(Name = "消息类型")]
        [StringLength(50)]
        public string TypeName { get; set; }

        [Display(Name = "描述")]
        [StringLength(50)]
        public string TypeDescription { get; set; }

        [Display(Name = "备注")]
        [StringLength(50)]
        public string Remarks { get; set; }

    }
}
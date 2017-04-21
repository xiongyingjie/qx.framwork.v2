using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.CollectionContents
{
    public class CollectionContent_M
    {
        public static CollectionContent_M ToViewModel(Qx.Msg.Entity.msg msg)
        {
            return new CollectionContent_M()
            {
                MsgID = msg.MsgID,
                Subjects=msg.Subjects,
                Contents=msg.Contents
            };
        }
        [Display(Name = "消息ID")]
        [StringLength(50)]
        public string MsgID { get; set; }

        [Display(Name = "主题")]
        [StringLength(50)]
        public string Subjects { get; set; }

        [Display(Name = "消息内容")]
        [StringLength(50)]
        public string Contents { get; set; }
    }
}
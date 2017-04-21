using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Msg.ViewModels.SendMsg
{
    public class MsgAdd_M
    {
        public static MsgAdd_M ToViewModel(
            List<SelectListItem> MsgTypeItems,
             //List<SelectListItem> GetMyContactsItems,
            string ReceiverID = "", 
            string Subjects = "", 
            string Contents = "", 
            string SenderID = ""
           
            )
        {
            return new MsgAdd_M()
            {
                //_GetMyContactsItems= GetMyContactsItems,
                _MsgTypeItems = MsgTypeItems,
                ReceiverID = ReceiverID,
                Subjects= Subjects,
                Contents= Contents,
                SenderID= SenderID     
            };
        }
        [Display(Name = "收件人")]
        [StringLength(50)]
        public string ReceiverID { get; set; }

        [Display(Name = "发送状态ID")]
        [StringLength(50)]
        public string OutStateID { get; set; }

        [Display(Name = "主题")]
        [StringLength(50)]
        public string Subjects { get; set; }

        [Display(Name = "内容")]
        [StringLength(50)]
        public string Contents { get; set; }

        [Display(Name = "发送者ID")]
        [StringLength(50)]
        public string SenderID { get; set; }

        [Display(Name = "消息类型ID")]
        [StringLength(50)]
        public string MsgTypeID { get; set; }

        public List<SelectListItem> _MsgTypeItems { get; set; }
        public List<SelectListItem> _GetMyContactsItems { get; set; }
    }
}
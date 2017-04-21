using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.MsgUser
{
    public class MsgUser_M
    {
        public msg_user ToModel()
        {
            return new msg_user()
            {
                UserID= UserID,
                UserName= UserName,
                Gender= Gender,
                Address= Address,
                Tel= Tel,
                Title= Title
            };
        }
        public static MsgUser_M ToViewModel(msg_user msguser)
        {
            return new MsgUser_M()
            {
                UserID = msguser.UserID,
                UserName = msguser.UserName,
                Gender = msguser.Gender,
                Address = msguser.Address,
                Tel = msguser.Tel,
                Title = msguser.Title
            };
        }
        [Display(Name = "用户Id")]
        [StringLength(50)]
        public string UserID { get; set; }

        [Display(Name = "姓名")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Display(Name = "性别")]
        [StringLength(50)]
        public string Gender { get; set; }

        [Display(Name = "住址")]
        [StringLength(50)]
        public string Address { get; set; }

        [Display(Name = "电话")]
        [StringLength(50)]
        public string Tel { get; set; }

        [Display(Name = "职位")]
        [StringLength(50)]
        public string Title { get; set; }
    }
}
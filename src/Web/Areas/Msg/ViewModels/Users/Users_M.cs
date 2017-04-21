using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.Users
{
    public class Users_M
    {
        public msg_user ToModel()
        {
            return new msg_user()
            {
                UserID = UserID,
            UserName = UserName,
                Gender= Gender,
                Address=  Address,
                Tel= Tel,
                Title= Title
            };
        }
        public static Users_M ToViewModel(msg_user user)
        {
            return new Users_M()
            {
                UserID = user.UserID,
                UserName = user.UserName,
                Gender = user.Gender,
                Address = user.Address,
                Tel = user.Tel,
                Title = user.Title
            };
        }
        [Display(Name = "ID")]
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

        [Display(Name = "职称")]
        [StringLength(50)]
        public string Title { get; set; }
    }
}
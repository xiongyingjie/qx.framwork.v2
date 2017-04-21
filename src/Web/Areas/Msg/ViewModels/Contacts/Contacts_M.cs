using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Msg.ViewModels.Contacts
{
    public class Contacts_M
    {
        public contact ToModel()
        {
            return new contact()
            {
                ContactID= ContactID,
                OwnerID= OwnerID,
                MembersID= MembersID
            };
        }
        public static Contacts_M ToViewModel(contact Contact)
        {
            return new Contacts_M()
            {
                ContactID = Contact.ContactID,
                OwnerID = Contact. OwnerID,
                MembersID = Contact.MembersID
            };
        }

        [Display(Name = "联系人表ID")]
        [StringLength(50)]
        public string ContactID { get; set; }

        [Display(Name = "所属者ID")]
        [StringLength(50)]
        public string OwnerID { get; set; }

        [Display(Name = "通讯录成员")]
        [StringLength(50)]
        public string MembersID { get; set; }
    }
}
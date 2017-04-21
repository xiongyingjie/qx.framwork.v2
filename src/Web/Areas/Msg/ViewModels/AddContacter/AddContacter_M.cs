using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.AddContacter
{
    public class AddContacter_M
    {

        [Display(Name = "联系人表ID")]
        [StringLength(50)]
        public string ContactID { get; set; }

        [Display(Name = "所属者ID")]
        [StringLength(50)]
        public string OnwerID { get; set; }

        [Display(Name = "联系人ID")]
        [StringLength(50)]
        public string MembersID  { get; set; }
    }
}
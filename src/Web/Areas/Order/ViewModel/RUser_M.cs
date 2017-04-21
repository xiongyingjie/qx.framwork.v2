using Djk.Order.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Order.ViewModel
{
    public class RUser_M
    {
        public r_user ToModel()
        {
            return new r_user() {UserID=UserID };
        }
        public static RUser_M ToViewModel(r_user model)
        {
            return new RUser_M() { UserID=model.UserID };
        }

        [Key]
        [StringLength(50)]
        public string UserID { get; set; }
    }
}
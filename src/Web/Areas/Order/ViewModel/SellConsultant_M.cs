using Djk.Order.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Order.ViewModel
{
    public class SellConsultant_M
    {
        public sell_consultant ToModel()
        {
            return new sell_consultant() { SellConsultantID=SellConsultantID,UserID=UserID };
        }
        public static SellConsultant_M ToViewModel(sell_consultant model)
        {
            return new SellConsultant_M() { SellConsultantID=model.SellConsultantID,UserID=model.UserID};
        }

        [Key]
        [StringLength(150)]
        public string SellConsultantID { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }
    }
}
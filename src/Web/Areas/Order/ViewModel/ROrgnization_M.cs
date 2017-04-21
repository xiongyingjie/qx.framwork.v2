using Djk.Order.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Order.ViewModel
{
    public class ROrgnization_M
    {
        public r_orgnization ToModel()
        {
            return new r_orgnization() {OrgID=OrgID };
        }

        public static ROrgnization_M ToViewModel(r_orgnization model)
        {
            return new ROrgnization_M() {OrgID=model.OrgID };
        }

        [Key]
        [StringLength(50)]
        public string OrgID { get; set; }
    }
}
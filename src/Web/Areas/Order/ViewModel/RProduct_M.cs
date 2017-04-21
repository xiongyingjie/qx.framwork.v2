using Djk.Order.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Order.ViewModel
{
    public class RProduct_M
    {
        public r_product ToModel()
        {
            return new r_product() { ProductID=ProductID};
        }
        public RProduct_M ToViewModel(r_product model)
        {
            return new RProduct_M() { ProductID = model.ProductID };
        }

        [Key]
        [StringLength(300)]
        public string ProductID { get; set; }
    }
}
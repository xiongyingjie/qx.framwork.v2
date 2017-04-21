using Djk.Order.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Order.ViewModel
{
    public class PayOrder_M
    {
        public r_pay_order ToModel()
        {
            return new r_pay_order() {PO_ID=PO_ID };
        }
        public static PayOrder_M ToViewModel(r_pay_order model)
        {
            return new PayOrder_M() {PO_ID=model.PO_ID };
        }

        [Key]
        [StringLength(100)]
        public string PO_ID { get; set; }
    }
}
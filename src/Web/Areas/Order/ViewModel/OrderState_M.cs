using Djk.Order.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Order.ViewModel
{
    public class OrderState_M
    {
        public order_state ToModel()
        {
            return new order_state() {OrderStateID=OrderStateID,StateName=StateName };
        }
        public static OrderState_M ToViewModel(order_state model)
        {
            return new OrderState_M() {OrderStateID=model.OrderStateID,StateName=model.StateName };
        }

        [Key]
        [StringLength(50)]
        public string OrderStateID { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }
    }
}
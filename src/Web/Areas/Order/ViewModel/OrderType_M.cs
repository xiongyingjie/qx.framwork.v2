using Djk.Order.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Order.ViewModel
{
    public class OrderType_M
    {
        public order_type ToModel()
        {
            return new order_type() {OrderTypeID=OrderTypeID,Name=Name,Note=Note};
        }

        public static OrderType_M ToViewModel(order_type model)
        {
            return new OrderType_M() {OrderTypeID=model.OrderTypeID, Name=model.Name,Note=model.Note };
        }

        [Key]
        [StringLength(50)]
        public string OrderTypeID { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(40)]
        public string Note { get; set; }
    }
}
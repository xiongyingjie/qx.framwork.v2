using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Order.Entity;

namespace Web.Areas.Order.ViewModel
{
    public class OrderPayItem_M
    {
        public order_pay_item ToModel()
        {
            return new order_pay_item() {OrderPayItemsID=OrderPayItemsID,
            OrderID=OrderID,PO_ID=PO_ID};
        }
        public static OrderPayItem_M ToViewModel(order_pay_item model)
        {
            return new OrderPayItem_M() {OrderID=model.OrderID,OrderPayItemsID=model.OrderPayItemsID,PO_ID=model.PO_ID };
        }

        [Key]
        [StringLength(250)]
        public string OrderPayItemsID { get; set; }

        [Required]
        [StringLength(150)]
        public string OrderID { get; set; }

        [Required]
        [StringLength(100)]
        public string PO_ID { get; set; }
    }
}
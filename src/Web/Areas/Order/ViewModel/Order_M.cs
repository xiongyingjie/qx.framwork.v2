using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Order.Entity;

namespace Web.Areas.Order.ViewModel
{
    public class Order_M
    {
        public order ToModel()
        {
            return new order() {OrderID=OrderID,OrderTypeID=OrderTypeID,
            SellerID=SellerID,BuyerID=BuyerID,OrderTime=OrderTime,OrderStateID=OrderStateID,
            ShopID=ShopID};
        }
        public static Order_M ToViewModel(order model)
        {
            return new Order_M() {OrderID=model.OrderID,
            OrderTypeID=model.OrderTypeID,SellerID=model.SellerID,
            BuyerID=model.BuyerID,OrderTime=model.OrderTime,OrderStateID=model.OrderStateID,
            ShopID=model.ShopID};

        }


        [StringLength(150)]
        public string OrderID { get; set; }

        [StringLength(50)]
        public string OrderTypeID { get; set; }

        [StringLength(50)]
        public string SellerID { get; set; }

        [Required]
        [StringLength(50)]
        public string BuyerID { get; set; }

        public DateTime OrderTime { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderStateID { get; set; }

        [StringLength(50)]
        public string ShopID { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Order.Entity;

namespace Web.Areas.Order.ViewModel
{
    public class ShoppingCart_M
    {
        public shopping_cart ToModel()
        {
            return new shopping_cart() {SC_ID=SC_ID,BuyerID=BuyerID,SellerID=SellerID,ProductID=ProductID,Num=Num };
        }
        public static ShoppingCart_M ToViewModel(shopping_cart model)
        {
            return new ViewModel.ShoppingCart_M() { SellerID = model.SellerID, BuyerID=model.BuyerID, Num=model.Num, ProductID=model.ProductID, SC_ID=model.SC_ID};
        }
        [Key]
        [StringLength(100)]
        public string SC_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string BuyerID { get; set; }

        [Required]
        [StringLength(50)]
        public string SellerID { get; set; }

        [Required]
        [StringLength(300)]
        public string ProductID { get; set; }

        public int Num { get; set; }

    }
}
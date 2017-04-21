using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Qx.Order.Entity;
using Qx.Tools.CommonExtendMethods;
using Web.Areas.Order.ViewModel;

namespace Web.Areas.Order.ViewModel
{
    public class OrderItem_M
    {
        public order_item ToModel()
        {
            return new order_item() {
                SellOrderItemID = SellOrderItemID,
                OrderID = OrderID,
                ProductID = ProductID,
                Num = Num,
                PriceInOrder = PriceInOrder.EncodeingPrice(),
                TotalPrice = TotalPrice.EncodeingPrice(),
                BenefitDesc = BenefitDesc,
                Discount = Discount.EncodeingPrice()
            };
        }
        public static OrderItem_M ToViewModel(order_item model)
        {
            return new OrderItem_M() {SellOrderItemID=model.SellOrderItemID,
            OrderID=model.OrderID,ProductID=model.ProductID,
            Num= model.Num,
                PriceInOrder =model.PriceInOrder.Value.DeEncodeingPrice(),
                TotalPrice =model.TotalPrice.Value.DeEncodeingPrice(),
            BenefitDesc=model.BenefitDesc,Discount=model.Discount.Value.DeEncodeingPrice()};
        }

        [Key]
        [StringLength(150)]
        public string SellOrderItemID { get; set; }

        [Required]
        [StringLength(150)]
        public string OrderID { get; set; }

        [Required]
        [StringLength(300)]
        public string ProductID { get; set; }

        public int Num { get; set; }

        public double PriceInOrder { get; set; }

        public double TotalPrice { get; set; }

        [Column(TypeName = "text")]
        public string BenefitDesc { get; set; }

        public double Discount { get; set; }
    }
}
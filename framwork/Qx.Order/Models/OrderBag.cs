using System;
using System.Collections.Generic;
using Qx.Order.Entity;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Qx.Order.Interfaces;

namespace Qx.Order.Models
{
   public class OrderBag
   {
        #region 成员变量
        private DataContext _dataContext;
        public Entity.order Order;
        #endregion
        public OrderBag(DataContext dataContext,string sellerId,string shopId, OrderTypeEnum orderType, string buyerId)
        {
            _dataContext = dataContext;
            buyerId = buyerId.HasValue() ? buyerId : dataContext.UserID;
            Order = new Entity.order()
            {
                ShopID=shopId,
                SellerID= sellerId,
                BuyerID = buyerId,
                OrderTime = DateTime.Now,
                OrderID = DateTime.Now.Random(),
                OrderStateID = OrderStateEnum.Created.Parse(),
                OrderTypeID = OrderTypeEnum.Normal.Parse(),
                order_item = new List<order_item>()
            };
        }
        public OrderBag(DataContext dataContext, Entity.order order)
        {
            Order = order;
            _dataContext = dataContext;
        }
       
        public OrderBag BuyCart(CartBag cartBag,IProductProvider provider)
        {
            cartBag.CartItems.ForEach(a =>
            {
                //---------查询折扣和价格------------------
                const double PRICE = -999;
                const string BENEFITDESC = "";
                const double DISCOUNT =1;
                //---------查询折扣和价格------------------
                Order.order_item.Add(new order_item()
                {
                    OrderID = Order.OrderID,
                    ProductID = a.ProductId,
                    SellOrderItemID = Order.OrderID+"-"+ a.ProductId,
                    Num = a.Num,
                    PriceInOrder = provider.GetPromotionPrice(_dataContext,a.ProductId).EncodeingPrice(),
                    TotalPrice = (a.Num * provider.GetPromotionPrice(_dataContext, a.ProductId)).EncodeingPrice(),
                    BenefitDesc = BENEFITDESC,
                    Discount = DISCOUNT.EncodeingPrice()
                });
            });
           
            return this;
        }

       public OrderBag ChageType(OrderTypeEnum type)
       {
           Order.OrderTypeID = type.ToString();
           return this;
       }
        private OrderBag ChageState(OrderStateEnum state)
        {
            Order.OrderStateID = state.ToString();
            return this;
        }
        private OrderBag ChageState(OrderStateEnum from, OrderStateEnum to)
        {
            if (Order.OrderStateID != from.ToString())
            {
                throw new Exception("非法操作：要将订单状态变更为"+ to .ToString()+ 
                    "，要求订单当前状态必须为：" + from.ToString());
            }
            return ChageState(to);
        }
      
        public OrderBag Check()
       {
           return ChageState(OrderStateEnum.Created, OrderStateEnum.Checked);
       }
        public OrderBag Pay()
        {
            return ChageState(OrderStateEnum.Checked, OrderStateEnum.Payed);
        }
        public OrderBag Deliver()
        {
            return ChageState(OrderStateEnum.Payed, OrderStateEnum.Delivered);
        }
        public OrderBag Recei()
        {
            return ChageState(OrderStateEnum.Delivered, OrderStateEnum.Received);
        }
        public OrderBag Done()
        {
            return ChageState(OrderStateEnum.Received, OrderStateEnum.Done);
        }
        public OrderBag Evaluat()
        {
            return ChageState(OrderStateEnum.Received, OrderStateEnum.Evaluated);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Qx.Order.Entity;
using Qx.Order.Interfaces;
using Qx.Order.Models;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace Qx.Order.Services
{
    public class OrderService : BaseRepository, IOrderService
    {
        
       

        public CartBag CreateCart(DataContext dataContext)
        {
            return new CartBag(dataContext);
        }

        public CartBag FindCart(DataContext dataContext, IProductProvider provider)
        {
            var cart = CreateCart(dataContext);
            cart.CartItems = Db.shopping_cart.
                 Where(a => a.BuyerID == dataContext.UserID).
                 ToList().
                 Select(b=>new ShoppingCartItem
                 {
                     Price = provider.GetPrice(dataContext,b.ProductID).EncodeingPrice(),
                     BuyerId = b.BuyerID,
                     Name = provider.GetName(dataContext, b.ProductID),
                     Num=b.Num,
                     ProductId = b.ProductID,
                     SellerId = b.SellerID
                 }).
                 ToList();
            return cart;
        }

        public OrderBag CreateOrder(DataContext dataContext, string sellerId,string shopId, OrderTypeEnum orderType, string burerId)
        {
            return new OrderBag(dataContext,sellerId, shopId, orderType,burerId);
        }

        public OrderBag FindOrder(DataContext dataContext, string orderId)
        {
            var orderInDb = Db.order.Find(orderId);
            if (orderInDb == null)
            { throw new Exception("订单不存在！orderId=>" + orderId); }
            var order = new OrderBag(dataContext, orderInDb);
            return order;
        }

        public bool DeleteOrder(DataContext dataContext, string orderId)
        {
            var orderInDb = Db.order.Find(orderId);
            if (orderInDb == null)
            { throw new Exception("订单不存在！orderId=>" + orderId); }
            Db.order.Remove(orderInDb);
            return Db.SaveChanges() > 0;
        }

        public List<OrderBag> FindOrders(DataContext dataContext,string shopId="")
        {
            var orders = new List<order>();
            if (shopId.HasValue())            
                 orders = Db.order.Where(a => a.ShopID == shopId).ToList();
            else
                 orders = Db.order.Where(a => a.BuyerID == dataContext.UserID).ToList();
            return orders.Select(b => new OrderBag(dataContext, b)).
                ToList();
        }

        public bool SyncCart(CartBag cartBag)
        {
            return Db.SyncCart(cartBag);
        }

        public bool SyncOrder(OrderBag orderBag)
        {
            return Db.SyncOrder(orderBag);
        }
        public int ProductInOrderCount(string productid)
        {
            return Db.order_item.Count(a => a.ProductID == productid);
        }
        public int ProductInCartCount( string productid)
        {
            return Db.shopping_cart.Count(a => a.ProductID == productid);
        }
        public int ProductInCartCount(DataContext dataContext, string productid)
        {
            return Db.shopping_cart.Count(a => a.BuyerID == dataContext.UserID && a.ProductID == productid);
        }
    }
}

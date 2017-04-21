using System.Collections.Generic;
using Qx.Order.Models;
using Qx.Tools;
using Qx.Tools.Interfaces;

namespace Qx.Order.Interfaces
{
 public  interface IOrderService
 {
       
        CartBag CreateCart(DataContext dataContext);
        CartBag FindCart(DataContext dataContext, IProductProvider provider);
        bool SyncCart(CartBag cartBag);
        OrderBag CreateOrder(DataContext dataContext,string sellerId,string shopId, OrderTypeEnum orderType,string buyerId="");
        OrderBag FindOrder(DataContext dataContext,string orderId);
        bool DeleteOrder(DataContext dataContext, string orderId);
        List<OrderBag> FindOrders(DataContext dataContext,string sellerId="");
        bool SyncOrder(OrderBag orderBag);
        int ProductInCartCount(string productid);
        int ProductInOrderCount(string productid);
        int ProductInCartCount(DataContext dataContext, string productid);
 }
}

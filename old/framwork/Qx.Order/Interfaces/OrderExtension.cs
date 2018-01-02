using System.Data.Entity.Migrations;
using System.Linq;
using Qx.Order.Entity;
using Qx.Order.Models;

namespace Qx.Order.Interfaces
{
   public static class OrderExtension
    {
       public static bool SyncOrder(this MyDbContext db, OrderBag orderBag)
        {
            //同步到数据库

            ////是否已存在该订单 清空旧数据
            //var oldOrder = db.Orders.Find(orderBag.Order.OrderID);
            //if (oldOrder != null)
            //{
            //    db.Orders.Remove(oldOrder);
            //    orderBag.Order.OrderItems.ToList().ForEach(a =>
            //    {
            //        db.OrderItems.Remove(db.OrderItems.Find(a.SellOrderItemID));
            //    });
            //    //不安全保存
            //    db.SaveChanges();
            //}

            //添加新数据
            db.order.AddOrUpdate(orderBag.Order);
            orderBag.Order.order_item.ToList().ForEach(a=>db.order_item.AddOrUpdate(a));
            //保存
            return db.SaveChanges() > 0;
        }

        public static bool SyncCart(this MyDbContext db, CartBag cartBag)
        {

            var idInCart = cartBag._cartItems.Select(a => a.SC_ID);

            //删除
            var inDbNotInCart = db.shopping_cart.Where(a => !idInCart.Contains(a.SC_ID));
            //添加
            var inCartNotInDb = cartBag._cartItems.Where(a => !db.shopping_cart.Any(b => b.SC_ID.Contains(a.SC_ID)));
            //更新
            var inCartAndInDb = db.shopping_cart.AsNoTracking().Where(a => idInCart.Contains(a.SC_ID)).ToList();

            //同步到数据库
            db.shopping_cart.RemoveRange(inDbNotInCart);
            db.shopping_cart.AddRange(inCartNotInDb);
            inCartAndInDb.ForEach(a => db.shopping_cart.AddOrUpdate(a));
            return db.SaveChanges() > 0;
        }

        public static string Parse(this OrderStateEnum orderState)
       {
            return orderState.ToString();
       }
        public static string Parse(this OrderTypeEnum orderType)
        {
            return orderType.ToString();
        }
      
    }
}

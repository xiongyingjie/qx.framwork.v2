using System;
using System.Collections.Generic;
using System.Linq;
using Qx.Order.Entity;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace Qx.Order.Models
{
   public class CartBag
   {
       private DataContext _dataContext;
       public List<ShoppingCartItem> CartItems;

        public List<shopping_cart> _cartItems
       {
           get
           {
               return CartItems.Select(a => new shopping_cart()
               {
                   BuyerID = _dataContext.UserId,
                   SellerID = a.SellerId,
                   Num = 1,
                   ProductID = a.ProductId,
                   SC_ID = _dataContext.UserId + "-" +
                           a.SellerId + "-" +
                           a.ProductId
               }).ToList();
           }
        }

        public CartBag(DataContext dataContext)
       {
           _dataContext = dataContext;
            CartItems = new List<Models.ShoppingCartItem>();
       }
       public CartBag AddItem( string sellerId, string productId,IProductProvider provider)
       {
            //是否添加过
           var added = CartItems.FirstOrDefault(a => a.ProductId == productId &&
           a.SellerId == sellerId);
           if (added!=null)
           {
                CartItems.Remove(added);
                added.Num += 1;//只加数量
                CartItems.Add(added);
           }
           else
           {
                var product=new ShoppingCartItem()
                {
                    Price = provider.GetPrice(_dataContext, productId).EncodeingPrice(),
                    BuyerId = _dataContext.UserId,
                    Name = provider.GetName(_dataContext,productId),
                    Num =1,
                    ProductId = productId,
                    SellerId = sellerId
                };
                CartItems.Add(product);
            }
           
           return this;
       }
        public CartBag AddItems(string sellerId, string productId ,IProductProvider provider, int num)
        {
            var i = 0;
            while (i<num)
            {
                AddItem(sellerId, productId, provider);
                i++;
            }
            return this;
        }
        public CartBag RemoveItem(string sellerId, string productId)
       {
            //是否添加过
            var added = CartItems.FirstOrDefault(a => a.ProductId == productId &&
            a.SellerId == sellerId);
            if (added != null)
            {
                CartItems.Remove(added);
                added.Num -= 1;//只变数量,少于0删除
                if (added.Num <= 0)
                {
                    CartItems.Remove(added);
                }
                else
                {
                    CartItems.Add(added);
                }
               
            }
            else
            {
                throw new Exception("未在购物车中找到该商品:productId=>" + productId);
            }

            return this;
        }
        public CartBag RemoveItems(string sellerId, string productId)
        {
            CartItems.RemoveAll(a=>a.ProductId== productId);
            return this;
        }
        public CartBag RemoveAllItems()
        {
            while (_cartItems.Count > 0)
            {
                CartItems.Remove(CartItems[0]);
            }
            return this;
        }
    }
}

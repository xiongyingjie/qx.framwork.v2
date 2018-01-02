
namespace Qx.Order.Models
{
  public  class ShoppingCartItem
    {
        public float Price { get; set; }
        public string Name { get; set; }
        public string ProductId { get; set; }
        public string BuyerId { get; set; }

        public string SellerId { get; set; }

        public int Num { get; set; }
    }
}

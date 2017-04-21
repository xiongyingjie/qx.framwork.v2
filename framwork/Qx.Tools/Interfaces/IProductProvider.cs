namespace Qx.Tools.Interfaces
{
  public  interface IProductProvider
  {
      string GetName(DataContext dataContext, string productId);
      double GetPrice(DataContext dataContext, string productId);
      double GetPromotionPrice(DataContext dataContext, string productId);
    }
}

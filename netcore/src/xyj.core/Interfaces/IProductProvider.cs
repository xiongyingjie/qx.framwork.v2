namespace xyj.core.Interfaces
{
  public  interface IProductProvider : IAutoInject
    {
      string GetName(DataContext dataContext, string productId);
      double GetPrice(DataContext dataContext, string productId);
      double GetPromotionPrice(DataContext dataContext, string productId);
    }
}

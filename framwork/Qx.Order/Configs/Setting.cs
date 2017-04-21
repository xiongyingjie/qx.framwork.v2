using System.Configuration;

namespace Qx.Order.Configs
{
   public static class Setting
   {
       public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Djk.Order"].ConnectionString;
   }
}

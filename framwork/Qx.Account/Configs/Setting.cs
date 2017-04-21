using System.Configuration;

namespace Qx.Account.Configs
{
   public static class Setting
   {
       public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Djk.Account"].ConnectionString;
   }
}

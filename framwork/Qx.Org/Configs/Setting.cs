using System.Configuration;

namespace Qx.Org.Configs
{
   public static class Setting
   {
       public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Djk.Org"].ConnectionString;
   }
}

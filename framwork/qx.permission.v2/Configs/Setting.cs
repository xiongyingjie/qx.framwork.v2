using System.Configuration;

namespace qx.permmision.v2.Configs
{
   public static class Setting
   {
       public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["qx.permmision.v2"].ConnectionString;
   }
}

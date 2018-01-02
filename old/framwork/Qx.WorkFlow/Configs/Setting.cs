using System.Configuration;

namespace Qx.WorkFlow.Configs
{
   public static class Setting
   {
       public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Qx.WorkFlow"].ConnectionString;
   }
}

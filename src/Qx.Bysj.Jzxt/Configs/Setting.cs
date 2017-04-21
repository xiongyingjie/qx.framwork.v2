using System.Configuration;

namespace Qx.Bysj.Jzxt.Configs
{
   public static class Setting
   {
   
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Qx.Bysj.Jzxt"].ConnectionString;




    }
}

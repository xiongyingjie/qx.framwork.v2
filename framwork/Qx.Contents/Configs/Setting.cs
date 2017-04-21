using System.Configuration;

namespace Qx.Contents.Configs
{
    public static class Setting
    {
        public static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["qx.contents"].ConnectionString;

       
    }
}
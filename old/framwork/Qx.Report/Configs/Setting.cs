using System.Configuration;

namespace Qx.Report.Configs
{
    public static class Setting
    {
        public static readonly string ReportRuleConnectionString =
            ConfigurationManager.ConnectionStrings["qx.system"].ConnectionString;
    }
}
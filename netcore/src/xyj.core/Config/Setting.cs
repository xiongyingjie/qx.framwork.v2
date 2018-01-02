using System.Collections.Generic;

namespace xyj.core.Config
{
    public static class Setting
    {
        public readonly static bool IsUnitTest = false;
        public readonly static string FixedParamFlag = "!fixed";
        public readonly static List<string> AllType = new List<string>()
            {
               "System.Object",
               "System.String",
               "System.ValueType",
               "System.Enum",
               "System.Array",
               "System.Exception",
               "System.SByte",
               "System.Byte",
               "System.Int16",
               "System.Int32",
               "System.UInt32",
               "System.Int64",
               "System.UInt64",
               "System.Char",
               "System.Single",
               "System.Double",
               "System.Boolean",
               "System.Decimal",
               "System.DateTime"
            };
        public readonly static string DbHost = "qxamoy.com,10385";
        public readonly static string DbUser = "sa";
        public readonly static string DbPassword = "QxamoySQL666";
        public readonly static string SystemDbName = "sys.core";//框架数据库
        public readonly static Dictionary<string,string> DbMapping = new Dictionary<string, string> ()
        {
            {"qx.permmision.v2","sys.core" },
            {"qx.qx.system","sys.core" }
        };//框架数据库

    }
}

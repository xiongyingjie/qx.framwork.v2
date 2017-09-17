using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Tools
{
    public static class QxConfigs
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
    }
}

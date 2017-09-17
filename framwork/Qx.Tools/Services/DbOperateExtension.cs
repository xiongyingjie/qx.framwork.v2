using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Models.Db;

namespace Qx.Tools.Services
{
    public static class DbOperateExtension
    {
        public static Operate ToOperate(this string src)
        {
            Operate type;
            Operate.TryParse(src.ToBigCamelCase(), out type);
            return type;
        }

    }
}
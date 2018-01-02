using xyj.core.Extensions;
using xyj.core.Models.Db;

namespace xyj.core.Services
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
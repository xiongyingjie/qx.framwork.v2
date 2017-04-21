using System;
using System.IO;
using System.Web;

namespace Qx.Tools
{
    public class PathUtility
    {
        public static string MapPath(string virtualPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(virtualPath);
            }
            return ToPhysicalPath(virtualPath);
        }

        public static string ToPhysicalPath(string virtualPath)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            var path = virtualPath.TrimStart('~', '/');
            path = path.Replace('/', '\\');
            return Path.Combine(basePath, path);
        }

        public static string Combine(params string[] paths)
        {
            return Path.Combine(paths);
        }
    }
}
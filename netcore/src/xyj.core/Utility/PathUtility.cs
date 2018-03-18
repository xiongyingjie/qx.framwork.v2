using System;
using System.IO;
using xyj.core.Exceptions.Upgrate;

namespace xyj.core.Utility
{
    public class PathUtility
    {
        public static string MapPath(string virtualPath)
        {
            throw new NotSupportedExceptionInCoreException();
            //if (HttpContext.Current != null)
            //{
            //    return HttpContext.Current.Server.MapPath(virtualPath);
            //}
            //return ToPhysicalPath(virtualPath);
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
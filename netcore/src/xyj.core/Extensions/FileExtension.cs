using xyj.core.Exceptions.Upgrate;
using xyj.core.Utility;

namespace xyj.core.Extensions
{
    public static class FileExtension
    {
        #region 读写文件 
        public static string ReadFile(this string realPath)
        {
            return FileUtility.ReadFile(realPath);
        }
        public static bool WriteFile(this string content , string realPath, bool overWrite = false)
        {
            return FileUtility.WriteFile(realPath, content, overWrite);
        }
        #endregion
      
        public static string ToRealPath(this string path)
       {
            throw new NotSupportedExceptionInCoreException();
        //    return Web.HttpContext.Current.Request.MapPath(path);
       }
        #region 路径转换 
        public static string ReadHttpFile(this string realPath)
        {
            return FileUtility.ReadFile(realPath.ToRealPath());
        }
        public static bool WriteHttpFile(this string content, string realPath, bool apend = false)
        {
            return FileUtility.WriteFile(realPath.ToRealPath(), content, apend);
        }
        #endregion
    }
}
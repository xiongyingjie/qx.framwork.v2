using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Qx.Tools.CommonExtendMethods
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
            return System.Web.HttpContext.Current.Request.MapPath(path);
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
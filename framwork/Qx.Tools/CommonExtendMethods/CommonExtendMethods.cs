using System;
using System.Collections.Generic;
namespace Qx.Tools.CommonExtendMethods
{
   
    public static class CommonExtendMethods
    {  
        public static bool IsSame<T, K>(this object obj)
        {
            return typeof (T).Name == typeof (K).Name;
        }
        #region 快速创建 IEqualityComparer<T> 的实例
        public static IEqualityComparer<T> CreateEqualityComparer<T,V>(this object obj, Func<T, V> keySelector)
        {
            return Equality<T>.CreateComparer(keySelector);
        }
        #endregion
        #region 快速创建 IComparer<T> 的实例
        public static IComparer<T> CreateComparer<T, V>(this object obj, Func<T, V> keySelector)
        {
            return Comparison<T>.CreateComparer(keySelector);
        }
        #endregion
    }
}
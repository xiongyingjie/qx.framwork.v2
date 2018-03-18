using System;
using System.Collections.Generic;
using System.Reflection;
using xyj.core.Utility;

namespace xyj.core.Extensions
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
            return Utility.Comparison<T>.CreateComparer(keySelector);
        }
        #endregion


        /// <summary>
        /// Copy Propertys and Fileds 
        /// 拷贝属性和公共字段
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static T CopyToAll<T>(this object source, T target=null) where T : class, new()
        {
           
            if (source == null)
            {
                return target;
            }

            if (target == null)
            {
                target = new T();
               // throw new ApplicationException("target 未实例化！");
            }


            var properties = target.GetType().GetProperties();
            foreach (var targetPro in properties)
            {
                try
                {
                    //判断源对象是否存在与目标属性名字对应的源属性
                    if (source.GetType().GetProperty(targetPro.Name) == null)
                    {
                        continue;
                    }
                    //数据类型不相等
                    if (targetPro.PropertyType.FullName != source.GetType().GetProperty(targetPro.Name).PropertyType.FullName)
                    {
                        continue;
                    }
                    var propertyValue = source.GetType().GetProperty(targetPro.Name).GetValue(source, null);
                    if (propertyValue != null)
                    {

                        target.GetType().InvokeMember(targetPro.Name, BindingFlags.SetProperty, null, target, new object[] { propertyValue });
                    }
                }
                catch (Exception )
                {
                    
                }
            }
            //返回所有公共字段
            var targetFields = target.GetType().GetFields();
            foreach (var filed in targetFields)
            {
                try
                {
                    var tfield = source.GetType().GetField(filed.Name);
                    if (null == tfield)
                    {
                        //如果源对象中不包含这个公共字段则不处理
                        continue;
                    }
                    //类型不一致不处理
                    if (filed.FieldType.FullName != tfield.FieldType.FullName)
                    {
                        continue;
                    }
                    var fieldValue = tfield.GetValue(source);
                    if (fieldValue != null)
                    {
                        target.GetType().InvokeMember(filed.Name, BindingFlags.SetField, null, target, new object[] { fieldValue });
                    }
                }
                catch (Exception )
                {
                }
            }
            return target;
        }


        /// <summary>
        /// Copy Simple Property and Fileds
        /// 拷贝简单属性和公共字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static T  CopyTo<T>(this object source, T target = null) where T : class, new()
        {
            if (source == null)
            {
                return target;
            }

            if (target == null)
            {
                target = new T();
                // throw new ApplicationException("target 未实例化！");
            }

            var properties = target.GetType().GetProperties();
            foreach (var targetPro in properties)
            {
                try
                {
                    //判断源对象是否存在与目标属性名字对应的源属性
                    if (source.GetType().GetProperty(targetPro.Name) == null)
                    {
                        continue;
                    }
                    //判断是否枚举集合
                    if (targetPro.PropertyType.IsGenericType && targetPro.PropertyType.GetGenericArguments()[0].IsEnum)
                    {
                        continue;
                    }
                    // 判断是否数组
                    else if (targetPro.PropertyType.IsArray)
                    {
                        continue;
                    }
                    // 判断是否IList
                    else if (targetPro.PropertyType.IsGenericType && targetPro.PropertyType.GetInterface("System.Collections.IEnumerable") != null)
                    {
                        continue;
                    }

                    var propertyValue = source.GetType().GetProperty(targetPro.Name).GetValue(source, null);
                    if (propertyValue != null)
                    {
                        if (propertyValue.GetType().IsEnum)
                        {
                            continue;
                        }

                        target.GetType().InvokeMember(targetPro.Name, BindingFlags.SetProperty, null, target, new object[] { propertyValue });
                    }
                }
                catch (Exception )
                {

                }
            }

            //返回所有公共字段
            var targetFields = target.GetType().GetFields();
            foreach (var filed in targetFields)
            {
                try
                {
                    var tfield = source.GetType().GetField(filed.Name);
                    if (null == tfield)
                    {
                        //如果源对象中不包含这个公共字段则不处理
                        continue;
                    }
                    //类型不一致不处理
                    if (filed.FieldType.FullName != tfield.FieldType.FullName)
                    {
                        continue;
                    }
                    var fieldValue = tfield.GetValue(source);
                    if (fieldValue != null)
                    {
                        target.GetType().InvokeMember(filed.Name, BindingFlags.SetField, null, target, new object[] { fieldValue });
                    }
                }
                catch (Exception )
                {
                }
            }
            return target;
        }

    }
}
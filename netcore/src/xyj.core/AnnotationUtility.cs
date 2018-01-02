using System;
using System.Collections.Generic;
using System.Linq;

namespace xyj.core
{
    public static class AnnotationUtility
    {
        /// <summary>
        /// Cache Data
        /// </summary>
        private static readonly Dictionary<string, string> Cache = new Dictionary<string, string>();

     

        internal static string GetAttributeValue<T>(Type sourceType, Func<T, string> attributeValueAction,
            string name) where T : Attribute
        {
            var key = BuildKey(sourceType, name, attributeValueAction.Method.GetHashCode());
            if (!Cache.ContainsKey(key))
            {
                CacheAttributeValue(sourceType, attributeValueAction, name);
            }
            return Cache[key];
        }

        /// <summary>
        /// 缓存Attribute Value
        /// </summary>
        private static void CacheAttributeValue<T>(Type type,
            Func<T, string> attributeValueAction, string name)
        {
            var key = BuildKey(type, name, attributeValueAction.Method.GetHashCode());

            var value = GetValue(type, attributeValueAction, name);

            lock (key + "_attributeValueLockKey")
            {
                if (!Cache.ContainsKey(key))
                {
                    Cache[key] = value;
                }
            }
        }

        private static string GetValue<T>(Type type,
            Func<T, string> attributeValueAction, string name)
        {
            object attribute = null;
            if (string.IsNullOrEmpty(name))
            {
                attribute =
                    type.GetCustomAttributes(typeof(T), false).FirstOrDefault();
            }
            else
            {
                var propertyInfo = type.GetProperty(name);
                if (propertyInfo != null)
                {
                    attribute =
                        propertyInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
                }

                var fieldInfo = type.GetField(name);
                if (fieldInfo != null)
                {
                    attribute = fieldInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
                }
            }

            return attribute == null ? null : attributeValueAction((T)attribute);
        }

        /// <summary>
        /// 缓存Collection Name Key
        /// </summary>
        private static string BuildKey(Type type, string name,int fn)
        {
            if (string.IsNullOrEmpty(name))
            {
                return type.FullName+ fn;
            }

            return type.FullName + "." + name+ fn;
        }
    }
}

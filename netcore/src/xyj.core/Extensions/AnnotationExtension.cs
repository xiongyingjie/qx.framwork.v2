using System;

namespace xyj.core.Extensions
{
  public static   class AnnotationExtension
    {
        /// <summary>
        /// 获取CustomAttribute Value
        /// </summary>
        /// <typeparam name="T">Attribute的子类型</typeparam>
        /// <param name="sourceType">头部标有CustomAttribute类的类型</param>
        /// <param name="attributeValueAction">取Attribute具体哪个属性值的匿名函数</param>
        /// <returns>返回Attribute的值，没有则返回null</returns>
        public static string GetCustomAttributeValue<T>(this Type sourceType, 
            Func<T, string> attributeValueAction) where T : Attribute
        {
            return AnnotationUtility.GetAttributeValue(sourceType, attributeValueAction, null);
        }

        /// <summary>
        /// 获取CustomAttribute Value
        /// </summary>
        /// <typeparam name="T">Attribute的子类型</typeparam>
        /// <param name="sourceType">头部标有CustomAttribute类的类型</param>
        /// <param name="attributeValueAction">取Attribute具体哪个属性值的匿名函数</param>
        /// <param name="name">field name或property name</param>
        /// <returns>返回Attribute的值，没有则返回null</returns>
        public static string GetCustomAttributeValue<T>(this Type sourceType,
            Func<T, string> attributeValueAction,
            string name) where T : Attribute
        {
            return AnnotationUtility.GetAttributeValue(sourceType, attributeValueAction, name);
        }

    }
}

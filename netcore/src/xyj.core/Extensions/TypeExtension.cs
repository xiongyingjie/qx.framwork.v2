using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using xyj.core.Exceptions.Upgrate;

namespace xyj.core.Extensions
{
    public static class TypeExtension
    {

        //获取Controller下的public action =>通过反射获取Controller的子方法
        public static List<MethodInfo> GetSubActions(this Type t)
        {
            throw new NotSupportedExceptionInCoreException();
         //   return t.GetMethods().Where(m => m.ReturnType == typeof(ActionResult) && m.IsPublic).ToList();
        }

        //获取所有的Controllers =>通过反射获取Controller的子类
        public static List<Type> GetSubClasses(this Type type)
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(
                t => t.IsSubclassOf(type)).ToList();
        }

        public static List<Type> GetAllTypes(this object obj, List<string> AssemblieFilter, List<string> NamespaceFilter)
        {
            var allAssemlys = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var filteredAssemlys = new List<Assembly>();

            var allTypes = new List<Type>();
            var filteredTypes = new List<Type>();

            AssemblieFilter.ForEach(a => { filteredAssemlys.AddRange(allAssemlys.Where(b => b.FullName.Contains(a))); });
            for (var i = 0; i < filteredAssemlys.Count; i++)
            {
                try
                {
                    allTypes.AddRange(allAssemlys[i].GetTypes());
                }
                catch (Exception)
                {
                    i++;
                    //越过异常 throw;
                }
            }

            NamespaceFilter.ForEach(a => { filteredTypes.AddRange(allTypes.Where(b => b.FullName.Contains(a))); });
            return filteredTypes;
        }

        public static Dictionary<Type, Type> GetClassInterfaceDic(this List<Type> Types)
        {
            var dest = new Dictionary<Type, Type>();

            var interfaces = Types.Where(a => a.IsInterface);
            var classes = Types.Where(a => !a.IsInterface);

            foreach (var _interface in interfaces)
            {
                foreach (var _class in classes.Where(a => a.GetInterfaces().Contains(_interface))) //实现该接口的所有类
                {
                    //如果出现一个接口被多个类实现，这里会执行多次，对于ioc是非常不利的！！
                    //采用dictionary 可以避免避免插入重复匹配记录
                    try
                    {
                        dest.Add(_interface, _class);
                    }
                    catch (Exception )
                    {
                        break; //检测到重复 做中断处理
                    }
                }
            }

            return dest;
        }
    }
}
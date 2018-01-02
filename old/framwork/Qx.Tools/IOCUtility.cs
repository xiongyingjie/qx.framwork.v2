using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Qx.Tools.Interfaces;

namespace Qx.Tools
{
   public static class IOCUtility
    {
       public static void AutoRegist()
       {
            var builder = new ContainerBuilder();
            //获取IAutoInject的Type
            var baseType = typeof(IAutoInject);
            //获取所有程序集
            var assemblies = System.Web.Compilation.BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();
            //错误写法(在回收程序池后会导致注册信息丢失)： var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToArray();
            //自动注册接口
            builder.RegisterAssemblyTypes(assemblies).Where(b => b.GetInterfaces().
            Any(c => c == baseType && b != baseType)).AsImplementedInterfaces(). InstancePerLifetimeScope();
            //自动注册控制器
            builder.RegisterControllers(assemblies);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

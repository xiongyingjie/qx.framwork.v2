using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Qx.Tools.CommonExtendMethods;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using Qx.Tools;
using Web.Controllers.Base;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

           IOCUtility.AutoRegist();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var debug = true;
            if (debug)
            {
                var ex = Server.GetLastError();

                var message = ex.Message;
                if (ex.GetType() == typeof(DbEntityValidationException))
                {
                    var entityEx = (DbEntityValidationException)ex;
                    message = "保存到数据库时出现错误:<br/>" + entityEx.EntityValidationErrors.SelectMany(a => a.ValidationErrors.Select(b => b.ErrorMessage))
                        .ToList()
                        .PackString("<br/>");
                }
                else if (ex.GetType() == typeof(InvalidOperationException) && ex.StackTrace.Contains("DefaultControllerFactory"))
                //System.Web.Mvc.DefaultControllerFactory.DefaultControllerActivator.Create
                {
                    var invalidOperationException = (InvalidOperationException)ex;
                    var url = Request.Url.ToString();

                    var temp = url.Substring(0, url.LastIndexOf("/", StringComparison.Ordinal));
                    var controller = temp.Substring(temp.LastIndexOf("/", StringComparison.Ordinal) + 1) + "Controller";

                    message = "为" + controller + "注入依赖时出错:<br/>1.请确保" + controller + "构造函数中的Service/Repository均被实现<br/>2.请检查1中的Service是否实现了IAutoInject接口";
                }

                Response.ClearContent();
                Response.Write(new BaseController.FormUI()
                {
                    code = (int)BaseController.State.Error,
                    jsonData = new { Message = message, StackTrace = ex.StackTrace, InnerException = ex.InnerException }.Serialize(),
                    msg = "请求失败",
                    url = ""
                }.Serialize());
                Response.Flush();
                Response.End();
            }
           
        }
    }
}

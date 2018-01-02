
using Web.Controllers.Base;

namespace Web.Controllers.Filter
{
    public class AppFilterController : BaseController
    {
        //
      
       // private IPermission _permission;
        
        public AppFilterController()
        {
         
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var uid = filterContext.RequestContext.HttpContext.Request["uid"];
            if (uid == null|| uid=="游客")//未登录
            {
                ReturnUrl = Request.RawUrl;
                filterContext.Result = new RedirectResult("/F2/NotLogin");
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}

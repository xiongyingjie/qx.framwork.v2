
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;

namespace Web.Controllers.Filter
{
    public class WxFilter : BaseController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!DataContext.UserId.HasValue())//未登录
            {
                filterContext.Result = new RedirectResult("/WeChat/Web/Authorize?return_url=" + Request.RawUrl);
            }
            else
            {
                //Response.Write(DataContext.UserID);
                base.OnActionExecuting(filterContext);
            }
        }
    }
}

using System.Web.Mvc;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;

namespace Web.Controllers.Base
{
    public class WxWebFilterController : BaseController
    {
        protected const string PLATE_WECHATPAY_ACCOUNT = "plate-wechat";
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!DataContext.UserID.HasValue())//未登录
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

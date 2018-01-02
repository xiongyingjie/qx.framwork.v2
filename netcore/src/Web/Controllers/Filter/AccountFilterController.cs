
using Qx.Tools;
using Web.Controllers.Base;

namespace Web.Controllers.Filter
{
    public class AccountFilterController : BaseController
    {
        //
      
       // private IPermission _permission;
        
        public AccountFilterController()
        {
          //  _permission =new PermissionServices();
        }

        //public IActionResult _PandaLayout_Menu(string selectedId="")
        //{
        //  //  if (MenuItems == null)
        //        MenuItems = (_permission.GetMenuByUserId(DataContext.UserID));

        //    return PartialView(MenuItems.Selected(selectedId));
        //}
        //protected List<MenuItem> MenuItems
        //{
        //    get
        //    {
        //        return Session["MenuItems"] as List<MenuItem>;
        //    }
        //    set
        //    {
        //        Session["MenuItems"] = value;
        //    }
        //}
        protected AccountContext AccountContext
        {
            get
            {
                return Session["AccountContext"] as AccountContext;
            }
            set
            {
                Session["AccountContext"] = value;
            }
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {   
            if (AccountContext == null)//未登录
            {
                ReturnUrl = Request.RawUrl;
                filterContext.Result = new RedirectResult("/F2/Login");
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}

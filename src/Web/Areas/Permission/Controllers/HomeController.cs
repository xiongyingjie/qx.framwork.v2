using Qx.Permission.Interfaces;

namespace Web.Areas.Permission.Controllers
{
    public class HomeController : BasePermissionController
    {
        //
        // GET: /Permision2/Home/
        private IPermission _permission;
        public HomeController(IPermission permission)
        {
            _permission = permission;
        }
        //获取菜单[排序后]
       
        //public ActionResult Index()
        //{
        //    return View();
        //   //(new Index_M()
        //   //{
        //   //   // MenuItems = (_permission.GetMenuByUserId("10385-14093"))
        //   //}
        //   );
        //}

    }
}

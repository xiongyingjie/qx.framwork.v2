using System.Collections.Generic;
using System.Web.Mvc;
using Qx.Permission.Entity;
using Qx.Permission.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Web.Areas.Permission.ViewModels.Admin;

namespace Web.Areas.Permission.Controllers
{
    public class AdminController : BasePermissionController
    {
        private IPermission _permission;
        private IRepository<role> _role;
        private IRepository<permission_user> _user;
        public AdminController(IPermission permission, IRepository<role> role, IRepository<permission_user> user)
        {
            _permission = permission;
            _role = role;
            _user = user;
        }
        //
        // GET: /Permission/Admin/

        public ActionResult Index()
        {
            InitMenu(new Dictionary<string, string>() {
                {"角色列表","/Permission/Admin/RoleList?ReportID=Permision_角色列表&Params=;"},
                {"用户列表","/Permission/Admin/UserList?ReportID=Permision_用户列表&Params=;"},
                {"按钮列表","/Permission/Admin/ButtonList?ReportID=Permision_按钮列表&Params=;"},
                {"菜单列表","/Permission/Admin/MenuList?ReportID=Permision_菜单列表&Params=MRoot"}
            });
            return View();
        }
        ///Permission/Admin/RoleList?ReportID=Permision_角色列表&Params=;
        public ActionResult RoleList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {

                return RedirectToAction("RoleList", new { ReportID = "Permision_角色列表", Params = ";;", pageIndex = 1, perCount = 10 });
            }
            Search.Add("角色编号");
            Search.Add("角色名称");
            InitReport("角色列表", "/Permission/CRUD/RoleAdd", pageIndex, perCount);
            return ReportView();
            // return View(RoleList_M.ToViewModel(Params));
        }
        public ActionResult UserList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {

                return RedirectToAction("UserList", new { ReportID = "Permision_用户列表", Params = ";;", pageIndex = 1, perCount = 10 });
            }
            Search.Add("用户编号");
            Search.Add("用户名");
            InitReport("用户列表", "/Permission/CRUD/UserAdd", pageIndex, perCount);
            return ReportView();
            //return View(UserList_M.ToViewModel(Params));
        }
        public ActionResult ButtonList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {

                return RedirectToAction("ButtonList", new { ReportID = "Permision_按钮列表", Params = Params.HasValue() ? Params : ";;", pageIndex = 1, perCount = 10 });
            }
            Search.Add("按钮编号");
            Search.Add("按钮名称");
            if (Params == ";;")
            {
                InitReport("按钮列表", "/Permission/CRUD/ButtonAdd", pageIndex, perCount);
            }
            else
            {
                InitReport("按钮列表", "/Permission/CRUD/ButtonAdd?menuid=" + Params, pageIndex, perCount);
            }
            return ReportView();
            // return View(ButtonList_M.ToViewModel(Params));
        }
        public ActionResult MenuList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {

                return RedirectToAction("MenuList", new { ReportID = "Permision_菜单列表", Params = "MRoot" + _FIXED_FLAG+";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("菜单编号");
            Search.Add("菜单名称");
            InitReport("菜单列表", "/Permission/CRUD/MenuAdd?fartherid=" + Params, pageIndex, perCount);
            return ReportView();
            //var fathers = _permission.FindFather(Params);
            //return View(MenuList_M.ToViewModel(fathers));
        }
        public ActionResult UserRoleList(string ReportID, string Params, string extParams, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("UserRoleList", new { extParams = Params, ReportID = "Permision_分配角色", Params = ";", pageIndex = 1, perCount = 10 });
            }
            extParams = Params;
            Search.Add("用户编号");
            SetFixedParam(extParams, ";");
            var user = _user.Find(extParams);
            InitReport("分配角色", "/Permission/Admin/ChooseRoleList?ReportID=Permision_选择分配角色&Params=;&userid=" + extParams, pageIndex, perCount);
            return ReportView();
            //return View(UserRoleList_M.ToViewModel(user));
        }
        public ActionResult RoleMenuList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("RoleMenuList", new { ReportID = "Permision_分配菜单", Params = Params, pageIndex = 1, perCount = 10 });
            }
            Search.Add("角色编号");
            var role = _role.Find(Params);
            InitReport("分配菜单", "/Permission/Admin/ChooseMenuList?ReportID=Permision_选择菜单&Params=;&roleid=" + Params, pageIndex, perCount);
            return ReportView();
            //return View(RoleMenuList_M.ToViewModel(role));
        }
        public ActionResult BanButtonList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("BanButtonList", new { ReportID = "Permision_按钮禁用", Params = Params, pageIndex = 1, perCount = 10 });
            }
            Search.Add("按钮编号");
            var role = _role.Find(Params);
            InitReport("按钮禁用", "/Permission/admin/ChooseBanButtonList?ReportID=Permision_选择禁用按钮&Params=;&roleid=" + Params, pageIndex, perCount);
            return ReportView();
            //return View(BanButtonList_M.ToViewModel(role));
        }
        public ActionResult ChooseBanButtonList(string ReportID, string roleid, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("ChooseBanButtonList", new { ReportID = "Permision_选择禁用按钮", Params = ";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("按钮编号");
            InitReport("选择禁用按钮", "#", pageIndex, perCount, "&roleid=" + roleid);
            return ReportView();
            //   return View();
        }
        public ActionResult ChooseRoleList(string ReportID, string userid, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("ChooseRoleList", new { ReportID = "Permision_选择分配角色", Params = ";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("角色编号");
            InitReport("选择分配角色", "#", pageIndex, perCount, "&userid=" + userid);
            return ReportView();
            //return View();
        }
        public ActionResult ChooseMenuList(string ReportID, string roleid, string buttonid, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("ChooseMenuList", new { ReportID = "Permision_选择菜单", Params = ";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("菜单名称");
            if (buttonid.HasValue())
            {
                InitReport("选择菜单", "#", pageIndex, perCount, "&buttonid=" + buttonid);
            }
            else
            {
                InitReport("选择菜单", "#", pageIndex, perCount, "&roleid=" + roleid);
            }
            return ReportView();
            //return View();
        }
    }
}
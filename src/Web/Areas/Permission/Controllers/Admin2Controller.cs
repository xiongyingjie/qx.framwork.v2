using System.Collections.Generic;
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using Qx.Permission.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Web.Areas.Permission.ViewModels.Admin;

namespace Web.Areas.Permission.Controllers
{
    public class Admin2Controller : BasePermissionController
    {
        private IPermission _permission;
        private IRepository<role> _role;
        private IRepository<permission_user> _user;
        public Admin2Controller(IPermission permission, IRepository<role> role,IRepository<permission_user> user)
        {
            _permission = permission;
            _role = role;
            _user = user;
        }



        //Permision2/Admin2/UserGroupList
        public ActionResult UserGroupList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserGroupList",
                    new
                    {
                        reportId = "qx.permmision.v2.UQX.用户组",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            Search.Add("组名称");
            InitReport("用户组", "/Permision2/CRUD2/AddUserGrou", "", true, "qx.permmision.v2");
            return ReportView();
        }
        //Permision2/Admin2/UserGroupMemberList
        public ActionResult UserGroupMemberList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserGroupMemberList",
                    new
                    {
                        reportId = "qx.permmision.v2.TWE.用户组成员",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            Search.Add("成员姓名");
            InitReport("用户组成员", " /Permission/CRUD2/AddUserGroupMember", "", true, "qx.permmision.v2");
            return ReportView();
        }


        //Permision2/Admin2/RoleGroupList
        public ActionResult RoleGroupList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("RoleGroupList",
                    new
                    {
                        reportId = "qx.permmision.v2.KX5.角色组",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            Search.Add("组名称");
            InitReport("角色组", "/Permission/CRUD2/AddRoleGroupMember", "", true, "qx.permmision.v2");
            return ReportView();
        }


        //Permision2/Admin2/RoleGroupMemberList
        public ActionResult RoleGroupMemberList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("RoleGroupMemberList",
                    new
                    {
                        reportId = "qx.permmision.v2.KX5.角色组",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            Search.Add("组名称");
            InitReport("角色组成员", "/Permission/CRUD2/AddRoleGroupMember", "", true, "qx.permmision.v2");
            return ReportView();
        }


       




        ///Permission/Admin/RoleList?ReportID=Permision_角色列表&Params=;
        public ActionResult RoleList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {

                return RedirectToAction("RoleList", new { ReportID = "Permision.v2_角色列表", Params = ";;", pageIndex = 1, perCount = 10 });
            }
            Search.Add("角色编号");
            Search.Add("角色名称"); 
            InitReport("角色列表", "/Permission/CRUD2/RoleAdd", pageIndex, perCount);
            return ReportView();
            // return View(RoleList_M.ToViewModel(Params));
        }
        public ActionResult UserList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {

                return RedirectToAction("UserList", new { ReportID = "Permision.v2_用户列表", Params = ";;", pageIndex = 1, perCount = 10 });
            }
            Search.Add("用户编号");
            Search.Add("用户名");
            InitReport("用户列表", "/Permission/CRUD2/UserAdd", pageIndex, perCount);
            return ReportView();
            //return View(UserList_M.ToViewModel(Params));
        }
        public ActionResult ButtonList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {

                return RedirectToAction("ButtonList", new { ReportID = "Permision.v2_按钮列表", Params = Params.HasValue() ? Params : ";;", pageIndex = 1, perCount = 10 });
            }
            Search.Add("按钮编号");
            Search.Add("按钮名称");
            if (Params == ";;")
            {
                InitReport("按钮列表", "/Permission/CRUD2/ButtonAdd", pageIndex, perCount);
            }
            else
            {
                InitReport("按钮列表", "/Permission/CRUD2/ButtonAdd?menu_id=" + Params, pageIndex, perCount);
            }
            return ReportView();
            // return View(ButtonList_M.ToViewModel(Params));
        }
        public ActionResult MenuList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {

                return RedirectToAction("MenuList", new { ReportID = "Permision.v2_菜单列表", Params = "MRoot" + _FIXED_FLAG + ";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("菜单编号");
            Search.Add("菜单名称");
            InitReport("菜单列表", "/Permission/CRUD2/MenuAdd?farther_id=" + Params, pageIndex, perCount);
            return ReportView();
            //var fathers = _permission.FindFather(Params);
            //return View(MenuList_M.ToViewModel(fathers));
        }
        public ActionResult UserRoleList(string ReportID, string Params, string extParams, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("UserRoleList", new { extParams = Params, ReportID = "Permision.v2_分配角色", Params = ";", pageIndex = 1, perCount = 10 });
            }
            extParams = Params;
            Search.Add("用户编号");
            SetFixedParam(extParams, ";");
            var user = _user.Find(extParams);
            InitReport("分配角色", "/Permission/Admin2/ChooseRoleList?ReportID=Permision.v2_选择分配角色&Params=;&user_id=" + extParams, pageIndex, perCount);
            return ReportView();
            //return View(UserRoleList_M.ToViewModel(user));
        }
        public ActionResult RoleMenuList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("RoleMenuList", new { ReportID = "Permision.v2_分配菜单", Params = Params, pageIndex = 1, perCount = 10 });
            }
            Search.Add("角色编号");
            //var role = _role.Find(Params);
            InitReport("分配菜单", "/Permission/Admin2/ChooseMenuList?ReportID=Permision.v2_选择菜单&Params=;&role_id=" + Params, pageIndex, perCount);
            return ReportView();
            //return View(RoleMenuList_M.ToViewModel(role));
        }
        public ActionResult BanButtonList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("BanButtonList", new { ReportID = "Permision.v2_按钮禁用", Params = Params, pageIndex = 1, perCount = 10 });
            }
            Search.Add("按钮编号");
            var role = _role.Find(Params);
            InitReport("按钮禁用", "/Permission/admin2/ChooseBanButtonList?ReportID=Permision.v2_选择禁用按钮&Params=;&role_id=" + Params, pageIndex, perCount);
            return ReportView();
            //return View(BanButtonList_M.ToViewModel(role));
        }
        public ActionResult ChooseBanButtonList(string ReportID, string role_id, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("ChooseBanButtonList", new { ReportID = "Permision.v2_选择禁用按钮", Params = ";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("按钮编号");
            InitReport("选择禁用按钮", "#", pageIndex, perCount, "&role_id=" + role_id);
            return ReportView();
            //   return View();
        }
        public ActionResult ChooseRoleList(string ReportID, string user_id, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("/Permission/admin2/ChooseRoleList", new { ReportID = "Permision.v2_选择分配角色", Params = ";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("角色编号");
            InitReport("选择分配角色", "#", pageIndex, perCount, "&user_id=" + user_id);
            return ReportView();
            //return View();
        }
        public ActionResult ChooseMenuList(string ReportID, string role_id, string button_id, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("/Permission/admin2/ChooseMenuList", new { ReportID = "Permision.v2_选择菜单", Params = ";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("菜单名称");
            if (button_id.HasValue())
            {
                InitReport("选择菜单", "#",pageIndex, perCount, "&button_id=" + button_id);
                //  InitReport("角色列表", "/Permission/CRUD2/RoleAdd", pageIndex, perCount);
               //InitReport("环节对应的小项验证", "#", true, button_id);
            }
            else
            {
                InitReport("选择菜单", "#", pageIndex, perCount, "&role_id=" + role_id);
            }
            return ReportView();
            //return View();
        }
    }
}
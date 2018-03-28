using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;
using xyj.core.Extensions;
using xyj.acs.Interfaces;
namespace Web.Areas.Permission.Controllers
{
    [Area("Permission")]
    public class Admin2Controller : BaseController

    {
        private IAcsService _permission;
        public Admin2Controller(IAcsService permission)
        {
            _permission = permission;
        
        }

        //表名+Update、Detail、Add
        //Permission/Admin2/OrgnizationList
        public IActionResult OrgnizationList(string reportId, string Params, string father_id = "Root")
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("OrgnizationList",
                    new
                    {
                        reportId = "qx.permmision.v2.Z3F.机构管理",
                        // father_id = father_id,
                        Params = father_id.IsFixedParam(),
                        pageIndex = 1,
                        father_id = father_id.GetFixedParam(),
                        perCount = 10
                    });
            }
            Search.Add("机构编号");
            Search.Add("机构名称");
            InitReport("机构管理", "/core/permission/OrgnizationAdd?father_id=" + father_id, "", true, "sys.core");
            return ReportJson();
        }
        //Permission/Admin2/Org_Position  组织机构岗位
        public IActionResult Org_Position(string ReportID, string Params)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_Position",
                    new
                    {
                        ReportID = "permission.permission.permission.permission.v2.组织机构对应的职位",
                        Params = Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("职位名称");
            InitReport("组织机构职位", "/core/permission/Add_Org_Position?orgid=" + Params.GetFixedParam(), "", true, "sys.core");//CRUD 添加班级 ?url=/Yxxt/CRUD/YX_LinkListAdd?
            return ReportJson();
        }
        //Permission/Admin2/PositionList  岗位
        public IActionResult PositionList(string ReportID, string Params = ";")
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("PositionList",
                    new
                    {
                        ReportID = "permission.v2.职位列表",
                        Params = Params,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("职位名称");
            InitReport("职位列表", "/core/permission/AddPosition", "", true, "sys.core");
            return ReportJson();
        }

        //Permission/Admin2/Org_Position_User 组织机构相关职员
        public IActionResult Org_Position_User(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("Org_Position_User",
                    new
                    {
                        reportId = "permission.v2.组织机构职位相关职员",
                        Params = Params.IsFixedParam(),// Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            SetFixedParam(Params, ";");
            Search.Add("用户编号");
            Search.Add("用户名");
            InitReport("职位类型", "*r/Permission/Admin2/PositionUserList?orgnization_position_id=" + Params.GetFixedParam(), "Params=" + Params.GetFixedParam(), true, "sys.core", "#", "/QxJzxt/OrgCRUD/OrgUserFile?orgnization_position_id=" + Params);
            ViewData["orgnization_position_id"] = Params;
            return ReportJson();
        }
        //Permission/Admin2/PositionUserList 组织机构职位下的职员
        public IActionResult PositionUserList(string reportId, string Params, string orgnization_position_id)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("PositionUserList",
                    new
                    {
                        reportId = "permission.v2.职位添加用户列表",
                        Params = Params.IsFixedParam(),// Params.IsFixedParam(),
                        orgnization_position_id = orgnization_position_id,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("学号");
            Search.Add("姓名");
            InitReport("用户列表", "", "orgnization_position_id=" + orgnization_position_id, true, "sys.core");
            return ReportJson();
        }
        //Permision2/Admin2/UserGroupList
        public IActionResult UserGroupList(string reportId, string Params)
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
            InitReport("用户组", "/core/permission/AddUserGroup", "", true, "sys.core");
            return ReportJson();
        }
        //Permision2/Admin2/UserGroupMemberList
        public IActionResult UserGroupMemberList(string id, string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserGroupMemberList",
                    new
                    {
                        reportId = "qx.permmision.v2.TWE.用户组成员",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10,
                        id = id,
                    });
            }
            SetFixedParam(id, Params);
            Search.Add("成员别名");
            InitReport("用户组成员", "/core/permission/AddUserGroupRelation?id=" + id, "", true, "sys.core");
            return ReportJson();
        }
        //Permision2/Admin2/RoleGroupList
        public IActionResult RoleGroupList(string reportId, string Params)
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
            InitReport("角色组", "/core/permission/AddRoleGroup", "", true, "sys.core");
            return ReportJson();
        }
        //Permision2/Admin2/RoleGroupMemberList
        public IActionResult RoleGroupMemberList(string id, string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("RoleGroupMemberList",
                    new
                    {
                        reportId = "qx.permmision.v2.URM.角色组成员",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10,
                        id = id,
                    });
            }
            SetFixedParam(id, Params);
            Search.Add("角色名称");
            InitReport("角色组成员", "/core/permission/AddRoleGroupRelation?id=" + id, "", true, "sys.core");
            return ReportJson();
        }

        public IActionResult UserList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {

                return RedirectToAction("UserList", new { ReportID = "Permision.v2_用户列表", Params = ";;", pageIndex = 1, perCount = 10 });
            }
            Search.Add("用户编号");
            Search.Add("用户名");
            Search.Add("子系统");
            Search.Add("备注");
            InitReport("用户列表", "/core/permission/UserAdd", "", true, "sys.core");
            return ReportJson();
            //return View(UserList_M.ToViewModel(Params));
        }
        public IActionResult ButtonList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {

                return RedirectToAction("ButtonList", new { ReportID = "Permision.v2_按钮列表", Params = Params.HasValue() ? Params : ";;", pageIndex = 1, perCount = 10 });
            }

            if (Params == ";;")
            {
                InitReport("按钮列表", "/core/permission/ButtonAdd", "", true, "sys.core");
            }
            else
            {
                InitReport("按钮列表", "/core/permission/ButtonAdd?menu_id=" + Params, "", true, "sys.core");
            }
            Search.Add("按钮编号");
            Search.Add("按钮名称");
            return ReportJson();
            // return View(ButtonList_M.ToViewModel(Params));
        }
        public IActionResult MenuList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {

                return RedirectToAction("MenuList", new { ReportID = "Permision.v2_菜单列表", Params = "MRoot" + _FIXED_FLAG, pageIndex = 1, perCount = 10 });
            }
            Search.Add("菜单编号");
            Search.Add("菜单名称");
            InitReport("菜单列表", "/core/permission/MenuAdd?father_id=" + Params.GetFixedParam(), "", true, "sys.core");
            return ReportJson();
            //var fathers = _permission.FindFather(Params);
            //return View(MenuList_M.ToViewModel(fathers));
        }
        public IActionResult UserRoleList(string ReportID, string Params, string extParams, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("UserRoleList", new { extParams = Params, ReportID = "Permision.v2_分配角色", Params = ";", pageIndex = 1, perCount = 10 });
            }
            extParams = Params;
            Search.Add("用户编号");
            SetFixedParam(extParams, ";");
        
            InitReport("分配角色", "*r/Permission/Admin2/ChooseRoleList?ReportID=Permision.v2_选择分配角色&Params=;&user_id=" + extParams, "", true, "sys.core");
            return ReportJson();
            //return View(UserRoleList_M.ToViewModel(user));
        }
        public IActionResult RoleMenuList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {

            if (!ReportID.HasValue())
            {
                return RedirectToAction("RoleMenuList",
                    new
                    {
                        ReportID = "Permision.v2_分配菜单",
                        Params = Params.GetFixedParam(),//如果在报表操作列未配置参数FixParam,可在此处调用 IsFixedParam()
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            //注意检测顺序应该在检测ReportID之后
            var rid = Params.GetFixedParam();
          
            SetFixedParam(rid, Params);
            Search.Add("菜单编号");
            Search.Add("菜单名称");
            InitReport("该角色已拥有的菜单", "*r/Permission/Admin2/ChooseMenuList?ReportID=Permision.v2_选择菜单&Params=;&role_id=" + Params.GetFixedParam(), "", true, "sys.core");
            return ReportJson();
            //return View(RoleMenuList_M.ToViewModel(role));
        }
        public IActionResult DataFilterList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {

            if (!ReportID.HasValue())
            {
                return RedirectToAction("DataFilterList",
                    new
                    {
                        ReportID = "qx.permmision.v2.RYM.数据权限",
                        Params = Params.IsFixedParam(),//如果在报表操作列未配置参数FixParam,可在此处调用 IsFixedParam()
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            //注意检测顺序应该在检测ReportID之后
            var rid = Params.GetFixedParam();
           
            SetFixedParam(rid, Params);
            //Search.Add("菜单名称");
            //InitReport("分配数据", "*r/Permission/Admin2/ChooseMenuList?ReportID=qx.permmision.v2.RYM.数据权限&Params=;&role_id=" + Params, "", true, "sys.core");
            InitReport("分配数据", "/core/permission/DataFileAdd?role_id=" + rid, "", true, "sys.core");
            return ReportJson();
            //return View(RoleMenuList_M.ToViewModel(role));
        }
        public IActionResult RoleGroupMenuList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {

            if (!ReportID.HasValue())
            {
                return RedirectToAction("RoleGroupMenuList",
                    new
                    {
                        ReportID = "Permision.v2_分配菜单",
                        Params = Params.IsFixedParam(),//如果在报表操作列未配置参数FixParam,可在此处调用 IsFixedParam()
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            //注意检测顺序应该在检测ReportID之后
            var rid = Params.GetFixedParam();
           
            SetFixedParam(rid, Params);
            //Search.Add("菜单名称");
            InitReport("分配菜单", "*r/Permission/Admin2/ChooseMenuList?ReportID=Permision.v2_分配菜单&Params=;&role_id=" + Params, "", true, "sys.core");
            return ReportJson();
            //return View(RoleMenuList_M.ToViewModel(role));
        }
        public IActionResult UserGroupRoleList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {

            if (!ReportID.HasValue())
            {
                return RedirectToAction("UserGroupRoleList",
                    new
                    {
                        ReportID = "Permision.v2_分配角色",
                        Params = Params.IsFixedParam(),//如果在报表操作列未配置参数FixParam,可在此处调用 IsFixedParam()
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            //注意检测顺序应该在检测ReportID之后
            var rid = Params.GetFixedParam();
           
            SetFixedParam(rid, Params);
            //Search.Add("菜单名称");
            InitReport("分配角色", "*r/Permission/Admin2/ChooseMenuList?ReportID=Permision.v2_分配角色&Params=;&role_id=" + Params, "", true, "sys.core");
            return ReportJson();
            //return View(RoleMenuList_M.ToViewModel(role));
        }
        public IActionResult BanButtonList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("BanButtonList", new { ReportID = "Permision.v2_按钮禁用", Params = Params, pageIndex = 1, perCount = 10 });
            }
            Search.Add("按钮编号");
           
            InitReport("按钮禁用", "*r/Permission/admin2/ChooseBanButtonList?ReportID=Permision.v2_选择禁用按钮&Params=;&role_id=" + Params, "", true, "sys.core");
            return ReportJson();
            //return View(BanButtonList_M.ToViewModel(role));
        }
        public IActionResult ChooseBanButtonList(string ReportID, string role_id, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("ChooseBanButtonList", new { ReportID = "Permision.v2_选择禁用按钮", Params = ";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("按钮编号");
            InitReport("选择禁用按钮", "#", "role_id="+ role_id, true, "sys.core", "&role_id=" + role_id);
            return ReportJson();
            //   return View();
        }
        public IActionResult ChooseRoleList(string ReportID, string Params, string user_id, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return ChooseRoleList("Permision.v2_选择分配角色", ";", user_id, 1, 10);
            }
            Search.Add("角色编号");
            Search.Add("角色名称");
            InitReport("选择分配角色", "#", "&user_id=" + user_id, true, "sys.core");
            return ReportJson();
            //return View();
        }
        public IActionResult ChooseMenuList(string ReportID, string Params, string role_id, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return ChooseMenuList("Permision.v2_选择菜单", ";", role_id, 1, 10);
            }
            Search.Add("菜单编号");
            Search.Add("菜单名称");
            Search.Add("父菜单编号");
            InitReport("选择要分配给角色的菜单", "#", "&role_id=" + role_id, true, "sys.core");
            return ReportJson();

            //return View();
        }
        //Permission/Admin2/RoleList
        public IActionResult RoleList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("RoleList",
                    new
                    {
                        reportId = "qx.permmision.v2.RTA.角色管理",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("角色编号");
            Search.Add("角色名称");
            InitReport("角色管理", "/core/permission/roleAdd", "", true, "sys.core");
            return ReportJson();
        }
        //Permission/Admin2/UserOrgnizatioList
        public IActionResult UserOrgnizatioList(string reportId, string Params,string userid)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserOrgnizatioList",
                    new
                    {
                        reportId = "qx.permmision.v2.RWN.用户机构列表",
                        Params = "",
                        pageIndex = 1,
                        userid = userid,
                        perCount = 10
                    });
            }
            SetFixedParam(userid, ";");
            Search.Add("机构名称");
            InitReport("用户机构列表", "*r/Permission/Admin2/AddUserOrgnization?userid=" + userid, "", true, "sys.core");
            return ReportJson();
        }
        public IActionResult AddUserOrgnization(string reportId, string Params, string userid)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("AddUserOrgnization",
                    new
                    {
                        reportId = "qx.permmision.v2.RK7.添加用户机构",
                        Params = "",
                        pageIndex = 1,
                        userid = userid,
                        perCount = 10
                    });
            }
            Search.Add("机构编号");
            Search.Add("机构名称");
            InitReport("请选择要分配的机构", "#", "userid=" + userid, true, "sys.core");
            return ReportJson();
        }
        
        //Permission/Admin2/OrgnizatioUserList  (机构用户列表)
        public IActionResult OrgnizatioUserList(string reportId, string Params,string orgnization_id)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("OrgnizatioUserList",
                    new
                    {
                        reportId = "qx.permmision.v2.RBZ.机构用户列表",
                        Params = "",
                        pageIndex = 1,
                        orgnization_id= orgnization_id,
                        perCount = 10
                    });
            }
            SetFixedParam(orgnization_id, ";");
            Search.Add("用户名称");
            InitReport("机构用户列表", "*r/Permission/Admin2/AddOrgnizatioUser?orgnization_id="+ orgnization_id, "", true, "sys.core");
            return ReportJson();
        }
        //Permission/Admin2/AddOrgnizatioUser  (机构用户列表)
        public IActionResult AddOrgnizatioUser(string reportId, string Params,string orgnization_id)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("AddOrgnizatioUser",
                    new
                    {
                        reportId = "qx.permmision.v2.RJF.添加机构用户",
                        Params = "",
                        pageIndex = 1,
                        orgnization_id= orgnization_id,
                        perCount = 10
                    });
            }
            Search.Add("用户ID");
            Search.Add("用户名称");
            InitReport("机构用户列表", "#", "orgnization_id="+ orgnization_id, true, "sys.core");
            return ReportJson();
        }
    }
}
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Web.Areas.Permission.ViewModels.CRUD2;
using System;
using System.Collections.Generic;

namespace Web.Areas.Permission.Controllers
{
    public class CRUD2Controller : BasePermissionController
    {
        //
        // GET: /Permision2/CRUD2/

        private IRepository<button> _funcObject;
        private IRepository<menu> _module;
        private IRepository<role_button_forbid> _roleFuncObjForbid;
        private IRepository<role_menu> _roleModule;
        private IRepository<role> _role;
        private IRepository<permission_user> _user;
        private IRepository<user_role> _userRole;
        private IRepository<role_group> _roleGroup;
        private IRepository<role_group_relation> _roleGroupRelation;
        private IRepository<user_group> _userGroup;
        private IRepository<user_group_relation> _userGroupRelation;
        public CRUD2Controller(IRepository<button> funcObject, IRepository<menu> module,
            IRepository<role_button_forbid> roleFuncObjForbid, IRepository<role_menu> roleModule,
            IRepository<role> role, IRepository<permission_user> user,
            IRepository<user_role> userRole, IRepository<role_group> roleGroup, IRepository<user_group> userGroup,
            IRepository<role_group_relation> roleGroupRelation, IRepository<user_group_relation> userGroupRelation)
        {
            _funcObject = funcObject;
            _module = module;
            _roleFuncObjForbid = roleFuncObjForbid;
            _roleModule = roleModule;
            _role = role;
            _user = user;
            _userRole = userRole;
            _roleGroup = roleGroup;
            _userGroup = userGroup;
            _roleGroupRelation = roleGroupRelation;
            _userGroupRelation = userGroupRelation;

        }

        // GET: /Permission/CRUD2/

        public ActionResult Index()
        {
            InitMenu(new Dictionary<string, string>() {
                {"角色列表","/Permission/Admin2/RoleList"},
                {"角色组列表","/Permission/Admin2/RoleGroupList"},
                {"用户列表","/Permission/Admin2/UserList"},
                {"用户组列表","/Permission/Admin2/UserGroupList"},
                {"按钮列表","/Permission/Admin2/ButtonList"},
                {"菜单列表","/Permission/Admin2/MenuList"}
            });
            return View();
        }

        
        public ActionResult AddUserGroup()
        {
            InitForm("添加用户组");
            return View(new UserAdd_M());
        }
        public ActionResult AddRoleGroup()
        {
            InitForm("添加角色组");
            return View(new UserAdd_M());
        }
        public ActionResult AddUserGroupMember()
        {
            InitForm("添加用户组成员");
            return View(new UserAdd_M());
        }
        public ActionResult AddRoleGroupMember()
        {
            InitForm("添加角色组成员");
            return View(new UserAdd_M());
        }

        public ActionResult UserAdd()
        {
            InitForm("添加用户");
            return View(new UserAdd_M());
        }
        [HttpPost]
        public ActionResult UserAdd(UserAdd_M model)
        {
            if (ModelState.IsValid)
            {
                if (_user.Find(model.user_id) == null)
                {
                    if (_user.Add(model.ToModel()).HasValue())
                        return Redirect("/Permission/Admin2/UserList?ReportID=Permision.v2_用户列表&Params=;");
                    else
                        return Alert("添加失败");
                }
                else
                    return Alert("添加失败，请重新添加");
            }
            else
            {
                InitForm("添加用户");
                return View(model);
            }
        }
        public ActionResult RoleMenuAdd(string role_id,string menu_id)
        {
            //role_id = RQ("role_id");
            //menu_id = RQ("menu_id");
            var role = _role.Find(role_id);
            InitForm("分配菜单");
            var menu = _module.Find(menu_id);
            return View(RoleMenuAdd_M.ToViewModel(role_id, role.name, menu_id, menu.name));

        }
        [HttpPost]
        public ActionResult RoleMenuAdd(RoleMenuAdd_M model)
        {
            if (ModelState.IsValid)
            {
                model.role_menu_id = model.role_id + model.menu_id;
                if (_roleModule.Find(model.role_menu_id) == null)
                {
                    _roleModule.Add(model.ToModel());
                    return Redirect("/Permission/Admin2/RoleMenuList?ReportID=Permision.v2_分配菜单&Params=" + model.role_id);
                }
                else
                    return Alert("操作失败!");
            }
            else
            {
                InitForm("分配菜单");
                return View(model);
            }
        }
        public ActionResult BanButtonAdd(string role_id,string button_id)
        {
            role_id = RQ("role_id");
            button_id = RQ("button_id");
            var role = _role.Find(role_id);
            if (button_id.HasValue())
            {
                var button = _funcObject.Find(button_id);
                InitForm("禁用按钮");
                return View(BanButtonAdd_M.ToViewModel(role_id, role.name, button_id, button.name));
            }
            else
            {
                InitForm("禁用按钮");
                return View(BanButtonAdd_M.ToViewModel(role_id, role.name));
            }
        }
        [HttpPost]
        public ActionResult BanButtonAdd(BanButtonAdd_M model)
        {
            if(ModelState.IsValid)
            {
            model.role_Button_forbid_id = model.role_id + "-" + model.button_id;
            if (_roleFuncObjForbid.Find(model.role_Button_forbid_id) == null)
            {
                _roleFuncObjForbid.Add(model.ToModel());
                return Redirect("/Permission/Admin2/BanButtonList?ReportID=Permision.v2_按钮禁用&Params=" + model.role_id);
            }
            else
                return Alert("操作失败!");
            }
            else
            {
                InitForm("禁用按钮");
                return View(model);
            }
        }
        public ActionResult RoleAdd()
        {
            InitForm("添加角色");
            return View(new RoleAdd_M());
        }
        [HttpPost]
        public ActionResult RoleAdd(RoleAdd_M model)
        {
            if (ModelState.IsValid)
            {
                //我添加的一句
                model.role_id = DateTime.Now.Random();
                if (_role.Find(model.role_id) == null)
                {
                    _role.Add(model.ToModel());
                    return Redirect("/Permission/Admin2/RoleList?ReportID=Permision.v2_角色列表&Params=;");
                }
                else
                    return Alert("添加失败，请重新添加");
            }
            else
            {
                InitForm("添加角色");
                return View(model);
            }
        }
        public ActionResult UserRoleAdd(string user_id,string role_id)
        {
            role_id = RQ("role_id");
            user_id = RQ("user_id");
            if (role_id.HasValue())
            {
                var role = _role.Find(role_id);
                InitForm("分配角色");
                return View(UserRoleAdd_M.ToViewModel(user_id, role_id, role.name));
            }
            else
            {
                InitForm("分配角色");
                return View(UserRoleAdd_M.ToViewModel(user_id));
            }
        }
        [HttpPost]
        public ActionResult UserRoleAdd(UserRoleAdd_M model)
        {
            if (ModelState.IsValid)
            {
                model.user_role_id = model.user_id + model.role_id;
                if (_userRole.Find(model.user_role_id) == null)
                {
                    _userRole.Add(model.ToModel());
                    return Redirect("/Permission/Admin2/UserRoleList?ReportID=Permision.v2_分配角色&Params=" + model.user_id);
                }
                else
                    return Alert("添加失败，请重新添加");
            }
            else
            {
                InitForm("分配角色");
                return View(model);
            }
        }
        
        public ActionResult ButtonAdd(string menu_id)
        {
            menu_id = RQ("menu_id");
            InitForm("添加按钮");
            if (menu_id.HasValue())
                return View(ButtonAdd_M.ToViewModel(menu_id));
            else
               return View(new ButtonAdd_M());
        }
        [HttpPost]
        public ActionResult ButtonAdd(ButtonAdd_M model)
        {
            if (ModelState.IsValid)
            {
                model.button_id = model.menu_id + "-" + model.name;
                if (_funcObject.Find(model.button_id) == null)
                {
                    _funcObject.Add(model.ToModel());
                    return Redirect("/Permission/Admin2/ButtonList?ReportID=Permision.v2_按钮列表&Params=;");
                }
                else
                    return Alert("添加失败，请重新添加");
            }
            else
            {
                InitForm("添加按钮");
                return View(model);
            }
        }
        public ActionResult MenuAdd(string father_id)
        {
            //father_id = RQ("father_id");
            if (father_id==";")
                father_id = "MRoot";
            InitForm("添加菜单");
            return View(MenuAdd_M.ToViewModel(father_id));
        }
        [HttpPost]
        public ActionResult MenuAdd(MenuAdd_M model)
        {
            if (ModelState.IsValid)
            {
                if (_module.Find(model.menu_id) == null)
                {
                   
                    _module.Add(model.ToModel());
                    return Redirect("/Permission/Admin2/MenuList?ReportID=Permision.v2_菜单列表&Params="+model._farther_id);
                }
                else
                    return Alert("添加失败，请重新添加");
            }
            else
            {
                InitForm("添加菜单");
                return View(model);
            }
           
        }
        //public ActionResult MenuExtensionAdd(string menu_id)
        //{
        //    menu_id = RQ("menu_id");
        //    if (menu_id.HasValue())
        //    {
        //        InitForm("添加菜单扩展");
        //        return View(MenuExtension_M.ToViewModel(menu_id));
        //    }
        //    else
        //    {
        //        return Alert("操作失败！");
        //    }
        //}
        //[HttpPost]
        //public ActionResult MenuExtensionAdd(MenuExtension_M model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_menuExtension.Find(model.menu_id) == null)
        //        {
        //            var menu=_module.Find(model.menu_id);
        //            _menuExtension.Add(model.ToModel());
        //            return Redirect("/Permission/Admin2/MenuList?ReportID=Permision_菜单列表&Params="+menu.father_id);
        //        }
        //        else
        //            return Alert("添加失败，请重新添加");
        //    }
        //    else
        //    {
        //        InitForm("添加菜单扩展");
        //        return View(model);
        //    }
        //}
        //public ActionResult MenuExtensionEdit(string menu_id)
        //{
        //    menu_id = RQ("menu_id");
        //    var menuExtension = _menuExtension.Find(menu_id);
        //    if (menuExtension!=null)
        //    {
        //        InitForm("编辑菜单扩展");
        //        return View(MenuExtension_M.ToViewModel(menuExtension));
        //    }
        //    else
        //    {
        //        return Alert("操作失败！");
        //    }
        //}
        //[HttpPost]
        //public ActionResult MenuExtensionEdit(MenuExtension_M model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_menuExtension.Find(model.menu_id) != null)
        //        {
        //            var menu = _module.Find(model.menu_id);
        //            _menuExtension.Update(model.ToModel());
        //            return Redirect("/Permission/Admin2/MenuList?ReportID=Permision_菜单列表&Params="+menu.father_id);
        //        }
        //        else
        //            return Alert("操作失败！");
        //    }
        //    else
        //    {
        //        InitForm("编辑菜单扩展");
        //        return View(model);
        //    }
        //}
        public ActionResult UserDelete(string user_id)
        {
            //user_id = RQ("user_id");
            var user=_user.Find(user_id);
            if (user != null)
            {
                _user.Delete(user_id);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult RoleDelete(string role_id)
        {
            //role_id = RQ("role_id");
            var role = _role.Find(role_id);
            if (role != null)
            {
                _role.Delete(role_id);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败!");
        }
        public ActionResult UserRoleDelete(string user_role_id)
        {
            user_role_id = RQ("user_role_id");
            var userrole = _userRole.Find(user_role_id);
            if (userrole != null)
            {
                _userRole.Delete(user_role_id);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult RoleMenuDelete(string rolemenu_id)
        {
            rolemenu_id = RQ("rolemenu_id");
            if (rolemenu_id.HasValue())
            {
                if (_roleModule.Delete(rolemenu_id))
                    return Alert("删除成功");
                else
                    return Alert("操作失败!");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult BanButtonDelete(string banbutton_id)
        {
            banbutton_id = RQ("banbutton_id");
            var banbutton = _roleFuncObjForbid.Find(banbutton_id);
            if (banbutton != null)
            {
                _roleFuncObjForbid.Delete(banbutton_id);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult ButtonDelete(string button_id)
        {
            button_id = RQ("button_id");
            var button = _funcObject.Find(button_id);
            if (button != null)
            {
                _funcObject.Delete(button_id);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult MenuDelete(string menu_id)
        {
            menu_id = RQ("menu_id");
            if (menu_id.HasValue())
            {
                if (_module.Delete(menu_id))
                    return Alert("删除成功");
                else
                    return Alert("操作失败！");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult MenuEdit(string menu_id)
        {
            menu_id = RQ("menu_id");
            InitForm("菜单编辑");
            var menu = _module.Find(menu_id);
            if (menu == null)
                return Alert("操作失败");
            else
                return View(MenuEdit_M.ToViewModel(menu));
        }
        [HttpPost]
        public ActionResult MenuEdit(MenuEdit_M model)
        {
            if (ModelState.IsValid)
            {
                var old = _module.Find(model.menu_id);
                old.status = model.status;
                old.depth = model.depth;
                old.name = model.name;
                old.sequence = model.sequence;
                old.url = model.url;
                old.farther_id = model._farther_id;
                _module.Update(old);
                return Redirect("/Permission/Admin2/MenuList?ReportID=Permision.v2_菜单列表&Params="+old.farther_id);
            }
            else
            {
                InitForm("菜单编辑");
                return View(model);
            }
        }
        public ActionResult ChooseBanButton(string role_id, string button_id)
        {
            role_id = RQ("role_id");
            button_id = RQ("button_id");
            return Redirect("/Permission/CRUD2/BanButtonAdd?role_id=" + role_id + "&button_id=" + button_id);
        }
        public ActionResult ChooseRole(string user_id,string role_id)
        {
            role_id = RQ("role_id");
            user_id = RQ("user_id");

            return Redirect("/Permission/CRUD2/UserRoleAdd?user_id=" + user_id + "&role_id=" + role_id);
        }
        public ActionResult ChooseMenu(string menu_id,string role_id,string button_id)
        {
            //role_id = RQ("role_id");
            //button_id = RQ("button_id");
            //menu_id = RQ("menu_id");
            if (!role_id.HasValue())
                return Redirect("/Permission/CRUD2/ButtonAdd?button_id=" + button_id + "&menu_id=" + menu_id);
            else
                return Redirect("/Permission/CRUD2/RoleMenuAdd?role_id=" + role_id + "&menu_id=" + menu_id);
        }
    }
}

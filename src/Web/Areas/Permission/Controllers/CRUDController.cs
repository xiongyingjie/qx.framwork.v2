using System.Web.Mvc;
using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Web.Areas.Permission.ViewModels.CRUD;

namespace Web.Areas.Permission.Controllers
{
    public class CRUDController : BasePermissionController
    {
        //
        // GET: /Permision2/CRUD/

        private IRepository<button> _funcObject;
        private IRepository<menu> _module;
        private IRepository<role_button_forbid> _roleFuncObjForbid;
        private IRepository<role_menu> _roleModule;
        private IRepository<role> _role;
        private IRepository<permission_user> _user;
        private IRepository<user_role> _userRole;
        private IRepository<menu_extension> _menuExtension;
        public CRUDController(IRepository<button> funcObject, IRepository<menu> module,
            IRepository<role_button_forbid> roleFuncObjForbid, IRepository<role_menu> roleModule,
            IRepository<role> role, IRepository<permission_user> user,
            IRepository<user_role> userRole, IRepository<menu_extension> menuExtension)
        {
            _funcObject = funcObject;
            _module = module;
            _roleFuncObjForbid = roleFuncObjForbid;
            _roleModule = roleModule;
            _role = role;
            _user = user;
            _userRole = userRole;
            _menuExtension = menuExtension;
        }

        public ActionResult Index()
        {

            var temp = _user.All();

            return View();
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
                if (_user.Find(model.userid) == null)
                {
                    if (_user.Add(model.ToModel()).HasValue())
                        return Redirect("/Permission/Admin/UserList?ReportID=Permision_用户列表&Params=;");
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
        public ActionResult RoleMenuAdd(string roleid,string menuid)
        {
            roleid = RQ("roleid");
            menuid = RQ("menuid");
            var role = _role.Find(roleid);
            InitForm("分配菜单");
            var menu = _module.Find(menuid);
            return View(RoleMenuAdd_M.ToViewModel(roleid,role.Name, menuid, menu.Name));

        }
        [HttpPost]
        public ActionResult RoleMenuAdd(RoleMenuAdd_M model)
        {
            if (ModelState.IsValid)
            {
                model.RoleMenuID = model.RoleID + model.MenuID;
                if (_roleModule.Find(model.RoleMenuID) == null)
                {
                    _roleModule.Add(model.ToModel());
                    return Redirect("/Permission/Admin/RoleMenuList?ReportID=Permision_分配菜单&Params=" + model.RoleID);
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
        public ActionResult BanButtonAdd(string roleid,string buttonid)
        {
            roleid = RQ("roleid");
            buttonid = RQ("buttonid");
            var role = _role.Find(roleid);
            if (buttonid.HasValue())
            {
                var button = _funcObject.Find(buttonid);
                InitForm("禁用按钮");
                return View(BanButtonAdd_M.ToViewModel(roleid, role.Name, buttonid, button.Name));
            }
            else
            {
                InitForm("禁用按钮");
                return View(BanButtonAdd_M.ToViewModel(roleid, role.Name));
            }
        }
        [HttpPost]
        public ActionResult BanButtonAdd(BanButtonAdd_M model)
        {
            if(ModelState.IsValid)
            {
            model.roleButtonForbidID = model.roleid + "-" + model.buttonid;
            if (_roleFuncObjForbid.Find(model.roleButtonForbidID) == null)
            {
                _roleFuncObjForbid.Add(model.ToModel());
                return Redirect("/Permission/Admin/BanButtonList?ReportID=Permision_按钮禁用&Params=" + model.roleid);
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
            InitForm("角色管理");
            var id = Q("id");
            if (!id.HasValue()) return View(new RoleAdd_M()
            {
                roletype = "0", subSystem = "default"
            });

            var old = _role.Find(id);
            return View(new RoleAdd_M()
            {
                roleid = old.RoleID,
                name = old.Name,
                isDefault =old.IsDefault,
                roletype = old.RoleType,
                subSystem =old.subSystem
            });
        }
        [HttpPost]
        public ActionResult RoleAdd(RoleAdd_M model)
        {
            if (ModelState.IsValid)
            {
                if (_role.Find(model.roleid) == null)
                {
                    _role.Add(model.ToModel());
                    return Redirect("/Permission/Admin/RoleList?ReportID=Permision_角色列表&Params=;");
                }
                else
                    return Alert("提交失败，请重新提交");
            }
            else
            {
                InitForm("添加角色");
                return View(model);
            }
        }

        public ActionResult UserRoleAdd(string userid,string roleid)
        {
            roleid = RQ("roleid");
            userid = RQ("userid");
            if (roleid.HasValue())
            {
                var role = _role.Find(roleid);
                InitForm("分配角色");
                return View(UserRoleAdd_M.ToViewModel(userid, roleid, role.Name));
            }
            else
            {
                InitForm("分配角色");
                return View(UserRoleAdd_M.ToViewModel(userid));
            }
        }
        [HttpPost]
        public ActionResult UserRoleAdd(UserRoleAdd_M model)
        {
            if (ModelState.IsValid)
            {
                model.UserRoleID = model.userid + model.roleid;
                if (_userRole.Find(model.UserRoleID) == null)
                {
                    _userRole.Add(model.ToModel());
                    return Redirect("/Permission/Admin/UserRoleList?ReportID=Permision_分配角色&Params=" + model.userid);
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
        
        public ActionResult ButtonAdd(string menuid)
        {
            //menuid = RQ("menuid");
            InitForm("添加按钮");
            if (menuid.HasValue())
                return View(ButtonAdd_M.ToViewModel(menuid));
            else
               return View(new ButtonAdd_M());
        }
        [HttpPost]
        public ActionResult ButtonAdd(ButtonAdd_M model)
        {
            if (ModelState.IsValid)
            {
                model.buttonid = model.menuid + "-" + model.name;
                if (_funcObject.Find(model.buttonid) == null)
                {
                    if (model.menuid.IndexOf("!fixed") != -1)
                    {
                        model.menuid = model.menuid.Substring(0,model.menuid.Length-6);
                    }
                    _funcObject.Add(model.ToModel());
                    return Redirect("/Permission/Admin/ButtonList?ReportID=Permision_按钮列表&Params=;");
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
        public ActionResult MenuAdd(string fartherid)
        {
            fartherid = RQ("fartherid");
            if (fartherid==";")
                fartherid = "MRoot";
            InitForm("添加菜单");
            return View(MenuAdd_M.ToViewModel(fartherid));
        }
        [HttpPost]
        public ActionResult MenuAdd(MenuAdd_M model)
        {
            if (ModelState.IsValid)
            {
                if (_module.Find(model.menuid) == null)
                {
                   
                    _module.Add(model.ToModel());
                    return Redirect("/Permission/Admin/MenuList?ReportID=Permision_菜单列表&Params="+model._fartherid+"!fixed");
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
        public ActionResult MenuExtensionAdd(string menuid)
        {
            menuid = RQ("menuid");
            if (menuid.HasValue())
            {
                InitForm("添加菜单扩展");
                return View(MenuExtension_M.ToViewModel(menuid));
            }
            else
            {
                return Alert("操作失败！");
            }
        }
        [HttpPost]
        public ActionResult MenuExtensionAdd(MenuExtension_M model)
        {
            if (ModelState.IsValid)
            {
                if (_menuExtension.Find(model.MenuID) == null)
                {
                    var menu=_module.Find(model.MenuID);
                    _menuExtension.Add(model.ToModel());
                    return Redirect("/Permission/Admin/MenuList?ReportID=Permision_菜单列表&Params="+menu.FartherID+"!fixed");
                }
                else
                    return Alert("添加失败，请重新添加");
            }
            else
            {
                InitForm("添加菜单扩展");
                return View(model);
            }
        }
        public ActionResult MenuExtensionEdit(string menuid)
        {
            menuid = RQ("menuid");
            var menuExtension = _menuExtension.Find(menuid);
            if (menuExtension!=null)
            {
                InitForm("编辑菜单扩展");
                return View(MenuExtension_M.ToViewModel(menuExtension));
            }
            else
            {
                return Alert("操作失败！");
            }
        }
        [HttpPost]
        public ActionResult MenuExtensionEdit(MenuExtension_M model)
        {
            if (ModelState.IsValid)
            {
                if (_menuExtension.Find(model.MenuID) != null)
                {
                    var menu = _module.Find(model.MenuID);
                    _menuExtension.Update(model.ToModel());
                    return Redirect("/Permission/Admin/MenuList?ReportID=Permision_菜单列表&Params="+menu.FartherID+"!fixed");
                }
                else
                    return Alert("操作失败！");
            }
            else
            {
                InitForm("编辑菜单扩展");
                return View(model);
            }
        }
        public ActionResult UserDelete(string userid)
        {
            userid = RQ("userid");
            var user=_user.Find(userid);
            if (user != null)
            {
                _user.Delete(userid);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult RoleDelete(string roleid)
        {
            roleid = RQ("roleid");
            var role = _role.Find(roleid);
            if (role != null)
            {
                _role.Delete(roleid);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败!");
        }
        public ActionResult UserRoleDelete(string userroleid)
        {
            userroleid = RQ("userroleid");
            var userrole = _userRole.Find(userroleid);
            if (userrole != null)
            {
                _userRole.Delete(userroleid);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult RoleMenuDelete(string rolemenuid)
        {
            rolemenuid = RQ("rolemenuid");
            if (rolemenuid.HasValue())
            {
                if (_roleModule.Delete(rolemenuid))
                    return Alert("删除成功");
                else
                    return Alert("操作失败!");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult BanButtonDelete(string banbuttonid)
        {
            banbuttonid = RQ("banbuttonid");
            var banbutton = _roleFuncObjForbid.Find(banbuttonid);
            if (banbutton != null)
            {
                _roleFuncObjForbid.Delete(banbuttonid);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult ButtonDelete(string buttonid)
        {
            buttonid = RQ("buttonid");
            var button = _funcObject.Find(buttonid);
            if (button != null)
            {
                _funcObject.Delete(buttonid);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult MenuDelete(string menuid)
        {
            menuid = RQ("menuid");
            if (menuid.HasValue())
            {
                if (_module.Delete(menuid))
                    return Alert("删除成功");
                else
                    return Alert("操作失败！");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult MenuEdit(string menuid)
        {
            menuid = RQ("menuid");
            InitForm("菜单编辑");
            var menu = _module.Find(menuid);
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
                var old = _module.Find(model.menuid);
                old.IsAvailable = model.isavailable;
                old.Level = model.level;
                old.Name = model.name;
                old.Sequence = model.Sequence;
                old.Value = model.value;
                old.FartherID = model._fartherid;
                _module.Update(old);
                return Redirect("/Permission/Admin/MenuList?ReportID=Permision_菜单列表&Params="+old.FartherID+"!fixed");
            }
            else
            {
                InitForm("菜单编辑");
                return View(model);
            }
        }
        public ActionResult ChooseBanButton(string roleid, string buttonid)
        {
            roleid = RQ("roleid");
            buttonid = RQ("buttonid");
            return Redirect("/Permission/CRUD/BanButtonAdd?roleid=" + roleid + "&buttonid=" + buttonid);
        }
        public ActionResult ChooseRole(string userid,string roleid)
        {
            roleid = RQ("roleid");
            userid = RQ("userid");

            return Redirect("/Permission/CRUD/UserRoleAdd?userid=" + userid + "&roleid=" + roleid);
        }
        public ActionResult ChooseMenu(string menuid,string roleid,string buttonid)
        {
            //roleid = RQ("roleid");
            //buttonid = RQ("buttonid");
            //menuid = RQ("menuid");
            if (!roleid.HasValue())
                return Redirect("/Permission/CRUD/ButtonAdd?buttonid=" + buttonid + "&menuid=" + menuid);
            else
                return Redirect("/Permission/CRUD/RoleMenuAdd?roleid=" + roleid + "&menuid=" + menuid);
        }
    }
}

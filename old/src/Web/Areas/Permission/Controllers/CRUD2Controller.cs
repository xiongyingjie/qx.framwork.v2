using System.Web.Mvc;
using qx.permmision.v2.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Web.Areas.Permission.ViewModels.CRUD2;
using System;
using System.Collections.Generic;
using qx.permmision.v2.Interfaces;

namespace Web.Areas.Permission.Controllers
{
    public class CRUD2Controller : BasePermissionController
    {
        //
        // GET: /Permission/CRUD2/
        private IPermmisionService _iPermmisionService;
        private IRepository<button> _button;
        private IRepository<menu> _menu;
        private IRepository<role_button_forbid> _roleFuncObjForbid;
        private IRepository<role_menu> _role_menu;
        private IRepository<role> _role;
        private IRepository<permission_user> _user;
        private IRepository<user_role> _userRole;
        private IRepository<role_group> _roleGroup;
        private IRepository<role_group_relation> _roleGroupRelation;
        private IRepository<user_group> _userGroup;
        private IRepository<user_group_relation> _userGroupRelation;
        private IRepository<orgnization> _orgnization;
        private IRepository<orgnization_position> _orgnizationPosition;
        private IRepository<orgnization_type> _orgnizationType;
        private IRepository<position> _position;
        private IRepository<position_type> _positionType;
        private IRepository<user_orgnization> _userOrgnization;
        private IRepository<user_position> _userPosition;


        public CRUD2Controller(IRepository<button> funcObject, IRepository<menu> module,
            IRepository<role_button_forbid> roleFuncObjForbid, IRepository<role_menu> roleModule,
            IRepository<role> role, IRepository<permission_user> user,
            IRepository<user_role> userRole, IRepository<role_group> roleGroup, IRepository<user_group> userGroup,
            IRepository<role_group_relation> roleGroupRelation, IRepository<user_group_relation> userGroupRelation, IPermmisionService iPermmisionService, IRepository<orgnization> orgnization, IRepository<orgnization_position> orgnizationPosition, IRepository<orgnization_type> orgnizationType, IRepository<position> position, IRepository<position_type> positionType, IRepository<user_orgnization> userOrgnization, IRepository<user_position> userPosition)
        {
            _button = funcObject;
            _menu = module;
            _roleFuncObjForbid = roleFuncObjForbid;
            _role_menu = roleModule;
            _role = role;
            _user = user;
            _userRole = userRole;
            _roleGroup = roleGroup;
            _userGroup = userGroup;
            _roleGroupRelation = roleGroupRelation;
            _userGroupRelation = userGroupRelation;
            _iPermmisionService = iPermmisionService;
            _orgnization = orgnization;
            _orgnizationPosition = orgnizationPosition;
            _orgnizationType = orgnizationType;
            _position = position;
            _positionType = positionType;
            _userOrgnization = userOrgnization;
            _userPosition = userPosition;
        }
        //AddOrgnization
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
        #region 用户组
        // GET: Permision2/CRUD2/UpdateOrgnization
        public ActionResult UpdateOrgnization(string id)
        {
            InitForm("机构信息");
            return View(id.HasValue() ? 
                _orgnization.Find(id):
                new orgnization() {orgnization_id = DateTime.Now.Random()});
        }

        // Post:  Permision2/CRUD2/UpdateOrgnization
        [HttpPost]
        public ActionResult UpdateOrgnization(orgnization m)
        {
            if (ModelState.IsValid)
            {
                return Alert(_orgnization.Update(m) ? "提交成功" : "提交失败");
            }
            else
            {
                InitForm("机构信息");
                return View(m);
            }
        }

        #endregion


        #region 用户组
        public ActionResult AddUserGroup()
        {
            InitForm("添加用户组");
            return View("UpdateUserGroup",new UpdateUserGroup_M()
            {
                father_id = "Root"
            });
        }
        // Post:  Permission/CRUD2/UpdateUserGroup
        [HttpPost]
        public ActionResult AddUserGroup(UpdateUserGroup_M m)
        {
            if (ModelState.IsValid)
            {
                var success = _iPermmisionService.UpdateUserGroup(m.ToModel());
                return Alert(success ? "提交成功" : "提交失败");
            }
            else
            {
                InitForm("添加用户组");
                return View("UpdateUserGroup", m);
            }

        }


        // GET: Permission/CRUD2/UpdateUserGroup
        public ActionResult UpdateUserGroup(string id)
        {
            InitForm("更新用户组");
            return View(UpdateUserGroup_M.ToViewModel(
                _iPermmisionService.FindUserGroup(id)));
        }

        // Post:  Permission/CRUD2/UpdateUserGroup
        [HttpPost]
        public ActionResult UpdateUserGroup(UpdateUserGroup_M m)
        {
            if (ModelState.IsValid)
            {
                var success = _iPermmisionService.UpdateUserGroup(m.ToModel());
                return Alert(success ? "提交成功" : "提交失败");
            }
            else
            {
                InitForm("更新用户组");
                return  View(m);
            }

        }

        // GET: Permission/CRUD2/DeleteUserGroup
        public ActionResult DeleteUserGroup(string id)
        {
            var success = _iPermmisionService.DeleteUserGroup(id);
            return Alert(success ? "删除成功" : "删除失败");
        }
        #endregion

        #region 角色组
        public ActionResult AddRoleGroup()
        {
            InitForm("添加角色组");
            return View("UpdateRoleGroup",new UpdateRoleGroup_M()
            {
                father_id = "Root"
            });
        }
        // Post:  Permission/CRUD2/UpdateRoleGroup
        [HttpPost]
        public ActionResult AddRoleGroup(UpdateRoleGroup_M m)
        {
            if (ModelState.IsValid)
            {
                var success = _iPermmisionService.UpdateRoleGroup(m.ToModel());
                return Alert(success ? "提交成功" : "提交失败");
            }
            else
            {
                InitForm("添加角色组");
                return View("UpdateRoleGroup", m);
            }

        }

        // GET: Permission/CRUD2/UpdateRoleGroup
        public ActionResult UpdateRoleGroup(string id)
        {
            InitForm("更新角色组");
            return View(UpdateRoleGroup_M.ToViewModel(
                _iPermmisionService.FindRoleGroup(id)));
        }

        // Post:  Permission/CRUD2/UpdateRoleGroup
        [HttpPost]
        public ActionResult UpdateRoleGroup(UpdateRoleGroup_M m)
        {
            if (ModelState.IsValid)
            {
                var success = _iPermmisionService.UpdateRoleGroup(m.ToModel());
                return Alert(success ? "提交成功" : "提交失败");
            }
            else
            {
                InitForm("更新角色组");
                return View(m);
            }
       
        }

        // GET: Permission/CRUD2/DeleteRoleGroup
        public ActionResult DeleteRoleGroup(string id)
        {
            var success = _iPermmisionService.DeleteRoleGroup(id);
            return Alert(success ? "删除成功" : "删除失败");
        }

        #endregion

        #region 角色组成员
        public ActionResult AddRoleGroupRelation(string id)
        {
            InitForm("添加角色组成员");
            return View("UpdateRoleGroupRelation", new UpdateRoleGroupRelation_M()
            {
                role_group_id = id,
                _RoleListItems = _role.ToSelectItems()
            });
        }
        // Post:  Permission/CRUD2/UpdateRoleGroupRelation
        [HttpPost]
        public ActionResult AddRoleGroupRelation(UpdateRoleGroupRelation_M m)
        {
            if (ModelState.IsValid)
            {
                var success = _iPermmisionService.UpdateRoleGroupRelation(m.ToModel());
                return Alert(success ? "提交成功" : "提交失败");
            }
            else
            {
                InitForm("更新角色组成员");
                return View("UpdateRoleGroupRelation",m);
            }

        }

        // GET: Permission/CRUD2/UpdateRoleGroupRelation
        public ActionResult UpdateRoleGroupRelation(string id)
        {
            if (!id.HasValue())
            {
                return Alert("参数错误");
            }
            InitForm("更新角色组成员");
            var old = _iPermmisionService.FindRoleGroupRelation(id);
            return View( UpdateRoleGroupRelation_M.ToViewModel(
               old, _role.ToSelectItems(old.role_id)));
        }

        // Post:  Permission/CRUD2/UpdateRoleGroupRelation
        [HttpPost]
        public ActionResult UpdateRoleGroupRelation(UpdateRoleGroupRelation_M m)
        {
            if (ModelState.IsValid)
            {
                var success = _iPermmisionService.UpdateRoleGroupRelation(m.ToModel());
                return Alert(success ? "提交成功" : "提交失败");
            }
            else
            {
                InitForm("更新角色组成员");
                return View(m);
            }
           
        }

        // GET: Permission/CRUD2/DeleteRoleGroupRelation
        public ActionResult DeleteRoleGroupRelation(string id)
        {
            var success = _iPermmisionService.DeleteRoleGroupRelation(id);
            return Alert(success ? "删除成功" : "删除失败");
        }
        #endregion

        #region 用户组成员
        public ActionResult AddUserGroupRelation(string id)
        {
            if (!id.HasValue())
            {
                return Alert("参数错误");
            }

            InitForm("添加用户组成员");
            return View("UpdateUserGroupRelation", new UpdateUserGroupRelation_M()
            {
                user_group_id = id,
                _UserListItems = _user.ToSelectItems()
            });
        }

        // Post:  Permission/CRUD2/UpdateUserGroupRelation
        [HttpPost]
        public ActionResult AddUserGroupRelation(UpdateUserGroupRelation_M m)
        {
            if (ModelState.IsValid)
            {
                var success = _iPermmisionService.UpdateUserGroupRelation(m.ToModel());
                return Alert(success ? "提交成功" : "提交失败");
            }
            else
            {
                InitForm("更新用户组成员");
                return View("UpdateUserGroupRelation",m);
            }

        }

        // GET: Permission/CRUD2/UpdateUserGroupRelation
        public ActionResult UpdateUserGroupRelation(string id)
        {
            if (!id.HasValue())
            {
                return Alert("参数错误");
            }
            InitForm("更新用户组成员");
            var old = _iPermmisionService.FindUserGroupRelation(id);
            return View(UpdateUserGroupRelation_M.ToViewModel(
              old,_user.ToSelectItems(old.user_id)));
        }

        // Post:  Permission/CRUD2/UpdateUserGroupRelation
        [HttpPost]
        public ActionResult UpdateUserGroupRelation(UpdateUserGroupRelation_M m)
        {
            if (ModelState.IsValid)
            {
                var success = _iPermmisionService.UpdateUserGroupRelation(m.ToModel());
                return Alert(success ? "提交成功" : "提交失败");
            }
            else
            {
                InitForm("更新用户组成员");
                return View(m);
            }

        }

        // GET: Permission/CRUD2/DeleteUserGroupRelation
        public ActionResult DeleteUserGroupRelation(string id)
        {
            var success = _iPermmisionService.DeleteUserGroupRelation(id);
            return Alert(success ? "删除成功" : "删除失败");
        }
        #endregion
        // GET: Permission/CRUD2/UserAdd
        public ActionResult UserAdd()
        {
            InitForm("添加用户");
            var id = Q("id");
            if (!id.HasValue()) return View(new UserAdd_M()
            {
                user_id = DateTime.Now.Random(),
                user_type = "0",
            });

            var old = _user.Find(id);
            return View(new UserAdd_M()
            {
                user_id = old.user_id,
                nick_name = old.nick_name,
                user_pwd = old.user_pwd,
                user_type = old.user_type_id.CheckValue("0"),
                note = old.note
            });  
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
           
            var role = _role.Find(role_id);
            InitForm("分配菜单");
            var menu = _menu.Find(menu_id);
            return View(RoleMenuAdd_M.ToViewModel(role_id, role.name, menu_id, menu.name));

        }
        [HttpPost]
        public ActionResult RoleMenuAdd(RoleMenuAdd_M model)
        {
            if (ModelState.IsValid)
            {
                model.role_menu_id = model.role_id + model.menu_id;
                if (_role_menu.Find(model.role_menu_id) == null)
                {
                    _role_menu.Add(model.ToModel());
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
                var button = _button.Find(button_id);
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
            InitForm("角色管理");
            var id = Q("id");
            if (!id.HasValue()) return View(new RoleAdd_M()
            {
                role_id = DateTime.Now.Random(),
                role_type = "1",
                sub_system = "default"
            });

            var old = _role.Find(id);
            return View(new RoleAdd_M()
            {
                role_id = old.role_id,
                name = old.name,
                is_default = old.is_default,
                role_type = old.role_type.CheckValue("1"),
                sub_system = old.sub_system.CheckValue("default")
            });
        }
        [HttpPost]
        public ActionResult RoleAdd(RoleAdd_M model)
        {
            if (ModelState.IsValid)
            {
                return _role.Update(model.ToModel()) ? 
                    Redirect("/Permission/Admin2/RoleList?ReportID=Permision.v2_角色列表&Params=;") :
                    Alert("添加失败，请重新添加");
            }
            else
            {
                InitForm("角色管理");
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
                if (_button.Find(model.button_id) == null)
                {
                    _button.Add(model.ToModel());
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
            InitForm("添加菜单");
            return View(MenuAdd_M.ToViewModel(father_id.GetFixedParam("MRoot"),
                _menu.ToSelectItems(father_id)));
        }
        [HttpPost]
        public ActionResult MenuAdd(MenuAdd_M model)
        {
            if (ModelState.IsValid)
            {
                if (_menu.Find(model.menu_id) == null)
                {
                   
                    _menu.Add(model.ToModel());
                    return Redirect("/Permission/Admin2/MenuList?ReportID=Permision.v2_菜单列表&Params="+model._farther_id.IsFixedParam());
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
        public ActionResult RoleMenuDelete(string role_menu_id)
        {
            role_menu_id = role_menu_id.GetFixedParam();
            if (role_menu_id.HasValue())
            {
                if (_role_menu.Delete(role_menu_id))
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
            var button = _button.Find(button_id);
            if (button != null)
            {
                _button.Delete(button_id);
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
                if (_menu.Delete(menu_id))
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
            var menu = _menu.Find(menu_id);
            return menu == null ? Alert("操作失败") :
                View(MenuEdit_M.ToViewModel(menu,_menu.ToSelectItems(menu.farther_id)));
        }
        [HttpPost]
        public ActionResult MenuEdit(MenuEdit_M model)
        {
            if (ModelState.IsValid)
            {
                var old = _menu.Find(model.menu_id);
                old.status = model.status;
                old.depth = model.depth;
                old.name = model.name;
                old.sequence = model.sequence;
                old.url = model.url;
                old.farther_id = model._farther_id;
                _menu.Update(old);
                return Redirect("/Permission/Admin2/MenuList?ReportID=Permision.v2_菜单列表&Params="+old.farther_id.IsFixedParam());
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

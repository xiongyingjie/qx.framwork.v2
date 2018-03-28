using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using xyj.acs.Entity;
using xyj.acs.Exceptions;
using xyj.acs.Interfaces;
using xyj.acs.Models;
using xyj.core.Extensions;
using xyj.core.Models.Report;

namespace xyj.acs.Services
{
    public class AcsService : BaseRepository, IAcsService
    {
     
        public List<orgnization> GetOrgIdByUserId(string userId,bool includeSub=true)
        {
            //从用户机构获取
            var myOrg = Db.user_orgnization.Where(a => a.user_id == userId).Select(b => b.orgnization.orgnization_id).ToList();
            //从用户岗位获取
            var org2 = Db.user_position.Where(a => a.user_id == userId).Select(b => b.orgnization_position.orgnization.orgnization_id).ToList();
            //合并 去重  用户所在所有组织机构
            myOrg = myOrg.Union(org2).ToList();
           //查找子机构
           if (includeSub)
            {
                var subOrg = Db.orgnization.Where(a => myOrg.Contains(a.father_id)).Select(b => b.orgnization_id).ToList();
                while (subOrg.Any())
                {
                    myOrg = myOrg.Union(subOrg).ToList(); //用户所在机构以及子机构
                    subOrg = Db.orgnization.Where(a => subOrg.Contains(a.father_id)).Select(b => b.orgnization_id).ToList();
                }
            }
          
            return Db.orgnization.Where(a=>myOrg.Contains(a.orgnization_id)).ToList();
        }
        //获取全局权限
        public List<DataFilter> GetFilterByUserId(string userId)
        {
            var query = Db.user_role.Where(a => a.user_id == userId).
                SelectMany(b => b.role.data_filter).Where(a => a.report_id == "#");
             return query.OrderBy(o => o.seq).Select(c => new DataFilter()
            {
                data_filter_id = c.data_filter_id,
                role_id = c.role_id,
                role_name = c.role.name,
                note = c.note,
                seq = (int)c.seq,
                report_id = c.report_id,
                filter_script = c.filter_script.script,
                expire_time = c.expire_time,
            }).ToList();
        }
        //获取指定报表的权限
        public List<DataFilter> GetFilterByUserId(string userId, string reportId)
        {
            //报表权限优先
            var query = Db.user_role.Where(a => a.user_id == userId).
                SelectMany(b => b.role.data_filter);
            if (reportId.HasValue())
            {
                query = query.Where(a => a.report_id == reportId);
            }
            //如果未找针对该报表的规则，则尝试获取全局规则
            if (!query.Any())
            {
                var all = GetFilterByUserId(userId);
                if (all.Any())
                {//全局权限优先
                    return all;
                }
            }
            return query.OrderBy(o => o.seq).Select(c => new DataFilter()
            {
                data_filter_id = c.data_filter_id,
                role_id = c.role_id,
                role_name = c.role.name,
                note = c.note,
                seq = (int)c.seq,
                report_id = c.report_id,
                filter_script = c.filter_script.script,
                expire_time = c.expire_time,
            }).ToList();
        }


        public List<MenuItem> GetMenuByUserId(string userId)
        {
            var allMenus = Db.menu.ToList();

            List<string> myAllMenus;
         
            //我被直接分配的菜单配置
            var cfg = Db.user_role.Where(a => a.user_id == userId).
                SelectMany(b => b.role.role_menu);
            //踢出根节点后加入全集
            myAllMenus = cfg.Where(a => a.menu.farther_id != "MRoot").Select(a => a.menu.menu_id).ToList();//,));
            
            //取出直接分配中包含包含子菜单的部分
            var _myMenus1 = cfg.Where(a => a.include_children == 1).Select(b=>b.menu.menu_id).ToList();
            var subMenu = allMenus.Where(a => _myMenus1.Contains(a.farther_id)).Select(b=>b.menu_id).ToList();
            myAllMenus= myAllMenus.Union(subMenu).ToList();
            //寻找子菜单
            while (subMenu.Any())
            {
                subMenu = allMenus.Where(a => subMenu.Contains(a.farther_id)).Select(b=>b.menu_id).ToList();
                myAllMenus = myAllMenus.Union(subMenu).ToList();
            }
          
            ////我的所有包含孩子的菜单
            //var myMenus1 = Db.user_role.Where(a => a.user_id == userId).
            //  SelectMany(b => b.role.role_menu.Where(z=>z.include_children==1).Select(c => c.menu)).
            //  ToList().
            //  Distinct(this.CreateEqualityComparer<menu, string>(z => z.menu_id)).//去重
            //  ToList();

            ////补全缺失子菜单
            //var myMenus1ChildMenus =
            //    myMenus1.SelectMany(a => allMenus.
            //    Where(b => b.farther_id == a.menu_id).
            //    Select(c => c)).
            //   // OrderBy(c => c.sequence).//根菜单排序
            //    ToList();




            ////我被分配的包含孩子的根菜单
            //var myRootMenus = myMenus.
            //    Where(a => a.farther_id == "MRoot"&&a.RoleMenus.Any(b=>b.include_children==1)).
            //    OrderBy(c=>c.sequence).//根菜单排序
            //    ToList();



            ////我被分配的子菜单[]
            //var myChildMenus = myMenus.Except(myRootMenus).ToList();

            //myMenus0ExceptRoot+myMenus1ChildMenus
            // myMenus0ExceptRoot.AddRange(myMenus1ChildMenus);

            //去重后的所有子菜单
            //var myAllChilren =
            //    myMenus0ExceptRoot.Distinct(this.CreateEqualityComparer<menu,string>(z => z.menu_id)).//去重
            //    OrderBy(c => c.sequence).//排序
            //    ToList();

            //分组后找父亲

            var dest= allMenus.Where(z=> myAllMenus.Contains(z.menu_id)).GroupBy(a => a.farther_id).Select(g => new MenuItem()
            {
                Father = allMenus.FirstOrDefault(b => b.menu_id == g.Key),
                Children = g.OrderBy(oo=>oo.sequence).AsEnumerable().Select(c => c).ToList()
            }).ToList();

            //var dest = myRootMenus.Select(a => new MenuItem()
            //{
            //    Father = a,
            //    Children = allMenus.Where(b=>b.farther_id==a.menu_id).ToList()
            //}
            // ).ToList();

            ////追加已分配的子菜单
            //dest.ForEach(a =>
            //{
            //    a.Children.AddRange(myChildMenus.Where(b => b.farther_id == a.Father.menu_id));
            //    a.Children = a.Children.Distinct(CommonExtendMethods.Equality<Menu>.CreateComparer(z => z.menu_id)).//去重
            //    OrderBy(c=>c.sequence).//子菜单排序
            //    ToList();
            //});

            return dest;
        }

        public List<button> GetForbidenButtonByUserId(string userId)
        {
            //var roles = Db.UserRoles.Where(a => a.user_id == userId).Select(b => b.Role);
            //var dest =
            //    Db.RoleButtonForbids.Where(a => roles.Any(b => b.role_id == a.role_id)).Select(c => c.Button).ToList();

            var dest = Db.user_role.Where(a => a.user_id == userId).
              SelectMany(b => b.role.role_button_forbid.Select(c => c.button)).ToList();
            return dest;
        }

        public List<DropDownListItem> GetMenu(string selectedMenuId = "-1", string rootFather = "MRoot")
        {
            throw new System.NotImplementedException();
        }

        private Navbar Parse(menu a)
        {
            var bar = new Navbar();
            try
            {
                bar = (new Navbar()
                {
                    Id = a.menu_id,
                    Name = a.name,
                    ParentId = a.farther_id,
                    IsParent = a.farther_id == "MRoot" ? true : false,
                    Status = a.status == "true" ? true : false,
                    Action = a.action,
                    Controller = a.controller,
                    Area = a.area,
                    Activeli = a.active_li,
                    ImageClass = a.image_class,
                    Url = a.url
                });
            }
            catch (Exception)
            {

                bar = (new Navbar()
                {
                    Id = a.menu_id,
                    Name = "[Error]" + a.name,
                    ParentId = a.farther_id,
                    Status = true,
                    IsParent = a.farther_id == "MRoot" ? true : false, //a.Father.MenuExtension.IsParent
                    Action = "#",
                    Controller = "#",
                    Area = "#",
                    Activeli = "",
                    ImageClass = "fa fa-bar-chart-o fa-fw",
                    //    menu.Add(new Navbar { Id = 2, nameOption = "车辆管理(管理员)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
                    // menu.Add(new Navbar { Id = 21, nameOption = "车辆列表(管理员)", area = "FastCar", controller = "Admin", action = "CarList", status = true, isParent = false, parentId = 2 });
                });
            }
            return bar;
        }

        public IEnumerable<Navbar> GetNavbarByUserId(string userId)
        {
            var dest = new List<Navbar>();
            var myMenus = GetMenuByUserId(userId);
            myMenus.ForEach(a =>
            {
                //添加 Father
                dest.Add(Parse(a.Father));
                //添加 Children
                if (a.Children.Count > 0)
                {
                    a.Children.ForEach(b =>
                    {
                        dest.Add(Parse(b));
                    });
                }
            });
            return dest;
        }

        public List<menu> FindFather(string menuid)
        {
            var father = Db.menu.FirstOrDefault(a => a.menu_id == menuid);
            List<menu> fathers = new List<menu>();
            while (father != null)
            {
                if (father.menu_id == "MRoot")
                    break;
                fathers.Add(father);
                father = Db.menu.Find(father.farther_id);
            }
            fathers.Reverse();
            return fathers;
        }


        public bool UpdateUserGroup(UserGroup model)
        {
            Db.user_group.Update(model.ToEntity());
            var saveOk = Db.SaveChanges() > 0;
            return saveOk;
        }
        public bool UpdateRoleGroup(RoleGroup model)
        {
            Db.role_group.Update(model.ToEntity());
            var saveOk = Db.SaveChanges() > 0;
            return saveOk;
        }
        public bool UpdateRoleGroupRelation(RoleGroupRelation model)
        {
            Db.role_group_relation.Update(model.ToEntity());
            var saveOk = Db.SaveChanges() > 0;
            return saveOk;
        }
        public bool UpdateUserGroupRelation(UserGroupRelation model)
        {
            Db.user_group_relation.Update(model.ToEntity());
            var saveOk = Db.SaveChanges() > 0;
            return saveOk;
        }

        public UserGroup FindUserGroup(string id)
        {
            return UserGroup.ToModel(Db.user_group.
                FirstOrDefault(a=>a.user_group_id==id));

        }

        public RoleGroup FindRoleGroup(string id)
        {
            return RoleGroup.ToModel(Db.role_group.
               FirstOrDefault(a => a.role_group_id == id));
        }

        public RoleGroupRelation FindRoleGroupRelation(string id)
        {
            return RoleGroupRelation.ToModel(Db.role_group_relation.
                FirstOrDefault(a => a.role_group_id == id));
        }

        public UserGroupRelation FindUserGroupRelation(string id)
        {
            return UserGroupRelation.ToModel(Db.user_group_relation.
                FirstOrDefault(a => a.user_group_relation_id == id));
        }

        public bool DeleteUserGroup(string id)
        {
            var old = Db.user_group.
                FirstOrDefault(a => a.user_group_id == id);
            return old!=null && Db.user_group.Remove(old) != null && Db.SaveChanges() > 0;
         
        }

        public bool DeleteRoleGroup(string id)
        {
            var old = Db.role_group.
               FirstOrDefault(a => a.role_group_id == id);
            return old != null && Db.role_group.Remove(old) != null && Db.SaveChanges() > 0;

        }

        public bool DeleteRoleGroupRelation(string id)
        {
            var old = Db.role_group_relation.
             FirstOrDefault(a => a.role_group_relation_id == id);
            return old != null && Db.role_group_relation.Remove(old) != null && Db.SaveChanges() > 0;

        }

        public bool DeleteUserGroupRelation(string id)
        {
            var old = Db.user_group_relation.
            FirstOrDefault(a => a.user_group_relation_id == id);
            return old != null && Db.user_group_relation.Remove(old) != null && Db.SaveChanges() > 0;

        }
        public bool Login(string userId, string userPwd)
        {
            userPwd = NoneEncrypt(userPwd);
            var old=  Db.permission_user.FirstOrDefault(a => a.user_id == userId &&
                                               a.user_pwd == userPwd);
            if (old!=null)
            {
                old.last_login_date = DateTime.Now;
                Db.Entry(old).State = EntityState.Modified;
                Db.SaveChanges();
                return true;
            }
            return false;
        }

        public sub_system_data GetSubSystemData(string subSystemIdOrPk, string dataKey="")
        {
            return dataKey.HasValue()
                ?Db.sub_system_data.FirstOrDefault(a => a.sub_system_id == subSystemIdOrPk && a.data_key == dataKey)
                :  Db.sub_system_data.FirstOrDefault(a => a.sub_system_data_id == subSystemIdOrPk);
        }
        public bool SetSubSystemData(string subSystemId, string dataKey, string dataValue)
        {
            var old= Db.sub_system_data.FirstOrDefault(a => a.sub_system_id == subSystemId && a.data_key == dataKey);
            if (!Db.sub_system.Any(a => a.sub_system_id == subSystemId))
            {//拦截未由框架人员注册的写入请求
                return false;
            }
            if (old != null)
            {//编辑
                if (old.data_value == dataValue)
                {//更新前后一样，直接返回且不做日志
                    return true;
                }
                else
                {
                    Db.sub_system_data_log.Add(new sub_system_data_log()
                    {
                        sub_system_data_log_id = old.sub_system_data_id + DateTime.Now.Random(),
                        sub_system_data_id = old.sub_system_data_id,
                        old_data_value = old.data_value,
                        change_time = DateTime.Now
                    });
                    old.data_value = dataValue;
                    Db.sub_system_data.Update(old);
                }
            }
            else
            {//添加
                Db.sub_system_data.Add(new sub_system_data()
                {
                    sub_system_data_id = subSystemId+"-"+ dataKey,
                    sub_system_id = subSystemId,
                    data_key = dataKey,
                    data_value = dataValue,
                    create_time = DateTime.Now,
                    model = "",
                    note = ""
                });
            }
            return Db.SaveChanges() > 0;
        }
        public List<permission_user> FindUsers(List<string> userIdOrUserNameArray)
        {
            return Db.permission_user.Where(a => userIdOrUserNameArray.Contains(a.user_id) ||
                                                 userIdOrUserNameArray.Contains(a.nick_name)
            ).ToList();
        }
        public bool Regist(string userId, string userPwd,
            string nickName = "", string email = "", string phone = "", string userTypeId = "", 
            string note = "", List<string> roleList = null,string subSys="")
        {

            if (!(userId.HasValue() && userPwd.HasValue()))
            {
                throw new ParamNotEnoughException(
                    "userId=>" + userId + "\r\n" +
                    "userPwd=>" + userPwd + "\r\n"
                );
            }
            var site = note.ToLower().Replace("http://", "").Replace("https://", "").Replace("/", "");
            #region 基础数据准备
            object result;
            #region  subSystem 

            var subSystem = new sub_system()
            {
                sub_system_id = "deafult",
                name = "默认",
                create_time =  DateTime.Now ,
                note = "系统默认，用于兼容以前的旧用户",
                plateform = "sys"
            };
            result = Db.sub_system.Any(a => a.sub_system_id == subSystem.sub_system_id)
                ? new object() //  Db.sub_system.Update(subSystem)
                : Db.sub_system.Add(subSystem);
            #endregion

            #region subSystemRegDeafult

            var subSystemRegDeafult = new sub_system_reg()
            {
                sub_system_reg_id = "deafult",//子系统注册标识
                sub_system_id = subSystem.sub_system_id,//子系统标识
                site = "默认",//注册站点
                user_id = "deafult",
                reg_time = DateTime.Now,
                note = "系统默认，用于兼容以前的旧用户"
            };

            result = Db.sub_system_reg.Any(a => a.sub_system_id == subSystemRegDeafult.sub_system_id)
                ? new object() //Db.sub_system_reg.Update(subSystemReg)
                : Db.sub_system_reg.Add(subSystemRegDeafult);
            
            #endregion

            #region  orglevel 

            var orgLevel = new organization_level()
            {
                organization_level_id = "deafult",
                name = "根组织（虚拟）",
                note = "由PermissionProvider.Regist于" + DateTime.Now + "自动创建"
            };
             result = Db.organization_level.Any(a => a.organization_level_id == orgLevel.organization_level_id)
                ? new object() // Db.organization_level.Update(orgLevel)
                : Db.organization_level.Add(orgLevel);
            #endregion

            #region orgType  
            var orgType = new orgnization_type()
            {
                orgnization_type_id = "deafult",
                name = "默认",
                note = "由PermissionProvider.Regist于" + DateTime.Now + "自动创建"
            };

            result = Db.orgnization_type.Any(a => a.orgnization_type_id == orgType.orgnization_type_id)
                ? new object() //  Db.orgnization_type.Update(orgType)
                : Db.orgnization_type.Add(orgType);
            #endregion

            #region org 
            var org = new orgnization()
            {
                orgnization_id = "deafult",
                descripe = "系统自动注册的用户均放在该节点下",
                father_id = "Root",
                name = "普通用户",
                note = "由PermissionProvider.Regist于" + DateTime.Now + "自动创建",
                organization_level_id = orgLevel.organization_level_id,
                orgnization_type_id = orgType.orgnization_type_id
            };
            result = Db.orgnization.Any(a => a.orgnization_id == org.orgnization_id)
                ? new object() //  Db.orgnization.Update(org)
                : Db.orgnization.Add(org);
            #endregion

            #region role

            var role = new role()
            {
                role_id = "deafult",
                name = "默认角色",
                is_default = 1,
                sub_system = "system",
                role_type = "系统默认角色"
            };

            result = Db.role.Any(a => a.role_id == role.role_id)
                ? new object() // Db.role.Update(role)
                : Db.role.Add(role);

            #endregion
            #endregion


            #region 盗版检测
            if (subSys.HasValue() && subSys != "deafult")
            {
                var fakeApp = new sub_system()
                {
                    sub_system_id = subSys,
                    name = "fake-" + subSys,
                    create_time = DateTime.Now,
                    note = "盗版程序:" + subSys + ",盗版首次注册站点:" + note + ",首次注册的用户id:" + userId,
                    plateform = "fake"
                };
                result = Db.sub_system.Any(a => a.sub_system_id == fakeApp.sub_system_id)
                    ?new object() // Db.sub_system.Update(fakeApp)
                    : Db.sub_system.Add(fakeApp);

                Db.SaveChanges();
            }

            #endregion


            #region 注册系统

            var subSystemReg = new sub_system_reg()
            {
                sub_system_reg_id = subSys+"-"+ site,//子系统注册标识
                sub_system_id = subSys,//子系统标识
                site = site,//注册站点
                user_id = userId,
                reg_time = DateTime.Now,
                note = note//保留原始站点信息
            };

            result = Db.sub_system_reg.Any(a => a.sub_system_id == subSystemReg.sub_system_id && a.site == subSystemReg.site)
                ? new object() //Db.sub_system_reg.Update(subSystemReg)
                : Db.sub_system_reg.Add(subSystemReg);
            Db.SaveChanges();
            #endregion


            #region user 添加用户

            var user = new permission_user()
            {
                user_id =  userId,//同个用户打开不同站点处理为不同用户
                user_pwd = NoneEncrypt(userPwd),
                nick_name = nickName.CheckValue("none"),
                user_type_id = userTypeId.CheckValue("0"),
                email = email.CheckValue("none"),
                phone = phone.CheckValue("none"),
                register_date = DateTime.Now,
                last_login_date = DateTime.Now,
                sub_system_reg_id = subSystemReg.sub_system_reg_id,
                note= note//原始站点
            };

            result = Db.permission_user.Any(a => a.user_id == user.user_id)
                ? Db.permission_user.Update(user)
                : Db.permission_user.Add(user);

            #endregion

            //分配默认组织机构

            #region user_orgnization 
            var userOrg = new user_orgnization()
            {
                user_orgnization_id = user.user_id + "-" + org.orgnization_id,
                user_id = user.user_id,
                orgnization_id = org.orgnization_id
            };
            result = Db.user_orgnization.Any(a => a.user_orgnization_id == userOrg.user_orgnization_id)
                ? new object() //  Db.user_orgnization.Update(userOrg)
                : Db.user_orgnization.Add(userOrg);
            #endregion


            #region userRole

            var userRole = new user_role()
            {
                user_id = user.user_id,
                role_id = role.role_id,
                note = "新用户注册自动添加默认角色[" + role.name + "];有效期为永久",
                expire_time = DateTime.MaxValue,
                user_role_id = user.user_id + "-" + role.role_id
            };
            result = Db.user_role.Any(a => a.user_role_id == userRole.user_role_id)
                ? new object() //  Db.user_role.Update(userRole)
                : Db.user_role.Add(userRole);
            #endregion


            //分配角色

            roleList?.ForEach(rid =>
            {
                var tempRole = Db.role.FirstOrDefault(a => a.role_id == rid);
                if (tempRole != null)
                {

                    var tempUserRole = new user_role()
                    {
                        user_id = user.user_id,
                        role_id = tempRole.role_id,
                        note = "新用户注册自动添加默认角色[" + tempRole.name + "];有效期为永久",
                        expire_time = DateTime.MaxValue,
                        user_role_id = user.user_id + "-" + tempRole.role_id
                    };
                    result = Db.user_role.Any(a => a.user_role_id == tempUserRole.user_role_id)
                        ? new object() // Db.user_role.Update(tempUserRole)
                        : Db.user_role.Add(tempUserRole);

                }
            });
            Db.SaveChanges();
            return true;
        }

        public permission_user UserInfo(string userId)
        {
            var result = Db.permission_user.Where(a => a.user_id == userId);
            if (result.Count() > 1)
            {
                throw new Exception("找到" + result.Count() + "个UserID为" + userId + @"的用户");
            }
            if (result.FirstOrDefault() == null)
            {
                throw new Exception("未找到UserID为" + userId + @"的用户");
            }
            return result.FirstOrDefault();
        }



        public bool UpdateUser(string userId, string nickName, string userPwd = "", string email = "", string phone = "", string note = "")
        {
            var old = UserInfo(userId);

            old.nick_name = nickName;
            if (userPwd.HasValue())
            {
                old.user_pwd = NoneEncrypt(userPwd);
            }
            if (email.HasValue())
            {
                old.email = email;
            }
            if (phone.HasValue())
            {
                old.phone = phone;
            }
            if (note.HasValue())
            {
                old.note = note;
            }
            Db.Entry(old).State = EntityState.Modified;
            return Db.SaveChanges() > 0;
        }
        public bool DeleteUser(string userid)
        {
            var user = Db.permission_user.Find(userid);
            if (user != null)
            {
                Db.Entry(user).State = EntityState.Deleted;
                return Db.SaveChanges() > 0;
            }
            return true;

        }
        public bool AddOrgnization(string father_id, string name, string orgnization_type_id, string orgnization_id = "")
        {
            orgnization_id = orgnization_id.CheckValue(Pk);
            if (orgnization_id.HasValue() && father_id.HasValue() && name.HasValue() && orgnization_type_id.HasValue())
            {
                Db.orgnization.Update(new orgnization()
                {
                    orgnization_id = orgnization_id,
                    father_id = father_id,
                    name = name,
                    orgnization_type_id = orgnization_type_id,
                });
                return Db.SaveChanges() > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }

        public orgnization FindOrgnizationByUserId(string userid)
        {
            var data = Db.user_orgnization.FirstOrDefault(o => o.user_id == userid);
            return Db.orgnization.FirstOrDefault(o => o.orgnization_id == data.orgnization_id);
        }

        public bool AddUser(string userId, string userPwd, string nickName, string userTypeId, string email = "none", string phone = "none")
        {
            var data = new permission_user();
            data.user_id = userId;
            data.user_pwd = userPwd;
            data.nick_name = nickName;
            data.user_type_id = userTypeId;
            data.email = email;
            data.phone = phone;
            Db.permission_user.Update(data);
            return Db.SaveChanges() > 0 ? true : false;
        }

        public List<orgnization> FindRelationByOrgnizationId(string orgnization_id)
        {
            var relation_orgnization = new List<orgnization>();
            var items = Db.organization_relation.Where(a => a.orgnization_id == orgnization_id).ToList();
            foreach (var item in items)
            {
                var data = Db.orgnization.FirstOrDefault(o => o.orgnization_id == item.other_orgnization_id);
                relation_orgnization.Add(data);
            }
            return relation_orgnization;
        }

        public position FindPositionByUserId(string userid)
        {
            var data = Db.user_position.FirstOrDefault(o => o.user_id == userid);
            var data2 = Db.orgnization_position.FirstOrDefault(o => o.orgnization_position_id == data.orgnization_position_id);
            return Db.position.FirstOrDefault(o => o.position_id == data2.position_id);
        }

        public List<position> FindPositionsByOgnizationId(string orgnization_id)
        {
            var datas = new List<position>();
            var items = Db.orgnization_position.Where(o => o.orgnization_id == orgnization_id).ToList();
            foreach (var item in items)
            {
                var data = Db.position.FirstOrDefault(o => o.position_id == item.position_id);
                datas.Add(data);
            }
            return datas;
        }

        public string AddUserToOrgnization(string user_id, string orgnization_id)
        {
            string user_orgnization_id = orgnization_id + "-" + user_id;
            Db.user_orgnization.Add(new user_orgnization()
            {
                user_orgnization_id = user_orgnization_id,
                user_id = user_id,
                orgnization_id = orgnization_id
            });
            return Db.SaveChanges() > 0 ? user_orgnization_id : "";
        }

        public bool AddPosition(string position_id, string position_type_id, string name, string descripe = "none",
            string note = "none")
        {
            Db.position.Add(new position()
            {
                position_id = position_id,
                position_type_id = position_type_id,
                name = name,
                descripe = descripe,
                note = note
            });
            return Db.SaveChanges() > 0 ? true : false;
        }

        public bool AddPositionToOgnization(string orgnization_id, string position_id)
        {
            string orgnization_position_id = orgnization_id + "-" + position_id;
            Db.orgnization_position.Add(new orgnization_position()
            {
                orgnization_position_id = orgnization_position_id,
                position_id = position_id,
                orgnization_id = orgnization_id
            });
            return Db.SaveChanges() > 0 ? true : false;
        }

        public bool AddRoleToUser(string user_id, string role_id)
        {
            string user_role_id = user_id + "-" + role_id;
            Db.user_role.Add(new user_role()
            {
                user_role_id = user_role_id,
                user_id = user_id,
                role_id = role_id
            });
            return Db.SaveChanges() > 0 ? true : false;
        }

        public bool AddPositionToUser(string orgnization_position_id, string user_id)
        {
            Db.user_position.Add(new user_position()
            {
                user_position_id = DateTime.Now.Random(),
                user_id = user_id,
                orgnization_position_id = orgnization_position_id
            });
            return Db.SaveChanges() > 0 ? true : false;
        }

    }
}
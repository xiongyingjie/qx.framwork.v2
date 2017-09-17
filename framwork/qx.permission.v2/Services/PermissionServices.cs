using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Interfaces;
using qx.permmision.v2.Models;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Models.Report;

namespace qx.permmision.v2.Services
{
    public class PermissionServices : BaseRepository,IPermmisionService
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
                Children = g.AsEnumerable().Select(c => c).ToList()
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

        public List<SelectListItem> GetMenu(string selectedMenuId = "-1", string rootFather = "MRoot")
        {
            throw new System.NotImplementedException();
        }

        private Navbar Parse(menu a)
        {
            var bar = new Navbar();
            try
            {
                bar=(new Navbar()
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

                bar=(new Navbar()
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
            Db.user_group.AddOrUpdate(model.ToEntity());
            var saveOk = Db.SaveChanges() > 0;
            return saveOk;
        }
        public bool UpdateRoleGroup(RoleGroup model)
        {
            Db.role_group.AddOrUpdate(model.ToEntity());
            var saveOk = Db.SaveChanges() > 0;
            return saveOk;
        }
        public bool UpdateRoleGroupRelation(RoleGroupRelation model)
        {
            Db.role_group_relation.AddOrUpdate(model.ToEntity());
            var saveOk = Db.SaveChanges() > 0;
            return saveOk;
        }
        public bool UpdateUserGroupRelation(UserGroupRelation model)
        {
            Db.user_group_relation.AddOrUpdate(model.ToEntity());
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
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Interfaces;
using qx.permmision.v2.Models;
using Qx.Tools.CommonExtendMethods;

namespace qx.permmision.v2.Services
{
    public class PermissionServices : BaseRepository,IPermmisionService
    {

        public List<MenuItem> GetMenuByUserId(string userId)
        {
            var allMenus = Db.menu.ToList();

        var myAllMenus=new List<menu>();

            //�ҵ����в��������ӵĲ˵�
            var myMenus0 = Db.user_role.Where(a => a.user_id == userId).
              SelectMany(b => b.role.role_menu.Where(z => z.include_children == 0).Select(c => c.menu)).
              //  ToList().
              // Distinct(CommonExtendMethods.Equality<Menu>.CreateComparer(z => z.menu_id)).//ȥ��
              ToList();

            //�߳����ڵ�
          var myMenus0ExceptRoot= myMenus0.Where(a => a.farther_id != "MRoot").Select(b => b).ToList();

            //�ҵ����а������ӵĲ˵�
            var myMenus1 = Db.user_role.Where(a => a.user_id == userId).
              SelectMany(b => b.role.role_menu.Where(z=>z.include_children==1).Select(c => c.menu)).
              ToList().
              Distinct(this.CreateEqualityComparer<menu, string>(z => z.menu_id)).//ȥ��
              ToList();

            //��ȫȱʧ�Ӳ˵�
            var myMenus1ChildMenus =
                myMenus1.SelectMany(a => allMenus.
                Where(b => b.farther_id == a.menu_id).
                Select(c => c)).
               // OrderBy(c => c.sequence).//���˵�����
                ToList();




            ////�ұ�����İ������ӵĸ��˵�
            //var myRootMenus = myMenus.
            //    Where(a => a.farther_id == "MRoot"&&a.RoleMenus.Any(b=>b.include_children==1)).
            //    OrderBy(c=>c.sequence).//���˵�����
            //    ToList();



            ////�ұ�������Ӳ˵�[]
            //var myChildMenus = myMenus.Except(myRootMenus).ToList();

            //myMenus0ExceptRoot+myMenus1ChildMenus
            myMenus0ExceptRoot.AddRange(myMenus1ChildMenus);

           //ȥ�غ�������Ӳ˵�
            var myAllChilren =
                myMenus0ExceptRoot.Distinct(this.CreateEqualityComparer<menu,string>(z => z.menu_id)).//ȥ��
                OrderBy(c => c.sequence).//����
                ToList();

            //������Ҹ���

          var dest=  myAllChilren.GroupBy(a => a.farther_id).Select(g => new MenuItem()
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

            ////׷���ѷ�����Ӳ˵�
            //dest.ForEach(a =>
            //{
            //    a.Children.AddRange(myChildMenus.Where(b => b.farther_id == a.Father.menu_id));
            //    a.Children = a.Children.Distinct(CommonExtendMethods.Equality<Menu>.CreateComparer(z => z.menu_id)).//ȥ��
            //    OrderBy(c=>c.sequence).//�Ӳ˵�����
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
                    //    menu.Add(new Navbar { Id = 2, nameOption = "��������(����Ա)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
                    // menu.Add(new Navbar { Id = 21, nameOption = "�����б�(����Ա)", area = "FastCar", controller = "Admin", action = "CarList", status = true, isParent = false, parentId = 2 });
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
                //��� Father
                dest.Add(Parse(a.Father));
                //��� Children
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
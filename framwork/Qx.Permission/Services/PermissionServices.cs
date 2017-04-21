using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Web.Mvc;
using Qx.Permission.Entity;
using Qx.Permission.Interfaces;
using Qx.Permission.Models;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Permission.Services
{
    public class PermissionServices : BaseRepository,IPermission
    {

        public List<MenuItem> GetMenuByUserId(string userId)
        {
            var allMenus = Db.menu.ToList();

        var myAllMenus=new List<menu>();

            //�ҵ����в��������ӵĲ˵�
            var myMenus0 = Db.user_role.Where(a => a.UserID == userId).
              SelectMany(b => b.role.role_menu.Where(z => z.IncludeChildren == 0).Select(c => c.menu)).
              //  ToList().
              // Distinct(CommonExtendMethods.Equality<Menu>.CreateComparer(z => z.MenuID)).//ȥ��
              ToList();

            //�߳����ڵ�
          var myMenus0ExceptRoot= myMenus0.Where(a => a.FartherID != "MRoot").Select(b => b).ToList();

            //�ҵ����а������ӵĲ˵�
            var myMenus1 = Db.user_role.Where(a => a.UserID == userId).
              SelectMany(b => b.role.role_menu.Where(z=>z.IncludeChildren==1).Select(c => c.menu)).
              ToList().
              Distinct(CommonExtendMethods.Equality<menu>.CreateComparer(z => z.MenuID)).//ȥ��
              ToList();

            //��ȫȱʧ�Ӳ˵�
            var myMenus1ChildMenus =
                myMenus1.SelectMany(a => allMenus.
                Where(b => b.FartherID == a.MenuID).
                Select(c => c)).
               // OrderBy(c => c.Sequence).//���˵�����
                ToList();




            ////�ұ�����İ������ӵĸ��˵�
            //var myRootMenus = myMenus.
            //    Where(a => a.FartherID == "MRoot"&&a.RoleMenus.Any(b=>b.IncludeChildren==1)).
            //    OrderBy(c=>c.Sequence).//���˵�����
            //    ToList();



            ////�ұ�������Ӳ˵�[]
            //var myChildMenus = myMenus.Except(myRootMenus).ToList();

            //myMenus0ExceptRoot+myMenus1ChildMenus
            myMenus0ExceptRoot.AddRange(myMenus1ChildMenus);

           //ȥ�غ�������Ӳ˵�
            var myAllChilren =
                myMenus0ExceptRoot.Distinct(CommonExtendMethods.Equality<menu>.
                CreateComparer(z => z.MenuID)).//ȥ��
                OrderBy(c => c.Sequence).//����
                ToList();

            //������Ҹ���

          var dest=  myAllChilren.GroupBy(a => a.FartherID).Select(g => new MenuItem()
            {
                Father = allMenus.FirstOrDefault(b => b.MenuID == g.Key),
                Children = g.AsEnumerable().Select(c => c).ToList()
            }).ToList();

            //var dest = myRootMenus.Select(a => new MenuItem()
            //{
            //    Father = a,
            //    Children = allMenus.Where(b=>b.FartherID==a.MenuID).ToList()
            //}
            // ).ToList();

            ////׷���ѷ�����Ӳ˵�
            //dest.ForEach(a =>
            //{
            //    a.Children.AddRange(myChildMenus.Where(b => b.FartherID == a.Father.MenuID));
            //    a.Children = a.Children.Distinct(CommonExtendMethods.Equality<Menu>.CreateComparer(z => z.MenuID)).//ȥ��
            //    OrderBy(c=>c.Sequence).//�Ӳ˵�����
            //    ToList();
            //});

            return dest;
        }

        public List<button> GetForbidenButtonByUserId(string userId)
        {
            //var roles = Db.UserRoles.Where(a => a.UserID == userId).Select(b => b.Role);
            //var dest =
            //    Db.RoleButtonForbids.Where(a => roles.Any(b => b.RoleID == a.RoleID)).Select(c => c.Button).ToList();

            var dest = Db.user_role.Where(a => a.UserID == userId).
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
                    Id = a.MenuID,
                    Name = a.Name,
                    ParentId = a.FartherID,
                    IsParent = a.FartherID == "MRoot" ? true : false, 
                    Status = a.menu_extension.Status == "true" ? true : false,
                    Action = a.menu_extension.Action,
                    Controller = a.menu_extension.Controller,
                    Area = a.menu_extension.Area,
                    Activeli = a.menu_extension.ActiveLi,
                    ImageClass = a.menu_extension.ImageClass,
                });
            }
            catch (Exception)
            {

                bar=(new Navbar()
                {
                    Id = a.MenuID,
                    Name = "[Error]" + a.Name,
                    ParentId = a.FartherID,
                    Status = true,
                    IsParent = a.FartherID == "MRoot" ? true : false, //a.Father.MenuExtension.IsParent
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
            var father = Db.menu.FirstOrDefault(a => a.MenuID == menuid);
            List<menu> fathers = new List<menu>();
            while (father != null)
            {
                if (father.MenuID == "MRoot")
                    break;
                fathers.Add(father);
                father = Db.menu.Find(father.FartherID);
            }
            fathers.Reverse();
            return fathers;
        }
    }
}
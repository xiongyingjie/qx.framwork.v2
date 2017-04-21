using System.Collections.Generic;
using System.Linq;
using Qx.Permission.Entity;

namespace Qx.Permission.Models
{
    public static class MenuItemExtend
    {
        //public static List<MenuItem> Parse(this List<Menu> menus)
        //{
        //    //结果集
        //    var tempList = new List<MenuItem>();


        //    //找出一级菜单
        //    var fathers = menus.Where(a => a.FartherID == "MRoot").
        //        Distinct(Qx.Tools.CommonExtendMethods.CommonExtendMethods.Equality<Menu>.CreateComparer(m => m.MenuID)).
        //        OrderBy(b => b.Sequence);
        //    //找出二级菜单
        //    foreach (var father in fathers)
        //    {
        //        //该父亲的孩子
        //        var fatherID = father.MenuID;
        //        var children = menus.Where(a => a.FartherID == fatherID).
        //            Distinct(Qx.Tools.CommonExtendMethods.CommonExtendMethods.Equality<Menu>.CreateComparer(m => m.MenuID)).
        //            OrderBy(b => b.Sequence);
        //        tempList.Add(new MenuItem(father, children));
        //    }
        //    return tempList;
        //}

        public static List<MenuItem> Selected(this List<MenuItem> menus,string selectedId)
        {
            menus.ForEach(a =>
            {
                a.Selected = a.Father.MenuID == selectedId;
            });
            return menus;
        }
    }
}
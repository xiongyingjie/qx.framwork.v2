using System.Collections.Generic;

namespace xyj.acs.Models
{
    public static class MenuItemExtend
    {
        //public static List<MenuItem> Parse(this List<Menu> menus)
        //{
        //    //结果集
        //    var tempList = new List<MenuItem>();


        //    //找出一级菜单
        //    var fathers = menus.Where(a => a.farther_id == "MRoot").
        //        Distinct(Qx.Tools.CommonExtendMethods.CommonExtendMethods.Equality<Menu>.CreateComparer(m => m.menu_id)).
        //        OrderBy(b => b.sequence);
        //    //找出二级菜单
        //    foreach (var father in fathers)
        //    {
        //        //该父亲的孩子
        //        var fatherID = father.menu_id;
        //        var children = menus.Where(a => a.farther_id == fatherID).
        //            Distinct(Qx.Tools.CommonExtendMethods.CommonExtendMethods.Equality<Menu>.CreateComparer(m => m.menu_id)).
        //            OrderBy(b => b.sequence);
        //        tempList.Add(new MenuItem(father, children));
        //    }
        //    return tempList;
        //}

        public static List<MenuItem> Selected(this List<MenuItem> menus,string selectedId)
        {
            menus.ForEach(a =>
            {
                a.Selected = a.Father.menu_id == selectedId;
            });
            return menus;
        }
    }
}
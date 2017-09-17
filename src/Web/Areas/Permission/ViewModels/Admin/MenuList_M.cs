using System.Collections.Generic;
using qx.permmision.v2.Entity;

namespace Web.Areas.Permission.ViewModels.Admin
{
    public class MenuList_M
    {
        public static MenuList_M ToViewModel(List<menu> fathers)
        {
            return new MenuList_M() { fathers = fathers };
        }
        public List<menu> fathers;
    }
}
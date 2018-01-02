using qx.permmision.v2.Entity;

namespace Web.Areas.Permission.ViewModels.Admin
{
    public class RoleMenuList_M
    {
        public static RoleMenuList_M ToViewModel(role role)
        {
            return new RoleMenuList_M() { role = role };
        }
        public role role;
    }
}
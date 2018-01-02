using qx.permmision.v2.Entity;
namespace Web.Areas.Permission.ViewModels.Admin
{
    public class BanButtonList_M
    {
        public static BanButtonList_M ToViewModel(role role)
        {
            return new BanButtonList_M() { role = role };
        }
        public role role;
    }
}
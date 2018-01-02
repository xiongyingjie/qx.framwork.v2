namespace Web.Areas.Permission.ViewModels.Admin
{
    public class RoleList_M
    {
        public static RoleList_M ToViewModel(string roleid)
        {
            return new RoleList_M() { roleid = roleid };
        }
        public string roleid;
    }
}
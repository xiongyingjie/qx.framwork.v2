using Qx.Permission.Entity;

namespace Web.Areas.Permission.ViewModels.Admin
{
    public class UserRoleList_M
    {
        public static UserRoleList_M ToViewModel(permission_user user)
        {
            return new UserRoleList_M() {user=user };
        }
        public permission_user user;
    }
}
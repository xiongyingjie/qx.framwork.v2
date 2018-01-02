namespace Web.Areas.Permission.ViewModels.Admin
{
    public class UserList_M
    {
        public static UserList_M ToViewModel(string userid)
        {
            return new UserList_M() { userid = userid };
        }
        public string userid;
    }
}
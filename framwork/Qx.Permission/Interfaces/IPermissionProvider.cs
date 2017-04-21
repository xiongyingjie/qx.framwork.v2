using System.Collections.Generic;
using Qx.Permission.Entity;
using Qx.Permission.Models;

namespace Qx.Permission.Interfaces
{
    public interface IPermissionProvider
    {
        List<MenuItem> GetMenuByUserId(string userId);
        List<button> GetForbidenButtonByUserId(string userId);
        IEnumerable<Navbar> GetNavbarByUserId(string userId);
        List<menu> FindFather(string menuid);
        bool Login(string userId, string userPwd);

        bool Regist(string userId, string userPwd, 
            string nickName,string email="",string phone="", string userTypeId="0");

        permission_user UserInfo(string userId);
        bool UpdateUser(string userId, string nickName, string userPwd = "", string email = "", string phone = "", string note = "");
        bool DeleteUser(string userid);
    }
}
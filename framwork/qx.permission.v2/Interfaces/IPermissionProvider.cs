using System.Collections.Generic;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Models;
using Qx.Tools.Interfaces;

namespace qx.permmision.v2.Interfaces
{
    public interface IPermissionProvider : IAutoInject
    {
        IPermmisionService Services();
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
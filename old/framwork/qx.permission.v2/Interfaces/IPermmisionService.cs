using System.Collections.Generic;
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Models;
using Qx.Tools.Interfaces;
using Qx.Tools.Models.Report;

namespace qx.permmision.v2.Interfaces
{
    public interface IPermmisionService : IAutoInject
    {
        List<orgnization> GetOrgIdByUserId(string userId, bool includeSub = true);
        //获取待办的数据角色
        List<DataFilter> GetFilterByUserId(string userId);
        List<DataFilter> GetFilterByUserId(string userId, string reportId);
        List<MenuItem>  GetMenuByUserId(string userId);
        List<button> GetForbidenButtonByUserId(string userId);
        List<SelectListItem> GetMenu(string selectedMenuId = "-1", string rootFather = "MRoot");

        IEnumerable<Navbar> GetNavbarByUserId(string userId);
        List<menu> FindFather(string menuid);

        /// <summary>
        /// 更新用户组
        /// </summary>
        /// <param name="model">UserGroup</param>
        /// <returns>true or false</returns>
        bool UpdateUserGroup(UserGroup model);
       //删除用户组
        bool DeleteUserGroup(string id);
        //查找用户组
        UserGroup FindUserGroup(string id);      

        /// <summary>
        /// 更新角色组
        /// </summary>
        /// <param name="model">RoleGroup</param>
        /// <returns>true or false</returns>
        bool UpdateRoleGroup(RoleGroup model);
        //删除角色组
        bool DeleteRoleGroup(string id);
        //查找角色组
        RoleGroup FindRoleGroup(string id);
       
        /// <summary>
        /// 更新角色组成员
        /// </summary>
        /// <param name="model">RoleGroupRelation</param>
        /// <returns>true or false</returns>
        bool UpdateRoleGroupRelation(RoleGroupRelation model);
        //删除角色组成员
        bool DeleteRoleGroupRelation(string id);
        //查找角色组成员
        RoleGroupRelation FindRoleGroupRelation(string id);

        /// <summary>
        /// 更新用户组成员
        /// </summary>
        /// <param name="model">UserGroupRelation</param>
        /// <returns>true or false</returns>
        bool UpdateUserGroupRelation(UserGroupRelation model);
        //删除用户组成员
        bool DeleteUserGroupRelation(string id);
        //查找角色组成员
        UserGroupRelation FindUserGroupRelation(string id);

    }
}
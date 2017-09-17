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
        //��ȡ��������ݽ�ɫ
        List<DataFilter> GetFilterByUserId(string userId);
        List<DataFilter> GetFilterByUserId(string userId, string reportId);
        List<MenuItem>  GetMenuByUserId(string userId);
        List<button> GetForbidenButtonByUserId(string userId);
        List<SelectListItem> GetMenu(string selectedMenuId = "-1", string rootFather = "MRoot");

        IEnumerable<Navbar> GetNavbarByUserId(string userId);
        List<menu> FindFather(string menuid);

        /// <summary>
        /// �����û���
        /// </summary>
        /// <param name="model">UserGroup</param>
        /// <returns>true or false</returns>
        bool UpdateUserGroup(UserGroup model);
       //ɾ���û���
        bool DeleteUserGroup(string id);
        //�����û���
        UserGroup FindUserGroup(string id);      

        /// <summary>
        /// ���½�ɫ��
        /// </summary>
        /// <param name="model">RoleGroup</param>
        /// <returns>true or false</returns>
        bool UpdateRoleGroup(RoleGroup model);
        //ɾ����ɫ��
        bool DeleteRoleGroup(string id);
        //���ҽ�ɫ��
        RoleGroup FindRoleGroup(string id);
       
        /// <summary>
        /// ���½�ɫ���Ա
        /// </summary>
        /// <param name="model">RoleGroupRelation</param>
        /// <returns>true or false</returns>
        bool UpdateRoleGroupRelation(RoleGroupRelation model);
        //ɾ����ɫ���Ա
        bool DeleteRoleGroupRelation(string id);
        //���ҽ�ɫ���Ա
        RoleGroupRelation FindRoleGroupRelation(string id);

        /// <summary>
        /// �����û����Ա
        /// </summary>
        /// <param name="model">UserGroupRelation</param>
        /// <returns>true or false</returns>
        bool UpdateUserGroupRelation(UserGroupRelation model);
        //ɾ���û����Ա
        bool DeleteUserGroupRelation(string id);
        //���ҽ�ɫ���Ա
        UserGroupRelation FindUserGroupRelation(string id);

    }
}
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Models;
using xyj.core.Models.Report;

namespace xyj.acs.Interfaces
{
    public interface IAcsService
    {
        List<orgnization> GetOrgIdByUserId(string userId, bool includeSub = true);
        //获取待办的数据角色
        List<DataFilter> GetFilterByUserId(string userId);
        List<DataFilter> GetFilterByUserId(string userId, string reportId);
        List<MenuItem>  GetMenuByUserId(string userId);
        List<button> GetForbidenButtonByUserId(string userId);
       // List<DropDownListItem> GetMenu(string selectedMenuId = "-1", string rootFather = "MRoot");

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
   

        //�û���¼
        bool Login(string userId, string userPwd);
        //�û�ע��
        bool Regist(string userId, string userPwd,
            string nickName = "", string email = "", string phone = "", string userTypeId = "", string note = "",
            List<string> roleList = null, string subSys = "");

         bool SetSubSystemData(string subSystemId, string dataKey, string dataValue);

        sub_system_data GetSubSystemData(string subSystemId, string dataKey = "");
        //ͨ���û�id��ȡ�û�������Ϣ
        permission_user UserInfo(string userId);
        //ͨ���û�id���û��������û������ܶ�����
        List<permission_user> FindUsers(List<string> userIdOrUserNameArray);
        //�����û���Ϣ
        bool UpdateUser(string userId, string nickName, string userPwd = "", string email = "", string phone = "", string note = "");
        //ɾ���û�
        bool DeleteUser(string userid);
        //��ӻ���
        bool AddOrgnization(string father_id, string name, string orgnization_type_id, string orgnization_id = "");
        //ͨ���û�id��ȡ��ȡ���ڻ���
        orgnization FindOrgnizationByUserId(string userid);
        //ͨ������id��ȡ��û����й����Ļ���
        List<orgnization> FindRelationByOrgnizationId(string orgnization_id);
        //ͨ���û�id��ȡ�û�ְλ
        position FindPositionByUserId(string userid);
        //��ȡһ�������µ�����ְλ
        List<position> FindPositionsByOgnizationId(string orgnization_id);
        //�û����ŵ�����
        string AddUserToOrgnization(string user_id, string orgnization_id);
        //���ְλ
        bool AddPosition(string position_id, string position_type_id, string name, string descripe = "", string note = "");
        //�������ְλ
        bool AddPositionToOgnization(string orgnization_id, string position_id);
        //Ϊ�û���ӽ�ɫ
        bool AddRoleToUser(string user_id, string role_id);
        //Ϊ�û�����ְλ
        bool AddPositionToUser(string orgnization_position_id, string user_id);

    }
}
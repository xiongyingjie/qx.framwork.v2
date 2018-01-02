using System;
using System.Collections.Generic;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Models;
using Qx.Tools.Interfaces;

namespace qx.permmision.v2.Interfaces
{
    public interface IPermissionProvider : IAutoInject
    {
        IPermmisionService Services();
        //通过用户id获取用户菜单
        List<MenuItem> GetMenuByUserId(string userId);
        //通过用户用户id获取禁止按钮
        List<button> GetForbidenButtonByUserId(string userId);
        IEnumerable<Navbar> GetNavbarByUserId(string userId);
        //找到该菜单的父级菜单
        List<menu> FindFather(string menuid);
        //用户登录
        bool Login(string userId, string userPwd);
        //用户注册
        bool Regist(string userId, string userPwd,  string nickName,string email="",string phone="", string userTypeId="0");
        //通过用户id获取用户基本信息
        permission_user UserInfo(string userId);
        //通过用户id或用户名查找用户（可能多条）
        List<permission_user> FindUsers(List<string> userIdOrUserNameArray);
        //更新用户信息
        bool UpdateUser(string userId, string nickName, string userPwd = "", string email = "", string phone = "", string note = "");
        //删除用户
        bool DeleteUser(string userid);
        //添加机构
        bool AddOrgnization(string father_id, string name, string orgnization_type_id, string orgnization_id="");
        //通过用户id获取获取所在机构
        orgnization FindOrgnizationByUserId(string userid);
        //通过机构id获取与该机构有关联的机构
        List<orgnization> FindRelationByOrgnizationId(string orgnization_id);
        //通过用户id获取用户职位
        position FindPositionByUserId(string userid);
        //获取一个机构下的所有职位
        List<position> FindPositionsByOgnizationId(string orgnization_id);
        //用户安排到机构
        string AddUserToOrgnization(string user_id, string orgnization_id);
        //添加职位
        bool AddPosition(string position_id,string position_type_id, string name,string descripe="",string note="");
        //机构添加职位
        bool AddPositionToOgnization( string orgnization_id, string position_id);
        //为用户添加角色
        bool AddRoleToUser(string user_id,string role_id);
        //为用户安排职位
        bool AddPositionToUser(string orgnization_position_id,string user_id);

    }
}
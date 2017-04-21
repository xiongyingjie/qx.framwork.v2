using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Web.Mvc;
using Qx.Permission.Entity;
using Qx.Permission.Interfaces;
using Qx.Permission.Models;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Exceptions;

namespace Qx.Permission.Services
{
    public class PermissionProvider : BaseRepository, IPermissionProvider
    {
        private readonly IPermission _permission;

        #region ��ת
                public PermissionProvider(IPermission permission)
                {
                    _permission = new PermissionServices();
                }

                public List<MenuItem> GetMenuByUserId(string userId)
                {
                    return _permission.GetMenuByUserId(userId);
                }

                public List<button> GetForbidenButtonByUserId(string userId)
                {
                    return _permission.GetForbidenButtonByUserId(userId);
                }

                public IEnumerable<Navbar> GetNavbarByUserId(string userId)
                {
                    return _permission.GetNavbarByUserId(userId);
                }

                public List<menu> FindFather(string menuid)
                {
                    return _permission.FindFather(menuid);
                }
        #endregion

        public bool Login(string userId, string userPwd)
        {
            userPwd = NoneEncrypt(userPwd);
            return Db.permission_user.Any(a => a.UserID == userId &&
                                a.UserPwd ==userPwd 
                );
        }

        public bool Regist(string userId, string userPwd, 
            string nickName,string email="none",string phone="none", string userTypeId="0")
        {

            if(!(userId.HasValue()&& userPwd.HasValue()&& nickName.HasValue()))
            {
                throw new ParamNotEnoughException(
                    "userId=>"+ userId+"\r\n"+
                    "userPwd=>" + userPwd + "\r\n" +
                    "nickName=>" + nickName + "\r\n" 
                    );
            }

            if (Db.permission_user.Any(a => a.UserID == userId))
                return false;

            //����û�
            Db.permission_user.Add(new permission_user()
            {
                UserID = userId,
                UserPwd =NoneEncrypt(userPwd) ,
                NickName = nickName,
                UserTypeId = userTypeId,
                Email = email,
                Phone = phone,
                RegisterDate = DateTime.Now,
                LastLoginDate = DateTime.Now,
            });
            //Ѱ��Ĭ�Ͻ�ɫ
             Db.role.Where(a=>a.IsDefault==1).
                 ToList().ForEach(b =>
                 {
                      //���Ĭ�Ͻ�ɫ
                     Db.user_role.Add(new user_role()
                     {
                         UserID = userId,
                         RoleID = b.RoleID,
                         Note = "���û�ע���Զ����Ĭ�Ͻ�ɫ[" + b.Name + "];��Ч��Ϊ����",
                         ExpireTime = DateTime.MaxValue,
                         UserRoleID = userId + "-" + b.RoleID
                     });
                 });
           
            return Db.SaveChanges() > 0;
        }

        public permission_user UserInfo(string userId)
        {
            var result= Db.permission_user.Where(a => a.UserID == userId);
            if (result.Count() > 1)
            {
                throw new Exception("�ҵ�"+ result.Count()+"��UserIDΪ" + userId + @"���û����볢��ִ��SELECT  [UserID]
                                                                                                              ,[NickName]
                                                                                                              ,[UserPwd]
                                                                                                              ,[Email]
                                                                                                              ,[Phone]
                                                                                                              ,[UserTypeId]
                                                                                                              ,[Note]
                                                                                                              ,[RegisterDate]
                                                                                                              ,[LastLoginDate]
                                                                                                          FROM[permission_user]
                                                                                                        where[UserID] = '" + userId+ "'���qx.permission.permission_user���е�����");
            }
            if (result.FirstOrDefault()==null)
            {
                throw new Exception("δ�ҵ�UserIDΪ" + userId + @"���û����볢��ִ��SELECT  [UserID]
                                                                                          ,[NickName]
                                                                                          ,[UserPwd]
                                                                                          ,[Email]
                                                                                          ,[Phone]
                                                                                          ,[UserTypeId]
                                                                                          ,[Note]
                                                                                          ,[RegisterDate]
                                                                                          ,[LastLoginDate]
                                                                                      FROM [permission_user]
                                                                                    where [UserID]='" + userId+ "'���qx.permission.permission_user���е�����");
            }
            return result.FirstOrDefault();
        }

        public bool UpdateUser(string userId, string nickName, string userPwd="", string email="", string phone = "", string note = "")
        {
            var old = UserInfo(userId);
           
            old.NickName = nickName;
            if(userPwd.HasValue())
            {
                old.UserPwd = NoneEncrypt(userPwd);
            }
            if (email.HasValue())
            {
                old.Email = email;
            }
            if (phone.HasValue())
            {
                old.Phone = phone;
            }
            if (note.HasValue())
            {
                old.Note = note;
            }
            Db.Entry(old).State = EntityState.Modified;
            return Db.SaveChanges() > 0;
        }
        public bool DeleteUser(string userid)
        {
            var user = Db.permission_user.Find(userid);  
            Db.Entry(user).State = EntityState.Deleted;
            return Db.SaveChanges() > 0;
        }
    }
}
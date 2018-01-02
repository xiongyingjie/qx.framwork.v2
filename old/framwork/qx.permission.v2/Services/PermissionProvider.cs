using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Exceptions;
using qx.permmision.v2.Interfaces;
using qx.permmision.v2.Models;
using Qx.Tools.CommonExtendMethods;

namespace qx.permmision.v2.Services
{
    public class PermissionProvider : BaseRepository, IPermissionProvider
    {
        private readonly IPermmisionService _permission;

        #region 中转
                public PermissionProvider(IPermmisionService permission)
                {
                    _permission = new PermissionServices();
                }
        public IPermmisionService Services()
        {
            return _permission;
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
            return Db.permission_user.Any(a => a.user_id == userId &&
                                a.user_pwd ==userPwd 
                );
        }
        public List<permission_user> FindUsers(List<string> userIdOrUserNameArray)
        {
            return Db.permission_user.Where(a => userIdOrUserNameArray.Contains(a.user_id)||
                               userIdOrUserNameArray.Contains(a.nick_name)
                ).ToList();
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

            //添加用户
            Db.permission_user.AddOrUpdate(new permission_user()
            {
                user_id = userId,
                user_pwd = NoneEncrypt(userPwd) ,
                nick_name = nickName,
                user_type_id = userTypeId,
                email = email,
                phone = phone,
                register_date = DateTime.Now,
                last_login_date = DateTime.Now,
            });
            //分配默认组织机构
            #region 组织机构数据完整性检测
            var orgId = "deafalt";
            var orgLevelId = "0";
            var orgTypeId = "deafalt";
            if (Db.organization_level.Find(orgLevelId) == null)
            {
                Db.organization_level.AddOrUpdate(new organization_level()
                {
                    organization_level_id = orgLevelId,
                    name = "根组织（虚拟）",
                    note = "由PermissionProvider.Regist于" + DateTime.Now + "自动创建"
                });
            }
            if (Db.orgnization_type.Find(orgTypeId) == null)
            {
                Db.orgnization_type.AddOrUpdate(new orgnization_type()
                {
                    orgnization_type_id = orgTypeId,
                    name = "默认",
                    note = "由PermissionProvider.Regist于"+DateTime.Now+"自动创建"
                });
            }
            if (Db.orgnization.Find(orgId)==null)
            {
                Db.orgnization.AddOrUpdate(new orgnization()
                {
                    orgnization_id = orgId,
                    descripe = "系统自动注册的用户均放在该节点下",
                    father_id = "Root",
                    name = "会员",
                    note = "由PermissionProvider.Regist于" + DateTime.Now + "自动创建",
                    organization_level_id = orgLevelId,
                    orgnization_type_id = orgTypeId
                });
            }
            #endregion
            Db.user_orgnization.AddOrUpdate(new user_orgnization()
            {
                user_orgnization_id = userId+"-"+ orgId,
                user_id = userId,
                orgnization_id = orgId
            });
            #region 角色完整性检测
            var roleId = "deafalt";
            if (Db.role.Find(roleId) == null)
            {
                Db.role.AddOrUpdate(new role()
                {
                    role_id = roleId,
                    name = "默认角色",
                    is_default = 1,
                    sub_system = "system",
                    role_type = "系统默认角色" 
                });
            }
            #endregion
            //分配默认角色
            Db.role.Where(a => a.is_default == 1).
                ToList().ForEach(b =>
                {
                    //添加默认角色
                    Db.user_role.AddOrUpdate(new user_role()
                    {
                        user_id = userId,
                        role_id = b.role_id,
                        note = "新用户注册自动添加默认角色[" + b.name + "];有效期为永久",
                        expire_time = DateTime.MaxValue,
                        user_role_id = userId + "-" + b.role_id
                    });
                });
            Db.SaveChanges();
            return true;
        }

        public permission_user UserInfo(string userId)
        {
            var result= Db.permission_user.Where(a => a.user_id == userId);
            if (result.Count() > 1)
            {
                throw new Exception("找到"+ result.Count()+"个UserID为" + userId + @"的用户");
            }
            if (result.FirstOrDefault()==null)
            {
                throw new Exception("未找到UserID为" + userId + @"的用户");
            }
            return result.FirstOrDefault();
        }

        public bool UpdateUser(string userId, string nickName, string userPwd="", string email="", string phone = "", string note = "")
        {
            var old = UserInfo(userId);
           
            old.nick_name = nickName;
            if(userPwd.HasValue())
            {
                old.user_pwd = NoneEncrypt(userPwd);
            }
            if (email.HasValue())
            {
                old.email = email;
            }
            if (phone.HasValue())
            {
                old.phone = phone;
            }
            if (note.HasValue())
            {
                old.note = note;
            }
            Db.Entry(old).State = EntityState.Modified;
            return Db.SaveChanges() > 0;
        }
        public bool DeleteUser(string userid)
        {
            var user = Db.permission_user.Find(userid);
            if (user != null)
            {
                Db.Entry(user).State = EntityState.Deleted;
                return Db.SaveChanges() > 0;
            }
            return true;

        }
        public bool AddOrgnization(string father_id, string name, string orgnization_type_id, string orgnization_id ="")
        {
            orgnization_id = orgnization_id.CheckValue(Pk);
            if (orgnization_id.HasValue() && father_id.HasValue() && name.HasValue() && orgnization_type_id.HasValue())
            {
                Db.orgnization.AddOrUpdate(new orgnization()
                {
                    orgnization_id= orgnization_id,
                    father_id= father_id,
                    name= name,
                    orgnization_type_id= orgnization_type_id,
                });
               return Db.SaveChanges() > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }

        public orgnization FindOrgnizationByUserId(string userid)
        {
            var data = Db.user_orgnization.FirstOrDefault(o => o.user_id == userid);
            return Db.orgnization.FirstOrDefault(o => o.orgnization_id == data.orgnization_id);
        }

        public bool AddUser(string userId, string userPwd, string nickName, string userTypeId, string email = "none", string phone = "none")
        {
            var data= new permission_user();
            data.user_id = userId;
            data.user_pwd = userPwd;
            data.nick_name = nickName;
            data.user_type_id = userTypeId;
            data.email = email;
            data.phone = phone;
            Db.permission_user.AddOrUpdate(data);
            return Db.SaveChanges() > 0 ? true : false;
        }

        public List<orgnization> FindRelationByOrgnizationId(string orgnization_id)
        {
            var relation_orgnization=new List<orgnization>();
            var items = Db.organization_relation.Where(a => a.orgnization_id == orgnization_id).ToList();
            foreach (var item in items)
            {
                var data = Db.orgnization.FirstOrDefault(o=>o.orgnization_id==item.other_orgnization_id);
                relation_orgnization.Add(data);
            }
            return relation_orgnization;
        }

        public position FindPositionByUserId(string userid)
        {
            var data = Db.user_position.FirstOrDefault(o => o.user_id == userid);
            var data2 =Db.orgnization_position.FirstOrDefault(o => o.orgnization_position_id == data.orgnization_position_id);
            return Db.position.FirstOrDefault(o => o.position_id == data2.position_id);
        }

        public List<position> FindPositionsByOgnizationId(string orgnization_id)
        {
            var datas=new List<position>();
            var items = Db.orgnization_position.Where(o => o.orgnization_id == orgnization_id).ToList();
            foreach (var item in items)
            {
                var data = Db.position.FirstOrDefault(o => o.position_id == item.position_id);
                datas.Add(data);
            }
            return datas;
        }

        public string AddUserToOrgnization(string user_id, string orgnization_id)
        {
            string user_orgnization_id = orgnization_id + "-" + user_id;
            Db.user_orgnization.Add(new user_orgnization()
            {
                user_orgnization_id = user_orgnization_id,
                user_id = user_id,
                orgnization_id = orgnization_id
            });
            return Db.SaveChanges() > 0 ? user_orgnization_id : "";
        }

       public bool AddPosition(string position_id, string position_type_id, string name, string descripe = "none",
            string note = "none")
        {
            Db.position.Add(new position()
            {
                position_id = position_id,
                position_type_id = position_type_id,
                name = name,
                descripe= descripe,
                note= note
            });
            return Db.SaveChanges() > 0 ? true : false;
        }

        public bool AddPositionToOgnization( string orgnization_id, string position_id)
        {
            string orgnization_position_id = orgnization_id + "-" + position_id;
            Db.orgnization_position.Add(new orgnization_position()
            {
                orgnization_position_id = orgnization_position_id,
                position_id = position_id,
                orgnization_id = orgnization_id
            });
            return Db.SaveChanges() > 0 ? true : false;
        }

        public bool AddRoleToUser(string user_id, string role_id)
        {
            string user_role_id = user_id + "-" + role_id;
            Db.user_role.Add(new user_role()
            {
                user_role_id = user_role_id,
                user_id = user_id,
                role_id = role_id
            });
            return Db.SaveChanges() > 0 ? true : false;
        }

        public bool AddPositionToUser(string orgnization_position_id, string user_id)
        {
            Db.user_position.Add(new user_position()
            {
                user_position_id = DateTime.Now.Random(),
                user_id = user_id,
                orgnization_position_id = orgnization_position_id
            });
            return Db.SaveChanges() > 0 ? true : false;
        }



    }
}
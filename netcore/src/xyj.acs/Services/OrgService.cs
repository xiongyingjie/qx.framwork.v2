using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using xyj.acs.Entity;
using xyj.acs.Interfaces;
using xyj.acs.Models;
using xyj.core.Extensions;
using xyj.core.Models.Report;

namespace xyj.acs.Services
{
    public class OrgService : BaseRepository, IOrgService
    {
      

        //导入职员
        public int ImportStaff(List<Staff> staffList, string orgnization_position_id)
        {
            //截取字符串
            int index = orgnization_position_id.IndexOf('!');
            var id = orgnization_position_id.Substring(0, index);

            int i = 0;//计数器
            foreach (var item in staffList)
            {
                //先判断该用户是否已经存在权限的用户表里面
                //不在用户表里面，就先将用户添加到用户表，再加入到user_position表
                //判断给用户是否在user_position表里面，如已经在，就不添加，否则添加
                var olduser =Db.permission_user.NoTrackingFind(o => o.user_id == item.工号);
                var olduserposition =
                    Db.user_position.NoTrackingFind(o => o.orgnization_position_id == id && o.user_id == item.工号);
                if (olduserposition == null)//当该用户不存在user_position表里面的时候再添加
                {
                    if (olduser == null)
                    {
                        Db.permission_user.Add(new permission_user()
                        {
                            user_id = item.工号,
                            nick_name = item.姓名,
                            user_pwd = NoneEncrypt(item.工号),//给密码加密
                            email = item.邮件,
                            phone = item.电话,
                            user_type_id = "0",
                            register_date = DateTime.Now,
                        });
                        Db.user_position.Add(new user_position()
                        {
                            user_position_id = DateTime.Now.Random(),
                            orgnization_position_id = id,
                            user_id = item.工号
                        });
                        i++;
                    }
                    else
                    {
                        Db.user_position.Add(new user_position()
                        {
                            user_position_id = DateTime.Now.Random(),
                            orgnization_position_id = id,
                            user_id = item.工号
                        });
                        i++;
                    }
                }
                continue; 
            }
          return  Db.SaveChanges()>0?i:0;
        }

        //查找该用户是否已经存在某一个具体的职位里面
        public bool FandUserIsExistOrgPosition(string uid, string orgnization_position_id)
        {
            return Db.user_position.NoTrackingFind(o => o.orgnization_position_id == orgnization_position_id&&o.user_id==uid) != null
               ? true
               : false;
        }

        //查找该组织机构的职位是否已经有具体的用户
        public bool FindOrgPositionIsRelationUser(string orgnization_position_id)
        {
            return Db.user_position.NoTrackingFind(o => o.orgnization_position_id == orgnization_position_id) != null
                ? true
                : false;
        }
        
        //查找该职位是否已经跟该组织机构有关联
        public bool FindPositionIsRelationOrg(string orgid, string position_id)
        {
            var data =
                Db.orgnization_position.NoTrackingFind(o => o.orgnization_id == orgid && o.position_id == position_id);
            return data != null ? true : false;
        }


        //查看该职位类型是否已经跟相关的职位有关联
        public bool FindPositionTypeIsRelation(string position_type_id)
        {
            var data = Db.position.NoTrackingFind(o => o.position_type_id == position_type_id);
            return data != null ? true : false;
        }

        //查看该组织机构级别是否已经跟相关的组织机构有关联
        public bool FindOrgLevelRelation(string organization_level_id)
        {
            var data = Db.orgnization.NoTrackingFind(o => o.organization_level_id == organization_level_id);
            return data != null ? true : false;
        }


        //查看该组织机构类型是否已经跟相关的组织机构有关联
        public bool FindOrgTypeIsRelation(string orgnization_type_id)
        {
            var data = Db.orgnization.NoTrackingFind(o => o.orgnization_type_id == orgnization_type_id);
            return data != null ? true : false;
        }

        public bool findOrgIsRelation(string OrgID)
        {
            var data = Db.orgnization.FirstOrDefault(o => o.father_id == OrgID);
            return data != null ? true : false;
        }

        public string [] SplitAllParams(string AllParams)
        {
            return AllParams.Split(';');
        }
        public bool CreateAssociation(string leaderId, string name, string associationId, string descripe)//创建社团
        {
            //一级社团组织机构id
            var stOrgId = "H23TLKUTRR";
            //社长岗位id
            var sz_id = "sz";
            // var org = Db.orgnization.FirstOrDefault(o => o.orgnization_id == stOrgId);//orgnization_id随机生成，已知name和OrgFatherID，通过OrgFatherID找到orgnization_type_id,organization_level_id(比父亲多一级)

            //加社团
            Db.orgnization.Add(new orgnization()
            {
                orgnization_id = associationId,
                father_id = stOrgId,
                name = name,
                descripe = descripe,
                orgnization_type_id = "12",
                note = "",
                sub_system = "",
                organization_level_id = "2",
            });
            //
            var orgnization_position_id = DateTime.Now.Random();
            Db.orgnization_position.Add(new orgnization_position()
            {
                orgnization_position_id = orgnization_position_id,
                orgnization_id = associationId,
                position_id = sz_id
            });
            //任职社长(默认申请者被任职为社长)
            Db.user_position.Add(new user_position()
            {
                user_position_id = DateTime.Now.Random(),
                orgnization_position_id = orgnization_position_id,
                user_id = leaderId
            });
            return Db.Saved();
        }
        public bool DeleteAssociation(string associationId)
        {
            var org = Db.orgnization.Find(associationId);
            Db.orgnization.Remove(org);
            return Db.Saved();
        }
        public bool UpdateAssociationLeader(string leaderId, string associationId)
        {
            var sz_id = "sz";
            var orgnization_position_id = Db.orgnization_position.Where(o => o.orgnization_id == associationId & o.position_id == sz_id).FirstOrDefault().orgnization_position_id;
            var user_position_id = Db.user_position.Where(o => o.orgnization_position_id == orgnization_position_id).FirstOrDefault().user_position_id;
            Db.user_position.Update(new user_position()
            {
                user_position_id = user_position_id,
                orgnization_position_id = orgnization_position_id,
                user_id = leaderId

            });
            return Db.Saved(); ;
        }
        public List<DropDownListItem> GetOrgItem(string user_id)
        {
            List<DropDownListItem> orgItem = new List<DropDownListItem>();
            var user_position = Db.user_position.Where(o => o.user_id == user_id);
            List<string> orgid = new List<string>();
            foreach (var item in user_position)
            {
                orgItem.Add(new DropDownListItem() {Text=Db.orgnization.Find(item.orgnization_position.orgnization_id).name, Value = item.orgnization_position.orgnization_id.Trim() });
            }
            return orgItem;
        }
        public List<string> GetOrgID(string user_id)//一个用户可能身兼多职，所以返回的OrgID可能有多个
        {
            List<string> list = new List<string>();
            var user_position = Db.user_position.Where(o => o.user_id == user_id);
            foreach (var item in user_position)
            {
                list.Add(Db.orgnization_position.Find(item.orgnization_position_id).orgnization_id);
            }
            return list;
        }
        //string leaderId, string name, string associationId, string descripe
        public bool RenZhi(string user_id, string associationId,string position_id)
        {
            var orgnization_position_id = DateTime.Now.Random();
            Db.orgnization_position.Add(new orgnization_position {
                orgnization_position_id = orgnization_position_id,
                orgnization_id =associationId,
                position_id=position_id,
            });
            Db.user_position.Add(new user_position() {
                user_position_id=DateTime.Now.Random(),
                orgnization_position_id= orgnization_position_id,
                user_id=user_id
            });
            return Db.Saved();
        }

        public List<Orgnization> getAllSubUnit(string orgnization_id)
        {
            throw new NotImplementedException();
        }

        //该组织机构的直属下属机构（列表）
        public List<Orgnization> getDirectSubUnit(string orgnization_id)
        {
            return Db.orgnization.Where(o => o.father_id == orgnization_id).Select(b=>new Orgnization()
            {
                orgnization_id = b.orgnization_id,
                father_id = b.father_id,
                orgnization_father_name = b.name,
                name = b.name,
                descripe = b.descripe,
                orgnization_type_id = b.orgnization_type_id,
                orgnization_type_name = b.orgnization_type.name,
                note = b.note,
                sub_system = b.sub_system,
                organization_level_id = b.organization_level_id,
                organization_level_name = b.organization_level.name
            }).ToList();
        }

        //该组织机构的详细信息
        public Orgnization getUnitInfo(string orgnization_id)
        {
            var data = Db.orgnization.FirstOrDefault(o => o.orgnization_id == orgnization_id);
            var fatherdata = Db.orgnization.FirstOrDefault(o => o.father_id == data.orgnization_id);
            return new Orgnization()
            {
                orgnization_id = data.orgnization_id,
                father_id = data.father_id,
                orgnization_father_name= fatherdata?.name,
                name = data.name,
                descripe = data.descripe,
                orgnization_type_id = data.orgnization_type_id,
                orgnization_type_name = data.orgnization_type.name,
                note = data.note,
                sub_system = data.sub_system,
                organization_level_id = data.organization_level_id,
                organization_level_name = data.organization_level.name
            };
        }
        //用户的职位列表
        public List<Position> getUserPosition(string uid)
        {
            return Db.user_position.Where(o => o.user_id == uid).Select(x => new Position()
            {
                orgnization_id=x.orgnization_position.orgnization_id,
                orgnization_name = x.orgnization_position.orgnization.name,
                position_id = x.orgnization_position.position.position_id,
                position_type_id = x.orgnization_position.position.position_type.position_type_id,
                position_type_name = x.orgnization_position.position.position_type.name,
                name = x.orgnization_position.position.name,
                descripe = x.orgnization_position.position.descripe,
                note = x.orgnization_position.position.note,
            }).ToList();
        }

        //该用户的组织机构
        public List<Orgnization> getUserOrg(string uid)
        {
            return Db.user_orgnization.Where(o => o.user_id == uid).Select(b => new Orgnization()
            {
                orgnization_id = b.orgnization_id,
                father_id = b.orgnization.father_id,
                orgnization_father_name = Db.orgnization.FirstOrDefault(o=>o.father_id==b.orgnization_id).name,
                name = b.orgnization.name,
                descripe = b.orgnization.descripe,
                orgnization_type_id = b.orgnization.orgnization_type_id,
                orgnization_type_name = b.orgnization.orgnization_type.name,
                note = b.orgnization.note,
                sub_system = b.orgnization.sub_system,
                organization_level_id = b.orgnization.organization_level_id,
                organization_level_name = b.orgnization.organization_level.name
            }).ToList();
        }

        //该组织机构下的所有用户
        public List<User> getUserByOrg(string orgid)
        {
            return Db.user_orgnization.Where(o => o.orgnization_id == orgid).Select(b => new User()
            {
                user_id = b.user_id,
                nick_name = b.permission_user.nick_name,
                user_pwd = b.permission_user.user_pwd,
                email = b.permission_user.email,
                phone = b.permission_user.phone,
                user_type_id = b.permission_user.user_type.user_type_id,
                note = b.permission_user.note,
                register_date = b.permission_user.register_date.Value,
                last_login_date = b.permission_user.last_login_date.Value
            }).ToList();
        }

        //该职位下的所有用户
        public List<User> getUserByPosition(string positionID)
        {
            return Db.user_position.Where(o=>o.user_position_id== positionID).Select(b=>new User()
             {
                user_id = b.user_id,
                nick_name = b.permission_user.nick_name,
                user_pwd = b.permission_user.user_pwd,
                email = b.permission_user.email,
                phone = b.permission_user.phone,
                user_type_id = b.permission_user.user_type.user_type_id,
                note = b.permission_user.note,
                register_date = b.permission_user.register_date.Value,
                last_login_date = b.permission_user.last_login_date.Value
            }).ToList();
        }
    }
}

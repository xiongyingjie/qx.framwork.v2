using System.Collections.Generic;
using System.Linq;
using Qx.Msg.Interfaces;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Qx.Msg.Entity;
using System;
using Qx.Tools.Interfaces;
using System.Data.Entity;
using Qx.Msg.Models;

namespace Qx.Msg.Services
{
    public class MsgService : BaseRepository, IMsgService
    {
        //private IRepository<msg_type> _msg_type;
        //private IRepository<msg_send_record> _msg_send_record;
        //public MsgService(IRepository<msg_type> msg_type, IRepository<msg_send_record>msg_send_record)
        //{
        //    _msg_type = msg_type;
        //    _msg_send_record =msg_send_record;
        //}
       public  bool AddContacter(string loginid, string membersId)
        {
            contact contact = new contact()
            {
                ContactID = loginid + membersId,
                OwnerID = loginid,
                MembersID= membersId
            };
            return Db.SaveAdd(contact);
        }
        public int GetGroupNum(string groupId)
        {
            return Db.group_member.Count(a => a.GroupID == groupId);
        }
        public List<List<string>> MyContacter(string loginid, string name)//我的联系人
        {
            var body = Db.contact.Where(a => a.OwnerID == loginid).Select(b => new List<string>()
                {
                   b.ContactID,
                   b.msg_user.UserName,
                 }).ToList();
            if (name == ";")
            {
                name = "";
            }
            body = body.Where(a => a[1].Contains(name)).ToList();
            return body;
        }
        public List<List<string>> MyGroup(string loginid, string groupname)//我的群组
        {
            var body = Db.msg_group.Where(a => a.OwnerID == loginid).Select(b => new List<string>()
                { 
                   b.GroupID,
                   b.GroupName,
                   b.CreatTime.ToString(),
                   b.crew_limite_type.CrewLimite.ToString(),
                   b.Remarks
                 }).ToList();
            if (groupname == ";")
            {
                groupname = "";
            }
            body = body.Where(a => a[1].Contains(groupname)).ToList();
            return body;
        }
        public List<List<string>> GroupDetails(string groupId, string groupname)//我的群组详情
        {
            var body = Db.group_member.Where(a => a.GroupID == groupId).Select(b => new List<string>()
                {
                   b.msg_group.GroupName,  
                   b.msg_user.UserName
                 }).ToList();
            if (groupname == ";")
            {
                groupname = "";
            }
            body = body.Where(a => a[1].Contains(groupname)).ToList();
            return body;
        }
        public List<Qx.Msg.Models.Msg> MyInBoxMsg(string loginId)//我的收件箱 
        {
            var body = Db.msg_send_record.Where(a => a.ReceiverID == loginId).Select(b => new Qx.Msg.Models.Msg()
                {
                MsgID=b.MsgID,
                Subjects= b.msg.Subjects,
                UserName= b.msg.msg_user.UserName,
                SendTime= b.SendTime == null ? "" : b.SendTime.Value.ToString(),//时间格式
                TypeName = b.msg.msg_type.TypeName,
                StateName= b.in_state.StateName,
                 }).ToList();
            return body;
        }
        public Models.Msg ReadMyInboxMsg(string userId,string msgId)//将消息标记为已读
        {

            var body = Db.msg_send_record.FirstOrDefault(a => a.MsgID == msgId && a.ReceiverID == userId);//找到一条记录
            Models.Msg msg = new Models.Msg()
            {
                MsgID = body.MsgID,
                Subjects = body.msg.Subjects,
                UserName = body.msg.msg_user.UserName,
                Contents = body.msg.Contents,
                SendTime = body.SendTime == null ? "" : body.SendTime.Value.ToString(),//时间格式
                TypeName = body.msg.msg_type.TypeName,
                StateName = body.in_state.StateName,
            };
            body.InStateID = "002";
            Db.Entry(body).State = EntityState.Modified;
            Db.SaveChanges();
            return msg;
            //var msgsendrecordId = Db.msg_send_record.Where(a => a.MsgID == msgId).Select(b=>b.MsgSendRecordID).ToString();
            //var msgsendrecord = _msg_send_record.Find(msgsendrecordId);
            //msgsendrecord.InStateID = "002";
            //Db.Entry(msgsendrecord).State = EntityState.Modified;
        }
        public List<List<string>> MyOutBoxMsg(string loginId, string subject)//我的发件箱 b.MsgID
        {
            var body = Db.msg_send_record.Where(a => a.msg.SenderID == loginId).Select(b => new List<string>()
            {
                b.MsgID,
                b.msg.Subjects,
                b.msg.msg_type.TypeName,
                b.msg_user.UserName,
                b.SendTime.ToString(),
                b.in_state.StateName
            }).ToList();
            if (subject == ";")
            {
                subject = "";
            }
            body = body.Where(a => a[1].Contains(subject)).ToList();
            return body;
        }
        public List<List<string>> MyCollectionBoxMsg(string loginId, string msgsubject)//我收藏的消息
        {
            var body = Db.msg_collection.Where(a => a.UserID == loginId).Select(b => new List<string>()
                {
                
                b.MsgID,
                b.msg.Subjects,
                b.msg.msg_user.UserName,
                b.msg_user.UserName,
                b.Time.ToString()
                 }).ToList();
            if (msgsubject == ";")
            {
                msgsubject = "";
            }
            body = body.Where(a => a[1].Contains(msgsubject)).ToList();
            return body;
        }
        public bool AddMsg(string Subjects,string Contents,string SenderID,string msgID, string MsgTypeID)
        {
            msg msg = new Entity.msg()
            {
                MsgID= msgID,
                MsgTypeID= MsgTypeID,             
                Subjects=Subjects,
                Contents= Contents,
                CreationTime=DateTime.Now,
                SenderID = SenderID
            };
            return Db.SaveAdd(msg);
        }//添加消息内容(消息存为草稿是只有内容名为没有发送记录)
        public bool AddSendRecord(string ReceiverID, string msgID)
        {
            msg_send_record record = new msg_send_record();
            var receiver = ReceiverID.UnPackString(';');
                foreach (var item in receiver)
            {
                record = new msg_send_record()
                {
                    MsgSendRecordID = msgID + item,
                    MsgID = msgID,
                    ReceiverID = item,
                    SendTime = DateTime.Now,               
                    OutStateID = "001",
                    ReadTime = null,
                    InStateID = "001",
                };
                Db.Entry(record).State = EntityState.Added;
            }
                
            return Db.SaveChanges() > 0;//将数据更改保存到数据库
        }//添加发送记录
        public bool SendMsg(string ReceiverID, string Subjects, string Contents, string SenderID)
        {
            string  MsgID = DateTime.Now.Random();
            string MsgTypeID;
            var receiver = ReceiverID.UnPackString(';');
            if (receiver.Count > 1)
            { MsgTypeID = "001"; }               
            else
            { MsgTypeID = "002"; }//通过收件人ID数量来判断消息是群发还是私信
            if (AddMsg(Subjects, Contents, SenderID, MsgID, MsgTypeID) &AddSendRecord(ReceiverID, MsgID))
                return true;
            else
                return false;
        }//发送消u息即需要消息内容和发送记录，分开写利于减小耦合  
        //public List<SelectListItem> GetMsgTypeSelectItems()
        //{
        //    return _msg_type.ToSelectItems();
        //}//获取消息类型
        public List<SelectListItem> GetMyContactsItems(string userId)
        {
            string value = "";
            var dest = Db.contact.Where(a => a.OwnerID == userId).Select(a => new SelectListItem()
            {
                Text =a.msg_user.UserName,
                Value =a.MembersID
            }
                                        ).ToList();
            return dest.Format(value);
        }//获取指定用户的联系人

    }
}

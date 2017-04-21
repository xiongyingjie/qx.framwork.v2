


using Qx.Msg.Entity;
using Qx.Msg.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Sms.Model.V20160927;
using Qx.Msg.Configs;
using Qx.Msg.Exceptions;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using sms_send_record = Qx.Msg.Entity.sms_send_record;

namespace Qx.Msg.Services
{
    public class MsgProvider :BaseRepository,IMsgProvider
    {
        private IRepository<contact> _contact;
        private IRepository<group_member> _groupmember;
        private IRepository<msg_group> _group;
        private IRepository<msg_collection> _msgcollection;
        private IRepository<Entity.msg> _msg;
        private IRepository<crew_limite_type> _crewlimitetype;
        public MsgProvider(IRepository<contact> contact, 
            IRepository<group_member> groupmember,
             IRepository<msg_group> group,
              IRepository<msg_collection> msgcollection,
            IRepository<Entity.msg>msg,
            IRepository<crew_limite_type>crewlimitetype
            )
        {
            _contact = contact;
            _groupmember = groupmember;
            _group = group;
            _msgcollection =msgcollection;
            _msg = msg;
            _crewlimitetype = crewlimitetype;
        }

        public IRepository<contact> ContactRepository
        {
            get
            {
                return _contact;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public IRepository<group_member> GroupMemberRepository
        {
            get
            {
                return _groupmember;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public IRepository<msg_group> GroupRepository
        {
            get
            {
                return _group;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public IRepository<msg_collection> MsgCollectionRepository
        {
            get
            {
                return _msgcollection;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public IRepository<Qx.Msg.Entity.msg> MsgRepository
        {
            get
            {
                return _msg;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public IRepository<Qx.Msg.Entity.crew_limite_type> CrewLimiteTypeRepository
        {
            get
            {
                return _crewlimitetype;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        //IRepository<Contact> IMsgProvider.GroupMemberRepository
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public bool ContactAdd(string memberid,string OnwerID)
        {
            contact contact = new contact()
            {
                ContactID = DateTime.Now.Random(),
                MembersID = memberid,
                OwnerID = OnwerID
            };
            return Db.SaveAdd(contact);
        }
        public List<msg_send_record> UnReadMsg(string userid)
        {
            return Db.msg_send_record.Where(a => a.ReceiverID == userid).ToList();
        }
        public List<msg_send_record> InBox(string userid)
        {
            return Db.msg_send_record.Where(a => a.ReceiverID == userid).ToList(); 
        }
        public List<msg_send_record> OutBox(string userid)
        {
            return Db.msg_send_record.Where(a => a.msg.SenderID == userid).ToList();
        }
        public List<msg_send_record> Drafts(string userid)
        {
            return Db.msg_send_record.Where(a => a.msg.SenderID == userid).ToList();
        }
        public List<msg_send_record> TimerSendRecords(string userid)
        {
            return Db.msg_send_record.Where(a => a.msg.SenderID == userid).ToList();
        }
        public List<msg_send_record> TimerTask(string userid)
        {
            return Db.msg_send_record.Where(a => a.msg.SenderID == userid).ToList();
        }

        //phoneNumber 接收号码，多个号码可以逗号分隔
        sms_send_record IMsgProvider.SendSms(string phoneNumber, string receiverName,string sender="defult")
        {
            //请求结果
            var result = new sms_send_record() { SendTime = DateTime.Now, Sender = sender, CheckCount = 0, Verified = 0 };
            result.ExpiredTime = result.SendTime.AddMinutes(Setting.ExpireTimeSpan);

            if (!phoneNumber.HasValue() || !receiverName.HasValue()) { return result; }

            var code = DateTime.Now.Random().Substring(0, 6);
            result.Code = code;
            var paramString = "{\"name\":\"" + receiverName + "\",\"code\":\"" + code + "\"}";

            var profile = DefaultProfile.GetProfile(
                Setting.RegionId,
                Setting.AccessKeyId,
                Setting.Secret
               );
            var client = new DefaultAcsClient(profile);
            var request = new SingleSendSmsRequest();
            try
            {
                //管理控制台中配置的短信签名（状态必须是验证通过）
                request.SignName = Setting.SignName;
                result.SignName = request.SignName;
                //管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）
                request.TemplateCode = Setting.TemplateCode;
                result.TemplateCode = request.TemplateCode;
                //接收号码，多个号码可以逗号分隔
                request.RecNum = phoneNumber;
                result.PhoneNumber = request.RecNum;
                //短信模板中的变量；数字需要转换为字符串；个人用户每个变量长度必须小于15个字符。
                request.ParamString = paramString;
                result.ParamString = request.ParamString;
                var httpResponse = client.GetAcsResponse(request);
                var requestId = httpResponse.RequestId;
                result.RequestId = requestId;
            }
            catch (ServerException e)
            {
                result.ErrorMessage += (e.RequestId + "/ErrorMessage:" + e.ErrorMessage + "/Message:" + e.Message);
            }
            catch (ClientException e)
            {
                result.ErrorMessage += (e.RequestId + "/ErrorMessage:" + e.ErrorMessage + "/Message:" + e.Message);
            }
            Db.sms_send_record.Add(result);
            Db.SaveChanges();
            return result;
        }

        public sms_send_record FindSms(string requestId)
        {
            var old = Db.sms_send_record.Find(requestId);
            if (old == null) { throw new SmsSendRecordNotFoundException();}
            return old;
        }

        public bool CheckSms(string requestId,string code)
        {
            var result = false;
            var old= Db.sms_send_record.Find(requestId);
            if (old == null) { throw new SmsSendRecordNotFoundException(); }
            if (DateTime.Now >= old.ExpiredTime||old.Verified==1) { throw new CodeOutOfDateException(); }
            if (old.CheckCount>=Setting.ErrorCount) { throw new ErrorTimeMoreThan3Exception();}
            if (old.Code == code)
            {
                old.Verified = 1;
                result= true;
            }
            else
            {
                old.CheckCount++;
            } 
            Db.Entry(old).State = EntityState.Modified;
            Db.SaveChanges();
            return result;
        }
       
        public List<contact> MyContacter(string memberid)
        {
            return Db.contact.Where(a => a.OwnerID == memberid).ToList();
        }
           }
}

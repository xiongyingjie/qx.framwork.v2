
using Qx.Msg.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using Qx.Tools.Interfaces;

namespace Qx.Msg.Interfaces
{
    public interface IMsgService : IAutoInject
    {
        //List<SelectListItem> GetContactName(string OwnerID);
        int GetGroupNum(string groupId);        //获取一个群租里联系人个数
        List<List<string>> MyContacter(string loginid, string name);//获取制定用户的联系人
        bool AddContacter(string loginid, string membersId);//添加联系人
        List<List<string>> MyGroup(string loginid, string groupname);//获取指定用户的联系人
        List<List<string>> GroupDetails(string groupId, string groupname);//群组详情
        List<Qx.Msg.Models.Msg> MyInBoxMsg(string loginId);//我的收件箱 
        Models.Msg ReadMyInboxMsg(string userId, string msgId);//返回消息的具体情况，并且修改状态
        List<List<string>> MyOutBoxMsg(string loginId, string msgsubject);//我的发件箱
        List<List<string>> MyCollectionBoxMsg(string loginId, string subject);//收藏消息
        bool AddMsg(string Subjects, string Contents, string SenderID, string msgID, string MsgTypeID);//添加消息
        bool AddSendRecord(string ReceiverID,string msgID);//发送记录
        bool SendMsg(string ReceiverID, string Subjects, string Contents, string SenderID);//发送消息
        //List<SelectListItem> GetMsgTypeSelectItems();
        List<SelectListItem> GetMyContactsItems(string userId);//获取联系人
    }
}

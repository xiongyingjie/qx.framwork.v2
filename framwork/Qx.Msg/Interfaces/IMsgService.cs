
using Qx.Msg.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Qx.Msg.Interfaces
{
    public interface IMsgService
    {
        //List<SelectListItem> GetContactName(string OwnerID);
        int GetGroupNum(string groupId);        //-------联系人
        List<List<string>> MyContacter(string loginid, string name);
        bool AddContacter(string loginid, string membersId);
        List<List<string>> MyGroup(string loginid, string groupname);
        List<List<string>> GroupDetails(string groupId, string groupname);
        List<Qx.Msg.Models.Msg> MyInBoxMsg(string loginId);//我的收件箱 
        Models.Msg ReadMyInboxMsg(string userId, string msgId);//返回消息的具体情况，并且修改状态
        List<List<string>> MyOutBoxMsg(string loginId, string msgsubject);
        List<List<string>> MyCollectionBoxMsg(string loginId, string subject);
        bool AddMsg(string Subjects, string Contents, string SenderID, string msgID, string MsgTypeID);
        bool AddSendRecord(string ReceiverID,string msgID);
        bool SendMsg(string ReceiverID, string Subjects, string Contents, string SenderID);
        //List<SelectListItem> GetMsgTypeSelectItems();
        List<SelectListItem> GetMyContactsItems(string userId);
    }
}

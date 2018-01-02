using System.Collections.Generic;
using qx.wechat.Models;
using Qx.Tools.Interfaces;

namespace qx.wechat.Interfaces
{
    public interface IWechatServices:IAutoInject
    {
        string ApiHttpGet(string host, string url, Dictionary<string, string> param, string logFileName = "");
        string ApiHttpPost(string host, string url, Dictionary<string, string> param, string logFileName = "");
        string ApiJsonHttpPost(string host, string url, object param, string logFileName = "", string extraParam = null);
        string RefreshToken<T>() where T : new();

        
        bool SendTemplateMsg<T>(string toWho, string templateId, string title, string[] body, string note,
            string click_url) where T : new();
        bool SendTemplateMsg<T>(string toWho, string templateId, string click_url, object templateData) where T : new();
        SystemSetup GetSetup();
        string GetToken<T>() where T : new();
        string GetTicket<T>() where T : new();
        bool SaveToken<T>(string tokenId, int expireTime) where T : new();
        bool Log(string logString, bool hasError);
        string MsgHandle(string xmlBody);
        MsgTypeEnum ParseMsgType(string msgType);
        EventTypeEnum ParseEventType(string msgType);
    }

}

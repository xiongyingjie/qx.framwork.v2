using System.Collections.Generic;
using qx.wechat.Models;
using Qx.Tools.Interfaces;

namespace qx.wechat.Interfaces
{
    public interface IEntWechatServices: IAutoInject
    {
        string ApiHttpGet(string host, string url, Dictionary<string, object> param, string logFileName = "");
        string ApiHttpPost(string host, string url, Dictionary<string, object> param, string logFileName = "");
        string ApiJsonHttpPost(string host, string url, object param, string logFileName = "", string extraParam = null);
        string RefreshToken<T>() where T : new();

        bool Send_Card_Msg<T>(string touser, string url,
            string title, string description) where T : new();

        bool SendTemplateMsg(string toWho, string templateId, string click_url, object templateData);
        SystemSetup GetSetup();
        string GetToken<T>() where T : new();
        bool SaveToken<T>(string tokenId, int expireTime) where T : new();
        bool Log(string logString, bool hasError);
        string MsgHandle(string xmlBody);
        MsgTypeEnum ParseMsgType(string msgType);
        EventTypeEnum ParseEventType(string msgType);
    }
}
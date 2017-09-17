using System.Web.Mvc;
using qx.wechat.Models;
using Qx.Tools.Interfaces;

namespace qx.wechat.Interfaces
{
    public interface IEntWxAuthorize
    {
        bool Regist(EntUserInfoModel userInfo);
        bool CheckRegistInfo(string uid);
        void RollbackRegistInfo(string uid);
    }
    public interface IWxAuthorize 
    {
        bool Regist(UserInfoModel userInfo);
        bool CheckRegistInfo(string uid);
        void RollbackRegistInfo(string uid);
    }
}
using System.Web.Mvc;
using Qx.Wechat.Models;

namespace Qx.Wechat.Interfaces
{
    public interface IWxAuthorizeController
    {
        bool CheckRegistInfo(string uid);
        void RollbackRegistInfo(string uid);
        ActionResult Authorize(string return_url);
        ActionResult AuthorizeRouting(string mode, string return_url);
        ActionResult BaseAuthorize(string return_url);
        ActionResult FullAuthorize(string return_url);
        ActionResult return_notify(string code, string state);
        ActionResult UserInfo(AccessTokenModel m, string return_url);
        ActionResult BackToBLL(string uid, string return_url, string msg ,string uName);
    }
}
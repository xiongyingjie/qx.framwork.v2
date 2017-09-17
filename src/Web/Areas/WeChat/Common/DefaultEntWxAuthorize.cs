using System.Linq;
using qx.permmision.v2.Interfaces;
using qx.wechat.Interfaces;
using qx.wechat.Models;
using Qx.Account.Interfaces;
using Qx.Account.Models;

namespace Web.Areas.WeChat.Common
{
    public class DefaultEntWxAuthorize : IEntWxAuthorize
    {
        private readonly IPermissionProvider _permissionProvider;

        public DefaultEntWxAuthorize( IPermissionProvider permissionProvider)
        {
            _permissionProvider = permissionProvider;
        }

        

        public bool Regist(EntUserInfoModel result)
        {
            //1.创建账户
            if (_permissionProvider.Regist(result.userid, "12345", result.name,result.email,result.mobile))
            {
                 return true;
            }
            else
            {
                result.errmsg = "绑定失败，请重试！";
                return false;
            }
        }

        public bool CheckRegistInfo(string uid)
        {
            try
            {
                //检测注册信息是否完全   
                return _permissionProvider.UserInfo(uid) != null&& _permissionProvider.Services().GetOrgIdByUserId(uid).Any() ;
            }
            catch
            {
                return false;
            }
        }

        public void RollbackRegistInfo(string uid)
        {
            _permissionProvider.DeleteUser(uid);
         }
    }
}
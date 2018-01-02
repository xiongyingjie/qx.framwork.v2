using System.Linq;
using qx.permmision.v2.Interfaces;
using qx.wechat.Interfaces;
using qx.wechat.Models;
using Qx.Account.Interfaces;
using Qx.Account.Models;

namespace Web.Areas.WeChat.Common
{
    public class DefaultWxAuthorize: IWxAuthorize
    {
        private readonly IAccountPayService _accountPayService;
        private readonly IPermissionProvider _permissionProvider;

        public DefaultWxAuthorize(IAccountPayService accountPayService, IPermissionProvider permissionProvider)
        {
            _accountPayService = accountPayService;
            _permissionProvider = permissionProvider;
        }

        

        public bool Regist(UserInfoModel result)
        {
            //1.创建账户
            if (_permissionProvider.Regist(result.openid, "12345", result.nickname))
            {
                var account = _accountPayService.CreateAccount(result.openid, AccountTypeEnum.Personal);
                //5.同步账户
                _accountPayService.SyncAccount(account);
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
                return _permissionProvider.UserInfo(uid) != null&& _permissionProvider.Services().GetOrgIdByUserId(uid).Any() && _accountPayService.FindAccount(uid) != null;
            }
            catch
            {
                return false;
            }
        }

        public void RollbackRegistInfo(string uid)
        {
            _permissionProvider.DeleteUser(uid);
            _accountPayService.DeleteAccount(uid);
         }
    }
}
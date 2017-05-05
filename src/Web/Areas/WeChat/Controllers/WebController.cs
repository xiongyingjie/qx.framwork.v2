using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.WeChat.ViewModels.Web;
using Web.Controllers.Base;
using Qx.Tools.CommonExtendMethods;
using Web.Areas.WeChat.Models;
using RestSharp;
using Qx.Tools;
using qx.permmision.v2.Interfaces;
using System.Data.Entity.Validation;
using Qx.Account.Interfaces;
using Qx.Account.Models;
using Qx.Wechat.Interfaces;
using Qx.Wechat.Models;

namespace Web.Areas.WeChat.Controllers
{
    public class WebController : BaseWebWeChatController, IWxAuthorizeController
    {
        private IAccountPayService _accountPayService;
        private IPermissionProvider _permissionProvider;
  
        public WebController(IAccountPayService accountPayService, IPermissionProvider permissionProvider)
        {
           
            _accountPayService = accountPayService;
            _permissionProvider = permissionProvider;


        }
        // GET: WeChat/Web/return_notify

        //第一步：用户同意授权，获取code
        /*
         * 第一步：用户同意授权，获取code
        https://open.weixin.qq.com/connect/oauth2/authorize?
        appid=wx9b6ef741694db0bd
        &redirect_uri=http%3a%2f%2fwx.52xyj.cn%2fwechat%2fweb%2freturn_notify
        &response_type=code
        &scope=snsapi_userinfo
        &state=test
        #wechat_redirect
         */


        // GET: /WeChat/Web/Authorize
        //加载授权页面
        public ActionResult Authorize(string return_url)
        {
            if((return_url.HasValue()&&return_url.Contains("Authorize"))||
                !return_url.HasValue())
            {
                return_url = "/WeChat/BookTiketWeb/Main";
            }
            //默认基本授权
            return BaseAuthorize(return_url);
        }


        // GET: /WeChat/Web/AuthorizeRouting
        //授权页中转 snsapi_base    snsapi_userinfo
        public ActionResult AuthorizeRouting(string mode, string return_url)
        {
            var url = URL_AUTHORIZE +
               "?appid=" + APP_ID +
               "&redirect_uri=" + URL_RETURN_NOTIFY +
               "&response_type=code"+
               "&scope=" + mode+
               "&state="+ return_url;
            return View("Authorize", Authorize_M.Init(url));
        }

        // GET: /WeChat/Web/BaseAuthorize
        //加载授权页面(基本)
        public ActionResult BaseAuthorize(string return_url)
        {
            return AuthorizeRouting("snsapi_base", return_url);
        }
        // GET: /WeChat/Web/FullAuthorize
        //加载授权页面(完全)
        public ActionResult FullAuthorize(string return_url)
        {
            return AuthorizeRouting("snsapi_userinfo", return_url);
        }
        public ActionResult return_notify(string code, string state)
        {
            var return_url = state;

            var url = URL_ACCESS_TOKEN +
              "?appid=" + APP_ID +
              "&secret=" + APP_SECRET +
              "&code=" + code +
              "&grant_type=authorization_code";
            var m = HttpGet<AccessTokenModel>(url);
            //-----------------判断授权模式

            //手动授权
            if(m.scope== "snsapi_userinfo")
            {
                return UserInfo(m,return_url);
            }
            //自动授权
            else
            {
                try
                {
                    //如果该用户已经注册
                    var find = _permissionProvider.UserInfo(m.openid);  
                    //还应检测注册信息是否完全   
                    if (CheckRegistInfo(find.user_id))
                    {
                        return BackToBLL(find.user_id, return_url, m.errmsg, find.nick_name);
                    }
                    else
                    {
                        RollbackRegistInfo(find.user_id);
                        //重定向到手动授权
                        return FullAuthorize(return_url);
                    }
                }
                catch
                {
                    //如果该用户未注册，重定向到手动授权
                    return FullAuthorize(return_url);
                }
            }

        }
        public bool CheckRegistInfo(string uid)
        {
            //检测注册信息
            throw new NotImplementedException();
        }

        public void RollbackRegistInfo(string uid)
        {//回滚注册
            throw new NotImplementedException();
        }

        public ActionResult UserInfo( AccessTokenModel m, string return_url)
        {
            var url = URL_USERINFO +
              "?access_token=" + m.access_token +
              "&openid=" + m.openid +
              "&lang=zh_CN";
            var result = HttpGet<UserInfoModel>(url);
            if (!result.openid.HasValue())
            {
                throw new Exception("request fail to" + url + "\r\n"+
                    "AccessTokenModel=>" + m.Serialize() + "\r\n"+
                    "UserInfoModel=>" + result.Serialize() + "\r\n" 
                    );
            }

            //-----------------这里编写绑定逻辑

            try
            {
                //1.创建账户
                if (_permissionProvider.Regist(result.openid, "12345", result.nickname))
                {
                 

                    var account = _accountPayService.CreateAccount(m.openid, AccountTypeEnum.Personal);
                    //5.同步账户
                    _accountPayService.SyncAccount(account);
                    result.errmsg = "恭喜绑定成功！";
                    return BackToBLL(result.openid, return_url, m.errmsg, result.nickname);
                }
                else
                {
                    result.errmsg = "绑定失败，请重试！";
                    return Content(result.Serialize());
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(m.openid + "(openid) Regist Failed" + "\r\n" +
                    m.access_token + "(access_token)\r\n" +
                    ex.Message + "\r\n" +
                    ex.EntityValidationErrors.SelectMany(a => a.ValidationErrors.Select(b => b.ErrorMessage)).Aggregate((c, d) => c + "\r\n" + d) + "\r\n" +
                    ex.StackTrace);
            }
        }

        public ActionResult BackToBLL(string uid, string return_url, string msg ,string uName)
        {
            return Redirect("/Account/LoginOk?uid=" + uid + "&return_url=" + return_url + "&msg=" + msg + "&uName=" + uName);
        }
        
    }
}

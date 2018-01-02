using System;
using System.Web.Mvc;
using qx.permmision.v2.Interfaces;
using qx.wechat.Configs;
using qx.wechat.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Web.Areas.WeChat.Common;

namespace Web.Areas.WeChat.Controllers
{
    public class EntWebController : BaseEntWebWeChatController
    {

        private IPermissionProvider _permissionProvider;
        private IEntWechatServices _entWechatServices;

        public EntWebController(IPermissionProvider permissionProvider, IEntWechatServices entWechatServices)
        {
            _permissionProvider = permissionProvider;
            _entWechatServices = entWechatServices;
        }

        // GET: /WeChat/EntWeb/Authorize
        //加载授权页面
        public ActionResult Authorize(string return_url)
        {
            if ((return_url.HasValue() && return_url.Contains("Authorize")) ||
                !return_url.HasValue())
            {
                throw new Exception("return_url为空");
                //return_url = "/WeChat/BookTiketWeb/Main";
            }
            //默认基本授权
            return Redirect(EntAuthorizeHelper.Authorize<Setting.EntWxConfig.Contact>(return_url));
            //  return View(Authorize_M.Init(AuthorizeHelper.Authorize(return_url)));
        }

        // GET: /WeChat/EntWeb/return_notify
        //授权回调页面
        public ActionResult return_notify(string code, string state)
        {
            var temp = state.Split('=');
            var subSystem = temp[1];
            if (subSystem.Contains(";"))
            {
                subSystem= subSystem.Split(';')[0];
            }
            switch (subSystem)
            {
                case "shop":
                    {
                        return Redirect(EntAuthorizeHelper.Handle<Setting.EntWxConfig.Shop>(code, state, _entWechatServices.GetToken<Setting.EntWxConfig.Shop>(), new DefaultEntWxAuthorize(_permissionProvider)));

                    }
                default:
                    {
                        return Redirect(EntAuthorizeHelper.Handle<Setting.EntWxConfig.Contact>(code, state, _entWechatServices.GetToken<Setting.EntWxConfig.Contact>(), new DefaultEntWxAuthorize(_permissionProvider)));
                  
                    }
            }
        }
        //http://wx.52xyj.cn/wechat/web/return_notify_debug?returnUrl=http://localhost:3456/web/app/sports/framework-m/login-wx.html?subSystem=sports&openid=olzsX1c4_xcaVFaEp0KN8ST-qxGk
        public ActionResult return_notify_debug(string returnUrl, string openid)
        {
            return Redirect(GeRootUrl(EntAuthorizeHelper.HandleDebug<Setting.EntWxConfig.Contact>("snsapi_base", returnUrl, openid, new DefaultEntWxAuthorize(_permissionProvider))));

        }

        public ActionResult return_notify2()
        {
            string code = Request["code"];
            string state = Request["state2"];
            return Content("test ok =>state:" + state);
        }
    }
}

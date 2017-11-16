using System;
using System.Web.Mvc;
using qx.permmision.v2.Interfaces;
using Qx.Account.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Web.Areas.WeChat.Common;
using Web.Controllers.Base;

namespace Web.Areas.WeChat.Controllers
{
    public class WebController : BaseController
    {
        private IAccountPayService _accountPayService;
        private IPermissionProvider _permissionProvider;



        public WebController(IAccountPayService accountPayService, IPermissionProvider permissionProvider)
        {

            _accountPayService = accountPayService;
            _permissionProvider = permissionProvider;
        }
        // GET: /WeChat/Web/Authorize?app=metting
        //加载授权页面
        public ActionResult Authorize(string return_url,string app)
        {
            if (app == "metting")
            {
                return_url = "http://baidu.com?subsystem=" + app;
            }

            if ((return_url.HasValue() && return_url.Contains("Authorize")) ||
                !return_url.HasValue())
            {
                throw new Exception("return_url为空");
                //return_url = "/WeChat/BookTiketWeb/Main";
            }
            //默认基本授权
            return Redirect(AuthorizeHelper.Authorize<qx.wechat.Configs.Setting.WxConfig.QxSoft>(return_url));
            //  return View(Authorize_M.Init(AuthorizeHelper.Authorize(return_url)));
        }
        // GET: /WeChat/Web/return_notify
        //授权回调页面
        public ActionResult return_notify(string code, string state)
        {
            var temp = state.Split('=');
            var subSystem = temp[1];
            switch (subSystem)
            {
                //case "sports":
                //{
                //        return Redirect(AuthorizeHelper.Handle(code, state, new SportsWxAuthorize(_accountPayService, _permissionProvider, _sportsService)));

                //    }
                default:
                    {
                        var url = AuthorizeHelper.Handle<qx.wechat.Configs.Setting.WxConfig.QxSoft>(code, state,
                            new DefaultWxAuthorize(_accountPayService, _permissionProvider));
                        if (url.HasValue())
                        {
                            return Redirect(url);
                        }
                        else
                        {
                            return Content("参数错误");
                        }


                    }
            }
        }
        //http://wx.52xyj.cn/wechat/web/return_notify_debug?returnUrl=http://localhost:3456/web/app/sports/framework-m/login-wx.html?subSystem=sports&openid=olzsX1c4_xcaVFaEp0KN8ST-qxGk
        public ActionResult return_notify_debug(string returnUrl, string openid)
        {
            return Redirect(AuthorizeHelper.HandleDebug<qx.wechat.Configs.Setting.WxConfig.QxSoft>("snsapi_base", returnUrl, openid, new DefaultWxAuthorize(_accountPayService, _permissionProvider)));

        }
        //

    }
}

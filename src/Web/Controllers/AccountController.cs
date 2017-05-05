using System;
using System.Web.Mvc;
using qx.permmision.v2.Interfaces;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Ioc.Unity;
using Web.Controllers.Base;
using Web.ViewModels;
using System.Collections.Generic;
using Qx.Contents.Interfaces;
using System.Linq;
namespace Web.Controllers
{
    public class AccountController : BaseController
    {
        private IPermissionProvider _permissionProvider;
       // private IEmployeeOrg _employeeOrg;
        private IContents _contents;
        public AccountController(IContents contents, IPermissionProvider permissionProvider)
        {
            _contents = contents;
            _permissionProvider = permissionProvider;
          //  _employeeOrg = employeeOrg;
        }

        // GET: /Account/Login
        public ActionResult Index(string msg)
        {

            List<string> aaa = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                aaa.Add(DateTime.Now.Random());
            }
            if (!msg.HasValue())
            {
                return Redirect("/WeChat/Web/Authorize?return_url=" + ReturnUrl);
               // return RedirectToAction("Authorize","Web",new { area= "WeChat" });
            }
            return RedirectToAction("Index","F2");
            InitAdminLayout("");
            return View();
        }
        #region 登录
        public ActionResult Login(string UserID, string isMoblie)
        {
            if(UserID.HasValue())
            {
                return Login(new Login_M() { UserId = UserID });
            }

            InitLayout("");
            if (DataContext.UserID.HasValue())
            {
                return RedirectToAction("Index",new {msg="用户"+DataContext.UserID+"已登录，切换账号请先 退出登录"});
            }
            else
            {
                //默认值
                var appUrl = "/UserFiles/Contents/app.apk";
                var appPicUrl = "/Content/Acounnt/img/二维码1.png";
                var weiXinPicUrl = "/Content/Acounnt/img/二维码2.png";
                //try
                //{
                //    //最新值
                //    appUrl = _contents.GetTableValue("218781812-U74UZF82YQ", "APP").Columns.FirstOrDefault().Value?? appUrl;
                //    appPicUrl = _contents.GetTableValue("497968152-4AV5NQX59V", "AppQRCode").Columns.FirstOrDefault().Value ?? appPicUrl;
                //    weiXinPicUrl = _contents.GetTableValue("529907810-8ZZVLNYME5", "WeChatQRCode").Columns.FirstOrDefault().Value ?? weiXinPicUrl;
                //}
                //catch(Exception ex)
                //{
                //    ViewData["ex"] = ex.Message;
                //}
                return View(isMoblie.HasValue() ? "Login_Mobile" : "Login", new Login_M() {AppUrl= appUrl ,AppPicUrl= appPicUrl, WeiXinPicUrl= weiXinPicUrl });
            }

        }
       
       
        [HttpPost]
        public ActionResult Login(Login_M model)
        {
            
            model.UserId = F("UserId");
            model.UserPsw = F("UserPsw");

            if (ModelState.IsValid)
            {
               
               // if (_permissionProvider.Login(model.UserId, model.UserPsw))
                 if (_permissionProvider.UserInfo(model.UserId)!=null)
                {
                    return LoginOk(model.UserId,"");
                }
                else
                {
                    return Alert("用户名或密码错误！",-1);
                }
            }
            else
            {
                return View(model);
            }



        }

        // GET: /Account/LoginOk?uid=panda&return_url=http://52xyj.cn&msg=测试
        public ActionResult LoginOk(string uid,string return_url,string msg="",string uName="未设置")
        {
            var accountContext = new AccountContext();
            DataContext.UserID =
                accountContext.UserID = uid;
            DataContext.UserName =
             accountContext.UserName = uName;
            Session["AccountContext"] = accountContext;
            if(return_url.HasValue())
            {
                return Redirect(return_url);
            }
           else if (ReturnUrl.HasValue())
            {
                return Redirect(ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index", new { msg = "用户[" + uid + "]登录成功!" });
            }
        }
        #endregion
        public ActionResult LoginOut()
        {
            //退出登录前准备工作
            Session.Clear();
            if (Session["AccountContext"] != null)
            {
                Session.Remove("AccountContext");
            }
            return RedirectToAction("Login", new { msg = "退出登录成功!" });
        }
        public ActionResult Forget()
        {
            return Alert("请联系管理员重置密码",-1);
        }

        #region 注册
        public ActionResult Regist()
        {
         
             return View(new Regist_M());
        }

        [HttpPost]
        public ActionResult Regist(Regist_M model)
        {
            model.UserId = F("UserId");
            model.UserPsw = F("UserPsw"); model.UserPsw2 = F("UserPsw2");
            model.NickName = F("NickName");
            model.Phone = F("Phone");
            model.Email = F("Email");
          
            if(model.UserPsw!= model.UserPsw2|| 
                !model.UserPsw.HasValue()|| 
                !model.UserPsw2.HasValue())
                return Alert("两次密码不一致！",-1);

            if (!model.UserId.HasValue() ||
                !model.NickName.HasValue())
            {
                return Alert("注册信息不完整！", -1);
            }
              


            if (ModelState.IsValid)
            {
                if (_permissionProvider.Regist(model.UserId, model.UserPsw,
                    model.NickName,model.Email,model.Phone
                    ))
                {
                    var accountContext = new AccountContext();
                    DataContext.UserID =
                        accountContext.UserID = model.UserId;
                    DataContext.UserUnit = "1577668579";
                    Session["AccountContext"] = accountContext;
                    if (ReturnUrl.HasValue())
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", new { msg = "用户[" + model.UserId + "]登录成功!" });
                    }
                }
                else
                {
                    return Alert("注册失败！",-1);
                }
            }
            else
            {
                return View(model);
            }
            


        }
        #endregion
    }
}
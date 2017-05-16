using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;
using HtmlAgilityPack;
using qx.permmision.v2.Interfaces;
using Qx.Tools;
using Qx.Tools.QxClass;
using Web.ViewModels;


namespace Web.Controllers
{
    public class F2Controller : BaseController
    {
        private IPermissionProvider _permissionProvider;
        
        public F2Controller(IPermissionProvider permissionProvider)
        {
            _permissionProvider = permissionProvider;
        }

        // GET: F2
        // GET: /<controller>/
        //  /F2/Grap?dist_url=/emap/sys/panda/*default/index.do#/jgb
        public ActionResult Grap(string dist_url)
        {
            
            var html = "Failed To Connect To" + dist_url;
            //抓取页面
            if (dist_url.HasValue())
            {
                var author_host = "http://148u548o08.imwork.net:31796";
                var author_url = "/emap/sys/emapAuth/debug/login.do?back=%2Femap%2Fsys%2Fpanda%2F*default%2Findex.do";
                dist_url = "/emap/sys/panda/*default/index.do#/jgb";
                var client= new HttpClient(new Uri(author_host));
                client.CookieContainer = new System.Net.CookieContainer();
                //身份认证
                html = client.Post(author_url, new Dictionary<string, string>()
                {
                    {"userId","admin" },
                    {"role","" }
                });
                html = client.Get(dist_url);
                //ar doc = new HtmlDocument();
                //oc.LoadHtml(html);
                //ar nodes = doc.DocumentNode.ChildNodes.ToList();
            }
            V("html", html);
            return View();
        }
        public ActionResult blank()
        {
            return View();
        }
        public ActionResult buttons()
        {
            return View();
        }
        public ActionResult flot()
        {
            return View();
        }
        public ActionResult forms()
        {
            return View();
        }
        public ActionResult grid()
        {
            return View();
        }
        public ActionResult icons()
        {
            return View();
        }
        public ActionResult index()
        {
            if (!DataContext.UserID.HasValue())
            {
                return RedirectToAction("Login");}
            V("uid", Session["user"]);
            return View();
        }
        public ActionResult welcome()
        {
            return View();
        }
        public ActionResult login()
        {
            if (DataContext.UserID.HasValue())
            {
                return RedirectToAction("index");
            }
            return View(new Login_M() {UserId = "1325112033"});
        }
        #region Login Logic
        [HttpPost]
        public ActionResult login(Login_M model)
        {
            model.UserId = F("UserId");
            model.UserPsw = F("UserPsw");

            if (model.UserId.HasValue()&&ModelState.IsValid)
            {
                var user = _permissionProvider.UserInfo(model.UserId);
                // if (_permissionProvider.Login(model.UserId, model.UserPsw))
                if (user != null)
                {
                    Session["user"] = user.nick_name;
                    return LoginOk(model.UserId, "");
                }
                else
                {
                    return Alert("用户名或密码错误！", -1);
                }
            }
            else
            {
                return View(model);
            }
     
        }
        // GET: /Account/LoginOk?uid=panda&return_url=http://52xyj.cn&msg=测试
        public ActionResult LoginOk(string uid, string return_url, string msg = "", string uName = "未设置")
        {
            var accountContext = new AccountContext();
            DataContext.UserID =
                accountContext.UserID = uid;
            DataContext.UserName =
             accountContext.UserName = uName;
            Session["AccountContext"] = accountContext;
            if (return_url.HasValue())
            {
                return Redirect(return_url);
            }
            else if (ReturnUrl.HasValue() && ReturnUrl != "/" && !return_url.ToLower().Contains("login"))
            {
                return Redirect(ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index", new {msg = "用户[" + uid + "]登录成功!"});
            }
        }
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
        #endregion
        public ActionResult morris()
        {
            return View();
        }
        public ActionResult notifications()
        {
            return View();
        }
        public ActionResult panelsWells()
        {
            return View();
        }
        public ActionResult tables()
        {
            return View();
        }
        public ActionResult typography()
        {
            return View();
        }
        public ActionResult layer()
        {
            return View();
        }
        
    }
}
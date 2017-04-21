using Qx.Wechat.LostAndFound.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.WeChat.ViewModels.Visitior;
using Web.Controllers.Base;

namespace Web.Areas.WeChat.Controllers.Visitior
{
    public class LostAndFoundController : BaseController
    {
        // GET: WeChat/LostAndFound
        private ILostAndFoundServices _lostAndFoundServices;

        public LostAndFoundController(ILostAndFoundServices _lostAndFoundServices)
        {
            _lostAndFoundServices = _lostAndFoundServices;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Regist()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login_M model)
        {

            if (_lostAndFoundServices.Login(model.UserID, model.Psw))
            {
                return Redirect("/WeChat/LostAndFound/LostList?uid=" + model.UserID);
            }
            return View(model);
        }
    }
}
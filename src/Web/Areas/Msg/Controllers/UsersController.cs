using Qx.Msg.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Msg.ViewModels.Users;

namespace Web.Areas.Msg.Controllers
{
    public class UsersController : BaseMsgController
    {
        private IRepository<msg_user> _user;

        public UsersController(IRepository<msg_user> user)
        {
            _user = user;
        }
        // GET: Msg/Users/UsersList
        public ActionResult UsersList(string reportID, string Params, int pageIndex = 1, int perCount = 10)
        {

            if (!reportID.HasValue())
            {
                return RedirectToAction("UsersList", new { reportId = "QX.Msg.用户信息编辑", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("用户信息编辑", "/Msg/Users/UserAdd");
            return View();
        }
        public ActionResult UserAdd()
        {
            InitForm("添加用户");
            return View();
        }
        [HttpPost]
        public ActionResult UserAdd(Users_M model)
        {

            if (ModelState.IsValid)
            {
                _user.Add(model.ToModel());
                return RedirectToAction("Msg", "Users/UsersList");
            }
            else
            {
                InitForm("添加用户");
                return View(model);
            }
        }
        public ActionResult UserEdit(string userid)
        {
            InitForm("编辑用户信息");
            var user = _user.Find(userid);
            return View(Users_M.ToViewModel(user));
        }
        [HttpPost]
        public ActionResult UserEdit(Users_M model)
        {

            if (ModelState.IsValid)
            {
                _user.Update(model.ToModel());
                return RedirectToAction("Msg", "Users/UsersList");
            }
            else
            {
                InitForm("编辑用户信息");
                return View(model);
            }
        }
        public ActionResult UserDelete(string userid)
        {

            if (_user.Find(userid) != null)
            {
                _user.Delete(userid);
                return Alert("移除成功");
            }
            else
                return Alert("移除失败");
        }
    }
}
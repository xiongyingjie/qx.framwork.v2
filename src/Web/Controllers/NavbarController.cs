using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Permission.Interfaces;
using Web.Controllers.Base;
using Web.Domain;
using Web.Models;
using Navbar = Qx.Permission.Models.Navbar;

namespace Web.Controllers
{
    public class NavbarController : BaseController
    {
        private readonly IPermission _permission;

        public NavbarController(IPermission permission)
        {
            _permission = permission;
        }

        // GET: Navbar
        public ActionResult Index()
        {
            ViewData["DataContext"] = DataContext;
            IEnumerable<Navbar>  model;
            if (Session[DataContext.UserID] == null)
            {
                //写入缓存
                model = _permission.GetNavbarByUserId(DataContext.UserID);
                Session[DataContext.UserID] = model;
            }
            else
            {
                //读取缓存
                model = Session[DataContext.UserID] as IEnumerable<Navbar>;
            }
            //   return PartialView("_Navbar", new Data().navbarItems().ToList());
            return PartialView("_Navbar", NavbarIndex.Init(_permission.GetNavbarByUserId(DataContext.UserID),
                 _permission.GetForbidenButtonByUserId(DataContext.UserID)));

        }
    }
}
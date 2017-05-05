using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Controllers.Base;
using Web.Domain;
using Web.Models;
using Navbar = qx.permmision.v2.Models.Navbar;
using qx.permmision.v2;
namespace Web.Controllers
{
    public class NavbarController : BaseController
    {
        private readonly qx.permmision.v2.Interfaces.IPermmisionService _permmisionService;

        public NavbarController(qx.permmision.v2.Interfaces.IPermmisionService permmisionService)
        {
            _permmisionService = permmisionService;
        }

        // GET: Navbar
        public ActionResult Index()
        {
            ViewData["DataContext"] = DataContext;
            IEnumerable<Navbar>  model;
            if (Session[DataContext.UserID] == null)
            {
                //写入缓存
                model = _permmisionService.GetNavbarByUserId(DataContext.UserID);
                Session[DataContext.UserID] = model;
            }
            else
            {
                //读取缓存
                model = Session[DataContext.UserID] as IEnumerable<Navbar>;
            }
            //   return PartialView("_Navbar", new Data().navbarItems().ToList());
            return PartialView("_Sb2Navbar", NavbarIndex.Init(_permmisionService.GetNavbarByUserId(DataContext.UserID),
                 _permmisionService.GetForbidenButtonByUserId(DataContext.UserID)));

        }
    }
}
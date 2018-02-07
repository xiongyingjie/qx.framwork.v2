using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Models;


namespace Web.Controllers
{
    public partial class OpenController
    {
        public class NavbarIndex
        {
            public static NavbarIndex Init(IEnumerable<Navbar> navbars, List<MenuItem> navbars2, IEnumerable<button> buttons)
            {
                return new NavbarIndex()
                {

                    Navbars = navbars,
                    Navbars2 = navbars2,
                    Buttons = buttons
                };
            }
            public IEnumerable<MenuItem> Navbars2;
            public IEnumerable<Navbar> Navbars;
            public IEnumerable<button> Buttons;

            public static NavbarIndex Init(List<MenuItem> navbars2, List<button> buttons)
            {
                return new NavbarIndex()
                {

               
                    Navbars2 = navbars2,
                    Buttons = buttons
                };
            }
        }
        // GET: /open/WxCfg
        //public IActionResult WxCfg(string key,string url)
        //{
        //    return Json( _configHelper.GetCfg(url,key),JsonRequestBehavior.AllowGet);
        //}
    }

}
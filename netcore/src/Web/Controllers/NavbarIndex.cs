using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Models;


namespace Web.Controllers
{
    public partial class OpenController
    {
        public class NavbarIndex
        {
            public static NavbarIndex Init(IEnumerable<Navbar> navbars,
                IEnumerable<button> buttons)
            {
                return new NavbarIndex()
                {
                    Navbars = navbars,
                    Buttons = buttons
                };
            }
            public IEnumerable<Navbar> Navbars;
            public IEnumerable<button> Buttons;
        }
        // GET: /open/WxCfg
        //public IActionResult WxCfg(string key,string url)
        //{
        //    return Json( _configHelper.GetCfg(url,key),JsonRequestBehavior.AllowGet);
        //}
    }

}
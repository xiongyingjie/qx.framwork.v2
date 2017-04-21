using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class NavbarIndex
    {
        public static NavbarIndex Init(IEnumerable<Qx.Permission.Models.Navbar> navbars,
             IEnumerable<Qx.Permission.Entity.button> buttons)
        {
            return new NavbarIndex()
            {
                Navbars = navbars,
                Buttons = buttons
            };
        }
        public IEnumerable<Qx.Permission.Models.Navbar> Navbars;
        public IEnumerable<Qx.Permission.Entity.button> Buttons;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Models;

namespace Web.Models
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
}
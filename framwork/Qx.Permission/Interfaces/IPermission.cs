using System.Collections.Generic;
using System.Web.Mvc;
using Qx.Permission.Entity;
using Qx.Permission.Models;

namespace Qx.Permission.Interfaces
{
    public interface IPermission
    {
        List<MenuItem>  GetMenuByUserId(string userId);
        List<button> GetForbidenButtonByUserId(string userId);
        List<SelectListItem> GetMenu(string selectedMenuId = "-1", string rootFather = "MRoot");

        IEnumerable<Navbar> GetNavbarByUserId(string userId);
        List<menu> FindFather(string menuid);
    }
}
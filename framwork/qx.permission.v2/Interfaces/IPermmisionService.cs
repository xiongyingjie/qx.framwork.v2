using System.Collections.Generic;
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Models;

namespace qx.permmision.v2.Interfaces
{
    public interface IPermmisionService
    {
        List<MenuItem>  GetMenuByUserId(string userId);
        List<button> GetForbidenButtonByUserId(string userId);
        List<SelectListItem> GetMenu(string selectedMenuId = "-1", string rootFather = "MRoot");

        IEnumerable<Navbar> GetNavbarByUserId(string userId);
        List<menu> FindFather(string menuid);
    }
}
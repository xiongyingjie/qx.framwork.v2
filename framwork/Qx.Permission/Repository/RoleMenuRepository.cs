using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Qx.Permission.Repository
{


    public class RoleMenuRepository : BaseRepository, IRepository<role_menu>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.role_menu.Select(a => new SelectListItem() { Text = a.RoleMenuID, Value = a.RoleMenuID }).ToList();
            return dest.Format(value);
        }

        public string Add(role_menu model)
        {
            model.RoleMenuID = model.RoleID+"-"+ model.MenuID;
            if (Find(model.RoleMenuID) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            else
            {
                return "";
            }
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(role_menu model, string note = "")
        {
            if (Find(model.RoleMenuID) != null)
            {
                return Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public role_menu Find(object id)
        {
            return Db.role_menu.NoTrackingFind(a => a.RoleMenuID == (string)id);
        }

        public List<role_menu> All()
        {
            return Db.role_menu.NoTrackingToList();
        }

        public List<role_menu> All(Func<role_menu, bool> filter)
        {
            return Db.role_menu.NoTrackingWhere(filter);
        }
    }
}

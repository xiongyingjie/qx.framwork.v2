using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System;

namespace Qx.Permission.Repository
{


    public class MenuRepository : BaseRepository, IRepository<menu>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.menu.Select(a => new SelectListItem() { Text = a.MenuID, Value = a.Name }).ToList();
            return dest.Format(value);
        }

        public string Add(menu model)
        {
            if (Find(model.MenuID) == null)
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

        public bool Update(menu model, string note = "")
        {
            if (Find(model.MenuID) != null)
            {
                return Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public menu Find(object id)
        {
            return Db.menu.NoTrackingFind(a => a.MenuID == (string)id);
        }

        public List<menu> All()
        {
            return Db.menu.NoTrackingToList();
        }

        public List<menu> All(Func<menu, bool> filter)
        {
            return Db.menu.NoTrackingWhere(filter);
        }
    }
}

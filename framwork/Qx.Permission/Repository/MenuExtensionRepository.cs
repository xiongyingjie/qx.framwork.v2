using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;

namespace Qx.Permission.Repository
{


    public class MenuExtensionRepository : BaseRepository, IRepository<menu_extension>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.menu_extension.Select(a => new SelectListItem() { Text = a.menu.Name, Value = a.MenuID }).ToList();
            return dest.Format(value);
        }

        public string Add(menu_extension model)
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

        public bool Update(menu_extension model, string note = "")
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

        public menu_extension Find(object id)
        {
            return Db.menu_extension.NoTrackingFind(a => a.MenuID == (string)id);
        }

        public List<menu_extension> All()
        {
            return Db.menu_extension.NoTrackingToList();
        }

        public List<menu_extension> All(Func<menu_extension, bool> filter)
        {
            return Db.menu_extension.NoTrackingWhere(filter);
        }
    }
}

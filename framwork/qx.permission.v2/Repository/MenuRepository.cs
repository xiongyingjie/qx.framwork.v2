using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace qx.permmision.v2.Repository
{


    public class MenuRepository : BaseRepository, IRepository<menu>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.menu.Select(a => new SelectListItem() { Text = a.menu_id, Value = a.name }).ToList();
            return dest.Format(value);
        }

        public string Add(menu model)
        {
            if (Find(model.menu_id) == null)
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
            if (Find(model.menu_id) != null)
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
            return Db.menu.NoTrackingFind(a => a.menu_id == (string)id);
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

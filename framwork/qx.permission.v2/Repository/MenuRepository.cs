using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
            return Db.menu.ToItems(v => v.menu_id,t => t.name );
         
        }

        public string Add(menu model)
        {
            return Find(model.menu_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(menu model, string note = "")
        {
            Db.menu.AddOrUpdate(model);
            return Db.Saved();
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

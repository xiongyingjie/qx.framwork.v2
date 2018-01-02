using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class RoleMenuRepository : BaseRepository, IRepository<role_menu>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            return Db.role_menu.ToItems(v => v.role_menu_id,t => t.role_menu_id);
        }

        public string Add(role_menu model)
        {
            model.role_menu_id = model.role_id+"-"+ model.menu_id;
            return Find(model.role_menu_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(role_menu model, string note = "")
        {
            Db.role_menu.Update(model);
            return Db.Saved();
        }

        public role_menu Find(object id)
        {
            return Db.role_menu.NoTrackingFind(a => a.role_menu_id == (string)id);
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

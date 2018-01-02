using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class RoleGroupRepository : BaseRepository, IRepository<role_group>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            return Db.role_group.ToItems(v => v.role_group_id, t => t.role_group_name);
        }

        public string Add(role_group model)
        {
            return Find(model.role_group_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(role_group model, string note = "")
        {
            Db.role_group.Update(model);
            return Db.Saved();
        }

        public role_group Find(object id)
        {
            return Db.role_group.NoTrackingFind(a => a.role_group_id == (string)id);
        }

        public List<role_group> All()
        {
            return Db.role_group.NoTrackingToList();
        }

        public List<role_group> All(Func<role_group, bool> filter)
        {
            return Db.role_group.NoTrackingWhere(filter);
        }
    }
}

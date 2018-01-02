using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class UserGroupRepository : BaseRepository, IRepository<user_group>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            return Db.user_group.ToItems(v => v.user_group_id, t => t.user_group_name);
        }

        public string Add(user_group model)
        {
            model.user_group_id = Pk;
            return Find(model.user_group_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(user_group model, string note = "")
        {
            Db.user_group.Update(model);
            return Db.Saved();
        }

        public user_group Find(object id)
        {
            return Db.user_group.NoTrackingFind(a => a.user_group_id == (string)id);
        }

        public List<user_group> All()
        {
            return Db.user_group.NoTrackingToList();
        }

        public List<user_group> All(Func<user_group, bool> filter)
        {
            return Db.user_group.NoTrackingWhere(filter);
        }
    }
}

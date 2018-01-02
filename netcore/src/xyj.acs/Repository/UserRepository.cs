using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class UserRepository : BaseRepository, IRepository<permission_user>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            return Db.permission_user.ToItems(v => v.user_id, t => t.nick_name);
           
        }

        public string Add(permission_user model)
        {
            return Find(model.user_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(permission_user model, string note = "")
        {
            Db.permission_user.Update(model);
            return Db.Saved();
        }

        public permission_user Find(object id)
        {
            return Db.permission_user.NoTrackingFind(a => a.user_id == (string)id);
        }

        public List<permission_user> All()
        {
            return Db.permission_user.NoTrackingToList();
        }

        public List<permission_user> All(Func<permission_user, bool> filter)
        {
            return Db.permission_user.NoTrackingWhere(filter);
        }
    }
}

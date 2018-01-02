using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class UserTypeRepository : BaseRepository, IRepository<user_type>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            return Db.user_type.ToItems(v => v.user_type_id, t => t.name);
        }

        public string Add(user_type model)
        {
            model.user_type_id = Pk;
            return Find(model.user_type_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(user_type model, string note = "")
        {
            Db.user_type.Update(model);
            return Db.Saved();
        }

        public user_type Find(object id)
        {
            return Db.user_type.NoTrackingFind(a => a.user_type_id == (string)id);
        }

        public List<user_type> All()
        {
            return Db.user_type.NoTrackingToList();
        }

        public List<user_type> All(Func<user_type, bool> filter)
        {
            return Db.user_type.NoTrackingWhere(filter);
        }
    }
}

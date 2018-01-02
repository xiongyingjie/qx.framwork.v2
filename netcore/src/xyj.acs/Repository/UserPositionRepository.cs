using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class UserPositionRepository : BaseRepository, IRepository<user_position>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            return Db.user_position.ToItems(v => v.user_position_id,t => t.user_position_id);
        }

        public string Add(user_position model)
        {
            model.user_position_id = Pk;
            return Find(model.user_position_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(user_position model, string note = "")
        {
            Db.user_position.Update(model);
            return Db.Saved();
        }

        public user_position Find(object id)
        {
            return Db.user_position.NoTrackingFind(a => a.user_position_id == (string)id);
        }

        public List<user_position> All()
        {
            return Db.user_position.NoTrackingToList();
        }

        public List<user_position> All(Func<user_position, bool> filter)
        {
            return Db.user_position.NoTrackingWhere(filter);
        }
    }
}

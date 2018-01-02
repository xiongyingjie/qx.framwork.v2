using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class PositionRepository : BaseRepository, IRepository<position>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            return Db.position.ToItems(v => v.position_id,t => t.name );
        }

        public string Add(position model)
        {
            model.position_id = Pk;
            return Find(model.position_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(position model, string note = "")
        {
            Db.position.Update(model);
            return Db.Saved();
        }

        public position Find(object id)
        {
            return Db.position.NoTrackingFind(a => a.position_id == (string)id);
        }

        public List<position> All()
        {
            return Db.position.NoTrackingToList();
        }

        public List<position> All(Func<position, bool> filter)
        {
            return Db.position.NoTrackingWhere(filter);
        }
    }
}

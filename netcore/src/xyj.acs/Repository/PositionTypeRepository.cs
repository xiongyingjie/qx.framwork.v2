using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class PositionTypeRepository : BaseRepository, IRepository<position_type>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            return Db.position_type.ToItems(v => v.position_type_id,t => t.name );
        }

        public string Add(position_type model)
        {
            model.position_type_id = Pk;
            return Find(model.position_type_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(position_type model, string note = "")
        {
            Db.position_type.Update(model);
            return Db.Saved();
        }

        public position_type Find(object id)
        {
            return Db.position_type.NoTrackingFind(a => a.position_type_id == (string)id);
        }

        public List<position_type> All()
        {
            return Db.position_type.NoTrackingToList();
        }

        public List<position_type> All(Func<position_type, bool> filter)
        {
            return Db.position_type.NoTrackingWhere(filter);
        }
    }
}

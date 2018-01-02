using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class OrgnizationPositionRepository : BaseRepository, IRepository<orgnization_position>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            return Db.orgnization_position.ToItems(v => v.orgnization_position_id,t => t.position_id);
        }

        public string Add(orgnization_position model)
        {
            model.orgnization_position_id = Pk;
            return Find(model.orgnization_position_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(orgnization_position model, string note = "")
        {
            Db.orgnization_position.Update(model);
            return Db.Saved();
        }

        public orgnization_position Find(object id)
        {
            return Db.orgnization_position.NoTrackingFind(a => a.orgnization_position_id == (string)id);
        }

        public List<orgnization_position> All()
        {
            return Db.orgnization_position.NoTrackingToList();
        }

        public List<orgnization_position> All(Func<orgnization_position, bool> filter)
        {
            return Db.orgnization_position.NoTrackingWhere(filter);
        }
    }
}

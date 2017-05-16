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


    public class PositionTypeRepository : BaseRepository, IRepository<position_type>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
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
            Db.position_type.AddOrUpdate(model);
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

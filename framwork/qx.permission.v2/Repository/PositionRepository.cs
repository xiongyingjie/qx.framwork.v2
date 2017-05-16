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


    public class PositionRepository : BaseRepository, IRepository<position>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
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
            Db.position.AddOrUpdate(model);
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

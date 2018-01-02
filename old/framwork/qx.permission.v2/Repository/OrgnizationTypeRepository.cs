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


    public class OrgnizationTypeRepository : BaseRepository, IRepository<orgnization_type>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.orgnization_type.ToItems(v => v.orgnization_type_id,t => t.name );
        }

        public string Add(orgnization_type model)
        {
            model.orgnization_type_id = Pk;
            return Find(model.orgnization_type_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(orgnization_type model, string note = "")
        {
            Db.orgnization_type.AddOrUpdate(model);
            return Db.Saved();
        }

        public orgnization_type Find(object id)
        {
            return Db.orgnization_type.NoTrackingFind(a => a.orgnization_type_id == (string)id);
        }

        public List<orgnization_type> All()
        {
            return Db.orgnization_type.NoTrackingToList();
        }

        public List<orgnization_type> All(Func<orgnization_type, bool> filter)
        {
            return Db.orgnization_type.NoTrackingWhere(filter);
        }
    }
}

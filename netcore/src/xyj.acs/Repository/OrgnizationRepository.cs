using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class OrgnizationRepository : BaseRepository, IRepository<orgnization>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            return Db.orgnization.ToItems(v => v.orgnization_id,t => t.name );
        }

        public string Add(orgnization model)
        {
            model.orgnization_id = Pk;
            return Find(model.orgnization_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(orgnization model, string note = "")
        {
            Db.orgnization.Update(model);
            return Db.Saved();
        }

        public orgnization Find(object id)
        {
            return Db.orgnization.NoTrackingFind(a => a.orgnization_id == (string)id);
        }

        public List<orgnization> All()
        {
            return Db.orgnization.NoTrackingToList();
        }

        public List<orgnization> All(Func<orgnization, bool> filter)
        {
            return Db.orgnization.NoTrackingWhere(filter);
        }
    }
}

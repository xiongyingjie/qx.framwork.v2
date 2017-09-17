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


    public class DataFilterRepository : BaseRepository, IRepository<data_filter>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.data_filter.ToItems( v => v.data_filter_id, t => t.note);
        }

        public string Add(data_filter model)
        {
            model.data_filter_id = Pk;
            return Find(model.data_filter_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(data_filter model, string note = "")
        {
            Db.data_filter.AddOrUpdate(model);
            return Db.Saved();
        }

        public data_filter Find(object id)
        {
            return Db.data_filter.NoTrackingFind(a => a.data_filter_id == (string)id);
        }

        public List<data_filter> All()
        {
            return Db.data_filter.NoTrackingToList();
        }

        public List<data_filter> All(Func<data_filter, bool> filter)
        {
            return Db.data_filter.NoTrackingWhere(filter);
        }
    }
}

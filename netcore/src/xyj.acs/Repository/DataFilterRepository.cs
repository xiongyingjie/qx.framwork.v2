using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class DataFilterRepository : BaseRepository, IRepository<data_filter>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
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
            Db.data_filter.Update(model);
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

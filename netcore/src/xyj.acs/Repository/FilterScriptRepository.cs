using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class FilterScriptRepository : BaseRepository, IRepository<filter_script>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            return Db.filter_script.ToItems( v => v.filter_script_id, t => t.name);
        }

        public string Add(filter_script model)
        {
            model.filter_script_id = Pk;
            return Find(model.filter_script_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(filter_script model, string note = "")
        {
            Db.filter_script.Update(model);
            return Db.Saved();
        }

        public filter_script Find(object id)
        {
            return Db.filter_script.NoTrackingFind(a => a.filter_script_id == (string)id);
        }

        public List<filter_script> All()
        {
            return Db.filter_script.NoTrackingToList();
        }

        public List<filter_script> All(Func<filter_script, bool> filter)
        {
            return Db.filter_script.NoTrackingWhere(filter);
        }
    }
}

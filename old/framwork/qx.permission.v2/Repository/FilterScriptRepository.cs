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


    public class FilterScriptRepository : BaseRepository, IRepository<filter_script>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
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
            Db.filter_script.AddOrUpdate(model);
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

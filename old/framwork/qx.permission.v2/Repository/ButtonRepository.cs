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


    public class ButtonRepository : BaseRepository, IRepository<button>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.button.ToItems(v => v.button_id,t => t.name );
        }

        public string Add(button model)
        {
            model.button_id = Pk;
            return Find(model.button_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(button model, string note = "")
        {
            Db.button.AddOrUpdate(model);
            return Db.Saved();
        }

        public button Find(object id)
        {
            return Db.button.NoTrackingFind(a => a.button_id == (string)id);
        }

        public List<button> All()
        {
            return Db.button.NoTrackingToList();
        }

        public List<button> All(Func<button, bool> filter)
        {
            return Db.button.NoTrackingWhere(filter);
        }
    }
}

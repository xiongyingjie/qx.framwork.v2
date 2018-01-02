using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class ButtonRepository : BaseRepository, IRepository<button>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
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
            Db.button.Update(model);
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

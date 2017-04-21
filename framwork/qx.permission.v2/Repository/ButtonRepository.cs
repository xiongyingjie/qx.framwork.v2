using System;
using System.Collections.Generic;
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
            var dest = Db.button.Select(a => new SelectListItem() { Text = a.button_id, Value = a.name }).ToList();
            return dest.Format(value);
        }

        public string Add(button model)
        {
            model.button_id = Pk;
            if (Find(model.button_id) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            else
            {
                return "";
            }
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(button model, string note = "")
        {
            if (Find(model.button_id) != null)
            {
                return Db.SaveModified(model);
            }
            else
            {
                return false;
            }
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

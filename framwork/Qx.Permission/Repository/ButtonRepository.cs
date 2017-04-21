using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Web.Mvc;

namespace Qx.Permission.Repository
{


    public class ButtonRepository : BaseRepository, IRepository<button>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.button.Select(a => new SelectListItem() { Text = a.ButtonID, Value = a.Name }).ToList();
            return dest.Format(value);
        }

        public string Add(button model)
        {
            model.ButtonID = Pk;
            if (Find(model.ButtonID) == null)
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
            if (Find(model.ButtonID) != null)
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
            return Db.button.NoTrackingFind(a => a.ButtonID == (string)id);
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

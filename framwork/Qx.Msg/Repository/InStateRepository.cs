using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Qx.Tools.Interfaces;
using System.Linq;
using Qx.Tools.CommonExtendMethods;
using Qx.Msg.Entity;
using Qx.Msg.Services;

namespace Qx.Msg.Repository
{

    public class InStateRepository : BaseRepository, IRepository<in_state>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.in_state.Select(a => new SelectListItem() { Text = a.InStateID, Value = a.InStateID }).ToList();
            return dest.Format(value);
        }

        public string Add(in_state model)
        {
            model.InStateID = Pk;
            if (Find(model.InStateID) == null)
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

        public bool Update(in_state model, string note = "")
        {
            if (Find(model.InStateID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public in_state Find(object id)
        {
            return Db.in_state.NoTrackingFind(a=>a.InStateID == (string) id);
        }

        public List<in_state> All()
        {
            return Db.in_state.NoTrackingToList();
        }

        public List<in_state> All(Func<in_state, bool> filter)
        {
            return Db.in_state.NoTrackingWhere(filter);
        }
    }
}

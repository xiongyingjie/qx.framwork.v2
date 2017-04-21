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

    public class OutStateRepository : BaseRepository, IRepository<out_state>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.out_state.Select(a => new SelectListItem() { Text = a.OutStateID, Value = a.OutStateID }).ToList();
            return dest.Format(value);
        }

        public string Add(out_state model)
        {
            model.OutStateID = Pk;
            if (Find(model.OutStateID) == null)
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

        public bool Update(out_state model, string note = "")
        {
            if (Find(model.OutStateID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public out_state Find(object id)
        {
            return Db.out_state.NoTrackingFind(a=>a.OutStateID == (string) id);
        }

        public List<out_state> All()
        {
            return Db.out_state.NoTrackingToList();
        }

        public List<out_state> All(Func<out_state, bool> filter)
        {
            return Db.out_state.NoTrackingWhere(filter);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Order.Entity;
using Qx.Order.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace Qx.Order.Repository
{


    public class OrderStatuRepository : BaseRepository, IRepository<order_state>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.order_state.Select(a => new SelectListItem() { Text = a.StateName, Value = a.OrderStateID }).ToList();
            return dest.Format(value);
        }

        public string Add(order_state model)
        {
            if (Find(model.OrderStateID) == null)
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

        public bool Update(order_state model, string note = "")
        {
            if (Find(model.OrderStateID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public order_state Find(object id)
        {
            return Db.order_state.NoTrackingFind(a=>a.OrderStateID == (string) id);
        }

        public List<order_state> All()
        {
            return Db.order_state.NoTrackingToList();
        }

        public List<order_state> All(Func<order_state, bool> filter)
        {
            return Db.order_state.NoTrackingWhere(filter);
        }
    }
}

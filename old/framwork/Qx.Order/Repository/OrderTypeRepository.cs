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


    public class OrderTypeRepository : BaseRepository, IRepository<order_type>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.order_type.Select(a => new SelectListItem() { Text = a.Name, Value = a.OrderTypeID }).ToList();
            return dest.Format(value);
        }

        public string Add(order_type model)
        {
            if (Find(model.OrderTypeID) == null)
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

        public bool Update(order_type model, string note = "")
        {
            if (Find(model.OrderTypeID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public order_type Find(object id)
        {
            return Db.order_type.NoTrackingFind(a=>a.OrderTypeID == (string) id);
        }

        public List<order_type> All()
        {
            return Db.order_type.NoTrackingToList();
        }

        public List<order_type> All(Func<order_type, bool> filter)
        {
            return Db.order_type.NoTrackingWhere(filter);
        }
    }
}

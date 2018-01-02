using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Order.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace Qx.Order.Repository
{


    public class OrderRepository : BaseRepository, IRepository<Order.Entity.order>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.order.Select(a => new SelectListItem() { Text = a.OrderID, Value = a.OrderID }).ToList();
            return dest.Format(value);
        }

        public string Add(Order.Entity.order model)
        {
            if (Find(model.OrderID) == null)
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

        public bool Update(Order.Entity.order model, string note = "")
        {
            if (Find(model.OrderID)!= null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public Order.Entity.order Find(object id)
        {
            return Db.order.NoTrackingFind(a=>a.OrderID==(string) id);
        }

        public List<Order.Entity.order> All()
        {
            return Db.order.NoTrackingToList();
        }

        public List<Order.Entity.order> All(Func<Order.Entity.order, bool> filter)
        {
            return Db.order.NoTrackingWhere(filter);
        }
    }
}

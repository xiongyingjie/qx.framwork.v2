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


    public class OrderItemRepository : BaseRepository, IRepository<order_item>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.order_item.Select(a => new SelectListItem() { Text = a.SellOrderItemID, Value = a.SellOrderItemID }).ToList();
            return dest.Format(value);
        }

        public string Add(order_item model)
        {
            if (Find(model.SellOrderItemID) == null)
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

        public bool Update(order_item model, string note = "")
        {
            if (Find(model.SellOrderItemID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public order_item Find(object id)
        {
            return Db.order_item.NoTrackingFind(a=>a.SellOrderItemID == (string) id);
        }

        public List<order_item> All()
        {
            return Db.order_item.NoTrackingToList();
        }

        public List<order_item> All(Func<order_item, bool> filter)
        {
            return Db.order_item.NoTrackingWhere(filter);
        }
    }
}

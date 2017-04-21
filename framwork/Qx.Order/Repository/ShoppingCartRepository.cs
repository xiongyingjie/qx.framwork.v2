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


    public class ShoppingCartRepository : BaseRepository, IRepository<shopping_cart>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.shopping_cart.Select(a => new SelectListItem() { Text = a.SC_ID, Value = a.SC_ID }).ToList();
            return dest.Format(value);
        }

        public string Add(shopping_cart model)
        {
            if (Find(model.SC_ID) == null)
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

        public bool Update(shopping_cart model, string note = "")
        {
            if (Find(model.SC_ID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public shopping_cart Find(object id)
        {
            return Db.shopping_cart.NoTrackingFind(a=>a.SC_ID == (string) id);
        }

        public List<shopping_cart> All()
        {
            return Db.shopping_cart.NoTrackingToList();
        }

        public List<shopping_cart> All(Func<shopping_cart, bool> filter)
        {
            return Db.shopping_cart.NoTrackingWhere(filter);
        }
    }
}

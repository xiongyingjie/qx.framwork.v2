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


    public class R_ProductsRepository : BaseRepository, IRepository<r_product>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.r_product.Select(a => new SelectListItem() { Text = a.ProductID, Value = a.ProductID }).ToList();
            return dest.Format(value);
        }

        public string Add(r_product model)
        {
            if (Find(model.ProductID) == null)
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

        public bool Update(r_product model, string note = "")
        {
            if (Find(model.ProductID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public r_product Find(object id)
        {
            return Db.r_product.NoTrackingFind(a=>a.ProductID == (string) id);
        }

        public List<r_product> All()
        {
            return Db.r_product.NoTrackingToList();
        }

        public List<r_product> All(Func<r_product, bool> filter)
        {
            return Db.r_product.NoTrackingWhere(filter);
        }
    }
}

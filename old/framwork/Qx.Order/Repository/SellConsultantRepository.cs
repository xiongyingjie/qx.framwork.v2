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


    public class SellConsultantRepository : BaseRepository, IRepository<sell_consultant>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.sell_consultant.Select(a => new SelectListItem() { Text = a.SellConsultantID, Value = a.SellConsultantID }).ToList();
            return dest.Format(value);
        }

        public string Add(sell_consultant model)
        {
            if (Find(model.SellConsultantID) == null)
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

        public bool Update(sell_consultant model, string note = "")
        {
            if (Find(model.SellConsultantID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public sell_consultant Find(object id)
        {
            return Db.sell_consultant.NoTrackingFind(a=>a.SellConsultantID == (string) id);
        }

        public List<sell_consultant> All()
        {
            return Db.sell_consultant.NoTrackingToList();
        }

        public List<sell_consultant> All(Func<sell_consultant, bool> filter)
        {
            return Db.sell_consultant.NoTrackingWhere(filter);
        }
    }
}

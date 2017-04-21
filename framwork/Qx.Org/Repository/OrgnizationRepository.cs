using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Org.Entity;
using Qx.Org.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace Qx.Org.Repository
{

    public class OrgnizationRepository : BaseRepository, IRepository<Orgnization>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.Orgnizations.Select(a => new SelectListItem() { Text = a.Name, Value = a.O_ID }).ToList();
            return dest.Format(value);
        }

        public string Add(Orgnization model)
        {
            if (Find(model.O_ID) == null)
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

        public bool Update(Orgnization model, string note = "")
        {
            if (Find(model.O_ID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public Orgnization Find(object id)
        {
            return Db.Orgnizations.NoTrackingFind(a=>a.O_ID == (string) id);
        }

        public List<Orgnization> All()
        {
            return Db.Orgnizations.NoTrackingToList();
        }

        public List<Orgnization> All(Func<Orgnization, bool> filter)
        {
            return Db.Orgnizations.NoTrackingWhere(filter);
        }
    }
}

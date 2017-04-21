using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Qx.Wechat.Entity;
using Qx.Wechat.Services;

namespace Qx.Wechat.Repository
{


    public class LocationEventRepository : BaseRepository, IRepository<LocationEvent>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.LocationEvents.Select(a => new SelectListItem() { Text = a.EventId.ToString(), Value = a.EventId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(LocationEvent model)
        {
            model.EventId = Pk;
            if (Find(model.EventId) == null)
            {
                return Db.SaveAdd(model) ? Pk.ToString() : null;
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

        public bool Update(LocationEvent model, string note = "")
        {
            if (Find(model.EventId) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public LocationEvent Find(object id)
        {
            return Db.LocationEvents.NoTrackingFind(a=>a.EventId == (string) id);
        }

        public List<LocationEvent> All()
        {
            return Db.LocationEvents.NoTrackingToList();
        }

        public List<LocationEvent> All(Func<LocationEvent, bool> filter)
        {
            return Db.LocationEvents.NoTrackingWhere(filter);
        }
    }
}

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


    public class SubscribeEventRepository : BaseRepository, IRepository<SubscribeEvent>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.SubscribeEvents.Select(a => new SelectListItem() { Text = a.EventId.ToString(), Value = a.EventId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(SubscribeEvent model)
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

        public bool Update(SubscribeEvent model, string note = "")
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

        public SubscribeEvent Find(object id)
        {
            return Db.SubscribeEvents.NoTrackingFind(a=>a.EventId == (string) id);
        }

        public List<SubscribeEvent> All()
        {
            return Db.SubscribeEvents.NoTrackingToList();
        }

        public List<SubscribeEvent> All(Func<SubscribeEvent, bool> filter)
        {
            return Db.SubscribeEvents.NoTrackingWhere(filter);
        }
    }
}

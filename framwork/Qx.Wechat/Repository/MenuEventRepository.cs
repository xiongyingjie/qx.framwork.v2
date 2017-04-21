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


    public class MenuEventRepository : BaseRepository, IRepository<MenuEvent>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.MenuEvents.Select(a => new SelectListItem() { Text = a.EventId.ToString(), Value = a.EventId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(MenuEvent model)
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

        public bool Update(MenuEvent model, string note = "")
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

        public MenuEvent Find(object id)
        {
            return Db.MenuEvents.NoTrackingFind(a=>a.EventId.ToString() ==  id.ToString());
        }

        public List<MenuEvent> All()
        {
            return Db.MenuEvents.NoTrackingToList();
        }

        public List<MenuEvent> All(Func<MenuEvent, bool> filter)
        {
            return Db.MenuEvents.NoTrackingWhere(filter);
        }
    }
}

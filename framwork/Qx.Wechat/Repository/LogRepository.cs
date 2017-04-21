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


    public class LogRepository : BaseRepository, IRepository<Log>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.Logs.Select(a => new SelectListItem() { Text = a.LogId, Value = a.Contents }).ToList();
            return dest.Format(value);
        }

        public string Add(Log model)
        {
            model.LogId = Pk.ToString();
            if (Find(model.LogId) == null)
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

        public bool Update(Log model, string note = "")
        {
            if (Find(model.LogId) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public Log Find(object id)
        {
            return Db.Logs.NoTrackingFind(a=>a.LogId ==  id.ToString());
        }

        public List<Log> All()
        {
            return Db.Logs.NoTrackingToList();
        }

        public List<Log> All(Func<Log, bool> filter)
        {
            return Db.Logs.NoTrackingWhere(filter);
        }
    }
}

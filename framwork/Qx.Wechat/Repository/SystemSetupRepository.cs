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


    public class SystemSetupRepository : BaseRepository, IRepository<SystemSetup>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.SystemSetups.Select(a => new SelectListItem() { Text = a.APP_ID.ToString(), Value = a.APP_ID }).ToList();
            return dest.Format(value);
        }

        public string Add(SystemSetup model)
        {
            model.APP_ID = Pk.ToString();
            if (Find(model.APP_ID) == null)
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

        public bool Update(SystemSetup model, string note = "")
        {
            if (Find(model.APP_ID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public SystemSetup Find(object id)
        {
            return Db.SystemSetups.NoTrackingFind(a=>a.APP_ID ==  id.ToString());
        }

        public List<SystemSetup> All()
        {
            return Db.SystemSetups.NoTrackingToList();
        }

        public List<SystemSetup> All(Func<SystemSetup, bool> filter)
        {
            return Db.SystemSetups.NoTrackingWhere(filter);
        }
    }
}

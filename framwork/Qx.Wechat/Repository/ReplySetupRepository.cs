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


    public class ReplySetupRepository : BaseRepository, IRepository<ReplySetup>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ReplySetups.Select(a => new SelectListItem() { Text = a.ReplySetupId.ToString(), Value = a.ReplySetupId }).ToList();
            return dest.Format(value);
        }

        public string Add(ReplySetup model)
        {
            model.ReplySetupId = Pk.ToString();
            if (Find(model.ReplySetupId) == null)
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

        public bool Update(ReplySetup model, string note = "")
        {
            if (Find(model.ReplySetupId) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public ReplySetup Find(object id)
        {
            return Db.ReplySetups.NoTrackingFind(a=>a.ReplySetupId ==  id.ToString());
        }

        public List<ReplySetup> All()
        {
            return Db.ReplySetups.NoTrackingToList();
        }

        public List<ReplySetup> All(Func<ReplySetup, bool> filter)
        {
            return Db.ReplySetups.NoTrackingWhere(filter);
        }
    }
}

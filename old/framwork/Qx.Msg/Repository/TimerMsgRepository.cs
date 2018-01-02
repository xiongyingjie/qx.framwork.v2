using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Qx.Tools.Interfaces;
using System.Linq;
using Qx.Tools.CommonExtendMethods;
using Qx.Msg.Entity;
using Qx.Msg.Services;

namespace Qx.Msg.Repository
{

    public class TimerMsgRepository : BaseRepository, IRepository<timer_msg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.timer_msg.Select(a => new SelectListItem() { Text = a.TimerMsgID, Value = a.TimerMsgID }).ToList();
            return dest.Format(value);
        }

        public string Add(timer_msg model)
        {
            model.TimerMsgID = Pk;
            if (Find(model.TimerMsgID) == null)
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

        public bool Update(timer_msg model, string note = "")
        {
            if (Find(model.TimerMsgID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public timer_msg Find(object id)
        {
            return Db.timer_msg.NoTrackingFind(a=>a.TimerMsgID == (string) id);
        }

        public List<timer_msg> All()
        {
            return Db.timer_msg.NoTrackingToList();
        }

        public List<timer_msg> All(Func<timer_msg, bool> filter)
        {
            return Db.timer_msg.NoTrackingWhere(filter);
        }
    }
}

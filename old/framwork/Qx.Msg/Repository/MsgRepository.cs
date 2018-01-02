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

    public class MsgRepository : BaseRepository, IRepository<Qx.Msg.Entity.msg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.msg.Select(a => new SelectListItem() { Text = a.MsgID, Value = a.MsgID }).ToList();
            return dest.Format(value);
        }

        public string Add(Qx.Msg.Entity.msg model)
        {
            if (Find(model.MsgID) == null)
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

        public bool Update(Qx.Msg.Entity.msg model, string note = "")
        {
            if (Find(model.MsgID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public Qx.Msg.Entity.msg Find(object id)
        {
            return Db.msg.NoTrackingFind(a=>a.MsgID == (string) id);
        }

        public List<Qx.Msg.Entity.msg> All()
        {
            return Db.msg.NoTrackingToList();
        }

        public List<Qx.Msg.Entity.msg> All(Func<Qx.Msg.Entity.msg, bool> filter)
        {
            return Db.msg.NoTrackingWhere(filter);
        }
    }
}

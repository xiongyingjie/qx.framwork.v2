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

    public class MsgTypeRepository : BaseRepository, IRepository<msg_type>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.msg_type.Select(a => new SelectListItem() { Text = a.TypeName, Value = a.MsgTypeID }).ToList();
            return dest.Format(value);
        }

        public string Add(msg_type model)
        {
            model.MsgTypeID = Pk;
            if (Find(model.MsgTypeID) == null)
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

        public bool Update(msg_type model, string note = "")
        {
            if (Find(model.MsgTypeID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public msg_type Find(object id)
        {
            return Db.msg_type.NoTrackingFind(a=>a.MsgTypeID == (string) id);
        }

        public List<msg_type> All()
        {
            return Db.msg_type.NoTrackingToList();
        }

        public List<msg_type> All(Func<msg_type, bool> filter)
        {
            return Db.msg_type.NoTrackingWhere(filter);
        }
    }
}

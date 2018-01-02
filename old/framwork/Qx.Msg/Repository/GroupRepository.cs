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

    public class GroupRepository : BaseRepository, IRepository<msg_group>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.msg_group.Select(a => new SelectListItem() { Text = a.GroupID, Value = a.GroupID }).ToList();
            return dest.Format(value);
        }

        public string Add(msg_group model)
        {
            model.GroupID = Pk;
            if (Find(model.GroupID) == null)
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

        public bool Update(msg_group model, string note = "")
        {
            if (Find(model.GroupID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public msg_group Find(object id)
        {
            return Db.msg_group.NoTrackingFind(a=>a.GroupID == (string) id);
        }

        public List<msg_group> All()
        {
            return Db.msg_group.NoTrackingToList();
        }

        public List<msg_group> All(Func<msg_group, bool> filter)
        {
            return Db.msg_group.NoTrackingWhere(filter);
        }
    }
}

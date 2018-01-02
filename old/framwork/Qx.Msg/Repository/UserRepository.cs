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

    public class UserRepository : BaseRepository, IRepository<msg_user>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.msg_user.Select(a => new SelectListItem() { Text = a.UserID, Value = a.UserID }).ToList();
            return dest.Format(value);
        }

        public string Add(msg_user model)
        {
            //model.UserID = Pk;
            if (Find(model.UserID) == null)
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

        public bool Update(msg_user model, string note = "")
        {
            if (Find(model.UserID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public msg_user Find(object id)
        {
            return Db.msg_user.NoTrackingFind(a=>a.UserID == (string) id);
        }

        public List<msg_user> All()
        {
            return Db.msg_user.NoTrackingToList();
        }

        public List<msg_user> All(Func<msg_user, bool> filter)
        {
            return Db.msg_user.NoTrackingWhere(filter);
        }
    }
}

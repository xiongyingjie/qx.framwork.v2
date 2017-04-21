using System.Linq;
using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;
using System.Collections.Generic;
using System;
using System.Web.Mvc;

namespace Qx.Permission.Repository
{


    public class UserRepository : BaseRepository, IRepository<permission_user>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.permission_user.Select(a => new SelectListItem() { Text = a.UserID, Value = a.NickName }).ToList();
            return dest.Format(value);
        }

        public string Add(permission_user model)
        {
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

        public bool Update(permission_user model, string note = "")
        {
            if (Find(model.UserID) != null)
            {
                return Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public permission_user Find(object id)
        {
            return Db.permission_user.NoTrackingFind(a => a.UserID == (string)id);
        }

        public List<permission_user> All()
        {
            return Db.permission_user.NoTrackingToList();
        }

        public List<permission_user> All(Func<permission_user, bool> filter)
        {
            return Db.permission_user.NoTrackingWhere(filter);
        }
    }
}

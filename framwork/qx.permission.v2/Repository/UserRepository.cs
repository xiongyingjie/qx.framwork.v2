using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace qx.permmision.v2.Repository
{


    public class UserRepository : BaseRepository, IRepository<permission_user>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.permission_user.Select(a => new SelectListItem() { Text = a.user_id, Value = a.nick_name }).ToList();
            return dest.Format(value);
        }

        public string Add(permission_user model)
        {
            if (Find(model.user_id) == null)
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
            if (Find(model.user_id) != null)
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
            return Db.permission_user.NoTrackingFind(a => a.user_id == (string)id);
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

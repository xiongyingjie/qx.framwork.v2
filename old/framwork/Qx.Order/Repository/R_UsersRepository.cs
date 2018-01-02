using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Order.Entity;
using Qx.Order.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace Qx.Order.Repository
{


    public class R_UsersRepository : BaseRepository, IRepository<r_user>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.r_user.Select(a => new SelectListItem() { Text = a.UserID, Value = a.UserID }).ToList();
            return dest.Format(value);
        }

        public string Add(r_user model)
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

        public bool Update(r_user model, string note = "")
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

        public r_user Find(object id)
        {
            return Db.r_user.NoTrackingFind(a=>a.UserID == (string) id);
        }

        public List<r_user> All()
        {
            return Db.r_user.NoTrackingToList();
        }

        public List<r_user> All(Func<r_user, bool> filter)
        {
            return Db.r_user.NoTrackingWhere(filter);
        }
    }
}

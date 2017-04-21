using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;
using System.Collections.Generic;
using System;
using System.Web.Mvc;
using System.Linq;

namespace Qx.Permission.Repository
{


    public class UserRoleRepository : BaseRepository, IRepository<user_role>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.user_role.Select(a => new SelectListItem() { Text = a.UserRoleID, Value = a.UserRoleID }).ToList();
            return dest.Format(value);
        }

        public string Add(user_role model)
        {
            model.UserRoleID = model.UserID+"-"+ model.RoleID;
            if (Find(model.UserRoleID) == null)
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

        public bool Update(user_role model, string note = "")
        {
            if (Find(model.UserRoleID) != null)
            {
                return Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public user_role Find(object id)
        {
            return Db.user_role.NoTrackingFind(a => a.UserRoleID == (string)id);
        }

        public List<user_role> All()
        {
            return Db.user_role.NoTrackingToList();
        }

        public List<user_role> All(Func<user_role, bool> filter)
        {
            return Db.user_role.NoTrackingWhere(filter);
        }
    }
}

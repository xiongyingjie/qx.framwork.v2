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


    public class UserRoleRepository : BaseRepository, IRepository<user_role>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.user_role.Select(a => new SelectListItem() { Text = a.user_role_id, Value = a.user_role_id }).ToList();
            return dest.Format(value);
        }

        public string Add(user_role model)
        {
            model.user_role_id = model.user_id+"-"+ model.role_id;
            if (Find(model.user_role_id) == null)
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
            if (Find(model.user_role_id) != null)
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
            return Db.user_role.NoTrackingFind(a => a.user_role_id == (string)id);
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

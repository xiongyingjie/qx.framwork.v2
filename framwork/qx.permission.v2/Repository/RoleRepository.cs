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


    public class RoleRepository : BaseRepository, IRepository<role>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.role.Select(a => new SelectListItem() { Text = a.role_id, Value = a.name }).ToList();
            return dest.Format(value);
        }

        public string Add(role model)
        {
            model.role_id = Pk;
            if (Find(model.role_id) == null)
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

        public bool Update(role model, string note = "")
        {
            if (Find(model.role_id) != null)
            {
                return Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public role Find(object id)
        {
            return Db.role.NoTrackingFind(a => a.role_id == (string)id);
        }

        public List<role> All()
        {
            return Db.role.NoTrackingToList();
        }

        public List<role> All(Func<role, bool> filter)
        {
            return Db.role.NoTrackingWhere(filter);
        }
    }
}

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


    public class RoleGroupRepository : BaseRepository, IRepository<role_group>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.role_group.Select(a => new SelectListItem() { Text = a.role_group_id, Value = a.role_group_name }).ToList();
            return dest.Format(value);
        }

        public string Add(role_group model)
        {
            if (Find(model.role_group_id) == null)
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

        public bool Update(role_group model, string note = "")
        {
            if (Find(model.role_group_id) != null)
            {
                return Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public role_group Find(object id)
        {
            return Db.role_group.NoTrackingFind(a => a.role_group_id == (string)id);
        }

        public List<role_group> All()
        {
            return Db.role_group.NoTrackingToList();
        }

        public List<role_group> All(Func<role_group, bool> filter)
        {
            return Db.role_group.NoTrackingWhere(filter);
        }
    }
}

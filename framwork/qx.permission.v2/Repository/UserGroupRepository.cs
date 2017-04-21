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


    public class UserGroupRepository : BaseRepository, IRepository<user_group>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.user_group.Select(a => new SelectListItem() { Text = a.user_group_id, Value = a.user_group_name }).ToList();
            return dest.Format(value);
        }

        public string Add(user_group model)
        {
            model.user_group_id = Pk;
            if (Find(model.user_group_id) == null)
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

        public bool Update(user_group model, string note = "")
        {
            if (Find(model.user_group_id) != null)
            {
                return Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public user_group Find(object id)
        {
            return Db.user_group.NoTrackingFind(a => a.user_group_id == (string)id);
        }

        public List<user_group> All()
        {
            return Db.user_group.NoTrackingToList();
        }

        public List<user_group> All(Func<user_group, bool> filter)
        {
            return Db.user_group.NoTrackingWhere(filter);
        }
    }
}

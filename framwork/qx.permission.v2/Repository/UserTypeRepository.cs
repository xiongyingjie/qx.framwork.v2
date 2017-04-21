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


    public class UserTypeRepository : BaseRepository, IRepository<user_type>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.user_type.Select(a => new SelectListItem() { Text = a.user_type_id, Value = a.name }).ToList();
            return dest.Format(value);
        }

        public string Add(user_type model)
        {
            model.user_type_id = Pk;
            if (Find(model.user_type_id) == null)
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

        public bool Update(user_type model, string note = "")
        {
            if (Find(model.user_type_id) != null)
            {
                return Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public user_type Find(object id)
        {
            return Db.user_type.NoTrackingFind(a => a.user_type_id == (string)id);
        }

        public List<user_type> All()
        {
            return Db.user_type.NoTrackingToList();
        }

        public List<user_type> All(Func<user_type, bool> filter)
        {
            return Db.user_type.NoTrackingWhere(filter);
        }
    }
}

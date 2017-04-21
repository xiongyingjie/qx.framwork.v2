using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
namespace Qx.Permission.Repository
{


    public class RoleRepository : BaseRepository, IRepository<role>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.role.Select(a => new SelectListItem() { Text = a.RoleID, Value = a.Name }).ToList();
            return dest.Format(value);
        }

        public string Add(role model)
        {
            model.RoleID = Pk;
            if (Find(model.RoleID) == null)
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
            if (Find(model.RoleID) != null)
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
            return Db.role.NoTrackingFind(a => a.RoleID == (string)id);
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

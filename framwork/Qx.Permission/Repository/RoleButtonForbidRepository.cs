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


    public class RoleButtonForbidRepository : BaseRepository, IRepository<role_button_forbid>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.role_button_forbid.Select(a => new SelectListItem() { Text = a.RoleButtonForbidID, Value = a.RoleButtonForbidID }).ToList();
            return dest.Format(value);
        }

        public string Add(role_button_forbid model)
        {
            model.RoleButtonForbidID = model.RoleID+"-"+ model.ButtonID;
            if (Find(model.RoleButtonForbidID) == null)
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

        public bool Update(role_button_forbid model, string note = "")
        {
            if (Find(model.RoleButtonForbidID) != null)
            {
                return Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public role_button_forbid Find(object id)
        {
            return Db.role_button_forbid.NoTrackingFind(a => a.RoleButtonForbidID == (string)id);
        }

        public List<role_button_forbid> All()
        {
            return Db.role_button_forbid.NoTrackingToList();
        }

        public List<role_button_forbid> All(Func<role_button_forbid, bool> filter)
        {
            return Db.role_button_forbid.NoTrackingWhere(filter);
        }
    }
}

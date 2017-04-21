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


    public class RoleButtonForbidRepository : BaseRepository, IRepository<role_button_forbid>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.role_button_forbid.Select(a => new SelectListItem() { Text = a.role_Button_forbid_id, Value = a.role_Button_forbid_id }).ToList();
            return dest.Format(value);
        }

        public string Add(role_button_forbid model)
        {
            model.role_Button_forbid_id = model.role_id+"-"+ model.button_id;
            if (Find(model.role_Button_forbid_id) == null)
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
            if (Find(model.role_Button_forbid_id) != null)
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
            return Db.role_button_forbid.NoTrackingFind(a => a.role_Button_forbid_id == (string)id);
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

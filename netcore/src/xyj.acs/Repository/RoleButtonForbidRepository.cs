using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class RoleButtonForbidRepository : BaseRepository, IRepository<role_button_forbid>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            return Db.role_button_forbid.ToItems( v => v.role_Button_forbid_id,t => t.role_Button_forbid_id);
        }

        public string Add(role_button_forbid model)
        {
            model.role_Button_forbid_id = model.role_id+"-"+ model.button_id;
            return Find(model.role_Button_forbid_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(role_button_forbid model, string note = "")
        {
            Db.role_button_forbid.Update(model);
            return Db.Saved();
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

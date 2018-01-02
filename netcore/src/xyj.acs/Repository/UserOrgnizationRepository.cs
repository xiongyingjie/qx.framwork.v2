using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class UserOrgnizationRepository : BaseRepository, IRepository<user_orgnization>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            return Db.user_orgnization.ToItems(v => v.user_orgnization_id,t => t.user_orgnization_id);
        }

        public string Add(user_orgnization model)
        {
            model.user_orgnization_id = Pk;
            return Find(model.user_orgnization_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(user_orgnization model, string note = "")
        {
            Db.user_orgnization.Update(model);
            return Db.Saved();
        }

        public user_orgnization Find(object id)
        {
            return Db.user_orgnization.NoTrackingFind(a => a.user_orgnization_id == (string)id);
        }

        public List<user_orgnization> All()
        {
            return Db.user_orgnization.NoTrackingToList();
        }

        public List<user_orgnization> All(Func<user_orgnization, bool> filter)
        {
            return Db.user_orgnization.NoTrackingWhere(filter);
        }
    }
}

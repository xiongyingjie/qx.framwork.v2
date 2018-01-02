using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using System.Data.Entity.Migrations;
namespace qx.permmision.v2.Repository
{


    public class UserTypeRepository : BaseRepository, IRepository<user_type>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.user_type.ToItems(v => v.user_type_id, t => t.name);
        }

        public string Add(user_type model)
        {
            model.user_type_id = Pk;
            return Find(model.user_type_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(user_type model, string note = "")
        {
            Db.user_type.AddOrUpdate(model);
            return Db.Saved();
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

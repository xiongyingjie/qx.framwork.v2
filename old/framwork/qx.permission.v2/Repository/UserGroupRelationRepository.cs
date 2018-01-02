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


    public class UserGroupRelationRepository : BaseRepository, IRepository<user_group_relation>
    {

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.user_group_relation.ToItems(v => v.user_group_relation_id, t => t.user_group_relation_id);
         
        }

        public string Add(user_group_relation model)
        {
            model.user_group_relation_id = Pk;
            return Find(model.user_group_relation_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(user_group_relation model, string note = "")
        {
            Db.user_group_relation.AddOrUpdate(model);
            return Db.Saved();
        }

        public user_group_relation Find(object id)
        {
            return Db.user_group_relation.NoTrackingFind(a => a.user_group_relation_id == (string)id);
        }

        public List<user_group_relation> All()
        {
            return Db.user_group_relation.NoTrackingToList();
        }

        public List<user_group_relation> All(Func<user_group_relation, bool> filter)
        {
            return Db.user_group_relation.NoTrackingWhere(filter);
        }
    }
}

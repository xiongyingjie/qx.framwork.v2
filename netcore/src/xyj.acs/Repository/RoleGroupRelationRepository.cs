using System;
using System.Collections.Generic;
using xyj.acs.Entity;
using xyj.acs.Services;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Repository
{


    public class RoleGroupRelationRepository : BaseRepository, IRepository<role_group_relation>
    {

        public List<DropDownListItem> ToSelectItems(string value = "")
        {
          
            return Db.role_group_relation.ToItems( v => v.role_group_relation_id, t => t.role_group_relation_id);
        }

        public string Add(role_group_relation model)
        {
            model.role_group_relation_id = Pk;
            if (Find(model.role_group_relation_id) == null)
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

        public bool Update(role_group_relation model, string note = "")
        {
            Db.role_group_relation.Update(model);
            return Db.Saved();
        }

        public role_group_relation Find(object id)
        {
            return Db.role_group_relation.NoTrackingFind(a => a.role_group_relation_id == (string)id);
        }

        public List<role_group_relation> All()
        {
            return Db.role_group_relation.NoTrackingToList();
        }

        public List<role_group_relation> All(Func<role_group_relation, bool> filter)
        {
            return Db.role_group_relation.NoTrackingWhere(filter);
        }
    }
}

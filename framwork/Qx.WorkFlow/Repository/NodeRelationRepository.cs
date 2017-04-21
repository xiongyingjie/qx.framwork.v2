using System;
using System.Collections.Generic;
using System.Linq;
using Qx.WorkFlow.Entity;
using Qx.WorkFlow.Services;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace Qx.WorkFlow.Repository
{

    public class NodeRelationRepository : BaseRepository, IRepository<NodeRelation>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.NodeRelations.Select(a => new SelectListItem() { Text = a.NodeRelationID, Value = a.Note }).ToList();
            return dest.Format(value);
        }

        public string Add(NodeRelation model)
        {
            model.NodeRelationID = Pk;
            if (Find(model.NodeRelationID) == null)
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

        public bool Update(NodeRelation model, string note = "")
        {
            if (Find(model.NodeRelationID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public NodeRelation Find(object id)
        {
            return Db.NodeRelations.NoTrackingFind(a=>a.NodeRelationID == (string) id);
        }

        public List<NodeRelation> All()
        {
            return Db.NodeRelations.NoTrackingToList();
        }

        public List<NodeRelation> All(Func<NodeRelation, bool> filter)
        {
            return Db.NodeRelations.NoTrackingWhere(filter);
        }
    }
}

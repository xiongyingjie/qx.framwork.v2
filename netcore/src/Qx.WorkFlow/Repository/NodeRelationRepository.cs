using System;
using System.Collections.Generic;
using System.Linq;
using Qx.WorkFlow.Entity;
using Qx.WorkFlow.Services;

using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Qx.Tools.Models.Report;

namespace Qx.WorkFlow.Repository
{

    public class NodeRelationRepository : BaseRepository, IRepository<NodeRelation>
    {
        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            var dest = Db.NodeRelation.Select(a => new DropDownListItem() { Text = a.NodeRelationID, Value = a.Note }).ToList();
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
            return Db.NodeRelation.NoTrackingFind(a=>a.NodeRelationID == (string) id);
        }

        public List<NodeRelation> All()
        {
            return Db.NodeRelation.NoTrackingToList();
        }

        public List<NodeRelation> All(Func<NodeRelation, bool> filter)
        {
            return Db.NodeRelation.NoTrackingWhere(filter);
        }
    }
}

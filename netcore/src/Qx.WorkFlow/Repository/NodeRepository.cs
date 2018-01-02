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

    public class NodeRepository : BaseRepository, IRepository<Node>
    {
        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            var dest = Db.Node.Select(a => new DropDownListItem() { Text = a.NodeID, Value = a.Name }).ToList();
            return dest.Format(value);
        }

        public string Add(Node model)
        {
            model.NodeID = Pk;
            if (Find(model.NodeID) == null)
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

        public bool Update(Node model, string note = "")
        {
            if (Find(model.NodeID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public Node Find(object id)
        {
            return Db.Node.NoTrackingFind(a=>a.NodeID == (string) id);
        }

        public List<Node> All()
        {
            return Db.Node.NoTrackingToList();
        }

        public List<Node> All(Func<Node, bool> filter)
        {
            return Db.Node.NoTrackingWhere(filter);
        }
    }
}

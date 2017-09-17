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

    public class WorkFlowRepository : BaseRepository, IRepository<Entity.WorkFlow>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.WorkFlow.Select(a => new SelectListItem() { Text = a.WorkFlowID, Value = a.Name }).ToList();
            return dest.Format(value);
        }

        public string Add(Entity.WorkFlow model)
        {
            model.WorkFlowID = Pk;
            if (Find(model.WorkFlowID) == null)
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

        public bool Update(Entity.WorkFlow model, string note = "")
        {
            if (Find(model.WorkFlowID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public Entity.WorkFlow Find(object id)
        {
            return Db.WorkFlow.NoTrackingFind(a=>a.WorkFlowID == (string) id);
        }

        public List<Entity.WorkFlow> All()
        {
            return Db.WorkFlow.NoTrackingToList();
        }

        public List<Entity.WorkFlow> All(Func<Entity.WorkFlow, bool> filter)
        {
            return Db.WorkFlow.NoTrackingWhere(filter);
        }
    }
}

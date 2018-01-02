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

    public class WorkFlowInstanceRepository : BaseRepository, IRepository<WorkFlowInstance>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.WorkFlowInstance.Select(a => new SelectListItem() { Text = a.WorkFlowInstanceID, Value = a.Note }).ToList();
            return dest.Format(value);
        }

        public string Add(WorkFlowInstance model)
        {
            model.WorkFlowInstanceID = Pk;
            if (Find(model.WorkFlowInstanceID) == null)
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

        public bool Update(WorkFlowInstance model, string note = "")
        {
            if (Find(model.WorkFlowInstanceID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public WorkFlowInstance Find(object id)
        {
            return Db.WorkFlowInstance.NoTrackingFind(a=>a.WorkFlowInstanceID == (string) id);
        }

        public List<WorkFlowInstance> All()
        {
            return Db.WorkFlowInstance.NoTrackingToList();
        }

        public List<WorkFlowInstance> All(Func<WorkFlowInstance, bool> filter)
        {
            return Db.WorkFlowInstance.NoTrackingWhere(filter);
        }
    }
}

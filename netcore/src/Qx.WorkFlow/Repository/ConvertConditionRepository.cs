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

    public class ConvertConditionRepository : BaseRepository, IRepository<ConvertCondition>
    {
        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ConvertCondition.Select(a => new DropDownListItem() { Text = a.ConvertConditionID, Value = a.ConditionNote }).ToList();
            return dest.Format(value);
        }

        public string Add(ConvertCondition model)
        {
            model.ConvertConditionID = Pk;
            if (Find(model.ConvertConditionID) == null)
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

        public bool Update(ConvertCondition model, string note = "")
        {
            if (Find(model.ConvertConditionID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public ConvertCondition Find(object id)
        {
            return Db.ConvertCondition.NoTrackingFind(a=>a.ConvertConditionID == (string) id);
        }

        public List<ConvertCondition> All()
        {
            return Db.ConvertCondition.NoTrackingToList();
        }

        public List<ConvertCondition> All(Func<ConvertCondition, bool> filter)
        {
            return Db.ConvertCondition.NoTrackingWhere(filter);
        }
    }
}

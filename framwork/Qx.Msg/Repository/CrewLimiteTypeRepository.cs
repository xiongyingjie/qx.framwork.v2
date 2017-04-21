using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Msg.Entity;
using Qx.Msg.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace Qx.Msg.Repository
{


    public class CrewLimiteTypeRepository : BaseRepository, IRepository<crew_limite_type>
    {
        public List<SelectListItem> ToSelectItems(string value="")
        {
            var dest = Db.crew_limite_type.Select(a => new SelectListItem() { Text = a.CrewLimite.Value.ToString(), Value = a.CrewLimiteTypeID }).ToList();
            return dest.Format(value);
        }

        public string Add(crew_limite_type model)
        {
            model.CrewLimiteTypeID = Pk;
            if (Find(model.CrewLimiteTypeID) == null)
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

        public bool Update(crew_limite_type model, string note = "")
        {
            if (Find(model.CrewLimiteTypeID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public crew_limite_type Find(object id)
        {
            return Db.crew_limite_type.NoTrackingFind(a=>a.CrewLimiteTypeID == (string)id);
        }

        public List<crew_limite_type> All()
        {
            return Db.crew_limite_type.NoTrackingToList();
        }

        public List<crew_limite_type> All(Func<crew_limite_type, bool> filter)
        {
            return Db.crew_limite_type.NoTrackingWhere(filter);
        }
    }
}

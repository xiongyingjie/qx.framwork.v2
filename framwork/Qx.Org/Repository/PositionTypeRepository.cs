using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Org.Entity;
using Qx.Org.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace Qx.Org.Repository
{

    public class PositionTypeRepository : BaseRepository, IRepository<PositionType>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.PositionTypes.Select(a => new SelectListItem() { Text = a.Name, Value = a.PositionTypeID }).ToList();
            return dest.Format(value);
        }

        public string Add(PositionType model)
        {
            model.PositionTypeID = Pk;
            if (Find(model.PositionTypeID) == null)
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

        public bool Update(PositionType model, string note = "")
        {
            if (Find(model.PositionTypeID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public PositionType Find(object id)
        {
            return Db.PositionTypes.NoTrackingFind(a=>a.PositionTypeID == (string) id);
        }

        public List<PositionType> All()
        {
            return Db.PositionTypes.NoTrackingToList();
        }

        public List<PositionType> All(Func<PositionType, bool> filter)
        {
            return Db.PositionTypes.NoTrackingWhere(filter);
        }
    }
}

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

    public class PositionRepository : BaseRepository, IRepository<Position>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.Positions.Select(a => new SelectListItem() { Text =a.Name, Value = a.PositionID }).ToList();
            return dest.Format(value);
        }

        public string Add(Position model)
        {
            model.PositionID = Pk;
            if (Find(model.PositionID) == null)
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

        public bool Update(Position model, string note = "")
        {
            if (Find(model.PositionID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public Position Find(object id)
        {
            return Db.Positions.NoTrackingFind(a=>a.PositionID == (string) id);
        }

        public List<Position> All()
        {
            return Db.Positions.NoTrackingToList();
        }

        public List<Position> All(Func<Position, bool> filter)
        {
            return Db.Positions.NoTrackingWhere(filter);
        }
    }
}

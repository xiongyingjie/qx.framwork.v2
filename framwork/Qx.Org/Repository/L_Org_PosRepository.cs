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

    public class L_Org_PosRepository : BaseRepository, IRepository<L_Org_Pos>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.L_Org_Pos.Select(a => new SelectListItem() { Text = a.Position.Name, Value = a.L_O_P_ID }).ToList();
            return dest.Format(value);
        }

        public string Add(L_Org_Pos model)
        {
            model.L_O_P_ID = Pk;
            if (Find(model.L_O_P_ID) == null)
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

        public bool Update(L_Org_Pos model, string note = "")
        {
            if (Find(model.L_O_P_ID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public L_Org_Pos Find(object id)
        {
            return Db.L_Org_Pos.NoTrackingFind(a=>a.L_O_P_ID == (string) id);
        }

        public List<L_Org_Pos> All()
        {
            return Db.L_Org_Pos.NoTrackingToList();
        }

        public List<L_Org_Pos> All(Func<L_Org_Pos, bool> filter)
        {
            return Db.L_Org_Pos.NoTrackingWhere(filter);
        }
    }
}

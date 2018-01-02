using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Djk.Org.Entity;
using Djk.Org.Services;
using Qx.Tools.Interfaces;
using System.Linq;
using Qx.Tools.CommonExtendMethods;

namespace Djk.Org.Repository
{

    public class COrgAccTypeRepository : BaseRepository, IRepository<C_OrgAccType>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.C_OrgAccType.Select(a => new SelectListItem() { Text = a.AccTypeName, Value = a.AccTypeID }).ToList();
            return dest.Format(value);
        }

        public string Add(C_OrgAccType model)
        {
            model.AccTypeID = Pk;
            if (Find(model.AccTypeID) == null)
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

        public bool Update(C_OrgAccType model, string note = "")
        {
            if (Find(model.AccTypeID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public C_OrgAccType Find(object id)
        {
            return Db.C_OrgAccType.NoTrackingFind(a=>a.AccTypeID == (string) id);
        }

        public List<C_OrgAccType> All()
        {
            return Db.C_OrgAccType.NoTrackingToList();
        }

        public List<C_OrgAccType> All(Func<C_OrgAccType, bool> filter)
        {
            return Db.C_OrgAccType.NoTrackingWhere(filter);
        }
    }
}

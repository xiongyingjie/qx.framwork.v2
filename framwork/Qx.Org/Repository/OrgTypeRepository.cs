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

    public class OrgTypeRepository : BaseRepository, IRepository<OrgType>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.OrgTypes.Select(a => new SelectListItem() { Text = a.TypeName, Value = a.TypeID }).ToList();
            return dest.Format(value);
        }

        public string Add(OrgType model)
        {
            model.TypeID = Pk;
            if (Find(model.TypeID) == null)
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

        public bool Update(OrgType model, string note = "")
        {
            if (Find(model.TypeID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public OrgType Find(object id)
        {
            return Db.OrgTypes.NoTrackingFind(a=>a.TypeID == (string) id);
        }

        public List<OrgType> All()
        {
            return Db.OrgTypes.NoTrackingToList();
        }

        public List<OrgType> All(Func<OrgType, bool> filter)
        {
            return Db.OrgTypes.NoTrackingWhere(filter);
        }
    }
}

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

    public class OrgAssetTypeRepository : BaseRepository, IRepository<OrgAssetType>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.OrgAssetTypes.Select(a => new SelectListItem() { Text = a.Name, Value = a.TypeID.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(OrgAssetType model)
        {
            model.TypeID = Pk.ToInt();
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

        public bool Update(OrgAssetType model, string note = "")
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

        public OrgAssetType Find(object id)
        {
            return Db.OrgAssetTypes.NoTrackingFind(a => a.TypeID.ToString() == (string)id);
        }

        public List<OrgAssetType> All()
        {
            return Db.OrgAssetTypes.NoTrackingToList();
        }

        public List<OrgAssetType> All(Func<OrgAssetType, bool> filter)
        {
            return Db.OrgAssetTypes.NoTrackingWhere(filter);
        }
    }
}

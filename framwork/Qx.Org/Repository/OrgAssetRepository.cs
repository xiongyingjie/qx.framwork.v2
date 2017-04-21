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

    public class OrgAssetRepository : BaseRepository, IRepository<OrgAsset>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.OrgAssets.Select(a => new SelectListItem() { Text = a.Name, Value = a.OrgAssetID }).ToList();
            return dest.Format(value);
        }

        public string Add(OrgAsset model)
        {
            model.OrgAssetID = Pk;
            if (Find(model.OrgAssetID) == null)
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

        public bool Update(OrgAsset model, string note = "")
        {
            if (Find(model.OrgAssetID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public OrgAsset Find(object id)
        {
            return Db.OrgAssets.NoTrackingFind(a=>a.OrgAssetID == (string) id);
        }

        public List<OrgAsset> All()
        {
            return Db.OrgAssets.NoTrackingToList();
        }

        public List<OrgAsset> All(Func<OrgAsset, bool> filter)
        {
            return Db.OrgAssets.NoTrackingWhere(filter);
        }
    }
}

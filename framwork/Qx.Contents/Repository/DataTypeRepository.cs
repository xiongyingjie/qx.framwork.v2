using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Contents.Entity;
using Qx.Contents.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace Qx.Contents.Repository
{
    public class DataTypeRepository : BaseRepository, IRepository<data_type>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.data_type.Select(a => new SelectListItem {Text = a.TypeName, Value = a.DT_ID}).ToList();
            return dest.Format(value);
        }

        public string Add(data_type model)
        {
            model.DT_ID = Pk;
            if (Find(model.DT_ID) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            return "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(data_type model, string note = "")
        {
            if (Find(model.DT_ID) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public data_type Find(object id)
        {
            return Db.data_type.NoTrackingFind(a => a.DT_ID == (string) id);
        }

        public List<data_type> All()
        {
            return Db.data_type.NoTrackingToList();
        }

        public List<data_type> All(Func<data_type, bool> filter)
        {
            return Db.data_type.NoTrackingWhere(filter);
        }
    }
}
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
    public class ContentTypeRepository : BaseRepository, IRepository<content_type>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.content_type.Select(a => new SelectListItem {Text = a.TypeName, Value = a.CT_ID}).ToList();
            return dest.Format(value);
        }

        public string Add(content_type model)
        {
            model.CT_ID = Pk;
            if (Find(model.CT_ID) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            return "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(content_type model, string note = "")
        {
            if (Find(model.CT_ID) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public content_type Find(object id)
        {
            return Db.content_type.NoTrackingFind(a => a.CT_ID == (string) id);
        }

        public List<content_type> All()
        {
            return Db.content_type.NoTrackingToList();
        }

        public List<content_type> All(Func<content_type, bool> filter)
        {
            return Db.content_type.NoTrackingWhere(filter);
        }
    }
}
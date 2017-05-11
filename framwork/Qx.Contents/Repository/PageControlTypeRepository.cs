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
    public class PageControlTypeRepository : BaseRepository, IRepository<page_control_type>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest =
                Db.page_control_type.Select(a => new SelectListItem {Text = a.pct_name, Value = a.pct_id}).ToList();
            return dest.Format(value);
        }

        public string Add(page_control_type model)
        {
            model.pct_id = Pk;
            if (Find(model.pct_id) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            return "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(page_control_type model, string note = "")
        {
            if (Find(model.pct_id) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public page_control_type Find(object id)
        {
            return Db.page_control_type.NoTrackingFind(a => a.pct_id == (string) id);
        }

        public List<page_control_type> All()
        {
            return Db.page_control_type.NoTrackingToList();
        }

        public List<page_control_type> All(Func<page_control_type, bool> filter)
        {
            return Db.page_control_type.NoTrackingWhere(filter);
        }
    }
}
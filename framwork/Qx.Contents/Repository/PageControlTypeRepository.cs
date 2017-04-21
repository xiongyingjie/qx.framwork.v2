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
                Db.page_control_type.Select(a => new SelectListItem {Text = a.PCT_Name, Value = a.PCT_ID}).ToList();
            return dest.Format(value);
        }

        public string Add(page_control_type model)
        {
            model.PCT_ID = Pk;
            if (Find(model.PCT_ID) == null)
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
            if (Find(model.PCT_ID) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public page_control_type Find(object id)
        {
            return Db.page_control_type.NoTrackingFind(a => a.PCT_ID == (string) id);
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
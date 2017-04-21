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
    public class ContentColumnDesignRepository : BaseRepository, IRepository<content_column_design>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest =
                Db.content_column_design.Select(a => new SelectListItem {Text = a.ColumnName, Value = a.CCD_ID}).ToList();
            return dest.Format(value);
        }

        public string Add(content_column_design model)
        {
            model.CCD_ID = Pk;
            if (Find(model.CCD_ID) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            return "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(content_column_design model, string note = "")
        {
            if (Find(model.CCD_ID) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public content_column_design Find(object id)
        {
            return Db.content_column_design.NoTrackingFind(a => a.CCD_ID == (string) id);
        }

        public List<content_column_design> All()
        {
            return Db.content_column_design.NoTrackingToList();
        }

        public List<content_column_design> All(Func<content_column_design, bool> filter)
        {
            return Db.content_column_design.NoTrackingWhere(filter);
        }
    }
}
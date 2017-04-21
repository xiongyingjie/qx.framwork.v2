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
    public class ContentColumnValueRepository : BaseRepository, IRepository<content_column_value>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest =
                Db.content_column_value.Select(a => new SelectListItem {Text = a.ColumnValue, Value = a.CCV_ID}).ToList();
            return dest.Format(value);
        }

        public string Add(content_column_value model)
        {
            model.CCV_ID = Pk;
            if (Find(model.CCV_ID) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            return "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(content_column_value model, string note = "")
        {
            if (Find(model.CCV_ID) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public content_column_value Find(object id)
        {
            return Db.content_column_value.NoTrackingFind(a => a.CCV_ID == (string) id);
        }

        public List<content_column_value> All()
        {
            return Db.content_column_value.NoTrackingToList();
        }

        public List<content_column_value> All(Func<content_column_value, bool> filter)
        {
            return Db.content_column_value.NoTrackingWhere(filter);
        }
    }
}
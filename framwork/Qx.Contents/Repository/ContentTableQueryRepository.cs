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
    public class ContentTableQueryRepository : BaseRepository, IRepository<content_table_query>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest =
                Db.content_table_query.Select(a => new SelectListItem {Text = a.ctq_id, Value = a.ctq_id}).ToList();
            return dest.Format(value);
        }

        public string Add(content_table_query model)
        {
            model.ctq_id = Pk;
            if (Find(model.ctq_id) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            return "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(content_table_query model, string note = "")
        {
            if (Find(model.ctq_id) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public content_table_query Find(object id)
        {
            return Db.content_table_query.NoTrackingFind(a => a.ctq_id == (string) id);
        }

        public List<content_table_query> All()
        {
            return Db.content_table_query.NoTrackingToList();
        }

        public List<content_table_query> All(Func<content_table_query, bool> filter)
        {
            return Db.content_table_query.NoTrackingWhere(filter);
        }
    }
}
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
                Db.dontent_column_value.Select(a => new SelectListItem {Text = a.column_value, Value = a.ccv_id}).ToList();
            return dest.Format(value);
        }

        public string Add(content_column_value model)
        {
            model.ccv_id = Pk;
            if (Find(model.ccv_id) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            return "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool DeleteByRelationkeyID(string relationkey)
        {
            return Db.SaveDelete(Db.dontent_column_value.NoTrackingFind(a=>a.relation_key_value == relationkey));
        }

        public bool Update(content_column_value model, string note = "")
        {
            if (Find(model.ccv_id) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public content_column_value Find(object id)
        {
            return Db.dontent_column_value.NoTrackingFind(a => a.ccv_id == (string) id);
        }

        public List<content_column_value> All()
        {
            return Db.dontent_column_value.NoTrackingToList();
        }

        public List<content_column_value> All(Func<content_column_value, bool> filter)
        {
            return Db.dontent_column_value.NoTrackingWhere(filter);
        }
    }
}
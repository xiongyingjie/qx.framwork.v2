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
    public class ContentTableDesignRepository : BaseRepository, IRepository<content_table_design>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest =
                Db.content_table_design.Select(a => new SelectListItem {Text = a.TableName, Value = a.CTD_ID}).ToList();
            return dest.Format(value);
        }

        public string Add(content_table_design model)
        {
            model.CTD_ID = Pk;
            if (Find(model.CTD_ID) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            return "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(content_table_design model, string note = "")
        {
            if (Find(model.CTD_ID) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public content_table_design Find(object id)
        {
            return Db.content_table_design.NoTrackingFind(a => a.CTD_ID == (string) id);
        }

        public List<content_table_design> All()
        {
            return Db.content_table_design.NoTrackingToList();
        }

        public List<content_table_design> All(Func<content_table_design, bool> filter)
        {
            return Db.content_table_design.NoTrackingWhere(filter);
        }
    }
}
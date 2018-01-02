using System;
using System.Collections.Generic;
using System.Linq;

using Qx.Contents.Entity;
using Qx.Contents.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Qx.Tools.Models.Report;

namespace Qx.Contents.Repository
{
    public class ContentTableDesignRepository : BaseRepository, IRepository<content_table_design>
    {
        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            var dest =
                Db.content_table_design.Select(a => new DropDownListItem {Text = a.table_name, Value = a.ctd_id}).ToList();
            return dest.Format(value);
        }

        public string Add(content_table_design model)
        {
            model.ctd_id = Pk;
            if (Find(model.ctd_id) == null)
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
            if (Find(model.ctd_id) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public content_table_design Find(object id)
        {
            return Db.content_table_design.NoTrackingFind(a => a.ctd_id == (string) id);
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
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
    public class ColumnDesignRepository : BaseRepository, IRepository<column_design>
    {
        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            var dest = Db.content_type.Select(a => new DropDownListItem { Text = a.type_name, Value = a.ct_id }).ToList();
            return dest.Format(value);
        }

        public string Add(column_design model)
        {
            model.column_design_id = Pk;
            if (Find(model.column_design_id) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            return "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(column_design model, string note = "")
        {
            if (Find(model.column_design_id) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public column_design Find(object id)
        {
            return Db.column_design.NoTrackingFind(a => a.column_design_id == (string)id);
        }

        public List<column_design> All()
        {
            return Db.column_design.NoTrackingToList();
        }

        public List<column_design> All(Func<column_design, bool> filter)
        {
            return Db.column_design.NoTrackingWhere(filter);
        }
    }
}

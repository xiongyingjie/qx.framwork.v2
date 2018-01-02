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
    public class ColumnTempelateRepository : BaseRepository, IRepository<column_tempelate>
    {
        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            var dest = Db.content_type.Select(a => new DropDownListItem { Text = a.type_name, Value = a.ct_id }).ToList();
            return dest.Format(value);
        }

        public string Add(column_tempelate model)
        {
            //model.ColumnTempelateID = new Guid(Pk);
            if (Find(model.column_tempelate_id) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            return "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(column_tempelate model, string note = "")
        {
            if (Find(model.column_tempelate_id) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public column_tempelate Find(object id)
        {
            return Db.column_tempelate.NoTrackingFind(a => a.column_tempelate_id == new Guid(id.ToString()));
        }

        public List<column_tempelate> All()
        {
            return Db.column_tempelate.NoTrackingToList();
        }

        public List<column_tempelate> All(Func<column_tempelate, bool> filter)
        {
            return Db.column_tempelate.NoTrackingWhere(filter);
        }
    }
}

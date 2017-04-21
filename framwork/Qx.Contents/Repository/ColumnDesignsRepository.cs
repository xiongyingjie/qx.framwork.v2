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
    public class ColumnDesignRepository : BaseRepository, IRepository<column_design>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.column_design.Select(a => new SelectListItem { Text = a.Name, Value = a.ColumnDesignID }).ToList();
            return dest.Format(value);
        }

        public string Add(column_design model)
        {
            model.ColumnDesignID = Pk;
            if (Find(model.ColumnDesignID) == null)
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
            if (Find(model.ColumnDesignID) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public column_design Find(object id)
        {
            return Db.column_design.NoTrackingFind(a => a.ColumnDesignID == (string)id);
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

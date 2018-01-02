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
    public class LibrarysRepository : BaseRepository, IRepository<librarys>
    {
        public List<DropDownListItem> ToSelectItems(string value = "")
        {
            var dest = Db.librarys.Select(a => new DropDownListItem { Text = a.name, Value = a.library_id }).ToList();
            return dest.Format(value);
        }

        public string Add(librarys model)
        {
            model.library_id = Pk;
            if (Find(model.library_id) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            return "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(librarys model, string note = "")
        {
            if (Find(model.library_id) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public librarys Find(object id)
        {
            return Db.librarys.NoTrackingFind(a => a.library_id == (string)id);
        }

        public List<librarys> All()
        {
            return Db.librarys.NoTrackingToList();
        }

        public List<librarys> All(Func<librarys, bool> filter)
        {
            return Db.librarys.NoTrackingWhere(filter);
        }
    }
}

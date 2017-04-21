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
    public class LibrarysRepository : BaseRepository, IRepository<library>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.library.Select(a => new SelectListItem { Text = a.Name, Value = a.LibraryID }).ToList();
            return dest.Format(value);
        }

        public string Add(library model)
        {
            model.LibraryID = Pk;
            if (Find(model.LibraryID) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            return "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(library model, string note = "")
        {
            if (Find(model.LibraryID) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public library Find(object id)
        {
            return Db.library.NoTrackingFind(a => a.LibraryID == (string)id);
        }

        public List<library> All()
        {
            return Db.library.NoTrackingToList();
        }

        public List<library> All(Func<library, bool> filter)
        {
            return Db.library.NoTrackingWhere(filter);
        }
    }
}

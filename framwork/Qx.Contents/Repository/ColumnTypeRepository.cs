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
    public class ColumnTypeRepository : BaseRepository, IRepository<conlumn_type>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.content_type.Select(a => new SelectListItem { Text = a.type_name, Value = a.ct_id }).ToList();
            return dest.Format(value);
        }

        public string Add(conlumn_type model)
        {
            model.column_type_id = Pk;
            if (Find(model.column_type_id) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            return "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(conlumn_type model, string note = "")
        {
            if (Find(model.column_type_id) != null)
            {
                return Db.SaveModified(model);
            }
            return false;
        }

        public conlumn_type Find(object id)
        {
            return Db.conlumn_type.NoTrackingFind(a => a.column_type_id == (string)id);
        }

        public List<conlumn_type> All()
        {
            return Db.conlumn_type.NoTrackingToList();
        }

        public List<conlumn_type> All(Func<conlumn_type, bool> filter)
        {
            return Db.conlumn_type.NoTrackingWhere(filter);
        }
    }
}

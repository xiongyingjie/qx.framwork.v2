/*
app_namespace=${model.app_namespace} 

repository_name=${model.repository_name}

table_name=${model.table_name}

table_column_pk=${model.table_column_pk}

table_column_name=${model.table_column_name}
*/

using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Web.Mvc;
using ${model.app_namespace}.Entity;
using ${model.app_namespace}.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace ${model.app_namespace}.Repository
{
    public class ${model.repository_name}Repository : BaseRepository, IRepository<${model.table_name}>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.${model.table_name}.ToItems(v => v.${model.table_column_pk}+"", t => t.name);
        }

        public string Add(${model.table_name} model)
        {
           return Find(model.${model.table_column_pk}) == null ? (Db.SaveAdd(model) ? model.${model.table_column_pk} : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(${model.table_name} model, string note = "")
        {
            Db.${model.table_name}.AddOrUpdate(model);
            return Db.Saved();
        }

        public ${model.table_name} Find(object id)
        {
            return Db.${model.table_name}.NoTrackingFind(a => a.${model.table_column_pk}.Trim() == ((string)id).Trim());
        }

        public List<${model.table_name}> All()
        {
            return Db.${model.table_name}.NoTrackingToList();
        }

        public List<${model.table_name}> All(Func<${model.table_name}, bool> filter)
        {
            return Db.${model.table_name}.NoTrackingWhere(filter);
        }
    }
}

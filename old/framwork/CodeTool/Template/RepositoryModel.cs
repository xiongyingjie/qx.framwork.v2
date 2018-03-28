using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyj.tool.Template
{
    public class RepositoryModel : BaseModel
    {
        public RepositoryModel(string appNamespace, string repositoryName, string tableName, string tableNote, string controllerArea, string controllerName, string tableColumnPk, string tableColumnName) : base(appNamespace, repositoryName, tableName, tableNote, controllerArea, controllerName)
        {
            table_column_pk = tableColumnPk;
            table_column_name = tableColumnName;
        }

        //public RepositoryModel()
        //{
        //    table_column_pk = "app_contact_person_id";
        //    table_column_name = "nike_name";
        //}
        public string table_column_pk { get; set; }
        public string table_column_name { get; set; }
    }
}

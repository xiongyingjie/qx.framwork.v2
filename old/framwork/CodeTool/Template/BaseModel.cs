using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyj.tool.Template
{
    public class BaseModel
    {
        public BaseModel(string appNamespace, string repositoryName, string tableName, string tableNote, string controllerArea, string controllerName)
        {
            app_namespace = appNamespace;
            repository_name = repositoryName;
            table_name = tableName;
            table_note = tableNote;
            controller_area = controllerArea;
            controller_name = controllerName;
        }

        public string app_namespace { get; set; }
        public string repository_name { get; set; }
        public string table_name { get; set; }
        public string table_note { get; set; }
        public string controller_area { get; set; }
        public string controller_name { get; set; }
        //public BaseModel()
        //{
        //    app_namespace = "hqu.scsxxt.v2";
        //    repository_name = "AppContactPerson";
        //    table_name = "app_contact_person";
        //    table_note = "通讯录";
        //    controller_area = "Json";
        //    controller_name = "Demo";
        //}
    }
}

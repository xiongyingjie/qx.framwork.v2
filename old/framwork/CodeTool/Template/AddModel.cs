using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyj.tool.Template
{
    public class AddModel: BaseModel
    {
        public string js { get; set; }

        public AddModel(string appNamespace, string repositoryName, string tableName, string tableNote, string controllerArea, string controllerName, string js) : base(appNamespace, repositoryName, tableName, tableNote, controllerArea, controllerName)
        {
            this.js = js;
        }

        //public AddModel()
        //{
        //    js = js="input('测试','test')";
        //}
    }
}

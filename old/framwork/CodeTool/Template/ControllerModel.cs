using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyj.tool.Template
{

    public class ControllerModel : BaseModel
    {
        public ControllerModel(string appNamespace, string repositoryName, string tableName, string tableNote, string controllerArea, string controllerName, string tableColumnPkNote, string reportTitle, string reportId, string @params, string pageIndex, string perCount, IEnumerable<Header> headers) : base(appNamespace, repositoryName, tableName, tableNote, controllerArea, controllerName)
        {
            table_column_pk_note = tableColumnPkNote;
            report_title = reportTitle;
            this.reportId = reportId;
            Params = @params;
            this.pageIndex = pageIndex;
            this.perCount = perCount;
            this.headers = headers;
        }

        //public ControllerModel()
        //{
        //    table_column_pk_note = "工号";
        //    report_title = "通讯录列表";
        //    reportId = "qx.test.dfssfsdf";
        //    Params = ";;;";
        //    pageIndex = "1";
        //    perCount = "10";
        //    headers = new List<Header>()
        //    {
        //        new Header()
        //        {
        //            name = "user_id",
        //            note = "工号"
        //        },  new Header()
        //        {
        //            name = "nike_name",
        //            note = "姓名"
        //        },  new Header()
        //        {
        //            name = "phone",
        //            note = "电话"
        //        }
        //    };  
        //}

        public string table_column_pk_note { get; set; }
        public string report_title { get; set; }
        public string reportId { get; set; }
        public string Params { get; set; }
        public string pageIndex { get; set; }
        public string perCount { get; set; }
        public IEnumerable<Header> headers { get; set; }

        public class Header
        {
            public string name { get; set; }
            public string note { get; set; }
        }
    }
}

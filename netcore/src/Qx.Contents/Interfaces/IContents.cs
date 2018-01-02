using System.Collections.Generic;
using System.Web;
using Microsoft.AspNetCore.Http;
using Qx.Contents.Models;
using Qx.Tools.Interfaces;

namespace Qx.Contents.Interfaces
{
    public interface IContents:IAutoInject
    {
        TableDesign GetTableDesign(string tableId);
       
        TableValue GetTableValue(string tableId, string relationKeyId);
        List<TableValue> GetTableValues(string tableId);

        bool UpdateTable(ContentBag contentValueBag);
        bool UpdateTable(HttpContext request, string tableId, string relationKeyId);
    }
}
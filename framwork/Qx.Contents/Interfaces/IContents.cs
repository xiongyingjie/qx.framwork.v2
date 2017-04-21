using System.Collections.Generic;
using System.Web;
using Qx.Contents.Models;

namespace Qx.Contents.Interfaces
{
    public interface IContents
    {
        TableDesign GetTableDesign(string tableId);
        TableValue GetTableValue(string tableId, string relationKeyId);
        List<TableValue> GetTableValues(string tableId);

        bool UpdateTable(ContentBag contentValueBag);
        bool UpdateTable(HttpRequestBase request, string tableId, string relationKeyId);
    }
}
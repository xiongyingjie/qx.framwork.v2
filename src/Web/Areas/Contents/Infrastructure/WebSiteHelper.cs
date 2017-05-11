using Qx.Contents.Repository;
using Qx.Contents.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Web.Infrastructure
{
    public class WebSiteHelper
    {
        private ColumnTempelateRepository _columnTempelate = new ColumnTempelateRepository();

        public MvcHtmlString TempelateFor(string tempelateKey)
        {
            var columnTemplete = _columnTempelate.Find(tempelateKey);
            var tempelete = columnTemplete.column_tempelate_html.Replace("\r\n", "");
            return MvcHtmlString.Create(tempelete);
        }
    }
}
using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Qx.Tools.Web.Mvc.Html
{
    public static class RichBoxExtensions
    {
        public static MvcHtmlString RichBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string tipString = "", int crossWidth = -1)
        {
            var dest = new StringBuilder();
            if (crossWidth != -1)
            {
                dest.Append("<div class='col-lg-" + crossWidth + "'>");
            }
            dest.Append("<div class='form-group'>");
            dest.Append(htmlHelper.LabelFor(expression, new {@class = "col-md-3 control-label"}));
            dest.Append(" <div class='col-md-9'>");
            dest.Append(htmlHelper.Partial("/Views/Templates/_KindEditor.cshtml", new ViewDataDictionary
            {
                {"css", ""},
                {"id", htmlHelper.IdFor(expression).ToString()},
                {"name", htmlHelper.NameFor(expression).ToString()},
                {"value", htmlHelper.DisplayFor(expression).ToString()}
            }));
            dest.Append("<span class='help-block'>");
            dest.Append(tipString);
            dest.Append(" </span>");
            dest.Append(" </div>");
            dest.Append(" </div>");
            if (crossWidth != -1)
            {
                dest.Append(" </div>");
            }
            return new MvcHtmlString(dest.ToString());
        }
    }
}
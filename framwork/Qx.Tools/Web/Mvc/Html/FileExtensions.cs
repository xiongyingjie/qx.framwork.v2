using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Qx.Tools.Web.Mvc.Html
{
    public static class FileExtensions
    {
        public static MvcHtmlString FileFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string saveDirectory, string tipString
            )
        {
            return File(htmlHelper,
                htmlHelper.LabelFor(expression, new {@class = "col-md-3 control-label"}).ToString(),
                htmlHelper.IdFor(expression).ToString(),
                htmlHelper.NameFor(expression).ToString(),
                saveDirectory,
                tipString
                );
            //var dest = new StringBuilder();
            //dest.Append("<div class='form-group'>");
            //dest.Append(htmlHelper.LabelFor(expression, new { @class = "col-md-3 control-label" }));
            //dest.Append(" <div class='col-md-9'>");
            //dest.Append(htmlHelper.Partial("/Views/Templates/_FileUpload.cshtml", new ViewDataDictionary()
            //{
            //    {"saveDirectory", saveDirectory},
            //    {"id", htmlHelper.IdFor(expression).ToString()},
            //    {"name", htmlHelper.NameFor(expression).ToString()}
            //}));
            //dest.Append("<span class='help-block'>");
            //dest.Append(tipString);
            //dest.Append(" </span>");
            //dest.Append(" </div>");
            //dest.Append(" </div>");

            //return new MvcHtmlString(dest.ToString());
        }

        public static MvcHtmlString FileFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string saveDirectory
            )
        {
            var dest = new StringBuilder();
            dest.Append(htmlHelper.Partial("/Views/Templates/_FileUpload.cshtml", new ViewDataDictionary
            {
                {"saveDirectory", saveDirectory},
                {"id", htmlHelper.IdFor(expression).ToString()},
                {"name", htmlHelper.NameFor(expression).ToString()}
            }));
            return new MvcHtmlString(dest.ToString());
        }

        public static MvcHtmlString File<TModel>(this HtmlHelper<TModel> htmlHelper,
            string lable, string id, string name, string saveDirectory, string tipString
            )
        {
            var dest = new StringBuilder();
            dest.Append("<div class='form-group'>");
            dest.Append("<Lable  class='col-md-3 control-label'>");
            dest.Append(lable);
            dest.Append("</Lable>");
            dest.Append(" <div class='col-md-9'>");
            dest.Append(htmlHelper.Partial("/Views/Templates/_FileUpload.cshtml", new ViewDataDictionary
            {
                {"saveDirectory", saveDirectory},
                {"id", id},
                {"name", name}
            }));
            dest.Append("<span class='help-block'>");
            dest.Append(tipString);
            dest.Append(" </span>");
            dest.Append(" </div>");
            dest.Append(" </div>");

            return new MvcHtmlString(dest.ToString());
        }
    }
}
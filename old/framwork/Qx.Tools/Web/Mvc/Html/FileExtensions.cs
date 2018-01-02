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
            Expression<Func<TModel, TProperty>> expression, string saveDirectory, string tipString, int crossWidth
            )
        {
            return File(htmlHelper,
                htmlHelper.LabelFor(expression, new {@class = "col-md-3 control-label"}).ToString(),
                htmlHelper.IdFor(expression).ToString(),
                htmlHelper.NameFor(expression).ToString(),
                saveDirectory,
                tipString,
                crossWidth
                );
        }

        public static MvcHtmlString FileFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string saveDirectory, int crossWidth = 4
            )
        {
            var dest = new StringBuilder();
            if (crossWidth != -1)
            {
                dest.Append("<div class='col-lg-" + crossWidth + "'>");
            }
            dest.Append(htmlHelper.Partial("/Views/Templates/_FileUpload.cshtml", new ViewDataDictionary
            {
                {"saveDirectory", saveDirectory},
                {"id", htmlHelper.IdFor(expression).ToString()},
                {"name", htmlHelper.NameFor(expression).ToString()}
            }));
            if (crossWidth != -1)
            {
                dest.Append(" </div>");
            }
            return new MvcHtmlString(dest.ToString());
        }

        public static MvcHtmlString File<TModel>(this HtmlHelper<TModel> htmlHelper,
            string lable, string id, string name, string saveDirectory, string tipString, int crossWidth=4
            )
        {
            var dest = new StringBuilder();
            if (crossWidth != -1)
            {
                dest.Append("<div class='col-lg-" + crossWidth + "'>");
            }
            dest.Append("<div class='form-group'>");
            dest.Append("<label>");
            dest.Append(lable);
            dest.Append("</label>");
            dest.Append(htmlHelper.Partial("/Views/Templates/_FileUpload.cshtml", new ViewDataDictionary
            {
                {"saveDirectory", saveDirectory},
                {"id", id},
                {"name", name}
            }));
          
            dest.Append("</div>");

            if (crossWidth != -1)
            {
                dest.Append(" </div>");
            }
            return new MvcHtmlString(dest.ToString());
        }

        public static MvcHtmlString FileFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
     Expression<Func<TModel, TProperty>> expression,
      int numberOfOneRow = 3, string saveDirectory="")
        {
            //宽度转换
            numberOfOneRow = 12 / numberOfOneRow;
            return FileFor(htmlHelper, expression, saveDirectory, numberOfOneRow);
        }
    }
}
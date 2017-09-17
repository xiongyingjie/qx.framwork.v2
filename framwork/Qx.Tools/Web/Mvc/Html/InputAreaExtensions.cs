using System;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Tools.Web.Mvc.Html
{
    public static class InputAreaExtensions
    {
        public static MvcHtmlString InputArea2For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string tipString = "", float width = 550, float height = 230, bool readOnly = false, int crossWidth = -1)
        {
            var dest = new StringBuilder();
            if (crossWidth != -1)
            {
                dest.Append("<div class='col-lg-" + crossWidth + "'>");
            }
            dest.Append("<div class='form-group'>");
            dest.Append(htmlHelper.LabelFor(expression, new {@class = "col-md-3 control-label"}));
            dest.Append(" <div class='col-md-9'>");
            dest.Append(readOnly
                ? htmlHelper.TextAreaFor(expression,
                    new
                    {
                        @class = "form-control",
                        @readonly = "readonly",
                        style = string.Format("width:{0}px;height:{1}px", width, height)
                    })
                : htmlHelper.TextAreaFor(expression,
                    new {@class = "form-control", style = string.Format("width:{0}px;height:{1}px", width, height)}));
            dest.Append("<span class='help-block'>");
            dest.Append(tipString.CheckValue("&nbsp;"));
            dest.Append(" </span>");
            dest.Append(" </div>");
            dest.Append(" </div>");
            if (crossWidth != -1)
            {
                dest.Append(" </div>");
            }
            return new MvcHtmlString(dest.ToString());
        }

        public static MvcHtmlString InputAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string tipString ,  float height, bool readOnly, int crossWidth)
        {
            var dest = new StringBuilder();
            if (crossWidth != -1)
            {
                dest.Append("<div class='col-lg-" + crossWidth + "'>");
            }
            dest.Append("<div class='form-group'>");
            dest.Append("<label>");
            dest.Append(htmlHelper.DisplayNameFor(expression));
            dest.Append("</label>");

            dest.Append(readOnly
                ? "<textarea class=\"form-control\" readonly=\"readonly\" rows=\"3\" name=\""+ htmlHelper.NameFor(expression) + "\"   style=\"" + string.Format("height:{0}px", height) + "\">"
                : "<textarea class=\"form-control\" rows=\"3\" name=\""+ htmlHelper.NameFor(expression) + "\"   style=\"" + string.Format("height:{0}px", height) + "\">");
            dest.Append(htmlHelper.DisplayFor(expression));
            dest.Append("</textarea>");

            dest.Append("<p class=\"help-block\">");
            dest.Append(tipString.CheckValue("&nbsp;"));
            dest.Append("</p>");
            dest.Append("</div>");
            if (crossWidth != -1)
            {
                dest.Append(" </div>");
            }
            return new MvcHtmlString(dest.ToString());
        }
      
        public static MvcHtmlString InputAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, int numberOfOneRow = 1,
            string tipString = "", float height = 230, bool readOnly = false)
        {
            //宽度转换
            numberOfOneRow = 12 / numberOfOneRow;
            return InputAreaFor<TModel, TProperty>(htmlHelper, expression, tipString, height, readOnly, numberOfOneRow);
        }
       
    }
}
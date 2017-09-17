using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Tools.Web.Mvc.Html
{
    public static class TimeExtensions
    {
        public static MvcHtmlString TimeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string tipString, int crossWidth = 4)
        {

            var value = htmlHelper.DisplayFor(expression).ToString().ToDateTime().FormatTime();

            var dest = new StringBuilder();
            if (crossWidth != -1)
            {
                dest.Append("<div class='col-lg-" + crossWidth + "'>");
            }
            dest.Append("<div class='form-group'>");
            dest.Append("<label>");
            dest.Append(htmlHelper.DisplayNameFor(expression));
            dest.Append("</label>");
            dest.Append("<div class='input-group date form_datetime'>");
            dest.Append("<input type = 'text' size='16' id='" + htmlHelper.IdFor(expression) +
                "'name='" + htmlHelper.NameFor(expression) +
                "'value='" + value + "' readonly=''class='form-control'>");
            dest.Append(" <span class='input-group-btn'>");
            dest.Append("<button class='btn btn-success date-set' type='button'><i class='fa fa-calendar'></i></button>");
            dest.Append("</span>");
            dest.Append("</div>");
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


        public static MvcHtmlString TimeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
Expression<Func<TModel, TProperty>> expression,
int numberOfOneRow = 3, string tipString = "")
        {
            //宽度转换
            numberOfOneRow = 12 / numberOfOneRow;
            return TimeFor(htmlHelper, expression, tipString, numberOfOneRow);
        }
    }
}
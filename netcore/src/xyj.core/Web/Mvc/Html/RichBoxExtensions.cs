using System;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Tools.Web.Mvc.Html
{
    public static class RichBoxExtensions
    {
        public static MvcHtmlString RichBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string tipString , int crossWidth)
        {
            var dest = new StringBuilder();
            if (crossWidth != -1)
            {
                dest.Append("<div class='col-lg-" + crossWidth + "'>");
            }
            dest.Append(string.Format(@"
<div class='form-group'>
<lalbe class='control-label'>{3}</lalbe>
<div>
<textarea id='{0}' name='{0}' style='width:700px;height:{4};'>
  {1}
</textarea>
<span class='help-block'>
{2}
</span>
</div>
</div>
<script>
    head.ready(function(){{
        $.editor('{0}');
    }})
</script>
", htmlHelper.IdFor(expression), htmlHelper.DisplayFor(expression), 
tipString.CheckValue("&nbsp;"), htmlHelper.DisplayNameFor(expression), crossWidth
            ));
            if (crossWidth != -1)
            {
                dest.Append(" </div>");
            }
            return new MvcHtmlString(dest.ToString());
        }

        public static MvcHtmlString RichBox<TModel>(this HtmlHelper<TModel> htmlHelper,
          string lable, string id,string value, string tipString , int crossWidth)
        {
            var dest = new StringBuilder();
            if (crossWidth != -1)
            {
                dest.Append("<div class='col-lg-" + crossWidth + "'>");
            }       
dest.Append(string.Format(@"
<div class='form-group'>
<lalbe class='col-md-3 control-label'>{3}</lalbe>
<div class='col-md-9'>
<textarea id='{0}' name='{0}' style='width:700px;height:300px;'>
  {1}
</textarea>
<span class='help-block'>
{2}
</span>
</div>
</div>
<script>
    head.ready(function(){{
        $.editor('{0}');
    }})
</script>
", id,value, tipString.CheckValue("&nbsp;"), lable
)); 
            if (crossWidth != -1)
            {
                dest.Append(" </div>");
            }
            return new MvcHtmlString(dest.ToString());
        }
        public static MvcHtmlString RichBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
     Expression<Func<TModel, TProperty>> expression,
      int numberOfOneRow = 1, string tipString = "")
        {
            //宽度转换
            numberOfOneRow = 12 / numberOfOneRow;
            return RichBoxFor(htmlHelper, expression, tipString, numberOfOneRow);
        }
        public static IHtmlString ShowRichBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, int numberOfOneRow = 1)
        {
            //宽度转换
            numberOfOneRow = 12 / numberOfOneRow;
            var dest = new StringBuilder();
            if (numberOfOneRow != -1)
            {
                dest.Append("<div class='col-lg-" + numberOfOneRow + "'>");
            }
            dest.Append("<div class='form-group'>");
            dest.Append("<label>");
            dest.Append(htmlHelper.DisplayNameFor(expression));
            dest.Append("</label>");
            dest.Append("<div class=\"form-control\" rows=\"3\" name=\"" + htmlHelper.NameFor(expression) + "\"   style=\"height:auto\">");
            dest.Append(htmlHelper.DisplayFor(expression));
            dest.Append("</div>");
            dest.Append("<p class=\"help-block\">");
            dest.Append("</p>");
            dest.Append("</div>");
            if (numberOfOneRow != -1)
            {
                dest.Append(" </div>");
            }
            return htmlHelper.Raw(HttpUtility.HtmlDecode(dest.ToString()));
        }
     
    }
}
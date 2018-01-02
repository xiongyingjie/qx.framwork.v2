using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Web.Mvc.Model;

namespace Qx.Tools.Web.Mvc.Html
{
    public static class ImageExtensions
    {
        public static MvcHtmlString ImageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,  int numberOfOneRow = 4, ImageShowType style =ImageShowType.Rounded,string tipString="")
        {
            //宽度转换
            numberOfOneRow = 12 / numberOfOneRow;
            var value = htmlHelper.DisplayFor(expression).ToString();

            var dest = new StringBuilder();
            dest.Append(string.Format(@"
<div{0}>
<img src='{1}' class='img-{2}'> 
<p class='help-block'>{3}</p>
</div>
", numberOfOneRow != -1 ? " class='col-lg-" + numberOfOneRow + "'" : "",
value, style.ToString().ToLower(), tipString));
            return new MvcHtmlString(dest.ToString());
        }


    }
}
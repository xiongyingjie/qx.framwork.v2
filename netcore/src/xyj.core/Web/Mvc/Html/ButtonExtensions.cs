using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Web.Mvc.Model;

namespace Qx.Tools.Web.Mvc.Html
{
    public static class ButtonExtensions
    {
        public static MvcHtmlString Button<TModel>(this HtmlHelper<TModel> htmlHelper,
           string text ,int numberOfOneRow = 4, Color color =Color.Blue, string idOrJs = "")
        {
            //检查参数
            var id = idOrJs.CheckValue();
            var function = "";
            if (idOrJs.Contains(";"))
            {//传入的是函数
                //重新生成id
                id = DateTime.Now.Random();
                function = "<script>head.ready(function(){$('#"+id+"').click(function(){"+ idOrJs.Replace("#id","#"+id) + "})}) </script>";
            }

            //宽度转换
            numberOfOneRow = 12 / numberOfOneRow;
            var dest = new StringBuilder();
            dest.Append(string.Format(@"
<div{0}>
<button id='{1}' type='button' class='btn btn-{2}'>{3}</button>
</div>
{4}
", numberOfOneRow != -1 ? " class='col-lg-" + numberOfOneRow + "'" : "",
id, color.GetCss(), text,function));
            return new MvcHtmlString(dest.ToString());
        }


    }
}
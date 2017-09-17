using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Web.Mvc.Model;

namespace Qx.Tools.Web.Mvc.Html
{
    public static class LayoutExtensions
    {
        public static MvcHtmlString Br<TModel>(this HtmlHelper<TModel> htmlHelper,bool visiable=false)
        {
            return new MvcHtmlString(visiable?"<hr/>":"<hr style='visibility:hidden'/>");
        }
        public static MvcHtmlString Sub<TModel>(this HtmlHelper<TModel> htmlHelper,string url)
        {
            return new MvcHtmlString(string.Format(@"<div id='{0}'></div>
<script>
   head.ready(function () 
{{
    $.get('{1}', function(result)
    {{
 $('#{0}').html($.body(result));      
    }});
}});
</script>", DateTime.Now.Random(), url));
        }
        public static MvcHtmlString Code<TModel>(this HtmlHelper<TModel> htmlHelper ,string code ,int numberOfOneRow = 1,string lable="代码")
        {
            numberOfOneRow = 12 / numberOfOneRow;
            var dest = new StringBuilder();
            dest.Append(string.Format(@"
<div {0}>
    <div class='form-group'>
        <label>{1}</label>
            <pre>{2}</pre>
    </div>
</div>
",numberOfOneRow!=-1? "class='col-lg-"+ numberOfOneRow+"'" : "",
lable.CheckValue("&nbsp;"), code.Replace("#","\"").Replace("<", "&lt;").Replace(">", "&gt;")));

            return new MvcHtmlString(dest.ToString());
        }


        public static MvcHtmlString BeginContainer<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new MvcHtmlString("<div class='container'>");
        }
        public static MvcHtmlString EndContainer<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new MvcHtmlString("</div>");
        }

        public static MvcHtmlString BeginRow<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new MvcHtmlString("<div class='row'>");
        }
        public static MvcHtmlString EndRow<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new MvcHtmlString("</div>");
        }
        public static MvcHtmlString BeginCol<TModel>(this HtmlHelper<TModel> htmlHelper,int numberOfOneRow=1)
        {
            numberOfOneRow = 12/numberOfOneRow;
            return new MvcHtmlString(string.Format("<div class='col-lg-{0}'>", numberOfOneRow));
        }
        public static MvcHtmlString EndCol<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new MvcHtmlString("</div>");
        }
        #region Group
        public static MvcHtmlString BeginGroup<TModel>(this HtmlHelper<TModel> htmlHelper,string title,  int  numberOfOneRow = 1)
        {
            
            numberOfOneRow = 12/numberOfOneRow;
            var dest = new StringBuilder();
            dest.Append(string.Format(@"
<div {0}>
    <div class='row'>  
        <div class='list-group'>
            <a href='#' class='list-group-item active'>
                <h4 class='list-group-item-heading'>
                    {1}
                </h4>
            </a>
            <div class='list-group-item list-group-item-heading'>
                <div class='row'>  
", numberOfOneRow != -1 ? "class='col-lg-" + numberOfOneRow+"'" : "", 
title));
          
            return new MvcHtmlString(dest.ToString());
        }
        public static MvcHtmlString EndGroup<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new MvcHtmlString(
           string.Format(@"
                </div>
            </div>
        </div>
    </div>  
</div>
"));
        }

#endregion

        #region Panel
      
        public static MvcHtmlString BeginPanel<TModel>(this HtmlHelper<TModel> htmlHelper, string title,Color color=Color.Blue, int numberOfOneRow = 1)
        {
            numberOfOneRow = 12 / numberOfOneRow;
            var dest = new StringBuilder();
            dest.Append(string.Format(@"
<div {0}>
 <div class='row'>  
    <div class='panel panel-{1}'>
        <div  class='panel-heading'>
            <h3 class='panel-title'>
                {2}
            </h3>
        </div>
        <div class='panel-body'>
            <div class='row'>  
", numberOfOneRow != -1 ? "class='col-lg-" + numberOfOneRow+"'" : "",
color.GetCss(),title));
            return new MvcHtmlString(dest.ToString());
        }
        public static MvcHtmlString EndPanel<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new MvcHtmlString(
           string.Format(@"
                </div>
            </div>
        </div>
    </div>  
</div>
"));
        }
        #endregion

        #region Group
        public static MvcHtmlString Tab<TModel>(this HtmlHelper<TModel> htmlHelper, 
            Dictionary<string,List<MvcHtmlString>> cfg, int numberOfOneRow = 1,int activeIndex=0)
        {

            numberOfOneRow = 12 / numberOfOneRow;
            var dest = new StringBuilder();
            var header = new StringBuilder();
            var body = new StringBuilder();
            var keys = cfg.Keys.ToList();
            
           
            for (var i = 0; i < keys.Count; i++)
            {
                //随机id
                var tabId = DateTime.Now.Random();
                //header
                header.AppendFormat(
@"<li {0}>
   <a href='#{1}' data-toggle='tab'>
     {2}
   </a>
</li>", i==activeIndex? "class='active'":"",
tabId,keys[i]);
                //构造bodyContent
                var bodyContent = new StringBuilder();
                cfg[keys[i]].ForEach(c =>
                {
                    bodyContent.Append(c);
                });
               
                //body
                body.AppendFormat(
@"<div class='tab-pane fade{0}' id='{1}'>
           {2}
</div>", i == activeIndex ? " in active" : "",
tabId, bodyContent);
            }
            //组装
            dest.Append(string.Format(@"
<div{0}>
    <ul class='nav nav-tabs'>
        {1}
    </ul>
    <div class='tab-content'>
       {2}
    </div>
</div>
", numberOfOneRow != -1 ? " class='col-lg-" + numberOfOneRow + "'" : "",
header,body));

            return new MvcHtmlString(dest.ToString());
        }
      
        #endregion
    }
}
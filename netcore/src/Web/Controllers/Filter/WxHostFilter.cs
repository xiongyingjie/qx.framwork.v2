
using Web.Controllers.Base;

namespace Web.Controllers.Filter
{
    public class WxHostFilter : BaseController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var token = "";
            var echoString = filterContext.RequestContext.HttpContext.Request.QueryString["echoStr"];
            var signature = filterContext.RequestContext.HttpContext.Request.QueryString["signature"];
            var timestamp = filterContext.RequestContext.HttpContext.Request.QueryString["timestamp"];
            var nonce = filterContext.RequestContext.HttpContext.Request.QueryString["nonce"];
            if (!string.IsNullOrEmpty(echoString))
            {
                filterContext.RequestContext.HttpContext.Response.Write(echoString);
                filterContext.RequestContext.HttpContext.Response.End();
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }

            //var arr = new[] { token, timestamp, nonce }.OrderBy(z => z).ToArray();
            //var arrString = string.Join("", arr);
            //var sha1 = System.Security.Cryptography.SHA1.Create();
            //var sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(arrString));
            //StringBuilder enText = new StringBuilder();
            //foreach (var b in sha1Arr)
            //{
            //    enText.AppendFormat("{0:x2}", b);
            //}
            //if (enText.ToString() == signature)
            //{
            //    Response.Output.Write(echoString);
            //}
        }

    }
}

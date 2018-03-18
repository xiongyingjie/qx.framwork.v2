using System;
using System.Collections.Generic;

using System.Linq;
using Microsoft.AspNetCore.Http;
using xyj.core.Adapter;
using xyj.core.Exceptions.Upgrate;

namespace xyj.core.Extensions
{
    public static class HttpExtension
    {
        public static string Q(this DataContext dataContext, HttpContext httpContext, string key)
        {
            if (httpContext == null)
            {
                return "";
            }
            var v = httpContext.Request.Query[key].FirstOrDefault();

            if (!v.HasValue()&& httpContext.Request.Method.ToLower()=="post")
            {  //Load Form variables into NameValueCollection variable.
                return httpContext.Request.Form[key];
            }
            #region 转换特殊标志

            #endregion
            return v;
        }
     
        public static string S(this DataContext dataContext, HttpContext httpContext, string key, string value = null)
        {
            string v = "";
          
            if (value == null)
                v = httpContext.Session.GetString(key); 
            else
            {
                httpContext.Session.SetString(key,value);
            }
            #region 转换特殊标志

            #endregion
            return v;
        }
        public static string Post(this HttpClient client, string url, Dictionary<string, string> param)
        {
            throw new NotSupportedExceptionInCoreException();
            //var request = new HttpRequest(url, RestSharp.Method.POST);
            //foreach (var key in param.Keys)
            //{
            //    request.AddParameter(key, param[key]);
            //}
            //var response = client.Execute(request);
            //var content = response.Content;
            //return content;
        }
        public static string Post(this HttpClient client, string url, Dictionary<string, string> param, Dictionary<string, string> header)
        {
            throw new NotSupportedExceptionInCoreException();
            //var request = new HttpRequest(url, RestSharp.Method.POST);
            //foreach (var key in param.Keys)
            //{
            //    request.AddParameter(key, param[key]);
            //}
            //foreach (var key in header.Keys)
            //{
            //    request.AddParameter(key, header[key]);
            //}
            //var response = client.Execute(request);
            //var content = response.Content;
            //return content;
        }
        public static string Get(this HttpClient client, string url)
        {
            throw new NotSupportedExceptionInCoreException();
            //var request = new HttpRequest(url, RestSharp.Method.GET);
            //var response = client.Execute(request);
            //var content = response.Content;
            //return content;
        }

    }
}
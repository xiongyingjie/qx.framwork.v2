using System;
using System.Collections.Generic;
using System.Linq;
using Qx.Tools.QxClass;

namespace Qx.Tools.CommonExtendMethods
{
    public static class HttpExtension
    {
        public static string Post(this HttpClient client, string url, Dictionary<string, string> param)
        {
            var request = new HttpRequest(url, RestSharp.Method.POST);
            foreach (var key in param.Keys)
            {
                request.AddParameter(key, param[key]);
            }
            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }
        public static string Post(this HttpClient client, string url, Dictionary<string, string> param, Dictionary<string, string> header)
        {
            var request = new HttpRequest(url, RestSharp.Method.POST);
            foreach (var key in param.Keys)
            {
                request.AddParameter(key, param[key]);
            }
            foreach (var key in header.Keys)
            {
                request.AddParameter(key, header[key]);
            }
            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }
        public static string Get(this HttpClient client, string url)
        {
            var request = new HttpRequest(url, RestSharp.Method.GET);
            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }

    }
}
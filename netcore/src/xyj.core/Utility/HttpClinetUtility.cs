using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using RestSharp;
using xyj.core.Exceptions.Upgrate;
using xyj.core.Extensions;
using xyj.core.Models;

namespace xyj.core.Utility
{
   public class HttpClinetUtility
    {
        private HttpContext _httpContext;
        private WeChatMsg _message;

        private Dictionary<string, string> _param;
        private string _requstLog;
        private Dictionary<string, string> _requstParam;
     
        public HttpClinetUtility(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        protected Dictionary<string, string> Param
        {
            get
            {
                if (_param == null)
                {
                    _param = new Dictionary<string, string>();
                }
                return _param;
            }
        }

        protected WeChatMsg Message
        {
            get
            {
                if (_message == null)
                {
                    _message = XmlToObj<WeChatMsg>(XmlRequstBody);
                }
                return _message;
            }
        }

        public string XmlRequstBody
        {
            get
            {
                throw new NotSupportedExceptionInCoreException("");
                //if (_xmlRequstBody == null)
                //{
                //    var s = Qx.Tools.Web.HttpContext.Current.Request.Scheme;
                //    var b = new byte[s.Length];
                //    s.Read(b, 0, (int)s.Length);
                //    var content = Encoding.UTF8.GetString(b);
                //    _xmlRequstBody = content;
                //}
                //return _xmlRequstBody;
            }
        }



        protected Dictionary<string, string> RequstParam
        {
            get
            {
                if (_requstParam == null)
                {
                    _requstParam = new Dictionary<string, string>();
                    var keyValues = XmlToKeyValues(XmlRequstBody);
                    keyValues.ForEach(a => { _requstParam.Add(a.Key, a.Value); });
                }
                return _requstParam;
            }
        }
        public string RequstLog
        {
            get
            {
                var Request = _httpContext.Request;
                if (_requstLog == null)
                {
                    var content = "";
                    content = "----------------------" + DateTime.Now + "----------------------" + "\r\n";

                    content += "--------RequstLog" + "\r\n";

                    if (Request.Query.Any())
                    {
                        foreach (var item in Request.Query)
                        {
                            content += item.Key + ":" + item.Value + "\r\n";
                        }
                    }
                    else
                    {
                        content += "none" + "\r\n";
                    }

                    content += "--------XmlBody[Source]" + "\r\n";
                    content += XmlRequstBody + "\r\n";

                    content += "--------XmlBody[Json]" + "\r\n";
                    content += Message.Serialize() + "\r\n";

                    content += "--------XmlBody[Formated]" + "\r\n";

                    foreach (var item in RequstParam)
                    {
                        content += item.Key + "=>" + item.Value + "\r\n";
                    }

                    content += "\r\n";
                    _requstLog = content;
                }
                return _requstLog;
            }
        }

        protected string ApiUrl(string action, string extraParam)
        {
            var url = ("/cgi-bin/" + action).ToLower();
            return extraParam.HasValue() ? url + "?" + extraParam : url;
        }

        public string ApiHttpGet(string host, string url, Dictionary<string, string> param, string logFileName)
        {
            var content = HttpGet(host, ApiUrl(url, null), param);
            WriteFile(string.Format("UserFiles\\Test\\{0}.txt", logFileName + DateTime.Now.ToString("-yyyy.MMMM.dd")),
                content, false);
            return content;
        }

        protected string ApiHttpPost(string host, string url, Dictionary<string, string> param, string logFileName)
        {
            var content = HttpPost(host, ApiUrl(url, null), param);
            WriteFile(string.Format("UserFiles\\Test\\{0}.txt", logFileName + DateTime.Now.ToString("-yyyy.MMMM.dd")),
                content, false);
            return content;
        }

        protected string ApiJsonHttpPost(string host, string url, object param, string logFileName, string extraParam = null)
        {
            var content = JsonHttp(host, ApiUrl(url, extraParam), param, Method.POST);
            WriteFile(string.Format("UserFiles\\Test\\{0}.txt", logFileName + DateTime.Now.ToString("-yyyy.MMMM.dd")),
                content, false);
            return content;
        }

        protected string HttpGet(string host, string url, Dictionary<string, string> param)
        {
            return NormalHttp(host, url, param, Method.GET);
        }
        public T HttpGet<T>(string url) where T : new()
        {//60秒超时
            var client = new RestClient(new Uri(url));
            var request = new RestRequest(Method.GET);
            return client.Execute<T>(request).Data;
        }
         
        protected string HttpPost(string host, string url, Dictionary<string, string> param)
        {
            return NormalHttp(host, url, param, Method.POST);
        }

        protected string NormalHttp(string host, string url, Dictionary<string, string> param, Method method)
        {
            var request = new RestRequest(url, method);
            foreach (var key in param.Keys)
            {
                request.AddParameter(key, param[key]);
            }
            return BaseHttp(request, host);
        }

        protected string JsonHttp(string host, string url, object objParam, Method method)
        {
            var request = new RestRequest(url, method);
            request.AddJsonBody(objParam);
            request.DateFormat = "application/json";
            return BaseHttp(request, host);
        }

        protected string BaseHttp(RestRequest request, string host)
        {
           
            var client = new RestClient(new Uri(host));
            

            return client.Execute(request).Content;
        }
        protected string BaseHttp(string host, string url, Dictionary<string, string> param, Method method, out RestClient client,int timeOut=60)
        {
            client = new RestClient(new Uri(host));
            var request = new RestRequest(url, method);
            foreach (var key in param.Keys)
            {
                request.AddParameter(key, param[key]);
            }
            string content =null;
            client.ExecuteAsync(request, callback => { content = callback.Content; });
            while (timeOut > 0)
            {
                timeOut--;
                if (content != null)
                {//取到结果返回
                    timeOut = 0;
                }
                Thread.Sleep(1000);//等待一秒
            }
            return content;
        }
        protected T XmlToObj<T>(string xmlBody) where T : new()
        {
            if (!xmlBody.HasValue())
                return new T();

            var dic = XmlToKeyValues(xmlBody);

            #region dic to jsonString

            var jsonString = new StringBuilder();
            jsonString.Append("{");

            for (var i = 0; i < dic.Count(); i++)
            {
                jsonString.Append("\"");
                jsonString.Append(dic[i].Key);
                jsonString.Append("\"");
                jsonString.Append(":");
                jsonString.Append("\"");
                jsonString.Append(dic[i].Value);
                jsonString.Append("\"");
                if (i < dic.Count() - 1)
                {
                    jsonString.Append(",");
                }
            }
            jsonString.Append("}");

            #endregion

            #region jsonString to obj

            var obj = jsonString.ToString().Deserialize<T>();

            #endregion

            return obj;
        }

        protected List<KeyValuePair<string, string>> XmlToKeyValues(string xmlBody)
        {
            if (!xmlBody.HasValue())
                return new List<KeyValuePair<string, string>>();

            var doc = new HtmlDocument();
            doc.LoadHtml(xmlBody);
            var nodes = doc.DocumentNode.ChildNodes.FirstOrDefault().
                ChildNodes.Where(a => !(a.InnerText == "\r\n" || a.Name == "#text" || a.InnerText == "")).
                Select(b => new KeyValuePair<string, string>(b.Name,
                    b.InnerText.Replace("<![CDATA[", "").Replace("]]>", ""))
                ).ToList();
            return nodes;
        }


        protected string ParseException(Exception ex)
        {
            var error = new StringBuilder();
            error.Append("----------------------" + DateTime.Now + "----------------------------");
            error.Append("\r\n");
            error.Append(ex.Message);
            error.Append("\r\n");
            error.Append("--------------------------StackTrace");
            error.Append("\r\n");
            error.Append(ex.StackTrace);
            error.Append("\r\n");
            foreach (var item in ex.Data)
            {
                error.Append(item);
                error.Append("\r\n");
            }

            if (ex.InnerException != null)
            {
                ex = ex.InnerException;//重新赋值
                error.Append("--------------------------InnerException");
                error.Append("\r\n");
                error.Append(ex.Message);
                error.Append("\r\n");
                error.Append("--------------------------InnerException.StackTrace");
                error.Append("\r\n");
                error.Append(ex.StackTrace);
                error.Append("\r\n");
            }


            return error.ToString();
        }
        protected string GetProjectDir(string FileName)
        {
            return Assembly.GetCallingAssembly().Location + FileName;
        }
        protected void WriteFile(string FilePath, string content, bool isBinaryWriter = true)
        {
            var filePath = GetProjectDir(FilePath);
            var fs = System.IO.File.Exists(filePath) ?
                new FileStream(filePath, FileMode.Append) :
                System.IO.File.Create(filePath);
            using (fs)
            {
                if (isBinaryWriter)
                {
                    var br = new BinaryWriter(fs, Encoding.UTF8);
                    br.Write(true);
                    br.Flush();
                    br.Close();
                }
                else
                {
                    var sw = new StreamWriter(fs);
                    sw.Write(content);
                    sw.Flush();
                    sw.Close();
                }
                fs.Close();
            }
        }

    }
}

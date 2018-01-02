using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Qx.Tools.QxClass
{
    public class HttpClient : RestClient
    {
        public HttpClient(Uri baseUrl) : base(baseUrl)
        {
        }
        public HttpClient(string baseUrl) : base(baseUrl)
        {
        }
    }
}

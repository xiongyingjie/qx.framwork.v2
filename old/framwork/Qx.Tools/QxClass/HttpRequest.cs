using RestSharp;

namespace Qx.Tools.QxClass
{
    public class HttpRequest : RestRequest
    {
        public HttpRequest(string resource, Method method) : base(resource, method)
        {
        }
    }
}

using RestSharp;

namespace xyj.core.Adapter
{
    public class HttpRequest : RestRequest
    {
        public HttpRequest(string resource, Method method) : base(resource, method)
        {
        }
    }
}

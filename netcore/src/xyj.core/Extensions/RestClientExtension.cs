using System.Threading;
using RestSharp;

namespace xyj.core.Extensions
{
    public static class RestClientExtension
    {
      
        public static string Execute(this RestClient client, IRestRequest request,int timeOut=60)
        {
            //60秒超时
            string content ="";
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
    }
}

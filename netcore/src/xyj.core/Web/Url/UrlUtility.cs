using System.Linq;

namespace xyj.core.Web.Url
{
    public class UrlUtility
    {
        public static string AddQueryParameter(string url, string parameterName, string parameterValue)
        {
            string delimiter;
            if (url.EndsWith("?") || url.EndsWith("&"))
            {
                delimiter = string.Empty;
            }
            else if (!url.Contains("?"))
            {
                delimiter = "?";
            }
            else
            {
                delimiter = "&";
            }

            return url + delimiter + parameterName + "=" + parameterValue;
        }

        public static string Combine(params string[] paths)
        {
            return paths.Aggregate(
                (current, path) =>
                {
                    if (string.IsNullOrEmpty(path))
                    {
                        return current;
                    }

                    return string.Format("{0}/{1}", current.TrimEnd('/'), path.TrimStart('/'));
                });
        }
    }
}
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "F2", action = "Login", id = UrlParameter.Optional },
                  namespaces: new[] { "Web.Controllers" }
            );

            routes.RouteExistingFiles = false;
        }
    }
}

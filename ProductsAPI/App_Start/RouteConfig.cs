using System.Web.Http;

namespace ProductsAPI.App_Start
{
    /// <summary>
    /// Represents route configuration.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Configures Web API routes.
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes(new WebApiCustomDirectRouteProvider());

            configuration.Routes.MapHttpRoute(
                name: "Index",
                routeTemplate: "",
                defaults: new { controller = "Home", action = "Index" }
                );

            configuration.Routes.MapHttpRoute(
                name: "NotFound",
                routeTemplate: "{*path}",
                defaults: new { controller = "Error", action = "NotFound" });
        }
    }
}
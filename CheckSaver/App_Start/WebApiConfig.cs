using System.Web.Http;

namespace CheckSaver
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "FilesApi",
                routeTemplate: "api/{controller}/{path}",
                defaults: new { path = RouteParameter.Optional }
            );
        }
    }
}

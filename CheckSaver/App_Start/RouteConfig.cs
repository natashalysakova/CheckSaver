using System.Web.Mvc;
using System.Web.Routing;

namespace CheckSaver
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //            routes.MapRoute(
            //                name: "Default",
            //                url: "{area}/{controller}/{action}/{id}",
            //                defaults: new { area = "Checks", controller = "Checks", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "Default",
            //    url: "Checks/{controller}/{action}/{id}",
            //    defaults: new {controller = "Checks", action = "Index", id = UrlParameter.Optional }
            //    );

            routes.MapRoute("redirect all other requests",
                "{*url}",
                new
                {
                    controller = "Checks",
                    action = "Index"
                }).DataTokens = new RouteValueDictionary(new { area = "Checks" });
        }
    }
}

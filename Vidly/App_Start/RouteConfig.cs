using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig //the order of the routing must be specific to generic, the order is important
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default", //route name
                url: "{controller}/{action}/{id}", //url with parameters
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } //parameter defaults
            );
        }
    }
}

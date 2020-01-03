using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web_NoiThat
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name:"Detail",
                url:"Detail/{action}/{id}",
                defaults:new {action="Index",id= UrlParameter.Optional }
            );
            routes.MapRoute(
                name:"Cart",
                url:"Cart/{action}/{id}",
                defaults:new {action="Index",id=UrlParameter.Optional }
           );


            routes.MapRoute(
                name: "Admin",
                url: "Admin/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Method",
                url: "Method/{action}/{id}",
                defaults: new {action= "UpdateProduct", id = UrlParameter.Optional }
           );
        }
    }
}

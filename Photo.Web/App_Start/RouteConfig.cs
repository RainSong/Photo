using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Photo.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ListPage",
                url: "list/{index}",
                defaults: new { controller = "Home", action = "Index", index = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TagPageList",
                url: "tag/{id}/{pageIndex}",
                defaults: new { controller = "Tag", action = "Pages", id = UrlParameter.Optional, pageIndex = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PageInfo",
                url: "{controller}/{pageId}",
                defaults: new { controller = "Home", action = "Index", pageId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
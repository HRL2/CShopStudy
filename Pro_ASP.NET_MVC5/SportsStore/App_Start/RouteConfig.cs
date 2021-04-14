using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // URL : / , 모든 카테고리의 상품들에 대한 첫번째 페이지를 보여줌
            routes.MapRoute(null, "", new { Controller = "Product", action = "List", category = (string)null, page = 1});

            // URL : /Page2 , 모든 카테고리의 상품에 대한 2번째 페이지를 보여줌
            routes.MapRoute(
                null,
                "Page{page}",
                new { Controller = "Product", action = "List", category = (string)null },
                new { page = @"\d+" });

            // URL : /Soccer , Soccer 카테고리의 상품에 대한 첫번째 페이지를 보여줌
            routes.MapRoute(
                null,
                "{category}",
                new { Controller = "Product", action = "List", page = 1 });

            // URL : /Soccer/Page2 , Soccer 카테고리의 상품에 대한 2번째 페이지를 보여줌
            routes.MapRoute(
                null,
                "{category}/Page{page}",
                new { Controller = "Product", action = "List" },
                new { page = @"\d+" });

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}

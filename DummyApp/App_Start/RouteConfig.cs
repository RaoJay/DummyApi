﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DummyApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Dummy", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

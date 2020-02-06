using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Dotnetsoft.HiFiLM.Management.Tool
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 구성 및 서비스

            // Web API 경로
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.InitializeReceiveCustomWebHooks();
        }
    }
}

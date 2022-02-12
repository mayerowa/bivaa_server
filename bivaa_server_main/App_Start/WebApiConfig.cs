using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace bivaa_server_main
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Služby a konfigurace rozhraní Web API
            config.EnableCors();

            // Trasy rozhraní Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

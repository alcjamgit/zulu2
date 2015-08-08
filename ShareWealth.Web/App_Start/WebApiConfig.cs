using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ShareWealth.Web.Filters;

namespace ShareWealth.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            
            //$http.get in angular prepends the base ref
            config.Routes.MapHttpRoute(
                name: "promiseApi",
                routeTemplate: "app/api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new HandleApiExceptionAttribute());

        }
    }
}

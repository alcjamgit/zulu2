using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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

            //http://stackoverflow.com/questions/5769200/serialize-one-to-many-relationships-in-json-net
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

        }
    }
}

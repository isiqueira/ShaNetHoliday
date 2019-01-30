using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShaNetHoliday.WebService
{
    public static class WebApiConfig
    {
        public static void Register( HttpConfiguration config )
        {
            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "NotFound",
                routeTemplate: "{*url}",
                defaults: new { controller = "Error", action = "Handle404" } );
        }
    }
}

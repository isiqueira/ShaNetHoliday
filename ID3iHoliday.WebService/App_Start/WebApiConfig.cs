using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ID3iHoliday.WebService
{
    public static class WebApiConfig
    {
        public static void Register( HttpConfiguration config )
        {
            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "BadRequest",
                routeTemplate: "{*url}",
                defaults: new { controller = "Error", action = "Handle400" } );
        }
    }
}

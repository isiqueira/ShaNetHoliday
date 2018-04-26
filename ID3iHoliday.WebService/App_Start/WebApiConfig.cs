using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ID3iHoliday.WebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();
        }
    }
}

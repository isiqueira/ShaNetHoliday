﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using ShaNetDiagnostics;
using ShaNetDiagnostics.Log4NetWriter;
using ShaNetDiagnostics.RaygunWriter;
using ShaNetHoliday.WebService.Filters;
using ShaNetHoliday.WebService.Services;

namespace ShaNetHoliday.WebService
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AppHealth.Current.AddWriter( new Log4NetHealthWriter() );
            AppHealth.Current.AddWriter( new RaygunHealthWriter( "NO_API_KEY" ) );

            AppHealth.Current.Info.Track( "Démarrage de l'application." );

            GlobalConfiguration.Configure( WebApiConfig.Register );

            GlobalConfiguration.Configuration.Formatters.Remove( GlobalConfiguration.Configuration.Formatters.XmlFormatter );

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

            GlobalConfiguration.Configuration.Services.Replace( typeof( IHttpControllerSelector ), new HttpNotFoundAwareDefaultHttpControllerSelector( GlobalConfiguration.Configuration ) );

            GlobalConfiguration.Configuration.Services.Replace( typeof( IHttpActionSelector ), new HttpNotFoundAwareControllerActionSelector() );

            GlobalConfiguration.Configuration.Filters.Add( new ValidateModelStateAttribute() );

            GlobalConfiguration.Configuration.Filters.Add( new ExceptionsFilterAttribute() );
        }
    }
}

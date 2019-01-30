using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using ShaNetDiagnostics;

namespace ShaNetHoliday.WebService.Filters
{
    public class ExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException( HttpActionExecutedContext context )
        {
            if ( context.Exception is Exception )
            {
                AppHealth.Current.Exception.Track( context.Exception );
                context.Response = new HttpResponseMessage( HttpStatusCode.InternalServerError );
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using iD3iHoliday.WebService.Controllers;

namespace iD3iHoliday.WebService.Services
{
    public class HttpNotFoundAwareControllerActionSelector : ApiControllerActionSelector
    {
        public HttpNotFoundAwareControllerActionSelector()
        {
        }

        public override HttpActionDescriptor SelectAction( HttpControllerContext controllerContext )
        {
            HttpActionDescriptor decriptor = null;
            try
            {
                decriptor = base.SelectAction( controllerContext );
            }
            catch ( HttpResponseException ex )
            {
                var code = ex.Response.StatusCode;
                if ( code != HttpStatusCode.NotFound && code != HttpStatusCode.MethodNotAllowed )
                {
                    throw;
                }

                var routeData = controllerContext.RouteData;
                routeData.Values.Clear();
                routeData.Values[ "controller" ] = "Error";
                routeData.Values[ "action" ] = "Handle404";

                IHttpController httpController = new ErrorController() {
                    RequestContext = controllerContext.RequestContext,
                    Request = controllerContext.Request
                };
                controllerContext.Controller = httpController;
                controllerContext.ControllerDescriptor = new HttpControllerDescriptor( controllerContext.Configuration, "Error", httpController.GetType() );
                decriptor = base.SelectAction( controllerContext );
            }
            return decriptor;
        }
    }
}

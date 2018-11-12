using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ID3iHoliday.WebService.Controllers
{
    [RoutePrefix( "" )]
    public class ErrorController : ApiController
    {
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs( "PATCH" )]
        public IHttpActionResult Handle404() => NotFound();
    }
}

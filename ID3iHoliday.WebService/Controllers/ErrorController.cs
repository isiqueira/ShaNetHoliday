using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ID3iHoliday.WebService.Controllers
{
    public class ErrorController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Handle400()
        {
            return BadRequest("The requested url is not found");
        }
    }
}

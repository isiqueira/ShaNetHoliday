using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ID3iHoliday.WebService.Controllers
{
    [RoutePrefix( "" )]
    public class HomeController : ApiController
    {
        [HttpGet, Route( "" )]
        public IHttpActionResult Index() => Ok();
    }
}

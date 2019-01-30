using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.WebService.Divers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShaNetHoliday.WebService.Controllers
{
    [RoutePrefix( "LongWeekEnds" )]
    public class LongWeekEndController : ApiController
    {
        [HttpGet]
        [Route( "{year:int}" )]
        public IHttpActionResult Get( int year, string ccode, string scode = null, string rcode = null )
        {
            return Ok( HolidaySystem.Instance.LongWeekEnds( year, ccode, scode, rcode ).Transform() );
        }
    }
}

using iD3iHoliday.Engine.Standard;
using iD3iHoliday.WebService.Divers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace iD3iHoliday.WebService.Controllers
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

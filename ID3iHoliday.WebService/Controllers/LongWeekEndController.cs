using ID3iHoliday.Engine.Standard;
using ID3iHoliday.WebService.Divers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ID3iHoliday.WebService.Controllers
{
    [RoutePrefix( "Api/LongWeekEnds" )]
    public class LongWeekEndController : ApiController
    {
        [HttpGet]
        [Route( "{year:int}" )]
        public IHttpActionResult Get( int year, string ccode, string scode = null, string rcode = null )
        {
            try
            {
                return Ok( HolidaySystem.Instance.LongWeekEnds( year, ccode, scode, rcode ).Transform() );
            }
            catch ( Exception )
            {
                return InternalServerError();
            }
        }
    }
}

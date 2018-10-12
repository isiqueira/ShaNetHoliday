using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;
using ID3iHoliday.WebService.Divers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ID3iHoliday.WebService.Controllers
{
    [RoutePrefix( "Api/Days" )]
    public class DaysController : ApiController
    {
        [HttpGet]
        [Route( "{year:int}" )]
        public IHttpActionResult Get( int year, string ccode, string scode = null, string rcode = null, RuleType rule = RuleType.All, Calendar calendar = Calendar.All )
        {
            try
            {
                return Ok( HolidaySystem.Instance.All( year, ccode, scode, rcode, rule, calendar ).Transform() );
            }
            catch ( Exception )
            {
                return InternalServerError();
            }
        }
    }
}

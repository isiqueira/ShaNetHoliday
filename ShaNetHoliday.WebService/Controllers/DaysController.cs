using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;
using ShaNetHoliday.WebService.Divers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShaNetHoliday.WebService.Controllers
{
    [RoutePrefix( "Days" )]
    public class DaysController : ApiController
    {
        [HttpGet]
        [Route( "{year:int}" )]
        public IHttpActionResult Get( int year, string ccode, string scode = null, string rcode = null, RuleType rule = RuleType.All, Calendar calendar = Calendar.All )
        {
            return Ok( HolidaySystem.Instance.All( year, ccode, scode, rcode, rule, calendar ).Transform() );
        }
    }
}

using iD3iHoliday.Engine.Standard;
using iD3iHoliday.Models;
using iD3iHoliday.WebService.Divers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace iD3iHoliday.WebService.Controllers
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

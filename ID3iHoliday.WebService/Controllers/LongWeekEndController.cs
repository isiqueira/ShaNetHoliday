using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;
using ID3iHoliday.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ID3iHoliday.WebService.Controllers
{
    [RoutePrefix("Api/LongWeekEnds")]
    public class LongWeekEndController : ApiController
    {
        [HttpGet]
        [Route("{year:int}")]
        public IHttpActionResult Get(int year, string ccode, string scode = null, string rcode = null)
        {
            return Ok(Transform(HolidaySystem.Instance.LongWeekEnds(year, ccode, scode, rcode)));
        }
        private IEnumerable<LongWeekEndModel> Transform(IEnumerable<LongWeekEnd> longWeekends)
        {
            return longWeekends?.Select(x => new LongWeekEndModel(x.StartDate, x.EndDate, x.HasBridge, x.ToString()));
        }
    }
}

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
    [RoutePrefix("Api/Days")]
    public class DaysController : ApiController
    {
        [HttpGet]
        [Route("{year:int}")]
        public IHttpActionResult Get(int year, string ccode, string scode = null, string rcode = null, RuleType rule = RuleType.All, Calendar calendar = Calendar.All)
        {
            return Ok(Transform(HolidaySystem.Instance.All(year, ccode, scode, rcode, rule, calendar)));
        }

        private IEnumerable<SpecificDayModel> Transform(IEnumerable<SpecificDay> days)
        {
            return days?.Select(x => new SpecificDayModel(x.Date, x.Names.ToDictionary(y => y.Key.ToString(), y => y.Value)));
        }
    }
}

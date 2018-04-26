using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;
using ID3iHoliday.WebService.Divers;

namespace ID3iHoliday.WebService.Controllers
{
    [RoutePrefix("Api/States")]
    public class StateController : ApiController
    {
        [HttpGet, Route("{code}")]
        public IHttpActionResult Get(string code)
        {
            var result = HolidaySystem.Instance.CountriesAvailable.SelectMany(x => x.States).FirstOrDefault(x => x.Code == code);
            if (result == null)
                return NotFound();
            return Ok(result.Transform());
        }

        [HttpGet, Route("{code}/Regions")]
        public IHttpActionResult Get1(string code)
        {
            var result = HolidaySystem.Instance.CountriesAvailable.SelectMany(x => x.States).FirstOrDefault(x => x.Code == code);
            if (result == null)
                return NotFound();
            return Ok(result.Regions.Select(x => x.Transform()).ToList());
        } 
        
        [HttpGet, Route("{code}/Days")]
        public IHttpActionResult Get2(string code, int year, RuleType rule = RuleType.All, Calendar calendar = Calendar.All)
        {
            var result = HolidaySystem.Instance.CountriesAvailable.SelectMany(x => x.States).FirstOrDefault(x => x.Code == code);
            if (result == null)
                return NotFound();
            return Ok(HolidaySystem.Instance.All(year, result.Parent.Code, code, rule, calendar).Transform());
        }
    }
}

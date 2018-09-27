using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;
using ID3iHoliday.WebService.Divers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ID3iHoliday.WebService.Controllers
{
    [RoutePrefix("Api/Regions")]
    public class RegionController : ApiController
    {
        [HttpGet, Route("{code}")]
        public IHttpActionResult Get(string code)
        {
            try
            {
                var result = HolidaySystem.Instance.CountriesAvailable.SelectMany(x => x.States.SelectMany(y => y.Regions)).FirstOrDefault(x => x.Code == code);
                if (result == null)
                    return NotFound();
                return Ok(result.Transform());
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet, Route("{code}/Days")]
        public IHttpActionResult Get1(string code, int year, RuleType rule = RuleType.All, Calendar calendar = Calendar.All)
        {
            try
            {
                var result = HolidaySystem.Instance.CountriesAvailable.SelectMany(x => x.States.SelectMany(y => y.Regions)).FirstOrDefault(x => x.Code == code);
                if (result == null)
                    return NotFound();
                return Ok(HolidaySystem.Instance.All(year, result.Parent.Parent.Code, result.Parent.Code, code, rule, calendar).Transform());
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}

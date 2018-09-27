using ID3iHoliday.Engine.Standard;
using ID3iHoliday.Models;
using ID3iHoliday.WebService.Divers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ID3iHoliday.WebService.Controllers
{
    [RoutePrefix("Api/Countries")]
    public class CountryController : ApiController
    {
        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(HolidaySystem.Instance.CountriesAvailable.Select(x => x.Transform()).ToList());
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet, Route("{code}")]
        public IHttpActionResult Get(string code)
        {
            try
            {
                var result = HolidaySystem.Instance.CountriesAvailable.FirstOrDefault(x => x.Code == code);
                if (result == null)
                    return NotFound();
                return Ok(result.Transform());
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("{code}/Days")]
        public IHttpActionResult Get0(string code, int year, RuleType rule = RuleType.All, Calendar calendar = Calendar.All)
        {
            try
            {
                var result = HolidaySystem.Instance.All(year, code, rule, calendar);
                if (result == null)
                    return NotFound();
                return Ok(result.Transform());
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("{code}/States")]
        public IHttpActionResult Get1(string code)
        {
            try
            {
                var result = HolidaySystem.Instance.CountriesAvailable.FirstOrDefault(x => x.Code == code)?.States;
                if (result == null)
                    return NotFound();
                return Ok(result.Select(x => x.Transform()).ToList());
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}

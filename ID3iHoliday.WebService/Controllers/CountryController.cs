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
    [RoutePrefix("Api/Country")]
    public class CountryController : ApiController
    {
        [HttpGet]
        [Route("~/Api/Countries")]
        public IHttpActionResult Get()
        {
            return Ok(HolidaySystem.Instance.CountriesAvailable.Select(x => Transform(x)).ToList());
        }

        [HttpGet]
        [Route("~/Api/Countries")]
        [Route("{ccode}")]
        public IHttpActionResult Get(string ccode)
        {
            var result = HolidaySystem.Instance.CountriesAvailable.FirstOrDefault(x => x.Code == ccode);
            if (result == null)
                return NotFound();
            return Ok(Transform(result));
        }

        [HttpGet]
        [Route("{ccode}/Days")]
        public IHttpActionResult Get0(string ccode, int year, RuleType rule = RuleType.All, Calendar calendar = Calendar.All)
        {
            var result = HolidaySystem.Instance.All(year, ccode, rule, calendar);
            if (result == null)
                return NotFound();
            return Ok(Transform(result));
        }

        [HttpGet]
        [Route("{ccode}/States")]
        public IHttpActionResult Get1(string ccode)
        {
            var result = HolidaySystem.Instance.CountriesAvailable.FirstOrDefault(x => x.Code == ccode)?.States;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => Transform(x)).ToList());
        }

        [HttpGet]
        [Route("{ccode}/States")]
        [Route("{ccode}/State/{scode}")]
        public IHttpActionResult Get2(string ccode, string scode)
        {
            var result = HolidaySystem.Instance.CountriesAvailable.FirstOrDefault(x => x.Code == ccode)?.States?.FirstOrDefault(x => x.Code == scode);
            if (result == null)
                return NotFound();
            return Ok(Transform(result));
        }

        [HttpGet]
        [Route("{ccode}/State/{scode}/Days")]
        public IHttpActionResult Get3(string ccode, string scode, int year, RuleType rule = RuleType.All, Calendar calendar = Calendar.All)
        {
            var result = HolidaySystem.Instance.All(year, ccode, scode, rule, calendar);
            if (result == null)
                return NotFound();
            return Ok(Transform(result));
        }

        [HttpGet]
        [Route("{ccode}/State/{scode}/Regions")]
        public IHttpActionResult Get4(string ccode, string scode)
        {
            var result = HolidaySystem.Instance.CountriesAvailable.FirstOrDefault(x => x.Code == ccode)?.States?.FirstOrDefault(x => x.Code == scode)?.Regions;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => Transform(x)).ToList());
        }

        [HttpGet]
        [Route("{ccode}/State/{scode}/Regions")]
        [Route("{ccode}/State/{scode}/Region/{rcode}")]
        public IHttpActionResult Get5(string ccode, string scode, string rcode)
        {
            var result = HolidaySystem.Instance.CountriesAvailable.FirstOrDefault(x => x.Code == ccode).States.FirstOrDefault(x => x.Code == scode).Regions.FirstOrDefault(x => x.Code == rcode);
            if (result == null)
                return NotFound();
            return Ok(Transform(result));
        }

        [HttpGet]
        [Route("{ccode}/State/{scode}/Region/{rcode}/Days")]
        public IHttpActionResult Get6(string ccode, string scode, string rcode, int year, RuleType rule = RuleType.All, Calendar calendar = Calendar.All)
        {
            var result = HolidaySystem.Instance.All(year, ccode, scode, rcode, rule, calendar);
            if (result == null)
                return NotFound();
            return Ok(Transform(result));
        }

        private CountryModel Transform(Country country)
        {
            if (country == null)
                return null;
            return new CountryModel()
            {
                Code = country.Code,
                Alpha3Code = country.Alpha3Code,
                Names = country.Names.ToDictionary(x => x.Key.ToString(), x => x.Value),
                Langues = country.Langues.Select(x => x.ToString()).ToList(),
            };
        }
        private StateModel Transform(State state)
        {
            if (state == null)
                return null;
            return new StateModel()
            {
                Code = state.Code,
                Names = state.Names.ToDictionary(x => x.Key.ToString(), x => x.Value),
                Langues = state.Langues.Select(x => x.ToString()).ToList(),
            };
        }
        private RegionModel Transform(Region region)
        {
            if (region == null)
                return null;
            return new RegionModel()
            {
                Code = region.Code,
                Names = region.Names.ToDictionary(x => x.Key.ToString(), x => x.Value),
                Langues = region.Langues.Select(x => x.ToString()).ToList()
            };
        }

        private IEnumerable<SpecificDayModel> Transform(IEnumerable<SpecificDay> days)
        {
            return days?.Select(x => new SpecificDayModel(x.Date, x.Names.ToDictionary(y => y.Key.ToString(), y => y.Value)));
        }
    }
}

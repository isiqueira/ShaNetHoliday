using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;
using ShaNetHoliday.WebService.Divers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShaNetHoliday.WebService.Controllers
{
    [RoutePrefix( "Regions" )]
    public class RegionController : ApiController
    {
        [HttpGet, Route( "{code}" )]
        public IHttpActionResult Get( string code )
        {
            var result = HolidaySystem.Instance.CountriesAvailable.SelectMany( x => x.States.SelectMany( y => y.Regions ) ).FirstOrDefault( x => x.Code == code );
            return result == null ? NotFound() : (IHttpActionResult)Ok( result.Transform() );
        }

        [HttpGet, Route( "{code}/Days" )]
        public IHttpActionResult Get1( string code, int year, RuleType rule = RuleType.All, Calendar calendar = Calendar.All )
        {
            var result = HolidaySystem.Instance.CountriesAvailable.SelectMany( x => x.States.SelectMany( y => y.Regions ) ).FirstOrDefault( x => x.Code == code );
            return result == null
                ? NotFound()
                : (IHttpActionResult)Ok( HolidaySystem.Instance.All( year, result.Parent.Parent.Code, result.Parent.Code, code, rule, calendar ).Transform() );
        }
    }
}

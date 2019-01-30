using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;
using ShaNetHoliday.WebService.Divers;

namespace ShaNetHoliday.WebService.Controllers
{
    [RoutePrefix( "States" )]
    public class StateController : ApiController
    {
        [HttpGet, Route( "{code}" )]
        public IHttpActionResult Get( string code )
        {
            var result = HolidaySystem.Instance.CountriesAvailable.SelectMany( x => x.States ).FirstOrDefault( x => x.Code == code );
            return result == null ? NotFound() : (IHttpActionResult)Ok( result.Transform() );
        }

        [HttpGet, Route( "{code}/Regions" )]
        public IHttpActionResult Get1( string code )
        {
            var result = HolidaySystem.Instance.CountriesAvailable.SelectMany( x => x.States ).FirstOrDefault( x => x.Code == code );
            return result == null ? NotFound() : (IHttpActionResult)Ok( result.Regions.Select( x => x.Transform() ).ToList() );
        }

        [HttpGet, Route( "{code}/Days" )]
        public IHttpActionResult Get2( string code, int year, RuleType rule = RuleType.All, Calendar calendar = Calendar.All )
        {
            var result = HolidaySystem.Instance.CountriesAvailable.SelectMany( x => x.States ).FirstOrDefault( x => x.Code == code );
            return result == null ? NotFound() : (IHttpActionResult)Ok( HolidaySystem.Instance.All( year, result.Parent.Code, code, rule, calendar ).Transform() );
        }
    }
}

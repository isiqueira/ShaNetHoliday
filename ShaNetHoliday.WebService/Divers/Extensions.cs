using ShaNetHoliday.Models;
using ShaNetHoliday.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShaNetHoliday.WebService.Divers
{
    public static class Extensions
    {
        public static CountryModel Transform( this Country country )
            => country == null
                ? null
                : new CountryModel() {
                    Code = country.Code,
                    Alpha3Code = country.Alpha3Code,
                    Names = country.Names.ToDictionary( x => x.Key.ToString(), x => x.Value ),
                    Langues = country.Langues.Select( x => x.ToString() ).ToList(),
                };

        public static StateModel Transform( this State state )
            => state == null
                ? null
                : new StateModel() {
                    Code = state.Code,
                    Names = state.Names.ToDictionary( x => x.Key.ToString(), x => x.Value ),
                    Langues = state.Langues.Select( x => x.ToString() ).ToList(),
                };

        public static RegionModel Transform( this Region region )
            => region == null
                ? null
                : new RegionModel() {
                    Code = region.Code,
                    Names = region.Names.ToDictionary( x => x.Key.ToString(), x => x.Value ),
                    Langues = region.Langues.Select( x => x.ToString() ).ToList()
                };

        public static IEnumerable<SpecificDayModel> Transform( this IEnumerable<SpecificDay> days )
            => days?.Select( x => new SpecificDayModel( x.Date, x.Names.ToDictionary( y => y.Key.ToString(), y => y.Value ) ) );

        public static IEnumerable<LongWeekEndModel> Transform( this IEnumerable<LongWeekEnd> longWeekends )
            => longWeekends?.Select( x => new LongWeekEndModel( x.StartDate, x.EndDate, x.HasBridge, x.ToString() ) );
    }
}

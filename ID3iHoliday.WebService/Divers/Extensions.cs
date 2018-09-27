using ID3iHoliday.Models;
using ID3iHoliday.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ID3iHoliday.WebService.Divers
{
    public static class Extensions
    {
        public static CountryModel Transform(this Country country)
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

        public static StateModel Transform(this State state)
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

        public static RegionModel Transform(this Region region)
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

        public static IEnumerable<SpecificDayModel> Transform(this IEnumerable<SpecificDay> days)
        {
            return days?.Select(x => new SpecificDayModel(x.Date, x.Names.ToDictionary(y => y.Key.ToString(), y => y.Value)));
        }

        public static IEnumerable<LongWeekEndModel> Transform(this IEnumerable<LongWeekEnd> longWeekends)
        {
            return longWeekends?.Select(x => new LongWeekEndModel(x.StartDate, x.EndDate, x.HasBridge, x.ToString()));
        }
    }
}
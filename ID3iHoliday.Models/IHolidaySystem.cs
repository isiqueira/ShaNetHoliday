using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    public interface IHolidaySystem
    {
        List<Country> CountriesAvailable { get; set; }
        IEnumerable<SpecificDay> All(int year, string countryCode, RuleType type = RuleType.All);
        IEnumerable<SpecificDay> All(int year, string countryCode, string stateCode, RuleType type = RuleType.All);
        IEnumerable<SpecificDay> All(int year, string countryCode, string stateCode, string regionCode, RuleType type = RuleType.All);

        IEnumerable<SpecificDay> Between(DateTime startDate, DateTime endDate, string countryCode, RuleType type = RuleType.All);
        IEnumerable<SpecificDay> Between(DateTime startDate, DateTime endDate, string countryCode, string stateCode, RuleType type = RuleType.All);
        IEnumerable<SpecificDay> Between(DateTime startDate, DateTime endDate, string countryCode, string stateCode, string regionCode, RuleType type = RuleType.All);

        SpecificDay Single(DateTime date, string countryCode, RuleType type = RuleType.Public);
        SpecificDay Single(DateTime date, string countryCode, string stateCode, RuleType type = RuleType.Public);
        SpecificDay Single(DateTime date, string countryCode, string stateCode, string regionCode, RuleType type = RuleType.Public);

        IEnumerable<LongWeekEnd> LongWeekEnds(int year, string countryCode);
        IEnumerable<LongWeekEnd> LongWeekEnds(int year, string countryCode, string stateCode);
        IEnumerable<LongWeekEnd> LongWeekEnds(int year, string countryCode, string stateCode, string regionCode);
    }
}

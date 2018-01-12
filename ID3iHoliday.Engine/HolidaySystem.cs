using ID3iCore;
using ID3iDate;
using ID3iHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Engine
{

    public partial class HolidaySystem : IHolidaySystem
    {
        public List<Country> CountriesAvailable { get; set; } = new List<Country>();

        public IEnumerable<SpecificDay> All(int year, string countryCode, RuleType type = RuleType.All)
            => All(year, countryCode, null, null, type);
        public IEnumerable<SpecificDay> All(int year, string countryCode, string stateCode, RuleType type = RuleType.All)
            => All(year, countryCode, stateCode, null, type);
        public IEnumerable<SpecificDay> All(int year, string countryCode, string stateCode, string regionCode, RuleType type = RuleType.All)
        {
            if (countryCode.IsNotNullOrEmpty() && stateCode.IsNotNullOrEmpty() && regionCode.IsNotNullOrEmpty())
                return CountriesAvailable.FirstOrDefault(x => x.Code == countryCode).Get(year, stateCode, regionCode, type);
            else if (countryCode.IsNotNullOrEmpty() && stateCode.IsNotNullOrEmpty() && regionCode.IsNullOrEmpty())
                return CountriesAvailable.FirstOrDefault(x => x.Code == countryCode).Get(year, stateCode, type);
            else
                return CountriesAvailable.FirstOrDefault(x => x.Code == countryCode).Get(year, type);
        }

        public IEnumerable<SpecificDay> Between(DateTime startDate, DateTime endDate, string countryCode, RuleType type = RuleType.All)
            => Between(startDate, endDate, countryCode, null, null, type);
        public IEnumerable<SpecificDay> Between(DateTime startDate, DateTime endDate, string countryCode, string stateCode, RuleType type = RuleType.All)
            => Between(startDate, endDate, countryCode, stateCode, null, type);
        public IEnumerable<SpecificDay> Between(DateTime startDate, DateTime endDate, string countryCode, string stateCode, string regionCode, RuleType type = RuleType.All)
        {
            if (startDate.IsAfter(endDate))
                throw new ArgumentException("startDate is after endDate.");
            var currentYear = startDate.Year;
            var endYear = endDate.Year;

            while (currentYear <= endYear)
            {
                IEnumerable<SpecificDay> items = null;
                if (countryCode.IsNotNullOrEmpty() && stateCode.IsNotNullOrEmpty() && regionCode.IsNotNullOrEmpty())
                    items = All(currentYear, countryCode, stateCode, regionCode, type);
                else if (countryCode.IsNotNullOrEmpty() && stateCode.IsNotNullOrEmpty() && regionCode.IsNullOrEmpty())
                    items = All(currentYear, countryCode, stateCode, type);
                else
                    items = All(currentYear, countryCode, type);
                foreach (var item in items)
                    if (item.Date >= startDate && item.Date <= endDate)
                        yield return item;
                currentYear++;
            }
        }

        public SpecificDay Single(DateTime date, string countryCode, RuleType type = RuleType.Public)
            => Single(date, countryCode, null, null, type);
        public SpecificDay Single(DateTime date, string countryCode, string stateCode, RuleType type = RuleType.Public)
            => Single(date, countryCode, stateCode, null, type);
        public SpecificDay Single(DateTime date, string countryCode, string stateCode, string regionCode, RuleType type = RuleType.Public)
        {
            var items = All(date.Year, countryCode, stateCode, regionCode, type);
            return items.Where(x => x.Type == type).FirstOrDefault(x => x.Date.Date == date.Date);
        }

        public IEnumerable<LongWeekEnd> LongWeekEnds(int year, string countryCode)
            => LongWeekEnds(year, countryCode, null, null);
        public IEnumerable<LongWeekEnd> LongWeekEnds(int year, string countryCode, string stateCode)
            => LongWeekEnds(year, countryCode, stateCode, null);
        public IEnumerable<LongWeekEnd> LongWeekEnds(int year, string countryCode, string stateCode, string regionCode)
        {
            var specificDays = All(year, countryCode, stateCode, regionCode, RuleType.Public);
            List<LongWeekEnd> lst = new List<LongWeekEnd>();
            foreach (var item in specificDays)
            {
                var longWeekEnd = DoSomeThing(specificDays, item, null, SearchType.All);
                if (longWeekEnd != null)
                    if (!lst.Any(x => x.StartDate <= longWeekEnd.StartDate && x.EndDate >= longWeekEnd.EndDate))
                        lst.Add(longWeekEnd);
            }
            return lst;
        }

        internal enum SearchType { All, StartDate, EndDate }
        private LongWeekEnd DoSomeThing(IEnumerable<SpecificDay> specificDays, SpecificDay specificDay, LongWeekEnd longWeekEnd, SearchType searchType = SearchType.All)
        {
            switch (specificDay.Date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return longWeekEnd;
                case DayOfWeek.Monday:
                    if (longWeekEnd == null)
                        longWeekEnd = new LongWeekEnd() { StartDate = 2.Days().Before(specificDay.Date), EndDate = specificDay.Date };
                    if (searchType == SearchType.StartDate || searchType == SearchType.All)
                    {
                        longWeekEnd.StartDate = 2.Days().Before(specificDay.Date);

                        var specFriday = specificDays.FirstOrDefault(x => x.Date == 4.Days().Before(specificDay.Date));
                        var specThursday = specificDays.FirstOrDefault(x => x.Date == 5.Days().Before(specificDay.Date));

                        if (specFriday != null)
                            DoSomeThing(specificDays, specFriday, longWeekEnd, SearchType.StartDate);
                        if (specThursday != null)
                            DoSomeThing(specificDays, specThursday, longWeekEnd, SearchType.StartDate);
                    }
                    if (searchType == SearchType.EndDate || searchType == SearchType.All)
                    {
                        longWeekEnd.EndDate = specificDay.Date;

                        var specTuesday = specificDays.FirstOrDefault(x => x.Date == 1.Days().After(specificDay.Date));
                        var specWednesday = specificDays.FirstOrDefault(x => x.Date == 2.Days().After(specificDay.Date));

                        if (specTuesday != null)
                            DoSomeThing(specificDays, specTuesday, longWeekEnd, SearchType.EndDate);
                        if (specWednesday != null)
                            DoSomeThing(specificDays, specWednesday, longWeekEnd, SearchType.EndDate);
                    }
                    return longWeekEnd;
                case DayOfWeek.Tuesday:
                    if (longWeekEnd == null)
                        longWeekEnd = new LongWeekEnd() { StartDate = 3.Days().Before(specificDay.Date), EndDate = specificDay.Date };
                    if (searchType == SearchType.StartDate || searchType == SearchType.All)
                    {
                        longWeekEnd.StartDate = 3.Days().Before(specificDay.Date);
                        longWeekEnd.HasBridge = true;

                        var specFriday = specificDays.FirstOrDefault(x => x.Date == 4.Days().Before(specificDay.Date));
                        var specThursday = specificDays.FirstOrDefault(x => x.Date == 5.Days().Before(specificDay.Date));

                        if (specFriday != null)
                            DoSomeThing(specificDays, specFriday, longWeekEnd, SearchType.StartDate);
                        if (specThursday != null)
                            DoSomeThing(specificDays, specThursday, longWeekEnd, SearchType.StartDate);
                    }
                    if (searchType == SearchType.EndDate || searchType == SearchType.All)
                    {
                        longWeekEnd.EndDate = specificDay.Date;

                        var specWednesday = specificDays.FirstOrDefault(x => x.Date == 1.Days().After(specificDay.Date));
                        var specThursday = specificDays.FirstOrDefault(x => x.Date == 2.Days().After(specificDay.Date));

                        if (specWednesday != null)
                            DoSomeThing(specificDays, specWednesday, longWeekEnd, SearchType.EndDate);
                        if (specThursday != null)
                            DoSomeThing(specificDays, specThursday, longWeekEnd, SearchType.EndDate);
                    }
                    return longWeekEnd;
                case DayOfWeek.Wednesday:
                    if (longWeekEnd != null && (searchType == SearchType.StartDate || searchType == SearchType.All))
                    {
                        longWeekEnd.StartDate = specificDay.Date;

                        var specTuesday = specificDays.FirstOrDefault(x => x.Date == 1.Days().Before(specificDay.Date));
                        var specMonday = specificDays.FirstOrDefault(x => x.Date == 2.Days().Before(specificDay.Date));

                        if (specTuesday != null)
                            DoSomeThing(specificDays, specTuesday, longWeekEnd, SearchType.StartDate);
                        if (specMonday != null)
                            DoSomeThing(specificDays, specMonday, longWeekEnd, SearchType.StartDate);
                    }
                    if (longWeekEnd != null && (searchType == SearchType.EndDate || searchType == SearchType.All))
                    {
                        longWeekEnd.EndDate = specificDay.Date;

                        var specThursday = specificDays.FirstOrDefault(x => x.Date == 1.Days().After(specificDay.Date));
                        var specFriday = specificDays.FirstOrDefault(x => x.Date == 2.Days().After(specificDay.Date));

                        if (specThursday != null)
                            DoSomeThing(specificDays, specThursday, longWeekEnd, SearchType.EndDate);
                        if (specFriday != null)
                            DoSomeThing(specificDays, specFriday, longWeekEnd, SearchType.EndDate);
                    }
                    return longWeekEnd;
                case DayOfWeek.Thursday:
                    {
                        if (longWeekEnd == null)
                            longWeekEnd = new LongWeekEnd() { StartDate = specificDay.Date, EndDate = 3.Days().After(specificDay.Date) };

                        if (searchType == SearchType.StartDate || searchType == SearchType.All)
                        {
                            longWeekEnd.StartDate = specificDay.Date;
                            longWeekEnd.HasBridge = true;

                            var specWednesday = specificDays.FirstOrDefault(x => x.Date == 1.Days().Before(specificDay.Date));
                            var specTuesday = specificDays.FirstOrDefault(x => x.Date == 2.Days().Before(specificDay.Date));

                            if (specWednesday != null)
                                DoSomeThing(specificDays, specWednesday, longWeekEnd, SearchType.StartDate);
                            if (specTuesday != null)
                                DoSomeThing(specificDays, specTuesday, longWeekEnd, SearchType.StartDate);
                        }
                        if (searchType == SearchType.EndDate || searchType == SearchType.All)
                        {
                            longWeekEnd.EndDate = 3.Days().After(specificDay.Date);

                            var specMonday = specificDays.FirstOrDefault(x => x.Date == 4.Days().After(specificDay.Date));
                            var specTuesday = specificDays.FirstOrDefault(x => x.Date == 5.Days().After(specificDay.Date));

                            if (specMonday != null)
                                DoSomeThing(specificDays, specMonday, longWeekEnd, SearchType.EndDate);
                            if (specTuesday != null)
                                DoSomeThing(specificDays, specTuesday, longWeekEnd, SearchType.EndDate);
                        }
                        return longWeekEnd;
                    }
                case DayOfWeek.Friday:
                    {
                        if (longWeekEnd == null)
                            longWeekEnd = new LongWeekEnd() { StartDate = specificDay.Date, EndDate = 2.Days().After(specificDay.Date) };
                        if (searchType == SearchType.StartDate || searchType == SearchType.All)
                        {
                            longWeekEnd.StartDate = specificDay.Date;

                            var specThursday = specificDays.FirstOrDefault(x => x.Date == 1.Days().Before(specificDay.Date));
                            var specWednesday = specificDays.FirstOrDefault(x => x.Date == 2.Days().Before(specificDay.Date));

                            if (specThursday != null)
                                DoSomeThing(specificDays, specThursday, longWeekEnd);
                            if (specWednesday != null)
                                DoSomeThing(specificDays, specWednesday, longWeekEnd);
                        }
                        if (searchType == SearchType.EndDate || searchType == SearchType.All)
                        {
                            var specMonday = specificDays.FirstOrDefault(x => x.Date == 3.Days().After(specificDay.Date));
                            var specTuesday = specificDays.FirstOrDefault(x => x.Date == 4.Days().After(specificDay.Date));

                            if (specMonday != null)
                                DoSomeThing(specificDays, specMonday, longWeekEnd);
                            if (specTuesday != null)
                                DoSomeThing(specificDays, specTuesday, longWeekEnd);
                        }
                        return longWeekEnd;
                    }
                case DayOfWeek.Saturday:
                    return longWeekEnd;
                default:
                    return longWeekEnd;
            }
        }
    }
}

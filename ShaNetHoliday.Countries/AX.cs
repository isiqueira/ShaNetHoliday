using ShaNetHoliday.Syntax;
using ShaNetDate;
using ShaNetHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ShaNetHoliday.Syntax.Count;
using static ShaNetHoliday.Models.RuleType;
using static ShaNetHoliday.Models.Calendar;

namespace ShaNetHoliday.Countries
{
    /// <summary>
    /// Définition pour Åland Islands.
    /// </summary>
    public class AX : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="AX"/>.
        /// </summary>
        public AX()
        {
            Code = "AX";
            Alpha3Code = "ALA";
            Names = NamesBuilder.Make.Add(Langue.EN, "Åland Islands").Add(Langue.SV, "Landskapet Åland").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.SV);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Nyårsdagen").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Trettondedag jul").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The30th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Ålands demilitariseringsdag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.SV, "Långfredagen").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.SV, "Påsk").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.SV, "Annandag påsk").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Första Maj").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay,
                    Names = NamesBuilder.Make.Add(Langue.SV, "Kristi himmelfärds dag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.SV, "Pingst").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The9th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Självstyrelsedagen").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Third, Friday).After("06-01").ThenStartAt("12:00"),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Midsommarafton").AsDictionary(),
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Third, Saturday).After("06-01"),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Midsommardagen").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The6th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Självständighetsdagen").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th).StartAtNoon,
                    Names = NamesBuilder.Make.Add(Langue.SV, "Julafton").AsDictionary(),
                    Type = Bank
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Juldagen").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Annandag jul").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The31st).StartAtNoon,
                    Names = NamesBuilder.Make.Add(Langue.SV, "Nyårsafton").AsDictionary(),
                    Type = Bank
                }
            };
        }
    }
}

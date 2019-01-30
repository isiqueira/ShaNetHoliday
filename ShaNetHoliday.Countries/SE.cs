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
using static ShaNetHoliday.Syntax.Month;
using static ShaNetHoliday.Models.RuleType;
using static ShaNetHoliday.Models.Calendar;

namespace ShaNetHoliday.Countries
{
    /// <summary>
    /// Définition pour Sweden.
    /// </summary>
    public class SE : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="SE"/>.
        /// </summary>
        public SE()
        {
            Code = "SE";
            Alpha3Code = "SWE";
            Names = NamesBuilder.Make.Add(Langue.EN, "Sweden").Add(Langue.SV, "Sverige").AsDictionary();
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
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.SV, "Långfredagen").AsDictionary()
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
                    Expression = ExpressionTree.Date.Movable(First, Sunday).Before(June),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Mors dag").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The6th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Sveriges nationaldag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Saturday).After("06-20"),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Midsommar").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Saturday).After("10-31"),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Alla Helgons dag").AsDictionary()
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
                    Expression = ExpressionTree.Date.Fix(On.January.The13th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Knut").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Sunday).In(March),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Vasaloppet").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The25th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Marie Bebådelsedag").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The30th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Valborgsmässoafton").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.SV, "Påsk").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.SV, "Pingst").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The6th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Gustav-Adolf-dagen").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The11th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Mårtensgås").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The10th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Nobeldagen").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The13th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Luciadagen").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Julafton").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The31st),
                    Names = NamesBuilder.Make.Add(Langue.SV, "Nyårsafton").AsDictionary(),
                    Type = Observance
                }
            };
        }
    }
}

using iD3iHoliday.Syntax;
using iD3iDate;
using iD3iHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static iD3iHoliday.Syntax.Count;
using static iD3iHoliday.Syntax.Month;
using static iD3iHoliday.Models.RuleType;
using static iD3iHoliday.Models.Calendar;

namespace iD3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Ukraine.
    /// </summary>
    public class UA : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="UA"/>.
        /// </summary>
        public UA()
        {
            Code = "UA";
            Alpha3Code = "UKR";
            Names = NamesBuilder.Make.Add(Langue.EN, "Ukraine").Add(Langue.UK, "Україна").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.UK);
            SupportedCalendar = new List<Calendar>() { Gregorian, Julian };
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.January.The1st).If(Saturday).Then.Next(Tuesday).Or.If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.UK, "Новий Рік").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.January.The2nd).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.UK, "Новий Рік").AsDictionary(),
                    Substitute = true
                },
                new JulianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.December.The25th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday).Over.Julian(),
                    Names = NamesBuilder.Make.Add(Langue.UK, "Різдво").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.March.The8th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.UK, "Міжнародний жіночий день").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Easter.StartAtMidnight.Duration.P2D(),
                    Names = NamesBuilder.Make.Add(Langue.UK, "Великдень").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Pentecost.StartAtMidnight.Duration.P2D(),
                    Names = NamesBuilder.Make.Add(Langue.UK, "Трійця").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.May.The1st).If(Saturday).Then.Next(Tuesday).Or.If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.UK, "День міжнародної солідарності трудящих").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.May.The2nd).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.UK, "День міжнародної солідарності трудящих").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.May.The9th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.UK, "День перемоги над нацизмом у Другій світовій війні").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.June.The28th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.UK, "День Конституції").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.August.The24th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.UK, "День Незалежності").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.October.The14th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday).Since(2015),
                    Names = NamesBuilder.Make.Add(Langue.UK, "День захисника України").AsDictionary(),
                    Substitute = true
                }
            };
        }
    }
}

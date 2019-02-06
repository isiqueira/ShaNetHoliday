using ShaNetCore;
using ShaNetDate;
using ShaNetHoliday.Models;
using ShaNetHoliday.Syntax;
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
    /// Définition pour Azerbaijan.
    /// </summary>
    public class AZ : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="AZ"/>.
        /// </summary>
        public AZ()
        {
            Code = "AZ";
            Alpha3Code = "AZE";
            Names = NamesBuilder.Make.Add(Langue.EN, "Azerbaijan").Add(Langue.AZ, "Azərbaycan Respublikası").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.AZ };
            SupportedCalendar.AddRange(Gregorian, Hijri);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.January.The1st).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Yeni il").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.January.The2nd).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Yeni il").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The20th),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Qara Yanvar").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.March.The8th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Qadınlar günü").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The20th).Since(2011),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Novruz").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.May.The9th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Faşizm üzərində qələbə günü").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.May.The28th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Respublika günü").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.June.The15th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Azərbaycan xalqının Milli Qurtuluş günü").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.June.The26th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Azərbaycan Respublikasının Silahlı Qüvvələri günü").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.October.The18th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Dövlət Müstəqilliyi günü").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.November.The9th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Dövlət Bayrağı günü").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The12th),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Konstitusiya günü").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The17th),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Milli Dirçəliş günü").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.December.The31st).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Dünya azərbaycanlıların həmrəyliyi günü").AsDictionary(),
                    Substitute = true
                },
                new HijriRule()
                {
                    Expression = ExpressionTree.Observe.Fix(OnM.Shawwal.The1st).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Tuesday).Over.Hijri(),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Ramazan Bayramı").AsDictionary(),
                    Substitute = true
                },
                new HijriRule()
                {
                    Expression = ExpressionTree.Observe.Fix(OnM.Shawwal.The2nd).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Tuesday).Over.Hijri(),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Ramazan Bayramı").AsDictionary(),
                    Substitute = true
                },
                new HijriRule()
                {
                    Expression = ExpressionTree.Observe.Fix(OnM.DhuAlHijjah.The10th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Tuesday).Over.Hijri(),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Qurban Bayramı").AsDictionary(),
                    Substitute = true
                },
                new HijriRule()
                {
                    Expression = ExpressionTree.Observe.Fix(OnM.DhuAlHijjah.The11th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Tuesday).Over.Hijri(),
                    Names = NamesBuilder.Make.Add(Langue.AZ, "Qurban Bayramı").AsDictionary(),
                    Substitute = true
                }
            };
        }
    }
}

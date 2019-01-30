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
    /// Définition pour Mexico.
    /// </summary>
    public class MX : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="MX"/>.
        /// </summary>
        public MX()
        {
            Code = "MX";
            Alpha3Code = "MEX";
            Names = NamesBuilder.Make.Add(Langue.EN, "Mexico").Add(Langue.ES, "México").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.ES);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Año Nuevo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).In(February),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de la Constitución (día libre)").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The21st),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Natalicio de Benito Juárez").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Third, Monday).In(March),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Natalicio de Benito Juárez (día libre)").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Fiesta del trabajo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The10th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de la Madre").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The16th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de la Independencia").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The20th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de la Revolución").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Third, Monday).In(November),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de la Revolución (día libre)").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The1st).StartAtMidnight.Every(6).Year.Since(1934),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Transmisión del Poder Ejecutivo Federal").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Navidad").AsDictionary()
                }
            };
        }
    }
}

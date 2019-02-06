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
    /// Définition pour Angola.
    /// </summary>
    public class AO: Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="AO"/>.
        /// </summary>
        public AO()
        {
            Code = "AO";
            Alpha3Code = "AGO";
            Names = NamesBuilder.Make.Add(Langue.EN, "Angola").Add(Langue.PT, "Angola").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.PT };
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Ano Novo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The4th),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Dia do Início da Luta Armada de Libertação Nacional").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CarnivalTuesday,
                    Names = NamesBuilder.Make.Add(Langue.PT, "Carnaval").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The8th),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Dia Internacional da Mulher").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.PT, "Sexta-Feira Santa").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.PT, "Páscoa").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The4th),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Dia da Paz").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Dia do trabalhador").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Dia das Mães").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The17th),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Fundador da Nação e Dia dos Heróis Nacionais").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The2nd),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Dia de Finados").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The11th),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Dia da Independência").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Natal").AsDictionary()
                }
            };
        }
    }
}

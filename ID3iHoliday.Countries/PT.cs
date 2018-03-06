using ID3iDate;
using ID3iHoliday.Models;
using ID3iHoliday.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ID3iHoliday.Syntax.Count;
using static ID3iHoliday.Syntax.Month;
using static ID3iHoliday.Models.RuleType;
using static ID3iHoliday.Syntax.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Portugal.
    /// </summary>
    public class PT : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="PT"/>.
        /// </summary>
        public PT()
        {
            Code = "PT";
            Alpha3Code = "PRT";
            Names = NamesBuilder.Make.Add(Langue.EN, "Portugal").Add(Langue.PT, "Portugal").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.PT);
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
                    Expression = ExpressionTree.Date.Catholic.CarnivalTuesday,
                    Names = NamesBuilder.Make.Add(Langue.PT, "Carnaval").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.PT, "Sexta-Feira Santa").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.PT, "Páscoa").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The25th),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Dia da Liberdade").AsDictionary()
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
                    Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                    Names = NamesBuilder.Make.Add(Langue.PT, "Corpo de Deus").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The10th),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Dia de Portugal").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Assunção").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The5th),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Implantação da República").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Todos os santos").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The1st),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Restauração da Independência").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The8th),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Imaculada Conceição").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Noite de Natal").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Natal").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The31st),
                    Names = NamesBuilder.Make.Add(Langue.PT, "Véspera de Ano Novo").AsDictionary(),
                    Type = Observance
                }
            };
        }
    }
}

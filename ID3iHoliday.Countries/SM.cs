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
    /// Définition pour San Marino.
    /// </summary>
    public class SM : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="SM"/>.
        /// </summary>
        public SM()
        {
            Code = "SM";
            Alpha3Code = "SMR";
            Names = NamesBuilder.Make.Add(Langue.EN, "San Marino").Add(Langue.IT, "San Marino").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.IT);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Capodanno").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Epifania").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The5th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Festa di Sant’Agata").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.IT, "Domenica di Pasqua").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.IT, "Lunedì dell’Angelo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The25th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Anniversario dell'Arengo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The1st),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Cerimonia di investitura dei Capitani Reggenti").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Festa del Lavoro").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Festa della mamma").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                    Names = NamesBuilder.Make.Add(Langue.IT, "Corpus Domini").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The28th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Anniversario della caduta del Fascismo e Festa della Libertà").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Ferragosto").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The3rd),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Festa di San Marino e di Fondazione della Repubblica").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The1st),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Cerimonia di investitura dei Capitani Reggenti").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Tutti i Santi").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The2nd),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Commemorazione dei defunti").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The8th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Immacolata Concezione").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Natale").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Santo Stefano").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The31st),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Ultimo dell’anno").AsDictionary(),
                    Type = Optional
                }
            };
        }
    }
}

using ID3iHoliday.Syntax;
using ID3iDate;
using ID3iHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ID3iHoliday.Syntax.Count;
using static ID3iHoliday.Syntax.Month;
using static ID3iHoliday.Models.RuleType;
using static ID3iHoliday.Models.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Finland.
    /// </summary>
    public class FI : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="FI"/>.
        /// </summary>
        public FI()
        {
            Code = "FI";
            Alpha3Code = "FIN";
            Names = NamesBuilder.Make.Add(Langue.EN, "Finland").Add(Langue.FI, "Suomi").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.FI);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.FI, "Uudenvuodenpäivä").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.FI, "Loppiainen").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.FI, "Pitkäperjantai").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.FI, "Pääsiäispäivä").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.FI, "2. pääsiäispäivä").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.FI, "Vappu").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay,
                    Names = NamesBuilder.Make.Add(Langue.FI, "Helatorstai").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.FI, "Helluntaipäivä").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.FI, "Äitien päivä").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Friday).After("06-19"),
                    Names = NamesBuilder.Make
                                .Add(Langue.FI, "Juhannusaatto")
                                .Add(Langue.SV, "Midsommarafton").AsDictionary(),
                    Type = Bank
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Saturday).After("06-20"),
                    Names = NamesBuilder.Make
                                .Add(Langue.FI, "Juhannuspäivä")
                                .Add(Langue.SV, "Midsommardagen").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Saturday).After("10-31"),
                    Names = NamesBuilder.Make.Add(Langue.FI, "Pyhäinpäivä").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The6th),
                    Names = NamesBuilder.Make.Add(Langue.FI, "Itsenäisyyspäivä").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th),
                    Names = NamesBuilder.Make.Add(Langue.FI, "Jouluaatto").AsDictionary(),
                    Type = Bank
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.FI, "Joulupäivä").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.FI, "2. joulupäivä").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The31st).StartAt2PM.UntilMidnight.If(Sunday).ThenStartAtMidnight,
                    Names = NamesBuilder.Make.Add(Langue.FI, "Uudenvuodenaatto").AsDictionary(),
                    Type = Bank
                }
            };
        }
    }
}

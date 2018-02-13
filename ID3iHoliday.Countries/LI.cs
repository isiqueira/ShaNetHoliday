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

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Lichtenstein.
    /// </summary>
    public class LI : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="LI"/>.
        /// </summary>
        public LI()
        {
            Code = "LI";
            Alpha3Code = "LIE";
            Names = NamesBuilder.Make.Add(Langue.EN, "Lichtenstein").Add(Langue.DE, "Lichtenstein").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.DE);
            Rules = new ListRule()
            {
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Neujahr").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The2nd),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Berchtoldstag").AsDictionary(),
                    Type = Bank
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Heilige Drei Könige").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The2nd),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Lichtmess").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The19th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Josefstag").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.CarnivalTuesday,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Faschingsdienstag").AsDictionary(),
                    Type = Bank
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Karfreitag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Ostersonntag").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Ostermontag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Tag der Arbeit").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Muttertag").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Auffahrt").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.CustomDay("EASTER +40"),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Feiertagsbrücke").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Pfingstsonntag").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Pfingstmontag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.CustomDay("EASTER +61"),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Feiertagsbrücke").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Staatsfeiertag").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The8th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Geburt").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The8th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Empfängnis").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Heiliger Abend").AsDictionary(),
                    Type = Bank
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Weihnachten").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Stephanstag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The31st),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Silvester").AsDictionary(),
                    Type = Bank
                }
            };
        }
    }
}

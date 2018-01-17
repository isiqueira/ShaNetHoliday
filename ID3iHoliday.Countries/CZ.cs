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
using ID3iHoliday.Syntax;
using ID3iDate;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Czech Republic.
    /// </summary>
    public class CZ : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="CZ"/>.
        /// </summary>
        public CZ()
        {
            Code = "CZ";
            Alpha3Code = "CZE";
            Names = NamesBuilder.Make.Add(Langue.EN, "Czech Republic").Add(Langue.CZ, "Česká republika").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.CZ);
            Rules = new ListRule()
            {
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Nový rok; Den obnovy samostatného českého státu").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.CustomDay("EASTER -4"),
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Škaredá středa").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.MaundyThursday,
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Zelený čtvrtek").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Velikonoční pátek").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.HolySaturday,
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Bílá sobota").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.CZ, " Neděle velikonoční").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Velikonoční pondělí").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Svátek práce").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The8th),
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Den vítězství or Den osvobození").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Den matek").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The5th),
                    Names = NamesBuilder.Make.Add(Langue.CZ, " Den slovanských věrozvěstů Cyrila a Metoděje").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The6th),
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Den upálení mistra Jana Husa").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The28th),
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Den české státnosti").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The28th),
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Den vzniku samostatného československého státu").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The17th),
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Den boje za svobodu a demokracii").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th),
                    Names = NamesBuilder.Make.Add(Langue.CZ, "Štědrý den").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.CZ, "1. svátek vánoční").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.CZ, "2. svátek vánoční").AsDictionary()
                }
            };
        }
    }
}

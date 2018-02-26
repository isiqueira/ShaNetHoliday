using ID3iCore;
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
    /// Définition pour Netherlands.
    /// </summary>
    public class NL : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="NL"/>.
        /// </summary>
        public NL()
        {
            Code = "NL";
            Alpha3Code = "NLD";
            Names = NamesBuilder.Make.Add(Langue.EN, "Netherlands").Add(Langue.NL, "Nederland").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.NL);
            Rules = new ListRule()
            {
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Nieuwjaar").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.NL, "Goede Vrijdag").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.NL, "Pasen").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.NL, "Paasmaandag").AsDictionary(),
                },
                new Rule()
                {
                    Expression = ExpressionTree.Move.Fix(On.April.The27th).If(Sunday).Then.Previous(Saturday),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Koningsdag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The4th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Nationale Dodenherdenking").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The5th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Bevrijdingsdag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Moederdag").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(Third, Sunday).In(June),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Vaderdag").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay,
                    Names = NamesBuilder.Make.Add(Langue.NL, "O.L.H. Hemelvaart").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.NL, "Pinksteren").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make.Add(Langue.NL, "Pinkstermaandag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(Third, Tuesday).In(September),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Prinsjesdag").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The4th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Dierendag").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The11th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Sint Maarten").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The5th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Sinterklaasavond").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The15th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Koninkrijksdag").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Kerstmis").AsDictionary(),
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Tweede kerstdag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The31st),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Oudejaarsavond").AsDictionary(),
                    Type = Bank
                }
            };
        }
    }
}

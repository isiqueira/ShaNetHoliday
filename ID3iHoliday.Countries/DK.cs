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
    /// Définition pour Denmark.
    /// </summary>
    public class DK : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="DK"/>.
        /// </summary>
        public DK()
        {
            Code = "DK";
            Alpha3Code = "DNK";
            Names = NamesBuilder.Make.Add(Langue.EN, "Denmark").Add(Langue.DA, "Danmark").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.DA);
            Rules = new ListRule()
            {
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.DA, "Nytår").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.CarnivalMonday,
                    Names = NamesBuilder.Make.Add(Langue.DA, "Fastelavn").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.MaundyThursday,
                    Names = NamesBuilder.Make.Add(Langue.DA, "Skærtorsdag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.DA, "Langfredag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.DA, "Påskesøndag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.DA, "Anden påskedag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.CustomDay("EASTER +26"),
                    Names = NamesBuilder.Make
                                .Add(Langue.DA, "Store Bededag")
                                .Add(Langue.DE, "Buß- und Bettag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay,
                    Names = NamesBuilder.Make.Add(Langue.DA, "Kristi Himmelfartsdag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.DA, "Mors Dag").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.DA, "Pinsedag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make.Add(Langue.DA, "2. Pinsedag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.DA, "1. Juledag").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.DA, "2. Juledag").AsDictionary()
                }
            };
        }
    }
}

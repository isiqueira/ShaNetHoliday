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
    /// Définition pour Lithuania.
    /// </summary>
    public class LT : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="LT"/>.
        /// </summary>
        public LT()
        {
            Code = "LT";
            Alpha3Code = "LTU";
            Names = NamesBuilder.Make.Add(Langue.EN, "Lithuania").Add(Langue.LT, "Lietuva").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.LT);
            Rules = new ListRule()
            {
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Naujieji metai").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The16th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Lietuvos valstybės atkūrimo diena").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The11th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Lietuvos nepriklausomybės atkūrimo diena").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.LT, "Velykos").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Tarptautinė darbo diena").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Motinos diena").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Sunday).In(June),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Tėvo diena").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The24th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Joninės, Rasos").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The6th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Valstybės diena").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Žolinė").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Visų šventųjų diena").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Šv. Kūčios").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Šv. Kalėdos").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "2. Kalėdų diena").AsDictionary()
                }
            };
        }
    }
}

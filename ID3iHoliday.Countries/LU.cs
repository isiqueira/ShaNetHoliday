using ID3iDate;
using ID3iHoliday.Models;
using ID3iHoliday.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ID3iHoliday.Models.RuleType;
using static ID3iHoliday.Syntax.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Luxembourg.
    /// </summary>
    public class LU : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="LU"/>.
        /// </summary>
        public LU()
        {
            Code = "LU";
            Alpha3Code = "LUX";
            Names = NamesBuilder.Make.Add(Langue.EN, "Luxembourg").Add(Langue.FR, "Luxembourg").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.FR);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Nouvel An").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.FR, "Vendredi saint").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.FR, "Pâques").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.FR, "Lundi de Pâques").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.FR, "1er mai").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay,
                    Names = NamesBuilder.Make.Add(Langue.FR, "Ascension").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make.Add(Langue.FR, "Lundi de Pentecôte").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The23rd),
                    Names = NamesBuilder.Make.Add(Langue.FR, "L’anniversaire du Grand-Duc").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Assomption").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Toussaint").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The11th),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Armistice 1918").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Noël").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Lendemain de Noël").AsDictionary()
                }
            };
        }
    }
}

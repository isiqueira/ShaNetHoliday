using iD3iDate;
using iD3iHoliday.Models;
using iD3iHoliday.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static iD3iHoliday.Syntax.Count;
using static iD3iHoliday.Syntax.Month;
using static iD3iHoliday.Models.RuleType;
using static iD3iHoliday.Models.Calendar;

namespace iD3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Slovakia.
    /// </summary>
    public class SK : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="SK"/>.
        /// </summary>
        public SK()
        {
            Code = "SK";
            Alpha3Code = "SVK";
            Names = NamesBuilder.Make.Add(Langue.EN, "Slovakia").Add(Langue.SK, "Slovenská republika").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.SK);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Deň vzniku Slovenskej republiky").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Zjavenie Pána").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.SK, "Veľkonočný piatok").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.SK, "Veľká noc").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.SK, "Veľkonočný pondelok").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Sviatok práce").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The8th),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Deň víťazstva nad fašizmom").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Mother's Day").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The5th),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Sviatok svätého Cyrila a Metoda").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The29th),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Výročie Slovenského národného povstania").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The1st),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Deň Ústavy").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The15th),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Sviatok Panny Márie Sedembolestnej").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Sviatok všetkých svätých").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The17th),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Deň boja za slobodu a demokraciu").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Štedrý deň").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Prvý sviatok vianočný").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.SK, "Druhý sviatok vianočný").AsDictionary()
                }
            };
        }
    }
}

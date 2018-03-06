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
using static ID3iHoliday.Syntax.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Jersey.
    /// </summary>
    public class JE : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="JE"/>.
        /// </summary>
        public JE()
        {
            Code = "JE";
            Alpha3Code = "JEY";
            Names = NamesBuilder.Make.Add(Langue.EN, "Jersey").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.EN);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.EN, "New Year's Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Good Friday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Easter Monday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Early May Bank Holiday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The9th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Liberation Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).Before(June),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Spring Bank Holiday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).Before(September),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Summer Bank Holiday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Boxing Day").AsDictionary()
                }
            };
        }
    }
}

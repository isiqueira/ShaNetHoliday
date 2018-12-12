using iD3iHoliday.Syntax;
using iD3iDate;
using iD3iHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static iD3iHoliday.Syntax.Count;
using static iD3iHoliday.Syntax.Month;
using static iD3iHoliday.Models.Calendar;

namespace iD3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Isle of Man.
    /// </summary>
    public class IM : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="IM"/>.
        /// </summary>
        public IM()
        {
            Code = "IM";
            Alpha3Code = "IMN";
            Names = NamesBuilder.Make.Add(Langue.EN, "Isle of Man").AsDictionary();
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
                    Names = NamesBuilder.Make.Add(Langue.EN, "Labour Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).Before(June),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Spring Bank Holiday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Friday).In(June),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Tourist Trophy, Senior Race Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The5th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Tynwald Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).Before(September),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Late Summer Bank Holiday").AsDictionary()
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

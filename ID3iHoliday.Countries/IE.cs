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
using static ID3iHoliday.Syntax.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Ireland.
    /// </summary>
    public class IE : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="IE"/>.
        /// </summary>
        public IE()
        {
            Code = "IE";
            Alpha3Code = "IRL";
            Names = NamesBuilder.Make.Add(Langue.EN, "Ireland").AsDictionary();
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
                    Expression = ExpressionTree.Date.Fix(On.March.The17th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "St. Patrick’s Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CustomDay("EASTER -21"),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Mothers Day").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Good Friday").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Easter Sunday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Easter Monday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.EN, "May Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).In(June),
                    Names = NamesBuilder.Make.Add(Langue.EN, "First Monday in June").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).In(August),
                    Names = NamesBuilder.Make.Add(Langue.EN, "First Monday in August").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).Before("10-31"),
                    Names = NamesBuilder.Make.Add(Langue.EN, "October Bank Holiday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "St. Stephen's Day").AsDictionary()
                }
            };
        }
    }
}

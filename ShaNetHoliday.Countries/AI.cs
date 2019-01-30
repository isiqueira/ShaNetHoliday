using ShaNetDate;
using System;
using System.Collections.Generic;
using ShaNetHoliday.Models;
using ShaNetHoliday.Syntax;

using static System.DayOfWeek;
using static ShaNetHoliday.Syntax.Count;
using static ShaNetHoliday.Syntax.Month;
using static ShaNetHoliday.Models.RuleType;
using static ShaNetHoliday.Models.Calendar;

namespace ShaNetHoliday.Countries
{
    /// <summary>
    /// Définition pour Anguilla.
    /// </summary>
    public class AI : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="AI"/>.
        /// </summary>
        public AI()
        {
            Code = "AI";
            Alpha3Code = "AIA";
            Names = NamesBuilder.Make.Add(Langue.EN, "Anguilla").AsDictionary();
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
                    Expression = ExpressionTree.Date.Fix(On.March.The2nd),
                    Names = NamesBuilder.Make.Add(Langue.EN, "James Ronald Webster Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Good Friday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Easter Sunday").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Easter Monday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Labour Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The30th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Anguilla Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Pentecost").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Whit Monday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Monday).In(June),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Celebration of the Birthday of Her Majesty the Queen").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).In(August),
                    Names = NamesBuilder.Make.Add(Langue.EN, "August Monday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Thursday).In(August),
                    Names = NamesBuilder.Make.Add(Langue.EN, "August Thursday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Friday).In(August),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Constitution Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The19th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "National Heroes and Heroines Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.December.The25th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Day").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.December.The26th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Boxing Day").AsDictionary(),
                    Substitute = true
                }
            };
        }
    }
}

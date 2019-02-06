using iD3iHoliday.Syntax;
using iD3iCore;
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
using static iD3iHoliday.Models.RuleType;
using static iD3iHoliday.Models.Calendar;
using iD3iHoliday.Syntax.Composition;

namespace iD3iHoliday.Countries
{
    /// <summary>
    /// Définition pour American Samoa.
    /// </summary>
    public class AS : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="AS"/>.
        /// </summary>
        public AS()
        {
            Code = "AS";
            Alpha3Code = "ASM";
            Names = NamesBuilder.Make.Add(Langue.EN, "American Samoa").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.EN };
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.January.The1st).If(Sunday).Then.Next(Monday).Or.If(Saturday).Then.Previous(Friday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "New Year's Day").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Key = "3MOJAN",
                    Expression = ExpressionTree.Date.Movable(Third, Monday).In(January),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Martin Luther King Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Key = "3MOFEB",
                    Expression = ExpressionTree.Date.Movable(Third, Monday).In(February),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Washington’s Birthday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The14th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Valentine's Day").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Move.Fix(On.April.The15th).If(Friday).Then.Next(Monday).Or.If(Saturday).Then.Next(Tuesday).Or.If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Tax Day").AsDictionary(),
                    Type = Observance,
                    IsEnable = false
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Wednesday).Before("04-28"),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Administrative Professionals Day").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Mother's Day").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).Before(June),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Memorial Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Third, Sunday).In(June),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Father's Day").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.July.The4th).If(Sunday).Then.Next(Monday).Or.If(Saturday).Then.Previous(Friday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Independence Day").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).In(September),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Labor Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Key = "2MOOCT",
                    Expression = ExpressionTree.Date.Movable(Second, Monday).In(October),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Columbus Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The31st).StartAt("18:00"),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Halloween").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The11th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Veterans Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Key = "ELECTIONDAY",
                    Expression = ExpressionTree.Date.MovableFromMovable(First, Tuesday).After(First, Monday).In(November).Every(4).Year.Since(1848),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Election Day").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Fourth, Thursday).In(November),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Thanksgiving Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Key = "1FRIA4THUNOV",
                    Expression = ExpressionTree.Date.MovableFromMovable(First, Friday).After(Fourth, Thursday).In(November),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Day after Thanksgiving Day").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Key = "DEC24",
                    Expression = ExpressionTree.Date.Fix(On.December.The24th).StartAtNoon,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Eve").AsDictionary(),
                    Type = Bank
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.December.The25th).If(Sunday).Then.Next(Monday).Or.If(Saturday).Then.Previous(Friday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Day").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Key = "DEC31",
                    Expression = ExpressionTree.Date.Fix(On.December.The31st).StartAtNoon,
                    Names = NamesBuilder.Make.Add(Langue.EN, "New Year's Eve").AsDictionary(),
                    Type = Bank
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.April.The17th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "American Samoa Flag Day").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The16th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Manu'a Cession Day").AsDictionary(),
                    Type = Optional,
                    Note = "Goverment offices closed"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(October),
                    Names = NamesBuilder.Make.Add(Langue.EN, "White Sunday").AsDictionary(),
                    Type = Observance,
                    Note = "christian"
                }
            };
        }
    }
}

using ID3iHoliday.Syntax;
using ID3iDate;
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
using static ID3iHoliday.Models.Calendar;
using ID3iCore;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour United Kingdom.
    /// </summary>
    public class GB : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="GB"/>.
        /// </summary>
        public GB()
        {
            Code = "GB";
            Alpha3Code = "GBR";
            Names = NamesBuilder.Make.Add(Langue.EN, "United Kingdom").AsDictionary();
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
                    Key = "SUB01",
                    Expression = ExpressionTree.Substitute.Fix(On.January.The1st).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "New Year's Day").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CustomDay("EASTER -21"),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Mother's Day").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Good Friday").AsDictionary()
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
                    Names = NamesBuilder.Make.Add(Langue.EN, "Early May bank holiday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).Before(June),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Spring bank holiday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.December.The25th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Day").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Boxing Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.December.The26th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Boxing Day").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Specific(On.June.The5th.Of(2012)),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Queen’s Diamond Jubilee").AsDictionary()
                }
            };
            States = new ListState()
            {
                Langues = Langues,
                Container = { new GB_ALD(), new GB_ENG(), new GB_NIR(), new GB_SCT(), new GB_WLS() }
            }.Initialize(x => x.Init());
        }
        internal class GB_ALD : State
        {
            public GB_ALD()
            {
                Code = "ALD";
                Names = NamesBuilder.Make.Add(Langue.EN, "Alderney").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The15th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Homecoming Day").AsDictionary()
                    }
                };
            }
        }
        internal class GB_ENG : State
        {
            public GB_ENG()
            {
                Code = "ENG";
                Names = NamesBuilder.Make.Add(Langue.EN, "England").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).Before(September),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Summer bank holiday").AsDictionary()
                    }
                };
            }
        }
        internal class GB_NIR : State
        {
            public GB_NIR()
            {
                Code = "NIR";
                Names = NamesBuilder.Make.Add(Langue.EN, "Northern Ireland").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The17th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "St Patrick's Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Substitute.Fix(On.March.The17th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.EN, "St Patrick's Day").AsDictionary(),
                        Substitute = true
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.July.The12th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Battle of the Boyne, Orangemen’s Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Substitute.Fix(On.July.The12th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Battle of the Boyne").AsDictionary(),
                        Substitute = true
                    }
                };
            }
        }
        internal class GB_SCT : State
        {
            public GB_SCT()
            {
                Code = "SCT";
                Names = NamesBuilder.Make.Add(Langue.EN, "Scottland").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "SUB01",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Substitute.Fix(On.January.The1st).If(Saturday).Then.Next(Tuesday).Or.If(Sunday).Then.Next(Tuesday),
                        Names = NamesBuilder.Make.Add(Langue.EN, "New Year's Day").AsDictionary(),
                        Substitute = true
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Substitute.Fix(On.January.The2nd).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Januar 2nd").AsDictionary(),
                        Substitute = true
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(August),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Summer bank holiday").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The30th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "St Andrew’s Day").AsDictionary()
                    }
                };
            }
        }
        internal class GB_WLS : State
        {
            public GB_WLS()
            {
                Code = "WLS";
                Names = NamesBuilder.Make.Add(Langue.EN, "Wales").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).Before(September),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Summer bank holiday").AsDictionary()
                    }
                };
            }
        }
    }
}

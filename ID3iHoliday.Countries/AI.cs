using System;
using System.Collections.Generic;
using ID3iHoliday.Models;
using ID3iHoliday.Syntax;

using static System.DayOfWeek;
using static ID3iHoliday.Syntax.Count;
using static ID3iHoliday.Syntax.Month;
using static ID3iHoliday.Models.RuleType;
using ID3iDate;

namespace ID3iHoliday.Countries
{
    public class AI : Country
    {
        public AI()
        {
            Code = "AI";
            Alpha3Code = "AIA";
            Names = NamesBuilder.Make.Add(Langue.EN, "Anguilla").AsDictionary();
            DaysOff = new List<DayOfWeek>() { Sunday };
            Langues = new List<Langue>() { Langue.EN };
            Rules = new ListRule()
            {
                Langues = Langues,
                Container =
                {
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The1st),
                        Names = NamesBuilder.Make.Add(Langue.EN, "New Year's Day").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The2nd),
                        Names = NamesBuilder.Make.Add(Langue.EN, "James Ronald Webster Day").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "Good Friday").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.Easter,
                        Names = NamesBuilder.Make.Add(Langue.EN, "Easter Sunday").AsDictionary(),
                        Type = Observance
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.EasterMonday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "Easter Monday").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The1st),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Labour Day").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The30th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Anguilla Day").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.Pentecost,
                        Names = NamesBuilder.Make.Add(Langue.EN, "Pentecost").AsDictionary(),
                        Type = Observance
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.WhitMonday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "Whit Monday").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Movable(Second, Monday).In(June),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Celebration of the Birthday of Her Majesty the Queen").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(August),
                        Names = NamesBuilder.Make.Add(Langue.EN, "August Monday").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Thursday).In(August),
                        Names = NamesBuilder.Make.Add(Langue.EN, "August Thursday").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Friday).In(August),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Constitution Day").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The19th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "National Heroes and Heroines Day").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Observe.Fix(On.December.The25th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Tuesday),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Day").AsDictionary(),
                        Substitute = true
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Observe.Fix(On.December.The26th).If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Boxing Day").AsDictionary(),
                        Substitute = true
                    }
                }
            };
        }
    }
}

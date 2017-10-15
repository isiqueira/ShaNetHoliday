using ID3iHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ID3iHoliday.Models.RuleType;
using static ID3iHoliday.Models.Rule.SpecificDayKey;
using ID3iHoliday.Syntax;

namespace ID3iHoliday.Countries
{
    public class AG : Country
    {
        public AG()
        {
            Code = "AG";
            Alpha3Code = "ATG";
            Names = new Dictionary<Langue, string>() { { Langue.EN, "Antigua & Barbuda" } };
            DaysOff = new List<DayOfWeek>() { Sunday };
            Langues = new List<Langue>() { Langue.EN };
            Rules = new ListRule()
            {
                Langues = Langues,
                Container =
                {
                    new Rule()
                    {
                        SpecDayKey = Jan01Key,
                        Expression = ExpressionTree.Observe.Fix(On.January.The1st).If(Sunday).Then.Next(Monday),
                        Substitute = true
                    },
                    Rule.GoodFriday,
                    Rule.Easter.Initialize(x => x.Type = Observance),
                    Rule.EasterMonday,
                    Rule.May01,
                    Rule.Pentecost.Initialize(x => x.Type = Observance),
                    Rule.WhitMonday,
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The1st),
                        Names = new Dictionary<Langue, string>() { { Langue.EN, "J'Ouvert Morning" } }
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The2nd),
                        Names = new Dictionary<Langue, string>() { { Langue.EN, "Last Lap" } }
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Move.Fix(On.November.The11th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                        Names = new Dictionary<Langue, string>() { { Langue.EN, "Independance Day"} }
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The9th),
                        Names = new Dictionary<Langue, string>() { {  Langue.EN, "V.C Bird Day"} }
                    },
                    new Rule()
                    {
                        SpecDayKey = Dec25Key,
                        Expression = ExpressionTree.Observe.Fix(On.December.The25th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Tuesday),
                        Substitute = true
                    },
                    new Rule()
                    {
                        SpecDayKey = Dec26Key,
                        Expression=  ExpressionTree.Observe.Fix(On.December.The26th).If(Sunday).Then.Next(Monday),
                        Substitute = true
                    }
                }
            };
            States = new ListState()
            {
                Langues = Langues,
                Container = { new AG_10() }
            }.Initialize(x => x.Init());
        }
        internal class AG_10 : State
        {
            public AG_10()
            {
                Code = "10";
                Names = new Dictionary<Langue, string>() { { Langue.EN, "Barbuda" } };
                Rules = new ListRule()
                {
                    Langues = Langues,
                    Container =
                    {
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.Catholic.CarnivalTuesday.Duration("P4D"),
                            Names = new Dictionary<Langue, string>() { { Langue.EN, "Caribana" } },
                            Type = Observance
                        }
                    }
                };
            }
        }
    }
}

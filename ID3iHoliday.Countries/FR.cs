using System;
using System.Collections.Generic;
using ID3iHoliday.Models;
using ID3iHoliday.Syntax;

using static System.DayOfWeek;
using static ID3iHoliday.Syntax.Count;
using static ID3iHoliday.Syntax.Month;
using static ID3iHoliday.Models.RuleType;
using static ID3iHoliday.Models.Rule.SpecificDayKey;

namespace ID3iHoliday.Countries
{
    public class FR : Country
    {
        public FR()
        {
            Code = "FR";
            Alpha3Code = "FRA";
            Names = new Dictionary<Langue, string>() { { Langue.FR, "France" }, { Langue.EN, "France" } };
            DaysOff = new List<DayOfWeek>() { Sunday };
            Langues = new List<Langue>() { Langue.FR };
            Rules = new ListRule()
            {
                Langues = Langues,
                Container =
                {
                    Rule.Jan01,
                    Rule.EasterMonday,
                    Rule.May01,
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The8th),
                        Names = new Dictionary<Langue, string>() { { Langue.FR, "Fête de la Victoire 1945" } }
                    },
                    Rule.Ascension,
                    Rule.Pentecost,
                    Rule.WhitMonday,
                    new Rule()
                    {
                        SpecDayKey = MotherDayKey,
                        Expression =  ExpressionTree.Date.Movable(First, Sunday).Before(June),
                        Type = Observance,
                    },
                    new Rule()
                    {
                        SpecDayKey = NationalDayKey,
                        Expression = ExpressionTree.Date.Fix(On.July.The14th)
                    },
                    Rule.Aug15,
                    Rule.Nov01,
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The11th),
                        Names = new Dictionary<Langue, string>() { { Langue.FR, "Armistice 1918"} }
                    },
                    Rule.Dec25
                }
            };
            States = new ListState()
            {
                Langues = Langues,
                Container = { new FR_67(), new FR_68(), new FR_57(), new FR_YT(), new FR_MQ(), new FR_GP(), new FR_GF(), new FR_RE() }
            }.Initialize(x => x.Init());
        }

        internal class FR_67 : State
        {
            public FR_67()
            {
                Code = "67";
                Names = new Dictionary<Langue, string>() { { Langue.FR, "Département du Bas-Rhin" } };
                Rules = new ListRule()
                {
                    Langues = Langues,
                    Container =
                        {
                            Rule.GoodFriday,
                            Rule.Dec26
                        }
                };
            }
        }
        internal class FR_68 : State
        {
            public FR_68()
            {
                Code = "68";
                Names = new Dictionary<Langue, string>() { { Langue.FR, "Département du Haut-Rhin" } };
                Rules = new ListRule()
                {
                    Langues = Langues,
                    Container =
                        {
                            Rule.GoodFriday,
                            Rule.Dec26
                        }
                };
            }
        }
        internal class FR_57 : State
        {
            public FR_57()
            {
                Code = "57";
                Names = new Dictionary<Langue, string>() { { Langue.FR, "Département Moselle" } };
                Rules = new ListRule()
                {
                    Langues = Langues,
                    Container =
                        {
                            Rule.GoodFriday,
                            Rule.Dec26
                        }
                };
            }
        }
        internal class FR_YT : State
        {
            public FR_YT()
            {
                Code = "YT";
                Names = new Dictionary<Langue, string>() { { Langue.FR, "Département et région d'outre-mer Mayotte" } };
                Rules = new ListRule()
                {
                    Langues = Langues,
                    Container =
                    {
                        Rule.AbolitionSlavery.Initialize(x => x.Expression = ExpressionTree.Date.Fix(On.April.The27th))
                    }
                };
            }
        }
        internal class FR_MQ : State
        {
            public FR_MQ()
            {
                Code = "MQ";
                Names = new Dictionary<Langue, string>() { { Langue.FR, "Département et région d'outre-mer Martinique" } };
                Rules = new ListRule()
                {
                    Langues = Langues,
                    Container =
                    {
                        Rule.GoodFriday,
                        Rule.AbolitionSlavery.Initialize(x => x.Expression = ExpressionTree.Date.Fix(On.May.The22nd))
                    }
                };
            }
        }
        internal class FR_GP : State
        {
            public FR_GP()
            {
                Code = "GP";
                Names = new Dictionary<Langue, string>() { { Langue.FR, "Département et région d'outre-mer Guadeloupe" } };
                Rules = new ListRule()
                {
                    Langues = Langues,
                    Container =
                    {
                        Rule.GoodFriday,
                        Rule.AbolitionSlavery.Initialize(x => x.Expression = ExpressionTree.Date.Fix(On.May.The27th))
                    }
                };
            }
        }
        internal class FR_GF : State
        {
            public FR_GF()
            {
                Code = "GF";
                Names = new Dictionary<Langue, string>() { { Langue.FR, "Département et région d'outre-mer Guyane" } };
                Rules = new ListRule()
                {
                    Langues = Langues,
                    Container =
                    {
                        Rule.AbolitionSlavery.Initialize(x => x.Expression = ExpressionTree.Date.Fix(On.June.The10th))
                    }
                };
            }
        }
        internal class FR_RE : State
        {
            public FR_RE()
            {
                Code = "RE";
                Names = new Dictionary<Langue, string>() { { Langue.FR, "Département et région d'outre-mer La Réunion" } };
                Rules = new ListRule()
                {
                    Langues = Langues,
                    Container =
                    {
                        Rule.AbolitionSlavery.Initialize(x => x.Expression = ExpressionTree.Date.Fix(On.December.The20th))
                    }
                };
            }
        }
    }
}

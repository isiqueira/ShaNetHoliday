using ShaNetCore;
using ShaNetDate;
using ShaNetHoliday.Models;
using ShaNetHoliday.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ShaNetHoliday.Syntax.Count;
using static ShaNetHoliday.Syntax.Month;
using static ShaNetHoliday.Models.RuleType;
using static ShaNetHoliday.Models.Calendar;

namespace ShaNetHoliday.Countries
{
    /// <summary>
    /// Définition pour Australia.
    /// </summary>
    public class AU : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="AU"/>.
        /// </summary>
        public AU()
        {
            Code = "AU";
            Alpha3Code = "AUS";
            Names = NamesBuilder.Make.Add(Langue.EN, "Australia").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.EN };
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.January.The1st).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "New Year's Day").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.January.The26th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Australia Day").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Good Friday").AsDictionary()
                },
                new GregorianRule()
                {
                    Key = "HOLYSATURDAY",
                    Expression = ExpressionTree.Date.Catholic.HolySaturday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Easter Saturday").AsDictionary()
                },
                new GregorianRule()
                {
                    Key = "EASTER",
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
                    Expression = ExpressionTree.Observe.Fix(On.April.The25th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "ANZAC Day").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Key = "2MOJUN",
                    Expression = ExpressionTree.Date.Movable(Second, Monday).In(June),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Queen's Birthday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Eve").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Key = "DEC24",
                    Expression = ExpressionTree.Observe.Fix(On.December.The25th).If(Saturday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Day").AsDictionary(),
                    Substitute = true,
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.December.The25th).If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Day").AsDictionary(),
                    Substitute = true
                },
               new GregorianRule()
               {
                    Expression = ExpressionTree.Observe.Fix(On.December.The26th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Boxing Day").AsDictionary(),
                    Substitute = true
               },
               new GregorianRule()
               {
                   Key = "DEC31",
                   Expression = ExpressionTree.Date.Fix(On.December.The31st),
                   Names = NamesBuilder.Make.Add(Langue.EN, "New Year's Eve").AsDictionary(),
                   Type = Observance
               }
            };
            States = new ListState()
            {
                Parent = this,
                Langues = Langues,
                Container = { new AU_ACT(), new AU_NSW(), new AU_NT(), new AU_QLD(),
                              new AU_SA(), new AU_TAS(), new AU_VIC(), new AU_WA() }
            }.Initialize(x => x.Init());
        }

        internal class AU_ACT : State
        {
            public AU_ACT()
            {
                Code = "AU-ACT";
                Names = NamesBuilder.Make.Add(Langue.EN, "Australian Capital Territory").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Second, Monday).In(March),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Canberra Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "EASTER", 
                        Type = Public,
                        Overrides = Overrides.Type
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).Before(October),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Family & Community Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(October),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Labour Day").AsDictionary()
                    }
                };
            }
        }
        internal class AU_NSW : State
        {
            public AU_NSW()
            {
                Code = "AU-NSW";
                Names = NamesBuilder.Make.Add(Langue.EN, "New South Wales").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "EASTER",
                        Type = Public,
                        Overrides = Overrides.Type
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(August),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Bank Holiday").AsDictionary(),
                        Type = Bank
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(October),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Labour Day").AsDictionary()
                    }
                };
            }
        }
        internal class AU_NT : State
        {
            public AU_NT()
            {
                Code = "AU-NT";
                Names = NamesBuilder.Make.Add(Langue.EN, "Northern Territory").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(May),
                        Names = NamesBuilder.Make.Add(Langue.EN, "May Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(August),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Picnic Day").AsDictionary()
                    }
                };
            }
        }
        internal class AU_QLD : State
        {
            public AU_QLD()
            {
                Code = "AU-QLD";
                Names = NamesBuilder.Make.Add(Langue.EN, "Queensland").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(October).Every(1).Year.Since(2013).To(2016),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Labour Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(May).Every(1).Year.Since(2016),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Labour Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "2MOJUN",
                        Expression = ExpressionTree.Date.Movable(Second, Monday).In(June).Every(1).Year.To(2016),
                        Overrides = Overrides.Expression
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(October).Every(1).Year.Since(2016),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Queen's Birthday").AsDictionary()
                    }
                };
            }
        }
        internal class AU_SA : State
        {
            public AU_SA()
            {
                Code = "AU-SA";
                Names = NamesBuilder.Make.Add(Langue.EN, "South Australia").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Second, Monday).In(March),
                        Names = NamesBuilder.Make.Add(Langue.EN, "March public holiday").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "DEC24",
                        Expression = ExpressionTree.Date.Fix(On.December.The24th).StartAt("19:00"),
                        Type = Public,
                        Overrides = Overrides.Expression | Overrides.Type
                    },
                    new GregorianRule()
                    {
                        Key = "DEC31",
                        Expression = ExpressionTree.Date.Fix(On.December.The31st).StartAt("19:00"),
                        Type = Public,
                        Overrides = Overrides.Expression | Overrides.Type
                    }
                };
            }
        }
        internal class AU_TAS : State
        {
            public AU_TAS()
            {
                Code = "AU-TAS";
                Names = NamesBuilder.Make.Add(Langue.EN, "Tasmania").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Second, Monday).In(March),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Eight Hours Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "HOLYSATURDAY",
                        Type = Observance,
                        Overrides = Overrides.Type
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CustomDay("EASTER +2"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Easter Tuesday").AsDictionary(),
                        Type = Optional,
                        Note = "Public service employees or contract dependent"
                    }
                };
                Regions = new ListRegion()
                {
                    Parent = this,
                    Langues = Langues,
                    Container = { new AU_TAS_H(), new AU_TAS_NH() }
                }.Initialize(x => x.Init());
            }
            internal class AU_TAS_H : Region
            {
                public AU_TAS_H()
                {
                    Code = "AU-TAS-H";
                    Names = NamesBuilder.Make.Add(Langue.EN, "Hobart").AsDictionary();
                    Rules = new ListRule()
                    {
                        new GregorianRule()
                        {
                            Expression = ExpressionTree.Date.Movable(Second, Monday).In(February),
                            Names = NamesBuilder.Make.Add(Langue.EN, "Royal Hobart Regatta").AsDictionary()
                        }
                    };
                }
            }
            internal class AU_TAS_NH : Region
            {
                public AU_TAS_NH()
                {
                    Code = "AU-TAS-NH";
                    Names = NamesBuilder.Make.Add(Langue.EN, "Non-Hobart").AsDictionary();
                    Rules = new ListRule()
                    {
                        new GregorianRule()
                        {
                            Expression = ExpressionTree.Date.Movable(First, Monday).In(November),
                            Names = NamesBuilder.Make.Add(Langue.EN, "Recreation Day").AsDictionary()
                        }
                    };
                }
            }
        }
        internal class AU_VIC : State
        {
            public AU_VIC()
            {
                Code = "AU-VIC";
                Names = NamesBuilder.Make.Add(Langue.EN, "Victoria").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Second, Monday).In(March),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Labour Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "EASTER",
                        Type = Public, 
                        Overrides = Overrides.Type
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Friday).Before("10-04"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Grand Final Friday").AsDictionary(),
                        Note = "Date might differ as dependent on AFL schedule"
                    }
                };
                Regions = new ListRegion()
                {
                    Parent = this,
                    Langues = Langues,
                    Container = { new AU_VIC_M() }
                }.Initialize(x => x.Init());
            }
            internal class AU_VIC_M : Region
            {
                public AU_VIC_M()
                {
                    Code = "AU-VIC-M";
                    Names = NamesBuilder.Make.Add(Langue.EN, "Melbourne").AsDictionary();
                    Rules = new ListRule()
                    {
                        new GregorianRule()
                        {
                            Expression = ExpressionTree.Date.Movable(First, Tuesday).In(November),
                            Names = NamesBuilder.Make.Add(Langue.EN, "Melbourne Cup").AsDictionary()
                        }                        
                    };
                }
            }
        }
        internal class AU_WA : State
        {
            public AU_WA()
            {
                Code = "AU-WA";
                Names = NamesBuilder.Make.Add(Langue.EN, "Western Australia").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(March),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Labour Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "HOLYSATURDAY", 
                        Type = Observance,
                        Overrides = Overrides.Type
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(June),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Western Australia Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "2MOJUN",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).Before(October),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Queen's Birthday").AsDictionary(),
                        Note = "Might be on a different day; is proclaimed by Governor"
                    }
                };
            }
        }
    }
}

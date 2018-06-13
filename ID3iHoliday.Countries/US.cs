using ID3iCore;
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
using static ID3iHoliday.Models.Calendar;
using static ID3iHoliday.Syntax.YearType;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour United States of America
    /// </summary>
    public class US : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="US"/>.
        /// </summary>
        public US()
        {
            Code = "US";
            Alpha3Code = "USA";
            Names = NamesBuilder.Make.Add(Langue.EN, "United States of America").AsDictionary();
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
                    Type = Observance
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
                    Expression = ExpressionTree.Date.Fix(On.December.The24th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Eve").AsDictionary(),
                    Type = Optional
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
                    Expression = ExpressionTree.Date.Fix(On.December.The31st).StartAt("18:00"),
                    Names = NamesBuilder.Make.Add(Langue.EN, "New Year's Eve").AsDictionary(),
                    Type = Observance
                }
            };
            States = new ListState()
            {
                Parent = this,
                Langues = Langues,
                Container = { new US_AL(), new US_AK(), new US_AZ(), new US_AR(), new US_CA(), new US_CO(), new US_CT(), new US_DE(), new US_DC(),
                              new US_FL(), new US_GA(), new US_HI(), new US_ID(), new US_IL(), new US_IN(), new US_IA(), new US_KS(), new US_KY(),
                              new US_LA(), new US_ME(), new US_MD(), new US_MA(), new US_MI(), new US_MN(), new US_MS(), new US_MO(), new US_MT(),
                              new US_NE(), new US_NV(), new US_NH(), new US_NJ(), new US_NM(), new US_NY(), new US_NC(), new US_ND(), new US_OH(),
                              new US_OK(), new US_OR(), new US_PA(), new US_RI(), new US_SC(), new US_SD(), new US_TN(), new US_TX(), new US_UT(),
                              new US_VT(), new US_VA(), new US_WA(), new US_WV(), new US_WI(), new US_WY()}
            }.Initialize(x => x.Init());
        }
        internal class US_AL : State
        {
            public US_AL()
            {
                Code = "US-AL";
                Names = NamesBuilder.Make.Add(Langue.EN, "Alabama").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "3MOJAN",
                        Names = NamesBuilder.Make.Add(Langue.EN, "Robert E. Lee/ Martin Luther King Birthday").AsDictionary(),
                        Overrides = Overrides.Name
                    },
                    new GregorianRule()
                    {
                        Key = "3MOFEB",
                        Names = NamesBuilder.Make.Add(Langue.EN, "George Washington/ Thomas Jefferson Birthday").AsDictionary(),
                        Overrides = Overrides.Name
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Fourth, Monday).In(April),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Confederate Memorial Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(June),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Jefferson Davis' birthday").AsDictionary()
                    }
                };
            }
        }
        internal class US_AK : State
        {
            public US_AK()
            {
                Code = "US-AK";
                Names = NamesBuilder.Make.Add(Langue.EN, "Alaska").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "2MOOCT",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).Before(April),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Seward's Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.October.The18th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Alaska Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_AZ : State
        {
            public US_AZ()
            {
                Code = "US-AZ";
                Names = NamesBuilder.Make.Add(Langue.EN, "Arizona").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "3MOJAN",
                        Names = NamesBuilder.Make.Add(Langue.EN, "Dr. Martin Luther King Jr./ Civil Rights Day").AsDictionary(),
                        Overrides = Overrides.Name
                    }
                };
            }
        }
        internal class US_AR : State
        {
            public US_AR()
            {
                Code = "US-AR";
                Names = NamesBuilder.Make.Add(Langue.EN, "Arkansas").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "3MOJAN",
                        Names = NamesBuilder.Make.Add(Langue.EN, "Dr. Martin Luther King Jr./ Robert E. Lee's Birthdays").AsDictionary(),
                        Overrides = Overrides.Name
                    },
                    new GregorianRule()
                    {
                        Key = "3MOFEB",
                        Names = NamesBuilder.Make.Add(Langue.EN, "George Washington's Birthday/ Daisy Gatson Bates Day").AsDictionary(),
                        Overrides = Overrides.Name
                    },
                    new GregorianRule()
                    {
                        Key = "DEC24",
                        Type = Public,
                        Overrides = Overrides.Type
                    }
                };
            }
        }
        internal class US_CA : State
        {
            public US_CA()
            {
                Code = "US-CA";
                Names = NamesBuilder.Make.Add(Langue.EN, "California").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "2MOOCT",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.February.The15th),
                        Names = NamesBuilder.Make.Add(Langue.EN , "Susan B. Anthony Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The31st),
                        Names = NamesBuilder.Make.Add(Langue.EN , "César Chávez Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The19th),
                        Names = NamesBuilder.Make.Add(Langue.EN , "Malcolm X Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The23rd),
                        Names = NamesBuilder.Make.Add(Langue.EN , "Harvey Milk Day").AsDictionary()
                    }
                };
                Regions = new ListRegion()
                {
                    Parent = this,
                    Langues = Langues,
                    Container = { new US_CA_LA() }
                }.Initialize(x => x.Init());
            }
            internal class US_CA_LA : Region
            {
                public US_CA_LA()
                {
                    Code = "US-CA-LA";
                    Names = NamesBuilder.Make.Add(Langue.EN, "Los Angeles").AsDictionary();
                    Rules = new ListRule()
                    {
                        new GregorianRule()
                        {
                            Expression = ExpressionTree.Date.Fix(On.August.The24th).StartAtMidnight.UntilMidnight.Every(1).Year.Since(2016),
                            Names = NamesBuilder.Make.Add(Langue.EN , "Kobe Bryant Day").AsDictionary(),
                            Type = Observance
                        }
                    };
                }
            }
        }
        internal class US_CO : State
        {
            public US_CO()
            {
                Code = "US-CO";
                Names = NamesBuilder.Make.Add(Langue.EN, "").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "2MOOCT",
                        Type = Observance,
                        Overrides = Overrides.Type
                    }
                };
            }
        }
        internal class US_CT : State
        {
            public US_CT()
            {
                Code = "US-CT";
                Names = NamesBuilder.Make.Add(Langue.EN, "Connecticut").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The2nd),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Lincoln's Birthday").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "").AsDictionary()
                    }
                };
            }
        }
        internal class US_DE : State
        {
            public US_DE()
            {
                Code = "US-DE";
                Names = NamesBuilder.Make.Add(Langue.EN, "Delaware").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "2MOOCT",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Key = "3MOFEB",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "1FRIA4THUNOV",
                        Type = Public,
                        Overrides = Overrides.Type
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Tuesday).After(First, Monday).In(November).In(Even),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Election Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_DC : State
        {
            public US_DC()
            {
                Code = "US-DC";
                Names = NamesBuilder.Make.Add(Langue.EN, "District of Columbia").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.April.The16th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Emancipation Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_FL : State
        {
            public US_FL()
            {
                Code = "US-FL";
                Names = NamesBuilder.Make.Add(Langue.EN, "Florida").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "3MOFEB",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Key = "2MOOCT",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.February.The15th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Susan B. Anthony Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "1FRIA4THUNOV",
                        Type = Public,
                        Overrides = Overrides.Type
                    }
                };
            }
        }
        internal class US_GA : State
        {
            public US_GA()
            {
                Code = "US-GA";
                Names = NamesBuilder.Make.Add(Langue.EN, "Georgia").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key ="3MOFEB",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The19th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Robert E. Lee's Birthday").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).Before(May),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Confederate Memorial Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "DEC24",
                        Expression = ExpressionTree.Substitute.Fix(On.December.The24th).If(Wednesday).Then.Next(Friday),
                        Names = NamesBuilder.Make.Add(Langue.EN, "ashington's Birthday").AsDictionary(),
                        Overrides = Overrides.Name | Overrides.Expression
                    }
                };
            }
        }
        internal class US_HI : State
        {
            public US_HI()
            {
                Code = "US-HI";
                Names = NamesBuilder.Make.Add(Langue.EN, "Hawaii").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "3MOFEB",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The26th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Prince Jonah Kuhio Kalanianaole Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.June.The11th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Kamehameha Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Third, Friday).In(August),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Statehood Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Tuesday).After(First, Monday).In(November).In(Even),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Election Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_ID : State
        {
            public US_ID()
            {
                Code = "US-ID";
                Names = NamesBuilder.Make.Add(Langue.EN, "Idaho").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "3MOJAN",
                        Names = NamesBuilder.Make.Add(Langue.EN, "Martin Luther King, Jr./ Idaho Human Rights Day").AsDictionary(),
                        Overrides = Overrides.Name
                    }
                };
            }
        }
        internal class US_IL : State
        {
            public US_IL()
            {
                Code = "US-IL";
                Names = NamesBuilder.Make.Add(Langue.EN, "Illinois").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The2nd),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Lincoln's Birthday").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).In(March),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Casimir Pulaski Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The19th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Malcolm X Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "ELECTIONDAY",
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Tuesday).After(First, Monday).In(November).In(Even),
                        Overrides = Overrides.Expression
                    }
                };
            }
        }
        internal class US_IN : State
        {
            public US_IN()
            {
                Code = "US-IN";
                Names = NamesBuilder.Make.Add(Langue.EN, "Indiana").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Tuesday).After(First, Monday).In(May),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Primary Election Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "ELECTIONDAY",
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Tuesday).After(First, Monday).In(November),
                        Overrides = Overrides.Expression
                    },
                    new GregorianRule()
                    {
                        Key = "1FRIA4THUNOV",
                        Names = NamesBuilder.Make.Add(Langue.EN, "Lincoln's Birthday").AsDictionary(),
                        Overrides = Overrides.Name
                    }
                };
            }
        }
        internal class US_IA : State
        {
            public US_IA()
            {
                Code = "US-IA";
                Names = NamesBuilder.Make.Add(Langue.EN, "Iowa").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The2nd),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Lincoln's Birthday").AsDictionary()
                    }
                };
            }
        }
        internal class US_KS : State
        {
            public US_KS()
            {
                Code = "US-KS";
                Names = NamesBuilder.Make.Add(Langue.EN, "Kansas").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "3MOFEB",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    }
                };
            }
        }
        internal class US_KY : State
        {
            public US_KY()
            {
                Code = "US-KY";
                Names = NamesBuilder.Make.Add(Langue.EN, "Kentucky").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "3MOFEB",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday.StartAt("14:00"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "DEC24",
                        Type = Public,
                        Overrides = Overrides.Type
                    },
                    new GregorianRule()
                    {
                        Key = "DEC31",
                        Type = Public,
                        Overrides = Overrides.Type
                    }
                };
            }
        }
        internal class US_LA : State
        {
            public US_LA()
            {
                Code = "US-LA";
                Names = NamesBuilder.Make.Add(Langue.EN, "Louisiana").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "ELECTIONDAY",
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Tuesday).After(First, Monday).In(November).In(Even),
                        Overrides = Overrides.Expression
                    },
                };
                Regions = new ListRegion()
                {
                    Parent = this,
                    Langues = Langues,
                    Container = { new US_LA_NO() }
                }.Initialize(x => x.Init());
            }
            internal class US_LA_NO : Region
            {
                public US_LA_NO()
                {
                    Code = "US-LA-NO";
                    Names = NamesBuilder.Make.Add(Langue.EN, "New Orleans").AsDictionary();
                    Rules = new ListRule()
                    {
                        new GregorianRule()
                        {
                            Expression = ExpressionTree.Date.Catholic.CarnivalTuesday,
                            Names = NamesBuilder.Make.Add(Langue.EN, "Mardi Gras").AsDictionary()
                        }
                    };
                }
            }
        }
        internal class US_ME : State
        {
            public US_ME()
            {
                Code = "US-ME";
                Names = NamesBuilder.Make.Add(Langue.EN, "Maine").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Third, Monday).In(April),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Patriots' Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_MD : State
        {
            public US_MD()
            {
                Code = "US-MD";
                Names = NamesBuilder.Make.Add(Langue.EN, "Maryland").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Friday).Before(First, Monday).Before(June),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Service Reduction Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "1FRIA4THUNOV",
                        Names = NamesBuilder.Make.Add(Langue.EN, "Native American Heritage Day").AsDictionary(),
                        Overrides = Overrides.Name
                    }
                };
            }
        }
        internal class US_MA : State
        {
            public US_MA()
            {
                Code = "US-MA";
                Names = NamesBuilder.Make.Add(Langue.EN, "Massachusetts").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The17th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Evacuation Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Third, Monday).In(April),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Patriots' Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.June.The17th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Bunker Hill Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_MI : State
        {
            public US_MI()
            {
                Code = "US-MI";
                Names = NamesBuilder.Make.Add(Langue.EN, "Michigan").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "DEC24",
                        Type = Public,
                        Overrides = Overrides.Type
                    },
                    new GregorianRule()
                    {
                        Key = "DEC31",
                        Type = Public,
                        Overrides = Overrides.Type
                    }
                };
            }
        }
        internal class US_MN : State
        {
            public US_MN()
            {
                Code = "US-MN";
                Names = NamesBuilder.Make.Add(Langue.EN, "Minnesota").AsDictionary();
                Rules = new ListRule();
            }
        }
        internal class US_MS : State
        {
            public US_MS()
            {
                Code = "US-MS";
                Names = NamesBuilder.Make.Add(Langue.EN, "Mississippi").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "3MONJAN",
                        Names = NamesBuilder.Make.Add(Langue.EN, "Martin Luther King's and Robert E. Lee's Birthdays").AsDictionary(),
                        Overrides = Overrides.Name
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).Before(May),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Confederate Memorial Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_MO : State
        {
            public US_MO()
            {
                Code = "US-MO";
                Names = NamesBuilder.Make.Add(Langue.EN, "Missouri").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The8th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Truman Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_MT : State
        {
            public US_MT()
            {
                Code = "US-MT";
                Names = NamesBuilder.Make.Add(Langue.EN, "").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "ELECTIONDAY",
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Tuesday).After(First, Monday).In(November),
                        Overrides = Overrides.Expression
                    },
                    new GregorianRule()
                    {
                        Key = "DEC24",
                        Type = Public,
                        Overrides = Overrides.Type
                    },
                    new GregorianRule()
                    {
                        Key = "DEC31",
                        Type = Public,
                        Overrides = Overrides.Type
                    }
                };
            }
        }
        internal class US_NE : State
        {
            public US_NE()
            {
                Code = "US-NE";
                Names = NamesBuilder.Make.Add(Langue.EN, "Nebraska").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Friday).Before(May),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Arbor Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_NV : State
        {
            public US_NV()
            {
                Code = "US-NV";
                Names = NamesBuilder.Make.Add(Langue.EN, "Nevada").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "2MOOCT",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Friday).Before(November),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Nevada Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "1FRIA4THUNOV",
                        Names = NamesBuilder.Make.Add(Langue.EN, "Family Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_NH : State
        {
            public US_NH()
            {
                Code = "US-NH";
                Names = NamesBuilder.Make.Add(Langue.EN, "New Hampshire").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "2MOOCT", 
                        Type = Optional,
                        Overrides = Overrides.Type
                    },
                    new GregorianRule()
                    {
                        Key = "3MONJAN",
                        Names = NamesBuilder.Make.Add(Langue.EN, "Martin Luther King, Jr./ Civil Rights Day").AsDictionary(),
                        Overrides = Overrides.Name
                    },
                    new GregorianRule()
                    {
                        Key = "ELECTIONDAY",
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Tuesday).After(First, Monday).In(November).In(Even),
                        Overrides = Overrides.Expression
                    },
                    new GregorianRule()
                    {
                        Key = "1FRIA4THUNOV",
                        Type = Public,
                        Overrides = Overrides.Type
                    }
                };
            }
        }
        internal class US_NJ : State
        {
            public US_NJ()
            {
                Code = "US-NJ";
                Names = NamesBuilder.Make.Add(Langue.EN, "New Jersey").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The22nd),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Lincoln's Birthday").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "ELECTIONDAY",
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Tuesday).After(First, Monday).In(November),
                        Overrides = Overrides.Expression
                    }
                };
            }
        }
        internal class US_NM : State
        {
            public US_NM()
            {
                Code = "US-NM";
                Names = NamesBuilder.Make.Add(Langue.EN, "New Mexico").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "3MONFEB",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Key = "1FRIA4THUNOV", 
                        Type = Public, 
                        Overrides = Overrides.Type
                    }
                };
            }
        }
        internal class US_NY : State
        {
            public US_NY()
            {
                Code = "US-NY";
                Names = NamesBuilder.Make.Add(Langue.EN, "New York").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The2nd),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Lincoln's Birthday").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The15th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Susan B. Anthony Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "ELECTIONDAY",
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Tuesday).After(First, Monday).In(November),
                        Overrides = Overrides.Expression
                    }
                };
            }
        }
        internal class US_NC : State
        {
            public US_NC()
            {
                Code = "US-NC";
                Names = NamesBuilder.Make.Add(Langue.EN, "North Carolina").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "3MONFEB",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Key = "2MONOCT",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "1FRIA4THUNOV", 
                        Type = Public,
                        Overrides = Overrides.Type
                    },
                    new GregorianRule()
                    {
                        Key = "DEC24",
                        Expression = ExpressionTree.Observe.Fix(On.December.The24th).If(Friday).Then.Previous(Thursday).Or.If(Saturday).Then.Previous(Friday).Or.If(Sunday).Then.Previous(Friday),
                        Substitute = true,
                        Overrides = Overrides.Expression
                    }
                };
            }
        }
        internal class US_ND : State
        {
            public US_ND()
            {
                Code = "US-ND";
                Names = NamesBuilder.Make.Add(Langue.EN, "North Dakota").AsDictionary();
                Rules = new ListRule();
            }
        }
        internal class US_OH : State
        {
            public US_OH()
            {
                Code = "US-OH";
                Names = NamesBuilder.Make.Add(Langue.EN, "Ohio").AsDictionary();
                Rules = new ListRule();
            }
        }
        internal class US_OK : State
        {
            public US_OK()
            {
                Code = "US-OK";
                Names = NamesBuilder.Make.Add(Langue.EN, "Oklahoma").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "1FRI14THUNOV",
                        Type = Public,
                        Overrides = Overrides.Type
                    }
                };
            }
        }
        internal class US_OR : State
        {
            public US_OR()
            {
                Code = "US-OR";
                Names = NamesBuilder.Make.Add(Langue.EN, "Oregon").AsDictionary();
                Rules = new ListRule();
            }
        }
        internal class US_PA : State
        {
            public US_PA()
            {
                Code = "US-PA";
                Names = NamesBuilder.Make.Add(Langue.EN, "Pennsylvania").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.June.The14th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Flag Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_RI : State
        {
            public US_RI()
            {
                Code = "US-RI";
                Names = NamesBuilder.Make.Add(Langue.EN, "Rhode Island").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Second, Monday).In(August),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Victory Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_SC : State
        {
            public US_SC()
            {
                Code = "US-SC";
                Names = NamesBuilder.Make.Add(Langue.EN, "South Carolina").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The10th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Confederate Memorial Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The26th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "").AsDictionary()
                    }
                };
            }
        }
        internal class US_SD : State
        {
            public US_SD()
            {
                Code = "US-SD";
                Names = NamesBuilder.Make.Add(Langue.EN, "South Dakota").AsDictionary();
                Rules = new ListRule();
            }
        }
        internal class US_TN : State
        {
            public US_TN()
            {
                Code = "US-TN";
                Names = NamesBuilder.Make.Add(Langue.EN, "Tennessee").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "DEC24",
                        Type = Public, 
                        Overrides = Overrides.Type
                    }
                };
            }
        }
        internal class US_TX : State
        {
            public US_TX()
            {
                Code = "US-TX";
                Names = NamesBuilder.Make.Add(Langue.EN, "Texas").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The1st),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Confederate Heroes Day").AsDictionary(),
                        Type = Observance,
                        Note = "state agencies are partially staffed"
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The2nd),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Texas Independence Day").AsDictionary(),
                        Type = Observance,
                        Note = "state agencies are partially staffed"
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The31st),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Cesar Chavez Day").AsDictionary(),
                        Type = Observance
                    },
                     new GregorianRule()
                     {
                         Expression = ExpressionTree.Date.Catholic.GoodFriday,
                         Names = NamesBuilder.Make.Add(Langue.EN, "").AsDictionary(),
                         Type = Observance
                     },
                     new GregorianRule()
                     {
                         Expression = ExpressionTree.Date.Fix(On.April.The21st),
                         Names = NamesBuilder.Make.Add(Langue.EN, "San Jacinto Day").AsDictionary(),
                         Type = Observance,
                         Note = "state agencies are partially staffed"
                     },
                     new GregorianRule()
                     {
                         Expression = ExpressionTree.Date.Fix(On.June.The19th),
                         Names = NamesBuilder.Make.Add(Langue.EN, "Emancipation Day In Texas").AsDictionary(),
                         Type = Observance,
                         Note = "state agencies are partially staffed"
                     },
                     new GregorianRule()
                     {
                         Expression = ExpressionTree.Date.Fix(On.August.The27th),
                         Names = NamesBuilder.Make.Add(Langue.EN, "Lyndon Baines Johnson Day").AsDictionary(),
                         Type = Observance,
                         Note = "state agencies are partially staffed"
                     },
                     new GregorianRule()
                     {
                         Key = "1FRIA4THUNOV",
                         Type = Public, 
                         Overrides = Overrides.Type,
                     },
                     new GregorianRule()
                     {
                         Key = "DEC24",
                         Type = Public,
                         Overrides = Overrides.Type
                     },
                     new GregorianRule()
                     {
                         Expression = ExpressionTree.Date.Fix(On.December.The26th),
                         Names = NamesBuilder.Make.Add(Langue.EN, "Day after Christmas").AsDictionary()
                     }
                };
            }
        }
        internal class US_UT : State
        {
            public US_UT()
            {
                Code = "US-UT";
                Names = NamesBuilder.Make.Add(Langue.EN, "Utah").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.July.The24th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Pioneer Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_VT : State
        {
            public US_VT()
            {
                Code = "US-VT";
                Names = NamesBuilder.Make.Add(Langue.EN, "Vermont").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Tuesday).In(March),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Town Meeting Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Third, Monday).In(August),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Bennington Battle Da").AsDictionary()
                    }
                };
            }
        }
        internal class US_VA : State
        {
            public US_VA()
            {
                Code = "US-VA";
                Names = NamesBuilder.Make.Add(Langue.EN, "Virginia").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Friday).Before(Third, Monday).In(January),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Lee–Jackson Day").AsDictionary()
                    }
                };
            }
        }
        internal class US_WA : State
        {
            public US_WA()
            {
                Code = "US-WA";
                Names = NamesBuilder.Make.Add(Langue.EN, "Washington").AsDictionary();
                Rules = new ListRule();
            }
        }
        internal class US_WV : State
        {
            public US_WV()
            {
                Code = "US-WV";
                Names = NamesBuilder.Make.Add(Langue.EN, "West Virginia").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.February.The15th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Susan B. Anthony Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.June.The20th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "West Virginia Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "1FRIA4THUNOV",
                        Names = NamesBuilder.Make.Add(Langue.EN, "Lincoln's Day").AsDictionary(),
                        Overrides = Overrides.Name
                    }
                };
            }
        }
        internal class US_WI : State
        {
            public US_WI()
            {
                Code = "US-WI";
                Names = NamesBuilder.Make.Add(Langue.EN, "Wisconsin").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.February.The15th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Susan B. Anthony Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Second, Tuesday).In(September),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Primary Election Day").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "ELECTIONDAY",
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Tuesday).After(First, Monday).In(November),
                        Overrides = Overrides.Expression
                    }
                };
            }
        }
        internal class US_WY : State
        {
            public US_WY()
            {
                Code = "US-WY";
                Names = NamesBuilder.Make.Add(Langue.EN, "Wyoming").AsDictionary();
                Rules = new ListRule();
            }
        }
    }
}

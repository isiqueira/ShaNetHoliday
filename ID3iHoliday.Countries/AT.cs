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
using ID3iHoliday.Syntax;

namespace ID3iHoliday.Countries
{
    public class AT : Country
    {
        public AT()
        {
            Code = "AT";
            Alpha3Code = "AUT";
            Names = NamesBuilder.Make.Add(Langue.DE_AT, "Österreich").Add(Langue.EN, "Austria").AsDictionary();
            DaysOff = new List<DayOfWeek>() { Sunday };
            Langues = new List<Langue>() { Langue.DE_AT, Langue.DE };
            Rules = new ListRule()
            {
                Langues = Langues,
                Container =
                {
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Neujahr").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The6th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Heilige Drei Könige").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Karfreitag").AsDictionary(),
                        Type = Optional
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.HolySaturday,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Karsamstag").Add(Langue.DE_AT, "").AsDictionary(),
                        Type = Observance
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.Easter,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Ostersonntag").Add(Langue.DE_AT, "").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.EasterMonday,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Ostermontag").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE_AT, "Staatsfeiertag").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Muttertag").AsDictionary(),
                        Type = Observance
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.AscensionDay,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Christi Himmelfahrt").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.Pentecost,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Pfingstsonntag").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.WhitMonday,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Pfingstmontag").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.October.The26th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Nationalfeiertag").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The8th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Empfängnis").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The24th).Start("14:00"),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Heiliger Abend").AsDictionary(),
                        Note = "Pour l'instant aucun pattern n'a été fait pour interpréter : DATE 12-24 14:00 IF SUNDAY 00:00",
                        Type = Bank
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The25th),
                        Names = NamesBuilder.Make
                                    .Add(Langue.DE, "Weihnachten")
                                    .Add(Langue.DE_AT, "Christtag").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The26th),
                        Names = NamesBuilder.Make
                                    .Add(Langue.DE, "Weihnachtstag")
                                    .Add(Langue.DE_AT, "Stefanitag").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The31st).Start("14:00"),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Silvester").AsDictionary(),
                        Note = "Pour l'instant aucun pattern n'a été fait pour interpréter : DATE 12-31 14:00 IF SUNDAY 00:00",
                        Type = Bank
                    },
                }
            };
            States = new ListState()
            {
                Langues = Langues,
                Container = { new AT_1(), new AT_2(), new AT_3(), new AT_4(), new AT_5(), new AT_6(), new AT_7(), new AT_8(), new AT_9() }
            }.Initialize(x => x.Init());
        }

        internal class AT_1 : State
        {
            public AT_1()
            {
                Code = "1";
                Names = NamesBuilder.Make.Add(Langue.DE, "Burgenland").AsDictionary();
                Rules = new ListRule()
                {
                    Container =
                    {
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.Fix(On.November.The11th),
                            Names = NamesBuilder.Make.Add(Langue.DE_AT, "Martinstag").AsDictionary()
                        }
                    }
                };
            }
        }
        internal class AT_2 : State
        {
            public AT_2()
            {
                Code = "2";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kärnten").AsDictionary();
                Rules = new ListRule()
                {
                    Container =
                    {
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.Fix(On.March.The19th),
                            Names = NamesBuilder.Make
                                        .Add(Langue.DE, "Josefstag")
                                        .Add(Langue.DE_AT, "Josefitag").AsDictionary()
                        },
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.Fix(On.October.The10th),
                            Names = NamesBuilder.Make.Add(Langue.DE_AT, "Tag der Volksabstimmung").AsDictionary()
                        }
                    }
                };
            }
        }
        internal class AT_3 : State
        {
            public AT_3()
            {
                Code = "3";
                Names = NamesBuilder.Make.Add(Langue.DE, "Niederösterreich").AsDictionary();
                Rules = new ListRule()
                {
                    Container =
                    {
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.Fix(On.November.The15th),
                            Names = NamesBuilder.Make.Add(Langue.DE_AT, "Leopold").AsDictionary()
                        }
                    }
                };
            }
        }
        internal class AT_4 : State
        {
            public AT_4()
            {
                Code = "4";
                Names = NamesBuilder.Make.Add(Langue.DE, "Oberösterreich").AsDictionary();
                Rules = new ListRule()
                {
                    Container =
                    {
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.Fix(On.May.The4th),
                            Names = NamesBuilder.Make.Add(Langue.DE_AT, "Florian").AsDictionary()
                        }
                    }
                };
            }
        }
        internal class AT_5 : State
        {
            public AT_5()
            {
                Code = "5";
                Names = NamesBuilder.Make.Add(Langue.DE, "Land Salzburg").AsDictionary();
                Rules = new ListRule()
                {
                    Container =
                    {
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.Fix(On.September.The24th),
                            Names = NamesBuilder.Make.Add(Langue.DE_AT, "Rupert").AsDictionary()
                        }
                    }
                };
            }
        }
        internal class AT_6 : State
        {
            public AT_6()
            {
                Code = "6";
                Names = NamesBuilder.Make.Add(Langue.DE, "Steiermark").AsDictionary();
                Rules = new ListRule()
                {
                    Container =
                    {
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.Fix(On.March.The19th),
                            Names = NamesBuilder.Make
                                        .Add(Langue.DE, "Josefstag")
                                        .Add(Langue.DE_AT, "Josefitag").AsDictionary()
                        }
                    }
                };
            }
        }
        internal class AT_7 : State
        {
            public AT_7()
            {
                Code = "7";
                Names = NamesBuilder.Make.Add(Langue.DE, "Tirol").AsDictionary();
                Rules = new ListRule()
                {
                    Container =
                    {
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.Fix(On.March.The19th),
                            Names = NamesBuilder.Make
                                        .Add(Langue.DE, "Josefstag")
                                        .Add(Langue.DE_AT, "Josefitag").AsDictionary()
                        }
                    }
                };
            }
        }
        internal class AT_8 : State
        {
            public AT_8()
            {
                Code = "8";
                Names = NamesBuilder.Make.Add(Langue.DE, "Vorarlberg").AsDictionary();
                Rules = new ListRule()
                {
                    Container =
                    {
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.Fix(On.March.The19th),
                            Names = NamesBuilder.Make
                                        .Add(Langue.DE, "Josefstag")
                                        .Add(Langue.DE_AT, "Josefitag").AsDictionary()
                        }
                    }
                };
            }
        }
        internal class AT_9 : State
        {
            public AT_9()
            {
                Code = "9";
                Names = NamesBuilder.Make.Add(Langue.DE, "Wien").AsDictionary();
                Rules = new ListRule()
                {
                    Container =
                    {
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.Fix(On.November.The15th),
                            Names = NamesBuilder.Make
                                        .Add(Langue.DE_AT, "Leopold").AsDictionary()
                        }
                    }
                };
            }
        }
    }
}

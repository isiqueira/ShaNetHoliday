using ShaNetHoliday.Syntax;
using ShaNetCore;
using ShaNetDate;
using ShaNetHoliday.Models;
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
    /// Définition pour Austria.
    /// </summary>
    public class AT : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="AT"/>.
        /// </summary>
        public AT()
        {
            Code = "AT";
            Alpha3Code = "AUT";
            Names = NamesBuilder.Make.Add(Langue.EN, "Austria").Add(Langue.DE_AT, "Österreich").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.DE_AT, Langue.DE };
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Neujahr").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Heilige Drei Könige").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Karfreitag").AsDictionary(),
                    Type = Optional
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.HolySaturday,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Karsamstag").Add(Langue.DE_AT, "").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Ostersonntag").Add(Langue.DE_AT, "").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Ostermontag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.DE_AT, "Staatsfeiertag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Muttertag").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Christi Himmelfahrt").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Pfingstsonntag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Pfingstmontag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The26th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Nationalfeiertag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The8th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Empfängnis").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th).StartAt2PM.UntilMidnight.If(Sunday).ThenStartAtMidnight,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Heiliger Abend").AsDictionary(),
                    Type = Bank
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make
                                .Add(Langue.DE, "Weihnachten")
                                .Add(Langue.DE_AT, "Christtag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make
                                .Add(Langue.DE, "Weihnachtstag")
                                .Add(Langue.DE_AT, "Stefanitag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The31st).StartAt2PM.UntilMidnight.If(Sunday).ThenStartAtMidnight,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Silvester").AsDictionary(),
                    Type = Bank
                }
            };
            States = new ListState()
            {
                Parent = this,
                Langues = Langues,
                Container = { new AT_1(), new AT_2(), new AT_3(), new AT_4(), new AT_5(), new AT_6(), new AT_7(), new AT_8(), new AT_9() }
            }.Initialize(x => x.Init());
        }

        internal class AT_1 : State
        {
            public AT_1()
            {
                Code = "AT-1";
                Names = NamesBuilder.Make.Add(Langue.DE, "Burgenland").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The11th),
                        Names = NamesBuilder.Make.Add(Langue.DE_AT, "Martinstag").AsDictionary()
                    }
                };
            }
        }
        internal class AT_2 : State
        {
            public AT_2()
            {
                Code = "AT-2";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kärnten").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The19th),
                        Names = NamesBuilder.Make
                                    .Add(Langue.DE, "Josefstag")
                                    .Add(Langue.DE_AT, "Josefitag").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.October.The10th),
                        Names = NamesBuilder.Make.Add(Langue.DE_AT, "Tag der Volksabstimmung").AsDictionary()
                    }
                };
            }
        }
        internal class AT_3 : State
        {
            public AT_3()
            {
                Code = "AT-3";
                Names = NamesBuilder.Make.Add(Langue.DE, "Niederösterreich").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE_AT, "Leopold").AsDictionary()
                    }
                };
            }
        }
        internal class AT_4 : State
        {
            public AT_4()
            {
                Code = "AT-4";
                Names = NamesBuilder.Make.Add(Langue.DE, "Oberösterreich").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The4th),
                        Names = NamesBuilder.Make.Add(Langue.DE_AT, "Florian").AsDictionary()
                    }
                };
            }
        }
        internal class AT_5 : State
        {
            public AT_5()
            {
                Code = "AT-5";
                Names = NamesBuilder.Make.Add(Langue.DE, "Land Salzburg").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.September.The24th),
                        Names = NamesBuilder.Make.Add(Langue.DE_AT, "Rupert").AsDictionary()
                    }
                };
            }
        }
        internal class AT_6 : State
        {
            public AT_6()
            {
                Code = "AT-6";
                Names = NamesBuilder.Make.Add(Langue.DE, "Steiermark").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The19th),
                        Names = NamesBuilder.Make
                                    .Add(Langue.DE, "Josefstag")
                                    .Add(Langue.DE_AT, "Josefitag").AsDictionary()
                    }
                };
            }
        }
        internal class AT_7 : State
        {
            public AT_7()
            {
                Code = "AT-7";
                Names = NamesBuilder.Make.Add(Langue.DE, "Tirol").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The19th),
                        Names = NamesBuilder.Make
                                    .Add(Langue.DE, "Josefstag")
                                    .Add(Langue.DE_AT, "Josefitag").AsDictionary()
                    }
                };
            }
        }
        internal class AT_8 : State
        {
            public AT_8()
            {
                Code = "AT-8";
                Names = NamesBuilder.Make.Add(Langue.DE, "Vorarlberg").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The19th),
                        Names = NamesBuilder.Make
                                    .Add(Langue.DE, "Josefstag")
                                    .Add(Langue.DE_AT, "Josefitag").AsDictionary()
                    }
                };
            }
        }
        internal class AT_9 : State
        {
            public AT_9()
            {
                Code = "AT-9";
                Names = NamesBuilder.Make.Add(Langue.DE, "Wien").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The15th),
                        Names = NamesBuilder.Make
                                    .Add(Langue.DE_AT, "Leopold").AsDictionary()
                    }
                };
            }
        }
    }
}

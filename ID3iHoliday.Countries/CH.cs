using iD3iCore;
using iD3iDate;
using System;
using System.Collections.Generic;
using iD3iHoliday.Models;
using iD3iHoliday.Syntax;

using static System.DayOfWeek;
using static iD3iHoliday.Syntax.Count;
using static iD3iHoliday.Syntax.Month;
using static iD3iHoliday.Models.RuleType;
using static iD3iHoliday.Models.Calendar;

namespace iD3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Switzerland.
    /// </summary>
    public class CH : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="CH"/>.
        /// </summary>
        public CH()
        {
            Code = "CH";
            Alpha3Code = "CHE";
            Names = NamesBuilder.Make.Add(Langue.EN, "Switzerland").Add(Langue.DE, "Schweiz").Add(Langue.FR, "Suisse").Add(Langue.IT, "Svizzera").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.DE, Langue.FR, Langue.IT };
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Neujahr")
                                             .Add(Langue.FR, "Nouvel An")
                                             .Add(Langue.IT, "Capodanno").AsDictionary()
                },
                new GregorianRule()
                {
                    Key = "EASTER-2",
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Karfreitag")
                                             .Add(Langue.FR, "Vendredi saint")
                                             .Add(Langue.IT, "Venerdì santo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Ostersonntag")
                                             .Add(Langue.FR, "Pâques")
                                             .Add(Langue.IT, "Domenica di Pasqua").AsDictionary()
                },
                new GregorianRule()
                {
                    Key = "EASTER+1",
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Ostermontag")
                                             .Add(Langue.FR, "Lundi de Pâques")
                                             .Add(Langue.IT, "Lunedì dell’Angelo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Auffahrt")
                                             .Add(Langue.FR, "Ascension")
                                             .Add(Langue.IT, "Ascensione").AsDictionary()
                },
                new GregorianRule()
                {
                    Key = "EASTER+50",
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make.Add(Langue.DE, "Pfingstmontag")
                                             .Add(Langue.FR, "Lundi de Pentecôte")
                                             .Add(Langue.IT, "Lunedì di Pentecoste").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Muttertag")
                                             .Add(Langue.FR, "Fête des Mères")
                                             .Add(Langue.IT, "Festa della mamma").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The1st),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Bundesfeier").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Weihnachten")
                                             .Add(Langue.FR, "Noël")
                                             .Add(Langue.IT, "Natale").AsDictionary()
                },
                new GregorianRule()
                {
                    Key = "DEC26",
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.DE, "Stephanstag")
                                             .Add(Langue.FR, "Lendemain de Noël")
                                             .Add(Langue.IT, "Santo Stefano").AsDictionary()
                }
            };
            States = new ListState()
            {
                Parent = this,
                Langues = Langues,
                Container = { new CH_BE(), new CH_LU(), new CH_RU(), new CH_SZ(), new CH_OW(), new CH_NW(), new CH_GL(), new CH_ZG(),
                              new CH_FR(), new CH_SO(), new CH_BL(), new CH_AI(), new CH_SG(), new CH_GR(), new CH_AG(), new CH_TG(),
                              new CH_TI(), new CH_VD(), new CH_VS(), new CH_NE(), new CH_GE(), new CH_JU()}
            }.Initialize(x => x.Init());
        }
        internal class CH_BE : State
        {
            public CH_BE()
            {
                Code = "CH-BE";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Bern").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The2nd),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Berchtoldstag").AsDictionary()
                    }
                };
            }
        }
        internal class CH_LU : State
        {
            public CH_LU()
            {
                Code = "CH-LU";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Luzern").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The19th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Josefstag")
                                                 .Add(Langue.IT, "San Giuseppe").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    }
                };
            }
        }
        internal class CH_RU : State
        {
            public CH_RU()
            {
                Code = "CH-RU";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Uri").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The6th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Heilige Drei Könige")
                                                 .Add(Langue.FR, "l'Épiphanie")
                                                 .Add(Langue.IT, "Befana").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The19th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Josefstag")
                                                 .Add(Langue.IT, "San Giuseppe").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    }
                };
            }
        }
        internal class CH_SZ : State
        {
            public CH_SZ()
            {
                Code = "CH-SZ";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Schwyz").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The6th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Heilige Drei Könige")
                                                 .Add(Langue.FR, "l'Épiphanie")
                                                 .Add(Langue.IT, "Befana").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The19th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Josefstag")
                                                 .Add(Langue.IT, "San Giuseppe").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    }
                };
            }
        }
        internal class CH_OW : State
        {
            public CH_OW()
            {
                Code = "CH-OW";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Obwalden").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    }
                };
            }
        }
        internal class CH_NW : State
        {
            public CH_NW()
            {
                Code = "CH-NW";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Nidwalden").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The19th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Josefstag")
                                                 .Add(Langue.IT, "San Giuseppe").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    }
                };
            }
        }
        internal class CH_GL : State
        {
            public CH_GL()
            {
                Code = "CH-GL";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Glarus").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    }
                };
            }
        }
        internal class CH_ZG : State
        {
            public CH_ZG()
            {
                Code = "CH-ZG";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Zug").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The19th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Josefstag")
                                                 .Add(Langue.IT, "San Giuseppe").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    }
                };
            }
        }
        internal class CH_FR : State
        {
            public CH_FR()
            {
                Code = "CH-FR";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Freiburg").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    }
                };
            }
        }
        internal class CH_SO : State
        {
            public CH_SO()
            {
                Code = "CH-SO";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Solothurn").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    }
                };
            }
        }
        internal class CH_BL : State
        {
            public CH_BL()
            {
                Code = "CH-BL";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Basel-Landschaft").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    }
                };
            }
        }
        internal class CH_AI : State
        {
            public CH_AI()
            {
                Code = "CH-AI";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Appenzell Innerrhoden").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    }
                };
            }
        }
        internal class CH_SG : State
        {
            public CH_SG()
            {
                Code = "CH-SG";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton St. Gallen").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    }
                };
            }
        }
        internal class CH_GR : State
        {
            public CH_GR()
            {
                Code = "CH-GR";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Graubünden").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The6th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Heilige Drei Könige")
                                                 .Add(Langue.FR, "l'Épiphanie")
                                                 .Add(Langue.IT, "Befana").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The19th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Josefstag")
                                                 .Add(Langue.IT, "San Giuseppe").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    }
                };
            }
        }
        internal class CH_AG : State
        {
            public CH_AG()
            {
                Code = "CH-AG";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Aargau").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The2nd),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Berchtoldstag").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    }
                };
            }
        }
        internal class CH_TG : State
        {
            public CH_TG()
            {
                Code = "CH-TG";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Thurgau").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The2nd),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Berchtoldstag").AsDictionary()
                    }
                };
            }
        }
        internal class CH_TI : State
        {
            public CH_TI()
            {
                Code = "CH-TI";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Tessin").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The6th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Heilige Drei Könige")
                                                 .Add(Langue.FR, "l'Épiphanie")
                                                 .Add(Langue.IT, "Befana").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The19th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Josefstag")
                                                 .Add(Langue.IT, "San Giuseppe").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "EASTER-2",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "DEC26",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    }
                };
            }
        }
        internal class CH_VD : State
        {
            public CH_VD()
            {
                Code = "CH-VD";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Waadt").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The2nd),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Berchtoldstag").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "DEC26",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    }
                };
            }
        }
        internal class CH_VS : State
        {
            public CH_VS()
            {
                Code = "CH-VS";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Wallis").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The19th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Josefstag")
                                                 .Add(Langue.IT, "San Giuseppe").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "EASTER-2",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Key = "EASTER+1",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Key = "EASTER+50",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "DEC26",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    }
                };
            }
        }
        internal class CH_NE : State
        {
            public CH_NE()
            {
                Code = "CH-NE";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Neuenburg").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "DEC26",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    }
                };
            }
        }
        internal class CH_GE : State
        {
            public CH_GE()
            {
                Code = "CH-GE";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Genf").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Key = "DEC26",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    }
                };
            }
        }
        internal class CH_JU : State
        {
            public CH_JU()
            {
                Code = "CH-JU";
                Names = NamesBuilder.Make.Add(Langue.DE, "Kanton Jura").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The2nd),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Berchtoldstag").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                        Names = NamesBuilder.Make.Add(Langue.DE, "Fronleichnam")
                                                 .Add(Langue.FR, "la Fête-Dieu")
                                                 .Add(Langue.IT, "Corpus Domini").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.August.The15th),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Mariä Himmelfahrt")
                                                 .Add(Langue.FR, "Assomption")
                                                 .Add(Langue.IT, "Ferragosto").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The1st),
                        Names = NamesBuilder.Make.Add(Langue.DE, "Allerheiligen")
                                                 .Add(Langue.FR, "Toussaint")
                                                 .Add(Langue.IT, "Ognissanti").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "DEC26",
                        IsEnable = false,
                        Overrides = Overrides.IsEnable
                    }
                };
            }
        }
    }
}

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

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Canada.
    /// </summary>
    public class CA : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="CA"/>.
        /// </summary>
        public CA()
        {
            Code = "CA";
            Alpha3Code = "CAN";
            Names = NamesBuilder.Make.Add(Langue.EN, "Canada").Add(Langue.FR, "Canada").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.EN, Langue.FR };
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.EN, "New Year's Day")
                                             .Add(Langue.FR, "Nouvel An").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Good Friday")
                                             .Add(Langue.FR, "Vendredi saint").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Easter Sunday")
                                             .Add(Langue.FR, "Pâques").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Mother's Day")
                                             .Add(Langue.FR, "Fête des Mères").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).Before("05-25"),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Victoria Day")
                                             .Add(Langue.FR, "Fête de la Reine").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Third, Sunday).In(June),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Father's Day").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The1st),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Canada Day")
                                             .Add(Langue.FR, "Fête du Canada").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).In(August),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Civic Holiday")
                                             .Add(Langue.FR, "Premier lundi d’août").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).After("08-31"),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Labour Day")
                                             .Add(Langue.FR, "Fête du travail").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Monday).After("10-01"),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Thanksgiving")
                                             .Add(Langue.FR, "Action de grâce").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The11th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Remembrance Day")
                                             .Add(Langue.FR, "Jour du Souvenir").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Day")
                                             .Add(Langue.FR, "Noël").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Boxing Day")
                                             .Add(Langue.FR, "Lendemain de Noël").AsDictionary()
                }
            };
            States = new ListState()
            {
                Parent = this,
                Langues = Langues,
                Container = { new CA_AB(), new CA_BC(), new CA_MB(), new CA_NB(), new CA_NL(), new CA_NS(), new CA_NT(), new CA_NU(), new CA_ON(), new CA_PE(), new CA_QC(), new CA_SK(), new CA_YT() }
            }.Initialize(x => x.Init());
        }

        internal class CA_AB : State
        {
            public CA_AB()
            {
                Code = "CA-AB";
                Names = NamesBuilder.Make.Add(Langue.EN, "Alberta").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Third, Monday).After("02-01"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Family Day")
                                             .Add(Langue.FR, "Fête de la famille").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.EasterMonday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "Easter Monday")
                                             .Add(Langue.FR, "Lundi de Pâques").AsDictionary(),
                        Type = Optional
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).After("08-01"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Heritage Day")
                                             .Add(Langue.FR, "Fête du patrimoine").AsDictionary(),
                        Type = Optional
                    },
                };
            }
        }
        internal class CA_BC : State
        {
            public CA_BC()
            {
                Code = "CA-BC";
                Names = NamesBuilder.Make.Add(Langue.EN, "British Columbia").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Second, Monday).After("02-01"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Family Day")
                                             .Add(Langue.FR, "Fête de la famille").AsDictionary()
                    }
                };
            }
        }
        internal class CA_MB : State
        {
            public CA_MB()
            {
                Code = "CA-MB";
                Names = NamesBuilder.Make.Add(Langue.EN, "Manitoba").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Third, Monday).After("02-01"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Louis Riel Day")
                                             .Add(Langue.FR, "Journée Louis Riel").AsDictionary()
                    }
                };
            }
        }
        internal class CA_NB : State
        {
            public CA_NB()
            {
                Code = "CA-NB";
                Names = NamesBuilder.Make.Add(Langue.EN, "New Brunswick").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).After("08-01"),
                        Names = NamesBuilder.Make.Add(Langue.EN, " New Brunswick Day")
                                             .Add(Langue.FR, "Jour de Nouveau Brunswick").AsDictionary()
                    }
                };
            }
        }
        internal class CA_NL : State
        {
            public CA_NL()
            {
                Code = "CA-NL";
                Names = NamesBuilder.Make.Add(Langue.EN, "Newfoundland and Labrador").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The17th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Saint Patrick's Day")
                                             .Add(Langue.FR, "Jour de la Saint-Patrick").AsDictionary(),
                        Type = Optional
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.April.The23rd),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Saint George's Day")
                                             .Add(Langue.FR, "Jour de St. George").AsDictionary(),
                        Type = Optional
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.June.The24th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Discovery Day")
                                             .Add(Langue.FR, "Journée découverte").AsDictionary(),
                        Type = Optional
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.July.The12th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Orangemen's Day")
                                             .Add(Langue.FR, "Fête des orangistes").AsDictionary(),
                        Type = Optional
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The11th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Armistice Day")
                                             .Add(Langue.FR, "Jour de l'Armistice").AsDictionary()
                    }
                };
            }
        }
        internal class CA_NS : State
        {
            public CA_NS()
            {
                Code = "CA-NS";
                Names = NamesBuilder.Make.Add(Langue.EN, "Nova Scotia").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Third, Monday).After("02-01"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Heritage Day")
                                             .Add(Langue.FR, "Fête du Patrimoine").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).After("08-01"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Natal Day")
                                             .Add(Langue.FR, "Jour de la Fondation").AsDictionary()
                    }
                };
            }
        }
        internal class CA_NT : State
        {
            public CA_NT()
            {
                Code = "CA-NT";
                Names = NamesBuilder.Make.Add(Langue.EN, "Northwest Territories").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.June.The21st),
                        Names = NamesBuilder.Make.Add(Langue.EN, "National Aboriginal Day")
                                             .Add(Langue.FR, "Journée nationale des Autochthones").AsDictionary()
                    }
                };
            }
        }
        internal class CA_NU : State
        {
            public CA_NU()
            {
                Code = "CA-NU";
                Names = NamesBuilder.Make.Add(Langue.EN, "Nunavut").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.July.The9th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Nunavut Day").AsDictionary(),
                        Type = Bank
                    }
                };
            }
        }
        internal class CA_ON : State
        {
            public CA_ON()
            {
                Code = "CA-ON";
                Names = NamesBuilder.Make.Add(Langue.EN, "name: Ontario").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Third, Monday).After("02-01"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Family Day")
                                             .Add(Langue.FR, "Fête de la famille").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.EasterMonday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "Easter Monday")
                                             .Add(Langue.FR, "Lundi de Pâques").AsDictionary()
                    }
                };
            }
        }
        internal class CA_PE : State
        {
            public CA_PE()
            {
                Code = "CA-PE";
                Names = NamesBuilder.Make.Add(Langue.EN, "Prince Edward Island").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Third, Monday).After("02-01"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Islander Day")
                                             .Add(Langue.FR, "Fête des Insulaires").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.EasterMonday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "Easter Monday")
                                             .Add(Langue.FR, "Lundi de Pâques").AsDictionary(),
                        Type = Optional
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Third, Friday).After("08-01"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Gold Cup Parade Day")
                                             .Add(Langue.FR, "Défilé de la Coupe d'or").AsDictionary()
                    }
                };
            }
        }
        internal class CA_QC : State
        {
            public CA_QC()
            {
                Code = "CA_QC";
                Names = NamesBuilder.Make.Add(Langue.EN, "Quebec").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Monday).Before("05-25"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "National Patriots' Day")
                                             .Add(Langue.FR, "Journée nationale des patriotes").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.June.The24th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "National Holiday")
                                             .Add(Langue.FR, "Fête nationale du Québec").AsDictionary()
                    }
                };
            }
        }
        internal class CA_SK : State
        {
            public CA_SK()
            {
                Code = "CA-SK";
                Names = NamesBuilder.Make.Add(Langue.EN, "Saskatchewan").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Third, Monday).After("02-01"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Family Day")
                                             .Add(Langue.FR, "Fête de la famille").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Third, Monday).After("08-01"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Saskatchewan Day").AsDictionary()
                    }
                };
            }
        }
        internal class CA_YT : State
        {
            public CA_YT()
            {
                Code = "CA-YT";
                Names = NamesBuilder.Make.Add(Langue.EN, "Yukon").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.EasterMonday,
                        Names = NamesBuilder.Make.Add(Langue.EN, "Easter Monday")
                                             .Add(Langue.FR, "Lundi de Pâques").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(Third, Monday).After("08-01"),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Discovery Day")
                                             .Add(Langue.FR, "Jour de la Découverte").AsDictionary()
                    }
                };
            }
        }
    }
}

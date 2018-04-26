using ID3iCore;
using ID3iDate;
using System;
using System.Collections.Generic;
using ID3iHoliday.Models;
using ID3iHoliday.Syntax;

using static System.DayOfWeek;
using static ID3iHoliday.Syntax.Count;
using static ID3iHoliday.Syntax.Month;
using static ID3iHoliday.Models.RuleType;
using static ID3iHoliday.Models.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour France.
    /// </summary>
    public class FR : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="FR"/>.
        /// </summary>
        public FR()
        {
            Code = "FR";
            Alpha3Code = "FRA";
            Names = NamesBuilder.Make.Add(Langue.EN, "France").Add(Langue.FR, "France").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.FR);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Jour de l'an").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.FR, "Lundi de pâques").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Fête du travail").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The8th),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Fête de la Victoire 1945").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay,
                    Names = NamesBuilder.Make.Add(Langue.FR, "Ascension").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.FR, "Pentecôte").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make.Add(Langue.FR, "Lundi de Pentecôte").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression =  ExpressionTree.Date.Movable(First, Sunday).Before(June),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Fête des mères").AsDictionary(),
                    Type = Observance,
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The14th),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Fête nationale").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Assomption").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Toussaint").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The11th),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Armistice 1918").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.FR, "Noël").AsDictionary()
                }
            };
            States = new ListState()
            {
                Parent = this,
                Langues = Langues,
                Container = { new FR_67(), new FR_68(), new FR_57(), new FR_YT(), new FR_MQ(), new FR_GP(), new FR_GF(), new FR_RE() }
            }.Initialize(x => x.Init());
        }

        internal class FR_67 : State
        {
            public FR_67()
            {
                Code = "FR-67";
                Names = NamesBuilder.Make.Add(Langue.FR, "Département du Bas-Rhin").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.FR, "Vendredi saint").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The26th),
                        Names = NamesBuilder.Make.Add(Langue.FR, "Lendemain de Noël").AsDictionary()
                    }
                };
            }
        }
        internal class FR_68 : State
        {
            public FR_68()
            {
                Code = "FR-68";
                Names = NamesBuilder.Make.Add(Langue.FR, "Département du Haut-Rhin").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.FR, "Vendredi saint").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The26th),
                        Names = NamesBuilder.Make.Add(Langue.FR, "Lendemain de Noël").AsDictionary()
                    }
                };
            }
        }
        internal class FR_57 : State
        {
            public FR_57()
            {
                Code = "FR-57";
                Names = NamesBuilder.Make.Add(Langue.FR, "Département Moselle").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.FR, "Vendredi saint").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The26th),
                        Names = NamesBuilder.Make.Add(Langue.FR, "Lendemain de Noël").AsDictionary()
                    }
                };
            }
        }
        internal class FR_YT : State
        {
            public FR_YT()
            {
                Code = "FR-YT";
                Names = NamesBuilder.Make.Add(Langue.FR, "Département et région d'outre-mer Mayotte").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.April.The27th),
                        Names = NamesBuilder.Make.Add(Langue.FR, "Abolition de l'esclavage").AsDictionary()
                    }
                };
            }
        }
        internal class FR_MQ : State
        {
            public FR_MQ()
            {
                Code = "FR-MQ";
                Names = NamesBuilder.Make.Add(Langue.FR, "Département et région d'outre-mer Martinique").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.FR, "Vendredi saint").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The22nd),
                        Names = NamesBuilder.Make.Add(Langue.FR, "Abolition de l'esclavage").AsDictionary()
                    }
                };
            }
        }
        internal class FR_GP : State
        {
            public FR_GP()
            {
                Code = "FR-GP";
                Names = NamesBuilder.Make.Add(Langue.FR, "Département et région d'outre-mer Guadeloupe").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.GoodFriday,
                        Names = NamesBuilder.Make.Add(Langue.FR, "Vendredi saint").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The27th),
                        Names = NamesBuilder.Make.Add(Langue.FR, "Abolition de l'esclavage").AsDictionary()
                    }
                };
            }
        }
        internal class FR_GF : State
        {
            public FR_GF()
            {
                Code = "FR-GF";
                Names = NamesBuilder.Make.Add(Langue.FR, "Département et région d'outre-mer Guyane").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.June.The10th),
                        Names = NamesBuilder.Make.Add(Langue.FR, "Abolition de l'esclavage").AsDictionary()
                    }
                };
            }
        }
        internal class FR_RE : State
        {
            public FR_RE()
            {
                Code = "FR-RE";
                Names = NamesBuilder.Make.Add(Langue.FR, "Département et région d'outre-mer La Réunion").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The20th),
                        Names = NamesBuilder.Make.Add(Langue.FR, "Abolition de l'esclavage").AsDictionary()
                    }
                };
            }
        }
    }
}

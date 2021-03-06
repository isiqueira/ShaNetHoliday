﻿using ShaNetHoliday.Syntax;
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
    /// Définition pour Belgique.
    /// </summary>
    public class BE : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="BE"/>.
        /// </summary>
        public BE()
        {
            Code = "BE";
            Alpha3Code = "BEL";
            Names = NamesBuilder.Make.Add(Langue.FR, "Belgique").Add(Langue.NL, "België").Add(Langue.DE, "Belgien").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.FR, Langue.NL, Langue.DE };
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Nouvel An")
                                .Add(Langue.NL, "Nieuwjaar")
                                .Add(Langue.DE, "Neujahr").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "l'Épiphanie")
                                .Add(Langue.NL, "Driekoningen")
                                .Add(Langue.DE, "Erscheinung des Herrn").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The14th),
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Saint-Valentin")
                                .Add(Langue.NL, "Valentijnsdag")
                                .Add(Langue.DE, "Valentinstag").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Pâques")
                                .Add(Langue.NL, "Pasen")
                                .Add(Langue.DE, "Ostersonntag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Lundi de Pâques")
                                .Add(Langue.NL, "Paasmaandag")
                                .Add(Langue.DE, "Ostermontag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Fête du travail")
                                .Add(Langue.NL, "Dag van de Arbeid")
                                .Add(Langue.DE, "Tag der Arbeit").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),

                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Fête des Mères")
                                .Add(Langue.NL, "Moederdag")
                                .Add(Langue.DE, "Muttertag").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay,
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Ascension")
                                .Add(Langue.NL, "O.L.H. Hemelvaart")
                                .Add(Langue.DE, "Christi Himmelfahrt").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Pentecôte")
                                .Add(Langue.NL, "Pinksteren")
                                .Add(Langue.DE, "Pfingstsonntag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Lundi de Pentecôte")
                                .Add(Langue.NL, "Pinkstermaandag")
                                .Add(Langue.DE, "Pfingstmontag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The21st),
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Fête nationale")
                                .Add(Langue.NL, "Nationale feestdag")
                                .Add(Langue.DE, "Nationalfeiertag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Assomption")
                                .Add(Langue.NL, "O.L.V. Hemelvaart")
                                .Add(Langue.DE, "Mariä Himmelfahrt").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Toussaint")
                                .Add(Langue.NL, "Allerheiligen")
                                .Add(Langue.DE, "Allerheiligen").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The2nd),

                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Fête des morts")
                                .Add(Langue.NL, "Allerzielen")
                                .Add(Langue.DE, "Allerseelen").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The11th),
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Armistice")
                                .Add(Langue.NL, "Wapenstilstand")
                                .Add(Langue.DE, "Waffenstillstand").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The15th),
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Fête du Roi")
                                .Add(Langue.NL, "Koningsdag")
                                .Add(Langue.DE, "Festtag des Königs").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The6th),
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Saint-Nicolas")
                                .Add(Langue.NL, "Sinterklaas")
                                .Add(Langue.DE, "Sankt Nikolaus").AsDictionary(),
                    Type = Observance,
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make
                                .Add(Langue.FR, "Noël")
                                .Add(Langue.NL, "Kerstmis")
                                .Add(Langue.DE, "Weihnachten").AsDictionary()
                }
            };
            States = new ListState()
            {
                Parent = this,
                Langues = Langues,
                Container = { new BE_BRU(), new BE_DE(), new BE_VLG(), new BE_WAL() }
            }.Initialize(x => x.Init());
        }

        internal class BE_BRU : State
        {
            public BE_BRU()
            {
                Code = "BE-BRU";
                Langues = new List<Langue>() { Langue.FR, Langue.NL };
                Names = NamesBuilder.Make.Add(Langue.FR, "Bruxelles").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The8th),
                        Names = NamesBuilder.Make
                                .Add(Langue.FR, "Fête de l'Iris")
                                .Add(Langue.NL, "Feest van de Iris").AsDictionary()
                    }
                };
            }
        }
        internal class BE_DE : State
        {
            public BE_DE()
            {
                Code = "BE-DE";
                Langues.Add(Langue.DE);
                Names = NamesBuilder.Make.Add(Langue.DE, "Deutschsprachige Gemeinschaft").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The15th),
                        Names = NamesBuilder.Make
                                .Add(Langue.FR, "Jour de la Communauté Germanophone")
                                .Add(Langue.NL, "Feestdag van de Duitstalige Gemeenschap")
                                .Add(Langue.DE, "Tag der Deutschsprachigen Gemeinschaft").AsDictionary()
                    }
                };
            }
        }
        internal class BE_VLG : State
        {
            public BE_VLG()
            {
                Code = "BE-VLG";
                Langues.Add(Langue.NL);
                Names = NamesBuilder.Make.Add(Langue.NL, "Vlaamse Gemeenschap").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.July.The11th),
                        Names = NamesBuilder.Make
                                .Add(Langue.FR, "Fête de la Région wallonne")
                                .Add(Langue.NL, "Feestdag van de Vlaamse Gemeenschap")
                                .Add(Langue.DE, "Festtag der Wallonischen Region").AsDictionary()
                    }
                };
            }
        }
        internal class BE_WAL : State
        {
            public BE_WAL()
            {
                Code = "BE-WAL";
                Langues.Add(Langue.FR);
                Names = NamesBuilder.Make.Add(Langue.FR, "Communauté française").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.July.The11th),
                        Names = NamesBuilder.Make
                                .Add(Langue.FR, "La fête de la communauté française")
                                .Add(Langue.NL, "Feestdag van de Franse Gemeenschap")
                                .Add(Langue.DE, "Tag der Französischsprachigen Gemeinschaft").AsDictionary()
                    }
                };
            }
        }
    }
}

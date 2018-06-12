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
    /// Définition pour Greenland.
    /// </summary>
    public class GL : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="GL"/>.
        /// </summary>
        public GL()
        {
            Code = "GL";
            Alpha3Code = "GRL";
            Names = NamesBuilder.Make.Add(Langue.EN, "Greenland").Add(Langue.KL, "Kalaallit Nunaat").Add(Langue.DA, "Grønland").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.KL, Langue.DA };
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.KL, "ukiortaaq")
                                             .Add(Langue.DA, "Nytår").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.DA, "Åbenbaring").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.MaundyThursday,
                    Names = NamesBuilder.Make.Add(Langue.KL, "sisamanngortoq illernartoq")
                                             .Add(Langue.DA, "Skærtorsdag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.KL, "tallimanngornersuaq")
                                             .Add(Langue.DA, "Langfredag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.KL, "poorskip-ullua")
                                             .Add(Langue.DA, "Påskesøndag").AsDictionary()

                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.KL, "poorskip-aappaa")
                                             .Add(Langue.DA, "Anden påskedag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CustomDay("EASTER +26"),
                    Names = NamesBuilder.Make.Add(Langue.KL, "tussiarfissuaq")
                                             .Add(Langue.DA, "Store Bededag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay,
                    Names = NamesBuilder.Make.Add(Langue.KL, "qilaliarfik")
                                             .Add(Langue.DA, "Kristi Himmelfartsdag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The21st),
                    Names = NamesBuilder.Make.Add(Langue.KL, "ullortuneq")
                                             .Add(Langue.DA, "Nationaldag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.KL, "piinsip ullua")
                                             .Add(Langue.DA, "Pinsedag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make.Add(Langue.KL, "piinsip aappaa")
                                             .Add(Langue.DA, "2. Pinsedag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th),
                    Names = NamesBuilder.Make.Add(Langue.KL, "juulliaraq")
                                             .Add(Langue.DA, "Juleaften").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.KL, "juullerujussuaq")
                                             .Add(Langue.DA, "1. Juledag").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.KL, "juullip aappaa")
                                             .Add(Langue.DA, "2. Juledag").AsDictionary()
                }
            };
        }
    }
}

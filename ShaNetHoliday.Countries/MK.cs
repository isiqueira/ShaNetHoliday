﻿using ShaNetDate;
using ShaNetHoliday.Models;
using ShaNetHoliday.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ShaNetHoliday.Models.RuleType;
using static ShaNetHoliday.Models.Calendar;

namespace ShaNetHoliday.Countries
{
    /// <summary>
    /// Définition pour Macedonia.
    /// </summary>
    public class MK : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="MK"/>
        /// </summary>
        public MK()
        {
            Code = "MK";
            Alpha3Code = "MKD";
            Names = NamesBuilder.Make.Add(Langue.EN, "Macedonia").Add(Langue.MK, "Република Македонија").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.MK);
            SupportedCalendar = new List<Calendar>() { Gregorian, Julian };
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.January.The1st).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Нова Година").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Easter,
                    Names = NamesBuilder.Make.Add(Langue.MK, "Прв ден Велигден").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.MK, "Втор ден Велигден").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.May.The1st).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Ден на трудот").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.May.The24th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Св. Кирил и Методиј").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.August.The2nd).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Ден на Републиката").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.September.The8th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Ден на независноста").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.October.The11th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Ден на востанието").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.October.The23rd).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Ден на македонската револуционерна борба").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.December.The8th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Св. Климент Охридски").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.MK, "Велики Петок").AsDictionary(),
                    Type = Optional,
                    Note = "Orthodox believers"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.CustomDay("EASTER +47"),
                    Names = NamesBuilder.Make.Add(Langue.MK, "петок пред Духовден").AsDictionary(),
                    Type = Optional,
                    Note = "Orthodox believers"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.MK, "Духовден").AsDictionary(),
                    Type = Optional,
                    Note = "Orthodox believers"
                },
                new JulianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th).Over.Julian(),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Бадник").AsDictionary(),
                    Type = Optional,
                    Note = "Orthodox believers"
                },
                new JulianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th).Over.Julian(),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Богојавление").AsDictionary(),
                    Type = Optional,
                    Note = "Orthodox believers"
                },
                new JulianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th).Over.Julian(),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Успение на Пресвета Богородица").AsDictionary(),
                    Type = Optional,
                    Note = "Orthodox believers"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.December.The25th).If(Sunday).Then.Next(Monday).Over.Julian(),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Успение на Пресвета Богородица").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.MK, "вториот ден на Велигден").AsDictionary(),
                    Type = Optional,
                    Note = "Catholic believers"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Празникот на сите светци").AsDictionary(),
                    Type = Optional,
                    Note = "Catholic believers"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Католички Божиќ").AsDictionary(),
                    Type = Optional, 
                    Note = "Catholic believers"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The22nd),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Ден на Албанската азбука").AsDictionary(),
                    Type = Optional,
                    Note = "For members of the Albanian community"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The21st),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Ден на настава на турски јазик").AsDictionary(),
                    Type = Optional, 
                    Note = "For members of the the Turkish community"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The27th),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Свети Сава").AsDictionary(),
                    Type = Optional, 
                    Note = "For members of the Serbian community"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The8th),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Меѓународен ден на Ромите").AsDictionary(),
                    Type = Optional,
                    Note = "For members of the the Roma community"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The23rd),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Национален ден на Властите").AsDictionary(),
                    Type = Optional,
                    Note = "For members of the Vlach community"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The28th),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Меѓународен ден на Бошњаците").AsDictionary(),
                    Type = Optional,
                    Note = "For Members of the Bosniak community."
                },
                new HijriRule()
                {
                    Expression = ExpressionTree.Date.Fix(OnM.DhuAlHijjah.The10th).Over.Hijri(),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Курбан Бајрам").AsDictionary(),
                    Type = Optional,
                    Note = "Muslim believers"
                },
                new HebrewRule()
                {
                    Expression = ExpressionTree.Date.Fix(OnH.Tishrei.The10th).Over.Hebrew(),
                    Names = NamesBuilder.Make.Add(Langue.MK, "Јом Кипур").AsDictionary(),
                    Type = Optional,
                    Note = "Jewish believers"
                }
            };
        }
    }
}

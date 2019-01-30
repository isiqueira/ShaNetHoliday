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
    /// Définition pour Lithuania.
    /// </summary>
    public class LT : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="LT"/>.
        /// </summary>
        public LT()
        {
            Code = "LT";
            Alpha3Code = "LTU";
            Names = NamesBuilder.Make.Add(Langue.EN, "Lithuania").Add(Langue.LT, "Lietuva").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.LT);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Naujieji metai").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The16th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Lietuvos valstybės atkūrimo diena").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The11th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Lietuvos nepriklausomybės atkūrimo diena").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.LT, "Velykos").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Tarptautinė darbo diena").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Motinos diena").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Sunday).In(June),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Tėvo diena").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The24th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Joninės, Rasos").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The6th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Valstybės diena").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Žolinė").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Visų šventųjų diena").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Šv. Kūčios").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "Šv. Kalėdos").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.LT, "2. Kalėdų diena").AsDictionary()
                }
            };
        }
    }
}

﻿using ShaNetDate;
using ShaNetHoliday.Models;
using ShaNetHoliday.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ShaNetHoliday.Models.Calendar;

namespace ShaNetHoliday.Countries
{
    /// <summary>
    /// Définition pour Malta.
    /// </summary>
    public class MT : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="MT"/>.
        /// </summary>
        public MT()
        {
            Code = "MT";
            Alpha3Code = "MLT";
            Names = NamesBuilder.Make.Add(Langue.EN, "Malta").Add(Langue.MT, "Malta").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.MT);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.MT, "L-Ewwel tas-Sena").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The10th),
                    Names = NamesBuilder.Make.Add(Langue.MT, "Nawfraġju ta' San Pawl").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The19th),
                    Names = NamesBuilder.Make.Add(Langue.MT, "San Ġużepp").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The31st),
                    Names = NamesBuilder.Make.Add(Langue.MT, "Jum il-Ħelsien").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.MT, "Il-Ġimgħa l-Kbira").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.MT, "Jum il-Ħaddiem").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The7th),
                    Names = NamesBuilder.Make.Add(Langue.MT, "Sette Giugno").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The29th),
                    Names = NamesBuilder.Make.Add(Langue.MT, "L-Imnarja").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.MT, "Santa Marija").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The8th),
                    Names = NamesBuilder.Make.Add(Langue.MT, "Jum il-Vitorja").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The21st),
                    Names = NamesBuilder.Make.Add(Langue.MT, "Jum l-Indipendenza").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The8th),
                    Names = NamesBuilder.Make.Add(Langue.MT, "Il-Kunċizzjoni").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The13th),
                    Names = NamesBuilder.Make.Add(Langue.MT, "Jum ir-Repubblika").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.MT, "Il-Milied").AsDictionary()
                }
            };
        }
    }
}

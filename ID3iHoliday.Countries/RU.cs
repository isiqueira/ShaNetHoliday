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
using static ID3iHoliday.Syntax.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Russia.
    /// </summary>
    public class RU : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe<see cref="RU"/>.
        /// </summary>
        public RU()
        {
            Code = "RU";
            Alpha3Code = "RUS";
            Names = NamesBuilder.Make.Add(Langue.EN, "Russia").Add(Langue.RU, "Россия").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.RU);
            Rules = new ListRule()
            {
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.RU, "Новый год").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The2nd).StartAt("00:00").Duration("P5D"),
                    Names = NamesBuilder.Make.Add(Langue.RU, "Новогодние каникулы").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th).Over(Julian),
                    Names = NamesBuilder.Make.Add(Langue.RU, "Рождество Христово").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The8th),
                    Names = NamesBuilder.Make.Add(Langue.RU, "Новогодние каникулы").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The23rd),
                    Names = NamesBuilder.Make.Add(Langue.RU, "День защитника Отечества").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The8th),
                    Names = NamesBuilder.Make.Add(Langue.RU, "Международный женский день").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The22nd),
                    Names = NamesBuilder.Make.Add(Langue.RU, "День Государственного флага").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.RU, "День весны и труда").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The9th),
                    Names = NamesBuilder.Make.Add(Langue.RU, "День Победы").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The12th),
                    Names = NamesBuilder.Make.Add(Langue.RU, "День России").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The4th),
                    Names = NamesBuilder.Make.Add(Langue.RU, "День народного единства").AsDictionary()
                }
            };
        }
    }
}

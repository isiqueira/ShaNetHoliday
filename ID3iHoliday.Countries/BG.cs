using ID3iHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ID3iHoliday.Syntax.Count;
using static ID3iHoliday.Syntax.Month;
using static ID3iHoliday.Models.RuleType;
using ID3iHoliday.Syntax;

namespace ID3iHoliday.Countries
{
    public class BG : Country
    {
        public BG()
        {
            Code = "BG";
            Alpha3Code = "BGR";
            Names = NamesBuilder.Make.Add(Langue.EN, "Bulgaria").Add(Langue.BG, "България").AsDictionary();
            DaysOff = new List<DayOfWeek>() { Sunday };
            Langues = new List<Langue>() { Langue.BG };
            Rules = new ListRule()
            {
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.BG, "Нова Година").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The1st),
                    Names = NamesBuilder.Make.Add(Langue.BG, "Баба Марта").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The3rd),
                    Names = NamesBuilder.Make.Add(Langue.BG, "Ден на Освобождението на България от Османската Империя").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The8th),
                    Names = NamesBuilder.Make.Add(Langue.BG, "Ден на жената").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.BG, "Разпети петък").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Easter,
                    Names = NamesBuilder.Make.Add(Langue.BG, "Великден").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.BG, "Велики понеделник").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.BG, "Ден на труда").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The6th),
                    Names = NamesBuilder.Make.Add(Langue.BG, "Гергьовден").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The7th),
                    Names = NamesBuilder.Make.Add(Langue.BG, "Ден на радиото и телевизията").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The24th),
                    Names = NamesBuilder.Make.Add(Langue.BG, "Ден на азбуката, културата и просветата").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The6th),
                    Names = NamesBuilder.Make.Add(Langue.BG, "Ден на съединението").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The22nd),
                    Names = NamesBuilder.Make.Add(Langue.BG, "Ден на независимостта").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.BG, "Ден на народните будители").AsDictionary(),
                    Type = School
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th),
                    Names = NamesBuilder.Make.Add(Langue.BG, "Бъдни вечер").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.BG, "Коледа").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.BG, "2-ри ден на Коледа").AsDictionary(),
                    Type = Observance
                }
            };
        }
    }
}

using ID3iHoliday.Syntax;
using ID3iDate;
using ID3iHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ID3iHoliday.Models.RuleType;
using static ID3iHoliday.Models.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Belarus.
    /// </summary>
    public class BY : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="BY"/>.
        /// </summary>
        public BY()
        {
            Code = "BY";
            Alpha3Code = "BLR";
            Names = NamesBuilder.Make.Add(Langue.EN, "Belarus").Add(Langue.BE, "Рэспубліка Беларусь").Add(Langue.RU, "Республика Беларусь").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.BE, Langue.RU };
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make
                                .Add(Langue.BE, "Новы год")
                                .Add(Langue.RU, "Новый год").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.BE, "Вялiкдзень каталiцкi").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Easter,
                    Names = NamesBuilder.Make.Add(Langue.BE, "Вялiкдзень праваслаўны").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.CustomDay("EASTER +9"),
                    Names = NamesBuilder.Make.Add(Langue.BE, "Радунiца").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The8th),
                    Names = NamesBuilder.Make
                                .Add(Langue.BE, "Мiжнародны жаночы дзень")
                                .Add(Langue.RU, "Международный женский день").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.BE, "Дзень працы").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The9th),
                    Names = NamesBuilder.Make.Add(Langue.BE, "Дзень Перамогi").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The3rd).Since(1996),
                    Names = NamesBuilder.Make.Add(Langue.BE, "Дзень Незалежнасцi").AsDictionary(),
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The7th),
                    Names = NamesBuilder.Make.Add(Langue.BE, "Дзень Кастрычніцкай рэвалюцыі").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.BE, "Каляды каталiцкiя").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th).Over.Julian(),
                    Names = NamesBuilder.Make.Add(Langue.BE, "Каляды каталiцкiя").AsDictionary()
                }
            };
        }
    }
}

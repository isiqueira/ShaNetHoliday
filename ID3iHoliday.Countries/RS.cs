using ID3iDate;
using ID3iHoliday.Models;
using ID3iHoliday.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ID3iHoliday.Models.RuleType;
using static ID3iHoliday.Models.Calendar;

#warning Penser aux jours fériés dans les autres types de calendriers.
namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Serbia.
    /// </summary>
    public class RS : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe<see cref="RS"/>.
        /// </summary>
        public RS()
        {
            Code = "RS";
            Alpha3Code = "SRB";
            Names = NamesBuilder.Make.Add(Langue.EN, "Serbia").Add(Langue.SR, "Република Србија").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.SR);
            SupportedCalendar = new List<Calendar>() { Gregorian, Julian };
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Move.Fix(On.January.The1st).If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Нова година").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Move.Fix(On.January.The2nd).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Нова година").AsDictionary()
                },
                new JulianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th).Over.Julian(),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Божић").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Move.Fix(On.February.The15th).If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Дан државности Србије").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Move.Fix(On.February.The16th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Дан државности Србије").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.SR, "Велики петак").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Easter,
                    Names = NamesBuilder.Make.Add(Langue.SR, "Васкрс").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.SR, "Васкрсни понедељак").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Move.Fix(On.May.The1st).If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Празник рада").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Move.Fix(On.May.The2nd).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Празник рада").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Move.Fix(On.November.The11th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Дан примирја").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.SR, "Велики петак").AsDictionary(),
                    Type = Optional,
                    Note = "Catholic believers"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.SR, "Католички Васкрс").AsDictionary(),
                    Type = Optional,
                    Note = "Catholic believers"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.SR, "Католички Васкрсни понедељак").AsDictionary(),
                    Type = Optional,
                    Note = "Catholic believers"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Католички Божић").AsDictionary(),
                    Type = Optional,
                    Note = "Catholic believers"
                },
                new JulianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The14th).Over.Julian(),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Свети Сава").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The22nd),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Дан сећања на жртве холокауста").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The9th),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Дан победе").AsDictionary(),
                    Type = Observance
                },
                new JulianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The15th).Over.Julian(),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Видовдан").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The21st),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Дан сећања на српске жртве у Другом светском рату").AsDictionary()
                },
                new HijriRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.Shawwal.The1st).Over.Hijri(),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Рамазански Бајрам").AsDictionary(),
                    Type = Optional,
                    Note = "Muslim believers"
                },
                new HijriRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.DhuAlHijjah.The10th).Over.Hijri(),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Курбански Бајрам").AsDictionary(),
                    Type = Optional,
                    Note = "Muslim believers"
                }
            };
        }
    }
}

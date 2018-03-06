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
            Rules = new ListRule()
            {
                new Rule()
                {
                    Expression = ExpressionTree.Move.Fix(On.January.The1st).If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Нова година").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Move.Fix(On.January.The2nd).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Нова година").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th).Over(Julian),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Божић").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Move.Fix(On.February.The15th).If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Дан државности Србије").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Move.Fix(On.February.The16th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Дан државности Србије").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.SR, "Велики петак").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Easter,
                    Names = NamesBuilder.Make.Add(Langue.SR, "Васкрс").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.SR, "Васкрсни понедељак").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Move.Fix(On.May.The1st).If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Празник рада").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Move.Fix(On.May.The2nd).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Празник рада").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Move.Fix(On.November.The11th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Дан примирја").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.SR, "Велики петак").AsDictionary(),
                    Type = Optional,
                    Note = "Catholic believers"
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.SR, "Католички Васкрс").AsDictionary(),
                    Type = Optional,
                    Note = "Catholic believers"
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.SR, "Католички Васкрсни понедељак").AsDictionary(),
                    Type = Optional,
                    Note = "Catholic believers"
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Католички Божић").AsDictionary(),
                    Type = Optional,
                    Note = "Catholic believers"
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The14th).Over(Julian),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Свети Сава").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The22nd),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Дан сећања на жртве холокауста").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The9th),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Дан победе").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The15th).Over(Julian),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Видовдан").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The21st),
                    Names = NamesBuilder.Make.Add(Langue.SR, "Дан сећања на српске жртве у Другом светском рату").AsDictionary()
                }
            };
        }
    }
}

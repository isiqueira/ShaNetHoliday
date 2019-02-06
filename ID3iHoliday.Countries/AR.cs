using iD3iHoliday.Syntax;
using iD3iCore;
using iD3iDate;
using iD3iHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static iD3iHoliday.Syntax.Count;
using static iD3iHoliday.Syntax.Month;
using static iD3iHoliday.Models.RuleType;
using static iD3iHoliday.Models.Calendar;

namespace iD3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Argentina.
    /// </summary>
    public class AR : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="AR"/>.
        /// </summary>
        public AR()
        {
            Code = "AR";
            Alpha3Code = "ARG";
            Names = NamesBuilder.Make.Add(Langue.EN, "Argentina").Add(Langue.ES, "Argentina").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.ES };
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Año Nuevo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CarnivalMonday,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Carnaval").AsDictionary(),
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CarnivalTuesday,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Carnaval").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The24th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de la Memoria por la Verdad y la Justicia").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.March.The24th).If(Tuesday).Then.Previous(Monday).Or.If(Thursday).Then.Next(Friday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Feriado Puente Turístico").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.MaundyThursday,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Jueves Santo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Viernes Santo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The2nd),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día del Veterano y de los Caídos en la Guerra de Malvinas").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.April.The2nd).If(Tuesday).Then.Previous(Monday).Or.If(Thursday).Then.Next(Friday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Feriado Puente Turístico").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Fiesta del trabajo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.May.The1st).If(Tuesday).Then.Previous(Monday).Or.If(Thursday).Then.Next(Friday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Feriado Puente Turístico").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The25th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Primer Gobierno Patrio").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.May.The25th).If(Tuesday).Then.Previous(Monday).Or.If(Thursday).Then.Next(Friday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Feriado Puente Turístico").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The20th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de la Bandera").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.June.The20th).If(Tuesday).Then.Previous(Monday).Or.If(Thursday).Then.Next(Friday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Feriado Puente Turístico").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The9th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de la Independencia").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Third, Monday).In(August),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día del Libertador José de San Martín").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Move.Fix(On.October.The12th)
                                    .If(Tuesday).Then.Previous(Monday)
                                    .Or.If(Wednesday).Then.Previous(Monday)
                                    .Or.If(Thursday).Then.Next(Monday)
                                    .Or.If(Friday).Then.Next(Monday)
                                    .Or.If(Saturday).Then.Next(Monday)
                                    .Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día del Respeto a la Diversidad Cultural").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Fourth, Monday).In(November).Every(1).Year.To(2014),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de la Soberanía nacional").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Specific(On.November.The27th.Of(2015)),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de la Soberanía nacional").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Fourth, Monday).In(November).Every(1).Year.Since(2016),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de la Soberanía nacional").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The8th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "La inmaculada concepción").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.December.The8th).If(Tuesday).Then.Previous(Monday).Or.If(Thursday).Then.Next(Friday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Feriado Puente Turístico").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th).StartAtNoon,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Nochebuena").AsDictionary(),
                    Type = Optional
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.December.The24th).If(Tuesday).Then.Previous(Monday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Feriado Puente Turístico").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Navidad").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.December.The25th).If(Thursday).Then.Next(Friday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Feriado Puente Turístico").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The31st).StartAtNoon,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Fin del Año").AsDictionary(),
                    Type = Optional
                }
            };
        }
    }
}

using iD3iCore;
using iD3iHoliday.Syntax;
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
    /// Définition pour Spai.
    /// </summary>
    public class ES : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="ES"/>.
        /// </summary>
        public ES()
        {
            Code = "ES";
            Alpha3Code = "ESP";
            Names = NamesBuilder.Make.Add(Langue.EN, "Spain").Add(Langue.ES, "España").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.ES);
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
                    Expression = ExpressionTree.Substitute.Fix(On.January.The1st).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Año Nuevo").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de los Reyes Magos").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.January.The6th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de los Reyes Magos").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The19th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "San José").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.March.The19th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "San José").AsDictionary(),
                    Substitute = true
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
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Pascua").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Fiesta del trabajo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.May.The1st).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Fiesta del trabajo").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de la Madre").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Pentecostés").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The25th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Santiago Apostol").AsDictionary(),
                    Type = Observance,
                    Note = "Regional"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Asunción").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.August.The15th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Asunción").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Move.Fix(On.October.The12th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Fiesta Nacional de España").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Todos los Santos").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.November.The1st).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Todos los Santos").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Move.Fix(On.December.The6th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de la Constitución Española").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The8th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "La inmaculada concepción").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.December.The8th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "La inmaculada concepción").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Navidad").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Substitute.Fix(On.December.The25th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Navidad").AsDictionary(),
                    Substitute = true
                }
            };
            States = new ListState()
            {
                Parent = this,
                Langues = Langues,
                Container = { new ES_MD(), new ES_AN(), new ES_AR() }
            }.Initialize(x => x.Init());
        }

        internal class ES_MD : State
        {
            public ES_MD()
            {
                Code = "ES-MD";
                Names = NamesBuilder.Make.Add(Langue.ES, "Comunidad de Madrid").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The16th),
                        Names = NamesBuilder.Make.Add(Langue.ES, "San Isidro Labrador").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Move.Fix(On.November.The9th).If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.ES, "Nuestra Señora de la Almudena").AsDictionary()
                    }
                };
            }
        }
        internal class ES_AN : State
        {
            public ES_AN()
            {
                Code = "ES-AN";
                Names = NamesBuilder.Make.Add(Langue.ES, "Andalucía").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.February.The28th),
                        Names = NamesBuilder.Make.Add(Langue.ES, "Día de Andalucía").AsDictionary()
                    }
                };
            }
        }
        internal class ES_AR : State
        {
            public ES_AR()
            {
                Code = "ES-AR";
                Names = NamesBuilder.Make.Add(Langue.ES, "Aragón").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Move.Fix(On.April.The23rd).If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.ES, "Día de Aragón").AsDictionary()
                    }
                };
            }
        }
    }
}

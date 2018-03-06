using ID3iCore;
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
using static ID3iHoliday.Models.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Andorra.
    /// </summary>
    public class AD : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="AD"/>.
        /// </summary>
        public AD()
        {
            Code = "AD";
            Alpha3Code = "AND";
            Names = NamesBuilder.Make.Add(Langue.EN, "Andorra").Add(Langue.ES, "Andorra").Add(Langue.CA, "Andorra").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.CA, Langue.ES };
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make
                                .Add(Langue.ES, "Año Nuevo")
                                .Add(Langue.CA, "Any nou").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Día de los Reyes Magos").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression  = ExpressionTree.Date.Fix(On.March.The3rd),
                    Names = NamesBuilder.Make
                                .Add(Langue.ES, "Día de la Constitución")
                                .Add(Langue.CA, "Dia de la Constitució").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Fiesta del trabajo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Asunción").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The8th),
                    Names = NamesBuilder.Make
                                .Add(Langue.ES, "Nuestra Sra. De Meritxell")
                                .Add(Langue.CA, "Mare de Déu de Meritxell").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Todos los Santos").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The8th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "La inmaculada concepción").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Nochebuena").AsDictionary(),
                    Type = Bank
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Navidad").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.ES, "San Esteban").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CarnivalTuesday,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Carnaval").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.MaundyThursday.StartAt("14:00"),
                    Names = NamesBuilder.Make.Add(Langue.ES, "Jueves Santo").AsDictionary(),
                    Type = Bank
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Viernes Santo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Pascua").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Lunes de Pascua").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Pentecostés").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make.Add(Langue.ES, "Lunes de Pentecostés").AsDictionary()
                }
            };
            States = new ListState()
            {
                Langues = Langues,
                Container = { new AD_07() }
            }.Initialize(x => x.Init());
        }

        internal class AD_07 : State
        {
            public AD_07()
            {
                Code = "07";
                Names = NamesBuilder.Make.Add(Langue.ES, "Andorra la Vella").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Movable(First, Saturday).In(August),
                        Names = NamesBuilder.Make.Add(Langue.ES, "Andorra La Vella Festival").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Sunday).After(First, Saturday).In(August),
                        Names = NamesBuilder.Make.Add(Langue.ES, "Andorra La Vella Festival").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.MovableFromMovable(First, Monday).After(First, Saturday).In(August),
                        Names = NamesBuilder.Make.Add(Langue.ES, "Andorra La Vella Festival").AsDictionary()
                    }
                };
            }
        }
    }
}

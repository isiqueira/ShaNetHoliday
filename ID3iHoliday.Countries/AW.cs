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
    /// Définition pour Aruba.
    /// </summary>
    public class AW : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="AW"/>.
        /// </summary>
        public AW()
        {
            Code = "AW";
            Alpha3Code = "ABW";
            Names = NamesBuilder.Make.Add(Langue.EN, "Aruba").Add(Langue.NL, "Aruba").Add(Langue.PAP, "Aruba").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.NL, Langue.PAP };
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Nieuwjaar")
                                             .Add(Langue.PAP, "Aña Nobo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The25th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Herdenking G. F. Croes")
                                             .Add(Langue.PAP, "Dia di Betico").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CarnivalMonday,
                    Names = NamesBuilder.Make.Add(Langue.NL, "Carnavalmaandag")
                                             .Add(Langue.PAP, "Dialuna di Carnaval").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.March.The18th).If(Saturday).Then.Previous(Friday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Herdenking Vlag en Volkslied")
                                             .Add(Langue.PAP, "Dia di Himno y Bandera").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.NL, "Goede Vrijdag")
                                             .Add(Langue.PAP, "Diabierna Santo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.NL, "Pasen")
                                             .Add(Langue.PAP, "Dia Pasco di Resureccion").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.NL, "Paasmaandag")
                                             .Add(Langue.PAP, "Di dos Dia Pasco di Resureccion").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The27th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Koningsdag")
                                             .Add(Langue.PAP, "Aña di Rey").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Move.Fix(On.May.The1st).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Dag van de Arbeid")
                                             .Add(Langue.PAP, "Dia di Obrero").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The24th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Dera Gai")
                                             .Add(Langue.PAP, "Dera Gai").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay,
                    Names = NamesBuilder.Make.Add(Langue.NL, "O.L.H. Hemelvaart")
                                             .Add(Langue.PAP, "Dia di Asuncion").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The5th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Sinterklaasavond").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Kerstmis")
                                             .Add(Langue.PAP, "Dia Pasco di Nascimento").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.NL, "Tweede kerstdag")
                                             .Add(Langue.PAP, "Di dos Dia Pasco di Nascimento").AsDictionary()
                }
            };
        }
    }
}

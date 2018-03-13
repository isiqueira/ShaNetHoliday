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
    /// Définition pour Slovenia.
    /// </summary>
    public class SI : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="SI"/>.
        /// </summary>
        public SI()
        {
            Code = "SI";
            Alpha3Code = "SVN";
            Names = NamesBuilder.Make.Add(Langue.EN, "Slovenia").Add(Langue.SL, "Republika Slovenija").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.SL);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.SL, "novo leto").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The2nd).Since(1955).To(2017),
                    Names = NamesBuilder.Make.Add(Langue.SL, "novo leto").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The8th).Since(1991),
                    Names = NamesBuilder.Make.Add(Langue.SL, "Prešeren Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The8th),
                    Names = NamesBuilder.Make.Add(Langue.SL, "Mednarodni dan žena").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The23rd),
                    Names = NamesBuilder.Make.Add(Langue.SL, "jurjevanje").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CustomDay("EASTER -49"),
                    Names = NamesBuilder.Make.Add(Langue.SL, "pust").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.SL, "velika noč").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.SL, "Velikonočni ponedeljek").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The27th),
                    Names = NamesBuilder.Make.Add(Langue.SL, "dan upora proti okupatorju").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st).Since(1949),
                    Names = NamesBuilder.Make.Add(Langue.SL, "praznik dela").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The2nd).Since(1949),
                    Names = NamesBuilder.Make.Add(Langue.SL, "praznik dela").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.SL, "binkošti").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The8th).Since(2010),
                    Names = NamesBuilder.Make.Add(Langue.SL, "dan Primoža Trubarja").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The25th).Since(1991),
                    Names = NamesBuilder.Make.Add(Langue.SL, "dan državnosti").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The22nd),
                    Names = NamesBuilder.Make.Add(Langue.SL, "dan vstaje").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th).Since(1992),
                    Names = NamesBuilder.Make.Add(Langue.SL, "Marijino vnebovzetje").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The17th).Since(2006),
                    Names = NamesBuilder.Make.Add(Langue.SL, "združitev prekmurskih Slovencev z matičnim narodom").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The15th).Since(2005),
                    Names = NamesBuilder.Make.Add(Langue.SL, "vrnitev Primorske k matični domovini").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The25th).Since(2015),
                    Names = NamesBuilder.Make.Add(Langue.SL, "dan suverenosti").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The31st),
                    Names = NamesBuilder.Make.Add(Langue.SL, "dan reformacije").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.SL, "dan spomina na mrtve or dan mrtvih").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The11th),
                    Names = NamesBuilder.Make.Add(Langue.SL, "martinovanje").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The23rd).Since(2015),
                    Names = NamesBuilder.Make.Add(Langue.SL, "dan Rudolfa Maistra").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The6th),
                    Names = NamesBuilder.Make.Add(Langue.SL, "miklavž").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th).Since(1953).To(1991),
                    Names = NamesBuilder.Make.Add(Langue.SL, "božič").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.SL, "dan samostojnosti in enotnosti").AsDictionary()
                }
            };
        }
    }
}

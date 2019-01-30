using ShaNetDate;
using ShaNetHoliday.Models;
using ShaNetHoliday.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ShaNetHoliday.Syntax.Count;
using static ShaNetHoliday.Syntax.Month;
using static ShaNetHoliday.Models.RuleType;
using static ShaNetHoliday.Models.Calendar;

namespace ShaNetHoliday.Countries
{
    /// <summary>
    /// Définition pour Hungary.
    /// </summary>
    public class HU : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="HU"/>.
        /// </summary>
        public HU()
        {
            Code = "HU";
            Alpha3Code = "HUN";
            Names = NamesBuilder.Make.Add(Langue.EN, "Hungary").Add(Langue.HU, "Magyarország").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.HU);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.HU, "Újév").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The1st),
                    Names = NamesBuilder.Make.Add(Langue.HU, "A köztársaság emléknapja").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The25th),
                    Names = NamesBuilder.Make.Add(Langue.HU, "A kommunista diktatúrák áldozatainak emléknapja").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The8th),
                    Names = NamesBuilder.Make.Add(Langue.HU, "Nemzetközi nőnap").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The15th),
                    Names = NamesBuilder.Make.Add(Langue.HU, "Nemzeti ünnep").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The16th),
                    Names = NamesBuilder.Make.Add(Langue.HU, "A holokauszt áldozatainak emléknapja").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.HU, "Húsvétvasárnap").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.HU, "Húsvéthétfő").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.HU, "A munka ünnepe").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.HU, "Anyák napja").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The21st),
                    Names = NamesBuilder.Make.Add(Langue.HU, "Honvédelmi nap").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.HU, "Pünkösdvasárnap").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make.Add(Langue.HU, "Pünkösdhétfő").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The4th),
                    Names = NamesBuilder.Make.Add(Langue.HU, "A nemzeti összetartozás napja").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The19th),
                    Names = NamesBuilder.Make.Add(Langue.HU, "A független Magyarország napja").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The20th),
                    Names = NamesBuilder.Make.Add(Langue.HU, "Szent István ünnepe").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The6th),
                    Names = NamesBuilder.Make.Add(Langue.HU, "Az aradi vértanúk emléknapja").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The23rd),
                    Names = NamesBuilder.Make.Add(Langue.HU, "Nemzeti ünnep").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.HU, "Mindenszentek").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The6th),
                    Names = NamesBuilder.Make.Add(Langue.HU, "Mikulás, Télapó").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.HU, "Karácsony").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.HU, "Karácsony másnapja").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The31st),
                    Names = NamesBuilder.Make.Add(Langue.HU, "Szilveszter").AsDictionary(),
                    Type = Observance
                }
            };
        }
    }
}

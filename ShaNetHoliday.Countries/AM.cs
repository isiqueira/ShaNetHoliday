using ShaNetCore;
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
    /// Définition pour Armenia.
    /// </summary>
    public class AM : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="AM"/>.
        /// </summary>
        public AM()
        {
            Code = "AM";
            Alpha3Code = "ARM";
            Names = NamesBuilder.Make.Add( Langue.EN, "Armenia" ).Add( Langue.HY, "Հայաստան" ).AsDictionary();
            DaysOff.Add( Sunday );
            Langues = new List<Langue>() { Langue.HY };
            SupportedCalendar.Add( Gregorian );
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The31st),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Նոր տարվա գիշեր").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st).StartAtMidnight.Duration.P2D(),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Ամանոր").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The3rd).StartAtMidnight.Duration.P3D(),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Նախածննդյան տոներ").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Սուրբ Ծնունդ").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The28th),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Բանակի օր").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The21st),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Մայրենի լեզվի օր").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CustomDay("EASTER -52"),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Սուրբ Վարդանանց տոն՝ բարի գործի եւ ազգային տուրքի օր").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The8th),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Կանանց տոն").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The7th),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Մայրության, գեղեցկության եւ սիրո տոն").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The24th),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Ցեղասպանության զոհերի հիշատակի օր").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Աշխատանքի օր").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The8th),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Երկրապահի օր").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The9th),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Հաղթանակի եւ Խաղաղության տոն").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The28th),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Հանրապետության օր").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The1st),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Երեխաների իրավունքների պաշտպանության օր").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.July.The5th),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Սահմանադրության օր").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The1st),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Գիտելիքի, գրի եւ դպրության օր").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The21st),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Անկախության օր").AsDictionary(),
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Saturday).In(October),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Թարգմանչաց տոն").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The7th),
                    Names = NamesBuilder.Make.Add(Langue.HY, "Երկրաշարժի զոհերի հիշատակի օր").AsDictionary(),
                    Type = Observance
                }
            };
        }
    }
}

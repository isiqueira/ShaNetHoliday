using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShaNetDate;
using ShaNetHoliday.Models;
using ShaNetHoliday.Syntax;
using static System.DayOfWeek;
using static ShaNetHoliday.Models.Calendar;

namespace ShaNetHoliday.Countries
{
    /// <summary>
    /// Définition pour China.
    /// </summary>
    public class CN : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="CN"/>.
        /// </summary>
        public CN()
        {
            Code = "CN";
            Alpha3Code = "CHN";
            Names = NamesBuilder.Make.Add( Langue.EN, "China" ).Add( Langue.ZH, "中华人民共和国" ).AsDictionary();
            DaysOff.Add( Sunday );
            Langues = new List<Langue>() { Langue.ZH };
            SupportedCalendar = new List<Calendar>() { Gregorian };
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.ZH, "元旦").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The8th).StartAtNoon,
                    Names = NamesBuilder.Make.Add(Langue.ZH, "国际妇女节").AsDictionary(),
                    Note = "Women"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.ZH, "劳动节").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The4th).StartAtNoon,
                    Names = NamesBuilder.Make.Add(Langue.ZH, "青年节").AsDictionary(),
                    Note = "Youth from the age of 14 to 28"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The1st),
                    Names = NamesBuilder.Make.Add(Langue.ZH, "六一儿童节").AsDictionary(),
                    Note = "Children below the age of 14"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The1st),
                    Names = NamesBuilder.Make.Add(Langue.ZH, "建军节").AsDictionary(),
                    Note = "Military personnel in active service"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The1st),
                    Names = NamesBuilder.Make.Add(Langue.ZH, "国庆节").AsDictionary()
                },
                new ChineseRule()
                {
                    Expression = ExpressionTree.Chinese.LunarDate("01-0-01"),
                    Names = NamesBuilder.Make.Add(Langue.ZH, "春节").AsDictionary()
                },
                new ChineseRule()
                {
                    Expression = ExpressionTree.Chinese.SolarDate(OnSolarTerm.The5th),
                    Names = NamesBuilder.Make.Add(Langue.ZH, "清明节 清明節").AsDictionary()
                },
                new ChineseRule()
                {
                    Expression = ExpressionTree.Chinese.LunarDate("05-0-05"),
                    Names = NamesBuilder.Make.Add(Langue.ZH, "端午节").AsDictionary()
                },
                new ChineseRule() {
                    Expression = ExpressionTree.Chinese.SolarDate(OnSolarTerm.The8th).The(15),
                    Names = NamesBuilder.Make.Add(Langue.ZH, "中秋节").AsDictionary()
                }
            };
        }
    }
}

using ID3iDate;
using ID3iHoliday.Models;
using ID3iHoliday.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ID3iHoliday.Models.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Kosovo.
    /// </summary>
    public class XK : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="XK"/>.
        /// </summary>
        public XK()
        {
            Code = "XK";
            Alpha3Code = "UNK";
            Names = NamesBuilder.Make.Add(Langue.EN, "Kosovo").Add(Langue.SQ, "Republika e Kosovës").Add(Langue.SR, "Република Косово").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.SQ, Langue.SR };
            SupportedCalendar = new List<Calendar>() { Gregorian, Julian };
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.SQ, "Viti i Ri")
                                             .Add(Langue.SR, "Нова година").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The17th),
                    Names = NamesBuilder.Make.Add(Langue.SQ, "Dita e Pavarësisë")
                                             .Add(Langue.SR, "Дан независности").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The9th),
                    Names = NamesBuilder.Make.Add(Langue.SQ, "Dita e Kushtetutës").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.SQ, "Pashkët Katolike")
                                             .Add(Langue.SR, "Католички Васкрс").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Easter,
                    Names = NamesBuilder.Make.Add(Langue.SQ, "Pashkët Ortodokse")
                                             .Add(Langue.SR, "Васкрс").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.SQ, "Dita Ndërkombëtare e Punonjësve")
                                             .Add(Langue.SR, "Празник рада").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The9th),
                    Names = NamesBuilder.Make.Add(Langue.SQ, "Dita e Evropës").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.SQ, "Krishtlindja")
                                             .Add(Langue.SR, "Католички Божић").AsDictionary()
                },
                new JulianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th).Over.Julian(),
                    Names = NamesBuilder.Make.Add(Langue.SQ, "Krishtlindjet Ortodokse")
                                             .Add(Langue.SR, "Божић").AsDictionary()
                },
                new HijriRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.Shawwal.The1st).Over.Hijri(),
                    Names = NamesBuilder.Make.Add(Langue.SQ, "Fitër Bajrami")
                                             .Add(Langue.SR, "Рамазански Бајрам").AsDictionary()
                },
                new HijriRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.DhuAlHijjah.The10th).Over.Hijri(),
                    Names = NamesBuilder.Make.Add(Langue.SQ, "Kurban Bajrami")
                                             .Add(Langue.SR, "Курбански Бајрам").AsDictionary()
                }
            };
        }
    }
}

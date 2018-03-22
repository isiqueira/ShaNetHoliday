using ID3iHoliday.Syntax;
using ID3iDate;
using ID3iHoliday.Models;
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
    /// Définition pour Vatican City.
    /// </summary>
    public class VA : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="VA"/>.
        /// </summary>
        public VA()
        {
            Code = "VA";
            Alpha3Code = "VAT";
            Names = NamesBuilder.Make.Add(Langue.EN, "Vatican City").Add(Langue.IT, "Stato della Città del Vaticano").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.IT);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Maria Santissima Madre di Dio").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Epifania del Signore").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The11th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Anniversario della istituzione dello Stato della Città del Vaticano").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The19th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "San Giuseppe").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.IT, "Lunedì dell’Angelo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay.StartAtMidnight.UntilMidnight.Every(1).Year.To(2009),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Ascensione").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CorpusChristi.StartAtMidnight.UntilMidnight.Every(1).Year.To(2009),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Corpus Domini").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.IT, "San Giuseppe lavoratore").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The29th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Santi Pietro e Paolo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Assunzione di Maria in Cielo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.September.The8th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Festa della natività della madonna").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Ognissanti").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The8th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Immacolata Concezione").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Natale").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Santo Stefano").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The16th).Since(1978).To(2005),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Anniversario dell'Elezione del Santo Padre").AsDictionary(),
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The4th).Since(1978).To(2005),
                    Names = NamesBuilder.Make.Add(Langue.IT, "San Carlo Borromeo - Onomastico del Santo Padre").AsDictionary(),
                    Note = "Name day of Pope John Paul II (Karol Józef Wojtyła)"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The19th).Since(2005).To(2013),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Anniversario dell'Elezione del Santo Padre").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The13th).Since(2013),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Anniversario dell'Elezione del Santo Padre").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The23rd).Since(2013),
                    Names = NamesBuilder.Make.Add(Langue.IT, "San Giorgio - Onomastico del Santo Padre").AsDictionary(),
                    Note = "Name day of Pope Francis (Jorge Mario Bergoglio)"
                }
            };
        }
    }
}

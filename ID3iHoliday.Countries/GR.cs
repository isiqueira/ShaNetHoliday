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
using static ID3iHoliday.Syntax.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Greece.
    /// </summary>
    public class GR : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="GR"/>.
        /// </summary>
        public GR()
        {
            Code = "GR";
            Alpha3Code = "GRC";
            Names = NamesBuilder.Make.Add(Langue.EN, "Greece").Add(Langue.EL, "Ελλάδα").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.EL);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Πρωτοχρονιά").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Θεοφάνεια").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.CarnivalMonday,
                    Names = NamesBuilder.Make.Add(Langue.EL, "Καθαρά Δευτέρα").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The25th),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Ευαγγελισμός, Εθνική Εορτή").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.EL, "Μεγάλη Παρασκευή").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Easter,
                    Names = NamesBuilder.Make.Add(Langue.EL, "Πάσχα").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.EL, "Δευτέρα του Πάσχα").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Εργατική Πρωτομαγιά").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.EL, "Αγίου Πνεύματος").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Γιορτή της μητέρας").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Κοίμηση της Θεοτόκου").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The28th),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Επέτειος του Όχι").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Χριστούγεννα").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Δεύτερη μέρα των Χριστουγέννων").AsDictionary()
                }
            };
        }
    }
}

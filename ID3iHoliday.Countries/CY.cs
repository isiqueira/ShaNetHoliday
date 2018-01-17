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
using ID3iHoliday.Syntax;
using ID3iDate;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Cyprus.
    /// </summary>
    public class CY : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="CY"/>.
        /// </summary>
        public CY()
        {
            Code = "CY";
            Alpha3Code = "CYP";
            Names = NamesBuilder.Make.Add(Langue.EN, "Cyprus").Add(Langue.EL, "Κύπρος").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.EL);
            Rules = new ListRule()
            {
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Πρωτοχρονιά").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Θεοφάνεια").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.CarnivalMonday,
                    Names = NamesBuilder.Make.Add(Langue.EL, "Καθαρά Δευτέρα").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.CarnivalTuesday,
                    Names = NamesBuilder.Make.Add(Langue.EL, "Καθαρά Δευτέρα").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The25th),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Ευαγγελισμός, Εθνική Εορτή").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The1st),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Κύπρος Εθνική Εορτή").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.EL, "Μεγάλη Παρασκευή").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Easter,
                    Names = NamesBuilder.Make.Add(Langue.EL, "Πάσχα").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.EL, "Δευτέρα του Πάσχα").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Εργατική Πρωτομαγιά").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.EL, "Αγίου Πνεύματος").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Γιορτή της μητέρας").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Κοίμηση της Θεοτόκου").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The1st),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Ημέρα της Ανεξαρτησίας Κύπρος").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.October.The28th),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Επέτειος του Όχι").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Χριστούγεννα").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.EL, "Δεύτερη μέρα των Χριστουγέννων").AsDictionary()
                }
            };
        }
    }
}

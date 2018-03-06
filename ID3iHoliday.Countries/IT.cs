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
using static ID3iHoliday.Syntax.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Italia.
    /// </summary>
    public class IT : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="IT"/>.
        /// </summary>
        public IT()
        {
            Code = "IT";
            Alpha3Code = "ITA";
            Names = NamesBuilder.Make.Add(Langue.EN, "Italia").Add(Langue.IT, "Italia").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.IT);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Capodanno").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Befana").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.IT, "Domenica di Pasqua").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.IT, "Lunedì dell’Angelo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.April.The25th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Anniversario della Liberazione").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Festa del Lavoro").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Festa della mamma").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The2nd),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Festa della Repubblica").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Ferragosto").AsDictionary()
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
                    Expression = ExpressionTree.Date.Specific(On.March.The17th.Of(2011)),
                    Names = NamesBuilder.Make.Add(Langue.IT, "Festa Nazionale 2011").AsDictionary()
                }
            };
            States = new ListState
            {
                Langues = Langues,
                Container = { new IT_32() }
            }.Initialize(x => x.Init());
        }

        internal class IT_32 : State
        {
            public IT_32()
            {
                Code = "32";
                Names = NamesBuilder.Make.Add(Langue.IT, "Südtirol, Alto Adige").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.WhitMonday,
                        Names = NamesBuilder.Make.Add(Langue.IT, "Lunedì di Pentecoste").AsDictionary()
                    }
                };
            }
        }
    }
}

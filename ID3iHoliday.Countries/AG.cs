using ID3iHoliday.Syntax;
using ID3iCore;
using ID3iDate;
using ID3iHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ID3iHoliday.Models.RuleType;
using static ID3iHoliday.Models.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Antigua &amp; Barbuda.
    /// </summary>
    public class AG : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="AG"/>.
        /// </summary>
        public AG()
        {
            Code = "AG";
            Alpha3Code = "ATG";
            Names = NamesBuilder.Make.Add(Langue.EN, "Antigua & Barbuda").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.EN);
            SupportedCalendar.Add(Gregorian);
            Rules = new ListRule()
            {
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.January.The1st).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "New Year's Day").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Good Friday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Easter Sunday").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Easter Monday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Labour Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Pentecost").AsDictionary(),
                    Type = Observance
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make.Add(Langue.EN, "Whit Monday").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The1st),
                    Names = NamesBuilder.Make.Add(Langue.EN, "J'Ouvert Morning").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The2nd),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Last Lap").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Move.Fix(On.November.The11th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Independance Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The9th),
                    Names = NamesBuilder.Make.Add(Langue.EN, "V.C Bird Day").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.December.The25th).If(Saturday).Then.Next(Monday).Or.If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Christmas Day").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression=  ExpressionTree.Observe.Fix(On.December.The26th).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.EN, "Boxing Day").AsDictionary(),
                    Substitute = true
                }
            };
            States = new ListState()
            {
                Parent = this,
                Langues = Langues,
                Container = { new AG_10() }
            }.Initialize(x => x.Init());
        }

        internal class AG_10 : State
        {
            public AG_10()
            {
                Code = "AG-10";
                Names = NamesBuilder.Make.Add(Langue.EN, "Barbuda").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Catholic.CarnivalTuesday.StartAtMidnight.Duration.P4D(),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Caribana").AsDictionary(),
                        Type = Observance
                    }
                };
            }
        }
    }
}

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

#warning Penser aux jours fériés dans les autres types de calendriers.
namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Moldova.
    /// </summary>
    public class MD : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="MD"/>.
        /// </summary>
        public MD()
        {
            Code = "MD";
            Alpha3Code = "MDA";
            Names = NamesBuilder.Make.Add(Langue.EN, "Moldova").Add(Langue.RO, "Republica Moldova").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.RO);
            Rules = new ListRule()
            {
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.RO, "Anul nou").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.March.The8th),
                    Names = NamesBuilder.Make.Add(Langue.RO, "Ziua Internationala a Femeii").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Easter,
                    Names = NamesBuilder.Make.Add(Langue.RO, "Paștele").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.RO, "Două zi de Pasti").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Orthodox.CustomDay("EASTER +8"),
                    Names = NamesBuilder.Make.Add(Langue.RO, "Paştele Blăjinilor").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.RO, "Ziua muncii").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The9th),
                    Names = NamesBuilder.Make.Add(Langue.RO, "Ziua Victoriei").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The27th),
                    Names = NamesBuilder.Make.Add(Langue.RO, "Ziua Independentei").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The31st),
                    Names = NamesBuilder.Make.Add(Langue.RO, "Limba noastră").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Saturday).In(October).Every(1).Year.Since(2013),
                    Names = NamesBuilder.Make.Add(Langue.RO, "Ziua vinului").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.MovableFromMovable(First, Sunday).After(First, Saturday).In(October).Every(1).Year.Since(2013),
                    Names = NamesBuilder.Make.Add(Langue.RO, "Ziua vinului").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.RO, "Craciun pe stil Nou").AsDictionary()
                }
            };
            States = new ListState()
            {
                Langues = Langues,
                Container = { new MD_CA(), new MD_CU() }
            }.Initialize(x => x.Init());
        }

        internal class MD_CA : State
        {
            public MD_CA()
            {
                Code = "CA";
                Names = NamesBuilder.Make.Add(Langue.RO, "Cahul").AsDictionary();
                Rules = new ListRule()
                {
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The21st),
                        Names = NamesBuilder.Make.Add(Langue.RO, "Ziua Cahul").AsDictionary()
                    }
                };
            }
        }
        internal class MD_CU : State
        {
            public MD_CU()
            {
                Code = "CU";
                Names = NamesBuilder.Make.Add(Langue.RO, "Chișinău").AsDictionary();
                Rules = new ListRule()
                {
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.October.The14th),
                        Names = NamesBuilder.Make.Add(Langue.RO, "Ziua capitalului").AsDictionary()
                    }
                };
            }
        }
    }
}

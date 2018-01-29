﻿using ID3iCore;
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

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Iceland.
    /// </summary>
    public class IS : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="IS"/>.
        /// </summary>
        public IS()
        {
            Code = "IS";
            Alpha3Code = "ISL";
            Names = NamesBuilder.Make.Add(Langue.EN, "Iceland").Add(Langue.IS, "Ísland").AsDictionary();
            DaysOff.Add(Sunday);
            Langues.Add(Langue.IS);
            Rules = new ListRule()
            {
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Nýársdagur").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Þrettándinn").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Friday).After("01-18"),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Bóndadagur").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.February.The18th),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Konudagur").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.CarnivalMonday,
                    Names = NamesBuilder.Make.Add(Langue.IS, "Bolludagur").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.CarnivalTuesday,
                    Names = NamesBuilder.Make.Add(Langue.IS, "Sprengidagur").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.AshWednesday,
                    Names = NamesBuilder.Make.Add(Langue.IS, "Öskudagur").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.PalmSunday,
                    Names = NamesBuilder.Make.Add(Langue.IS, "Pálmasunnudagur").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.MaundyThursday,
                    Names = NamesBuilder.Make.Add(Langue.IS, "Skírdagur").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.GoodFriday,
                    Names = NamesBuilder.Make.Add(Langue.IS, "Föstudagurinn langi").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make.Add(Langue.IS, "Páskadagur").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make.Add(Langue.IS, "Annar í páskum").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Thursday).After("04-18"),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Sumardagurinn fyrsti").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.May.The1st),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Hátíðisdagur Verkamanna").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(Second, Sunday).In(May),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Mæðradagurinn").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.AscensionDay,
                    Names = NamesBuilder.Make.Add(Langue.IS, "Uppstigningardagur").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.Pentecost,
                    Names = NamesBuilder.Make.Add(Langue.IS, "Hvítasunnudagur").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Catholic.WhitMonday,
                    Names = NamesBuilder.Make.Add(Langue.IS, "Annar í hvítasunnu").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Sunday).In(June),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Sjómannadagurinn").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.June.The17th),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Íslenski þjóðhátíðardagurinn").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Monday).In(August),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Frídagur verslunarmanna").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Movable(First, Saturday).After("10-21"),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Fyrsti vetrardagur").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The16th).Since(1996),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Dagur íslenskrar tungu").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The23rd),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Þorláksmessa").AsDictionary(),
                    Type = Observance
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The24th).StartAt("13:00").UntilMidnight.If(Sunday).ThenStartAt("00:00"),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Aðfangadagur").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Jóladagur").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Annar í jólum").AsDictionary()
                },
                new Rule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The31st).StartAt("13:00").UntilMidnight.If(Sunday).ThenStartAt("00:00"),
                    Names = NamesBuilder.Make.Add(Langue.IS, "Gamlársdagur").AsDictionary()
                }
            };
        }
    }
}
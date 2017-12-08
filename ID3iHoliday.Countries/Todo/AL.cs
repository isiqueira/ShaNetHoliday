using System;
using System.Collections.Generic;
using ID3iHoliday.Models;
using ID3iHoliday.Syntax;

using static System.DayOfWeek;
using static ID3iHoliday.Syntax.Count;
using static ID3iHoliday.Syntax.Month;
using static ID3iHoliday.Models.RuleType;

namespace ID3iHoliday.Countries
{
    public class AL : Country
    {
#warning attention ici il faut penser aux jours fériés dans le calendrier islamic
        public AL()
        {
            Code = "AL";
            Alpha3Code = "ALB";
            Names = NamesBuilder.Make.Add(Langue.SQ, "Shqipëri").Add(Langue.EN, "Albania").AsDictionary();
            DaysOff = new List<DayOfWeek>() { Sunday };
            Langues = new List<Langue>() { Langue.SQ };
            Rules = new ListRule()
            {
                Langues = Langues,
                Container =
                {
                    new Rule()
                    {
                        Expression = ExpressionTree.Substitute.Fix(On.January.The1st).If(Sunday).Then.Next(Tuesday),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Viti i Ri").AsDictionary(),
                        Substitute = true
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Substitute.Fix(On.January.The2nd).If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Festa e Vitit të Ri").AsDictionary(),
                        Substitute = true
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The2nd),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Dita e Besëlidhjes së Lezhës").AsDictionary(),
                        Type = Observance
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The7th),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Dita e Mësuesit").AsDictionary(),
                        Type = Observance
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The8th),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Dita e Nënës").AsDictionary(),
                        Type = Observance
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Observe.Fix(On.March.The14th).If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Dita e Verës").AsDictionary(),
                        Substitute = true
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Observe.Fix(On.March.The22nd).If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Dita e Sulltan Nevruzit").AsDictionary(),
                        Substitute = true
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.April.The1st),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Dita e Gënjeshtrave").AsDictionary(),
                        Type = Observance
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.Easter,
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Pashkët Katolike").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Catholic.EasterMonday,
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Pashkët Katolike").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Orthodox.Easter,
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Pashkët Ortodokse").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Orthodox.EasterMonday,
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Pashkët Ortodokse").AsDictionary()
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Observe.Fix(On.May.The1st).If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Dita Ndërkombëtare e Punonjësve").AsDictionary(),
                        Substitute = true
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.June.The1st),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Dita Ndërkombëtare e Fëmijëve").AsDictionary(),
                        Type = Observance
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Observe.Fix(On.October.The19th).If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Dita e Nënë Terezës").AsDictionary(),
                        Substitute = true,
                        Note = "Faire commencer ce jour férié à partir de 2004"
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The22nd),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Dita e Alfabetit").AsDictionary(),
                        Type = Observance
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Observe.Fix(On.November.The28th).If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Dita e Pavarësisë").AsDictionary(),
                        Substitute = true
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Observe.Fix(On.November.The29th).If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Dita e Çlirimit").AsDictionary(),
                        Substitute = true
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Observe.Fix(On.December.The8th).If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Dita Kombëtare e Rinisë").AsDictionary(),
                        Substitute = true,
                        Note = "Faire commencer ce jour férié à partir de 2010"
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.December.The24th),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Nata e Krishtlindjes").AsDictionary(),
                        Type = Bank
                    },
                    new Rule()
                    {
                        Expression = ExpressionTree.Observe.Fix(On.December.The25th).If(Sunday).Then.Next(Monday),
                        Names = NamesBuilder.Make.Add(Langue.SQ, "Krishtlindja").AsDictionary(),
                        Substitute = true
                    }
                }
            };
        }
    }
}

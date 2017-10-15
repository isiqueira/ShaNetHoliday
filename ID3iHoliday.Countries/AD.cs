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
using static ID3iHoliday.Models.Rule.SpecificDayKey;

namespace ID3iHoliday.Countries
{
    public class AD : Country
    {
        public AD()
        {
            Code = "AD";
            Alpha3Code = "AND";
            Names = new Dictionary<Langue, string>() { { Langue.CA, "Andorra" }, { Langue.ES, "Andorra" }, { Langue.EN, "Andorra" } };
            DaysOff = new List<DayOfWeek>() { Sunday };
            Langues = new List<Langue>() { Langue.CA, Langue.ES };
            Rules = new ListRule()
            {
                Langues = Langues,
                Container =
                {
                    Rule.Jan01,
                    Rule.Jan06,
                    new Rule()
                    {
                        SpecDayKey = ConstitutionDayKey,
                        Expression  = ExpressionTree.Date.Fix(On.March.The3rd)
                    },
                    Rule.May01,
                    Rule.Aug15,
                    new Rule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.September.The8th),
                        Names = new Dictionary<Langue, string>()
                        {
                            { Langue.EN, "Our Lady of Meritxell" }, { Langue.ES, "Nuestra Sra. De Meritxell" }, { Langue.CA, "Mare de Déu de Meritxell" }
                        }
                    },
                    Rule.Nov01,
                    Rule.Dec08,
                    new Rule()
                    {
                        SpecDayKey = Rule.Dec24.SpecDayKey,
                        Expression = Rule.Dec24.Expression,
                        Type = Bank
                    },
                    Rule.Dec25,
                    Rule.Dec26,
                    Rule.CarnivalTuesday,
                    new Rule()
                    {
                        SpecDayKey = MaundyThrusdayKey,
                        Expression = ExpressionTree.Date.Catholic.MaundyThursday.Start("14:00"),
                        Type = Bank
                    },
                    Rule.GoodFriday,
                    Rule.Easter,
                    Rule.EasterMonday,
                    Rule.Pentecost,
                    Rule.WhitMonday
                }
            };
            States = new ListState()
            {
                Langues = Langues,
                Container = { new AD_07() }
            }.Initialize(x => x.Init());
        }

        internal class AD_07 : State
        {
            public AD_07()
            {
                Code = "07";
                Names = new Dictionary<Langue, string>()
                {
                    { Langue.ES, "Andorra la Vella" }
                };
                Rules = new ListRule()
                {
                    Langues = Langues,
                    Container =
                    {
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.Movable(First, Saturday).In(August),
                            Names = new Dictionary<Langue, string>() { { Langue.ES, "Andorra La Vella Festival" } }
                        },
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.MovableFromMovable(First, Sunday).After(First, Saturday).In(August),
                            Names = new Dictionary<Langue, string>() { { Langue.ES, "Andorra La Vella Festival" } }
                        },
                        new Rule()
                        {
                            Expression = ExpressionTree.Date.MovableFromMovable(First, Monday).After(First, Saturday).In(August),
                            Names = new Dictionary<Langue, string>() { { Langue.ES, "Andorra La Vella Festival" } }
                        }
                    }
                };
            }
        }
    }
}

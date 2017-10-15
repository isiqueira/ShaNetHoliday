using ID3iHoliday.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ID3iHoliday.Models.Rule.SpecificDayKey;

namespace ID3iHoliday.Models
{
    public partial class Rule
    {
        public List<Langue> Langues { get; set; }
        public static Rule Jan01 => new Rule() { Expression = ExpressionTree.Date.Fix(On.January.The1st), SpecDayKey = Jan01Key };
        public static Rule Jan06 => new Rule() { Expression = ExpressionTree.Date.Fix(On.January.The6th), SpecDayKey = Jan06Key };
        public static Rule GoodFriday => new Rule() { Expression = ExpressionTree.Date.Catholic.GoodFriday, SpecDayKey = GoodFridayKey };
        public static Rule EasterMonday => new Rule() { Expression = ExpressionTree.Date.Catholic.EasterMonday, SpecDayKey = EasterMondayKey };
        public static Rule May01 => new Rule() { Expression = ExpressionTree.Date.Fix(On.May.The1st), SpecDayKey = May01Key };
        public static Rule Ascension => new Rule() { Expression = ExpressionTree.Date.Catholic.AscensionDay, SpecDayKey = AscensionKey };
        public static Rule Pentecost => new Rule() { Expression = ExpressionTree.Date.Catholic.Pentecost, SpecDayKey = PentecostKey };
        public static Rule WhitMonday => new Rule() { Expression = ExpressionTree.Date.Catholic.WhitMonday, SpecDayKey = WhitMondayKey };
        public static Rule CarnivalTuesday => new Rule() { Expression = ExpressionTree.Date.Catholic.CarnivalTuesday, SpecDayKey = CarnivalTuesdayKey };
        public static Rule MaundyThursday => new Rule() { Expression = ExpressionTree.Date.Catholic.MaundyThursday, SpecDayKey = MaundyThrusdayKey };
        public static Rule Easter => new Rule() { Expression = ExpressionTree.Date.Catholic.Easter, SpecDayKey = EasterKey };
        public static Rule Aug15 => new Rule() { Expression = ExpressionTree.Date.Fix(On.August.The15th), SpecDayKey = Aug15Key };
        public static Rule Nov01 => new Rule() { Expression = ExpressionTree.Date.Fix(On.November.The1st), SpecDayKey = Nov01Key };
        public static Rule Dec08 => new Rule() { Expression = ExpressionTree.Date.Fix(On.December.The8th), SpecDayKey = Dec08Key };
        public static Rule Dec24 => new Rule() { Expression = ExpressionTree.Date.Fix(On.December.The24th), SpecDayKey = Dec24Key };
        public static Rule Dec25 => new Rule() { Expression = ExpressionTree.Date.Fix(On.December.The25th), SpecDayKey = Dec25Key };
        public static Rule Dec26 => new Rule() { Expression = ExpressionTree.Date.Fix(On.December.The26th), SpecDayKey = Dec26Key };
        public static Rule AbolitionSlavery => new Rule() { SpecDayKey = AbolitionSlaveryKey };
    }
}

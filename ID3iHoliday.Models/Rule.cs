using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ID3iHoliday.Models.RuleType;

namespace ID3iHoliday.Models
{
    public partial class Rule
    {
        public string Key { get; set; }
        public ExpressionElement Expression { get; set; }
        public Dictionary<Langue, string> Names { get; set; } = new Dictionary<Langue, string>();
        public RuleType Type { get; set; } = Public;
        public string Note { get; set; }
        public bool Substitute { get; set; }
        public bool IsEnable { get; set; } = true;
        public override string ToString() => Expression.Expression;

        public void Parse(int year, List<SpecificDay> specificDays)
        {
            var result = Expression.Parse(year);
            result.DatesToAdd.ForEach(x => specificDays.Add(new SpecificDay(Type, x, Names)));
            if (result.DateToRemove != null)
                specificDays.RemoveAll(x => x.Date == result.DateToRemove);
        }
    }

    public class ListRule : BaseList<Rule> { }
}

using ID3iCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ID3iHoliday.Models.RuleType;

namespace ID3iHoliday.Models
{
    public class Country : GeographicElementBase
    {
        public string Alpha3Code { get; set; }
        public List<DayOfWeek> DaysOff { get; set; } = new List<DayOfWeek>();

        public ListState States { get; set; } = new ListState();

        public IEnumerable<SpecificDay> Get(int year, RuleType type)
            => Get(year, null, null, type);
        public IEnumerable<SpecificDay> Get(int year, string state, RuleType type)
            => Get(year, state, null, type);
        public IEnumerable<SpecificDay> Get(int year, string stateCode, string regionCode, RuleType type)
        {
            List<Rule> rules = new List<Rule>(Rules.Select(x => x.Clone() as Rule));

            void CheckRule(Rule rule)
            {
                if (rule.Key.IsNotNullOrEmpty() && !rule.IsEnable)
                    rules.RemoveAll(x => x.Key == rule.Key);
                else if (rule.Key.IsNotNullOrEmpty() && !rule.Overrides.HasFlag(Overrides.None))
                {
                    var baseRule = rules.FirstOrDefault(x => x.Key == rule.Key);
                    if (rule.Overrides.HasFlag(Overrides.Expression))
                        baseRule.Expression = rule.Expression;
                    if (rule.Overrides.HasFlag(Overrides.Type))
                        baseRule.Type = rule.Type;
                    if (rule.Overrides.HasFlag(Overrides.Note))
                        baseRule.Note = rule.Note;
                }
                else
                    rules.Add(rule);
            };

            States.FirstOrDefault(x => x.Code == stateCode)?.IfNotNull(x =>
            {
                x.Rules.ForEach(y => CheckRule(y));
                x.Regions.FirstOrDefault(y => y.Code == regionCode)?.Rules.ForEach(y => CheckRule(y));
            });

            List<SpecificDay> lst = new List<SpecificDay>();
            rules.ConditionnalWhere(() => type == All, x => true, x => x.Type == type).ForEach(x => x.Parse(year, lst));

            return lst.OrderBy(x => x.Date);
        }
    }
}

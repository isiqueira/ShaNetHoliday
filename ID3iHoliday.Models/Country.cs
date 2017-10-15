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
            =>Get(year, state, null, type);
        public IEnumerable<SpecificDay> Get(int year, string stateCode, string regionCode, RuleType type)
        {
            List<Rule> rules = new List<Rule>(Rules);
            var stateObj = States.FirstOrDefault(x => x.Code == stateCode);
            if (stateObj != null)
            {
                stateObj.Rules.ForEach(x =>
                {
                    if (x.Key.IsNotNullOrEmpty() && x.IsEnable)
                        rules.RemoveAll(y => y.Key == x.Key);
                    else
                        rules.Add(x);
                });
                var regionObj = stateObj.Regions.FirstOrDefault(x => x.Code == regionCode);
                if (regionObj != null)
                {
                    regionObj.Rules.ForEach(x =>
                    {
                        if (x.Key.IsNotNullOrEmpty() && x.IsEnable)
                            rules.RemoveAll(y => y.Key == x.Key);
                        else
                            rules.Add(x);
                    });
                }
            }

            Func<Rule, bool> ruleSelector = x => true;
            if (type != All)
                ruleSelector = x => x.Type == type;

            List<SpecificDay> lst = new List<SpecificDay>();
            rules.Where(x => ruleSelector(x)).ForEach(x => x.Parse(year, lst));
            return lst.OrderBy(x => x.Date);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    public class SpecificDay
    {
        public DateTime Date { get; set; }
        public Dictionary<Langue, string> Names { get; set; }
        public RuleType Type { get; set; }
        public SpecificDay(RuleType type, DateTime date, Dictionary<Langue, string> names)
        {
            Type = type;
            Date = date;
            Names = names;
        }
        public override string ToString() => $"{Date.ToShortDateString()} {Names.FirstOrDefault().Value}";
    }   
}

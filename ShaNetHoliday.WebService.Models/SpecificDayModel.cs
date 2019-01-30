using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.WebService.Models
{
    public class SpecificDayModel
    {
        public DateTime Date { get; set; }
        public Dictionary<string, string> Names { get; set; }

        public SpecificDayModel( DateTime date, Dictionary<string, string> names )
        {
            Date = date;
            Names = names;
        }

        public override string ToString() => $"{Date.ToShortDateString()} {Names.FirstOrDefault().Value}";
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    public class LongWeekEnd
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool HasBridge { get; set; } = false;
        public override string ToString() => $"{CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(StartDate.DayOfWeek)} {StartDate.ToShortDateString()} -> {CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(EndDate.DayOfWeek)} {EndDate.ToShortDateString()} : {EndDate.Subtract(StartDate).TotalDays + 1} jour(s).";
    }
}

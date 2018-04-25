using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.WebService.Models
{
    public class LongWeekEndModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool HasBridge { get; set; }
        public string Description { get; set; }
        public LongWeekEndModel(DateTime startDate, DateTime endDate, bool hasBridge, string description)
        {
            StartDate = startDate;
            EndDate = endDate;
            HasBridge = hasBridge;
            Description = description;
        }
    }
}

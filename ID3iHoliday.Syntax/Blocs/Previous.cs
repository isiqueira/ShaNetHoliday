using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class Previous : ExpressionElement
    {
        protected override string Token => $"PREVIOUS {Day.ToString().ToUpper()}";
        public DayOfWeek Day { get; set; }
        public Previous(ExpressionElement parent, DayOfWeek day) : base(parent) { Day = day; }
    }
}

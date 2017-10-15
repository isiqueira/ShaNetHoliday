using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class Next : ExpressionElement
    {
        protected override string Token => $"NEXT {Day.ToString().ToUpper()}";
        internal DayOfWeek Day { get; set; }
        public Next(ExpressionElement parent, DayOfWeek day) : base(parent) { Day = day; }
    }
}

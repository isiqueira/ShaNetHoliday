using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class SinceElement : ExpressionElement
    {
        protected override string Token => $"SINCE {Year}";
        internal int Year { get; set; }
        public SinceElement(ExpressionElement parent, int year) : base(parent) { Year = year; }
    }
}

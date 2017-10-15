using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class EveryElement : ExpressionElement
    {
        protected override string Token => "YEARS";
        public EveryElement(ExpressionElement parent) : base(parent) { }
        public SinceElement Since(int year) => new SinceElement(this, year);
    }
}

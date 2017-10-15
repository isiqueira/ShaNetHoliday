using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class FixDayBase: ExpressionElement
    {
        protected override string Token => Value.ToString("MM-dd");
        internal DateTime Value { get; }
        public FixDayBase(ExpressionElement parent, DateTime value) : base(parent) { Value = value; }
    }
    public class SpecificDayBase : FixDayBase
    {
        protected override string Token => Value.ToString("yyyy-MM-dd");
        public SpecificDayBase(ExpressionElement parent, DateTime date) : base(parent, date) { }
    }
}

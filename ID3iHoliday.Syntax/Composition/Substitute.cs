using ID3iHoliday.Core.Models;
using ID3iHoliday.Core.Parsers;
using ID3iHoliday.Syntax.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class Substitute : ExpressionElement
    {
        protected override string Token => "SUBSTITUTE";
        protected override ParserBase Parser => new ParserSubstitute();
        public Substitute() : base(null) { }
        public FixDay Fix(DateTime value) => new FixDay(this, value);

        public class FixDay : FixDayBase
        {
            public FixDay(ExpressionElement parent, DateTime value) : base(parent, value) { }
            public IfDay If(DayOfWeek day) => new IfDay(this, day);
        }
        public class IfDay : If
        {
            public IfDay(ExpressionElement parent, DayOfWeek day) : base(parent, day) { }
            public ThenDay Then => new ThenDay(this);
        }
        public class ThenDay : Then
        {
            public ThenDay(ExpressionElement parent) : base(parent) { }
            public NextDay Next(DayOfWeek day) => new NextDay(this, day);
            public PreviousDay Previous(DayOfWeek day) => new PreviousDay(this, day);
        }
        public class NextDay : Next
        {
            public NextDay(ExpressionElement parent, DayOfWeek day) : base(parent, day) { }

        }
        public class PreviousDay : Previous
        {
            public PreviousDay(ExpressionElement parent, DayOfWeek day) : base(parent, day) { }
        }
    }
}

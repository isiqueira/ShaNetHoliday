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
    //public class Move : ExpressionElement
    //{
    //    protected override string Token => "MOVE";
    //    protected override ParserBase Parser => new ParserMove();
    //    public Move() : base(null) { }
    //    public FixDay Fix(DateTime value) => new FixDay(this, value);
    //    public class FixDay : FixDayBase
    //    {
    //        public FixDay(ExpressionElement parent, DateTime value) : base(parent, value) { }
    //        public IfDay If(DayOfWeek day) => new IfDay(this, day);
    //    }
    //    public class IfDay : If
    //    {
    //        public IfDay(ExpressionElement parent, DayOfWeek day) : base(parent, day) { }
    //        public ThenAction Then => new ThenAction(this);
    //    }
    //    public class ThenAction : Then
    //    {
    //        public ThenAction(ExpressionElement parent) : base(parent) { }
    //        public NextDay Next(DayOfWeek day) => new NextDay(this, day);
    //        public PreviousDay Previous(DayOfWeek day) => new PreviousDay(this, day);
    //    }
    //    public class NextDay : Next
    //    {
    //        public NextDay(ExpressionElement parent, DayOfWeek day) : base(parent, day) { }
    //        public OrAnother Or => new OrAnother(this);

    //    }
    //    public class PreviousDay : Previous
    //    {
    //        public PreviousDay(ExpressionElement parent, DayOfWeek day) : base(parent, day) { }
    //        public OrAnother Or => new OrAnother(this);
    //    }
    //    public class OrAnother : Or
    //    {
    //        public OrAnother(ExpressionElement parent) : base(parent) { }
    //        public IfDay If(DayOfWeek day) => new IfDay(this, day);
    //    }
    //}
}

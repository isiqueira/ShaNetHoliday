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
    public class MovableFromMovable : ExpressionElement
    {
        protected override string Token => $"MOVABLE² {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
        protected override ParserBase Parser => new ParserMovableFromMovable();
        internal Count Count { get; set; }
        internal DayOfWeek Day { get; set; }
        public MovableFromMovable(ExpressionElement parent, Count count, DayOfWeek day) : base(parent)
        {
            Count = count;
            Day = day;
        }
        public BeforeMovable Before(Count count, DayOfWeek day) => new BeforeMovable(this, count, day);
        public AfterMovable After(Count count, DayOfWeek day) => new AfterMovable(this, count, day);

        public class BeforeMovable : Movable
        {
            protected override string Token => $"BEFORE {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
            protected override ParserBase Parser => ((MovableFromMovable)Parent).Parser;
            public BeforeMovable(ExpressionElement parent, Count count, DayOfWeek day) : base(parent, count, day) { }
        }
        public class AfterMovable : Movable
        {
            protected override string Token => $"AFTER {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
            protected override ParserBase Parser => ((MovableFromMovable)Parent).Parser;
            public AfterMovable(ExpressionElement parent, Count count, DayOfWeek day) : base(parent, count, day) { }
        }
    }
}

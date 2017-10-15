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
    public class Date : ExpressionElement
    {
        protected override string Token => "DATE";
        public Date() : base(null) { }
        public FixDay Fix(DateTime value) => new FixDay(this, value);
        public SpecificDay Specific(DateTime value) => new SpecificDay(this, value);
        public Catholic Catholic => new Catholic(this);
        public Orthodox Orthodox => new Orthodox(this);

        public Movable Movable(Count count, DayOfWeek day) => new Movable(this, count, day);
        public MovableFromMovable MovableFromMovable(Count count, DayOfWeek day) => new MovableFromMovable(this, count, day);

        public class FixDay : FixDayBase
        {
            protected override ParserBase Parser => new ParserDate();
            public FixDay(ExpressionElement parent, DateTime value) : base(parent, value) { }
            public StartDay Start(string value) => new StartDay(this, value);
            public Duration Duration(string value) => new Duration(this, value);
            public InYear In(Year type) => new InYear(this, type);
            public Every Every(int number) => new Every(this, number);

            public class StartDay : Start
            {
                public StartDay(ExpressionElement parent, string value) : base(parent, value) { }
                public Duration Duration(string value) => new Duration(this, value);
                public IfDay If(DayOfWeek day) => new IfDay(this, day);
            }
            public class IfDay : If
            {
                public IfDay(ExpressionElement parent, DayOfWeek day) : base(parent, day) { }
                public ThenDay Then(string value) => new ThenDay(this, value);
            }
            public class ThenDay : Then
            {
                protected override string Token => Value;
                internal string Value { get; set; }
                public ThenDay(ExpressionElement parent, string value) : base(parent) { Value = value; }
            }
        }
        public class SpecificDay : FixDay
        {
            public SpecificDay(ExpressionElement parent, DateTime value) : base(parent, value) { }
        }
    }
}

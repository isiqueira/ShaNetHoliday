using ID3iHoliday.Core.Models;
using ID3iHoliday.Core.Parsers;
using ID3iHoliday.Syntax.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ID3iHoliday.Syntax.Month;

namespace ID3iHoliday.Syntax
{
    public class Movable : ExpressionElement
    {
        protected override string Token => $"MOVABLE {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
        protected override ParserBase Parser => new ParserMovable();
        internal Count Count;
        internal DayOfWeek Day;
        public Movable(ExpressionElement parent, Count count, DayOfWeek day) : base(parent)
        {
            Count = count;
            Day = day;
        }
        public BeforeDay Before(string value) => new BeforeDay(this, value);
        public BeforeDay Before(Month month)
        {
            switch (month)
            {
                case January:
                    return new BeforeDay(this, "01-01");
                case February:
                    return new BeforeDay(this, "02-01");
                case March:
                    return new BeforeDay(this, "03-01");
                case April:
                    return new BeforeDay(this, "04-01");
                case May:
                    return new BeforeDay(this, "05-01");
                case June:
                    return new BeforeDay(this, "06-01");
                case July:
                    return new BeforeDay(this, "07-01");
                case August:
                    return new BeforeDay(this, "08-01");
                case September:
                    return new BeforeDay(this, "09-01");
                case October:
                    return new BeforeDay(this, "10-01");
                case November:
                    return new BeforeDay(this, "11-01");
                case December:
                    return new BeforeDay(this, "12-01");
                default:
                    return new BeforeDay(this, "01-01");
            }
        }
        public AfterDay After(string value) => new AfterDay(this, value);
        public AfterDay In(Month month)
        {
            switch (month)
            {
                case January:
                    return new AfterDay(this, "01-01");
                case February:
                    return new AfterDay(this, "02-01");
                case March:
                    return new AfterDay(this, "03-01");
                case April:
                    return new AfterDay(this, "04-01");
                case May:
                    return new AfterDay(this, "05-01");
                case June:
                    return new AfterDay(this, "06-01");
                case July:
                    return new AfterDay(this, "07-01");
                case August:
                    return new AfterDay(this, "08-01");
                case September:
                    return new AfterDay(this, "09-01");
                case October:
                    return new AfterDay(this, "10-01");
                case November:
                    return new AfterDay(this, "11-01");
                case December:
                    return new AfterDay(this, "12-01");
                default:
                    return new AfterDay(this, "01-01");
            }
        }

        public class BeforeDay : Before
        {
            protected override string Token => $"BEFORE {Value}";
            internal string Value { get; set; }
            public BeforeDay(ExpressionElement parent, string value) : base(parent) { Value = value; }

            public InYear In(Year type) => new InYear(this, type);
            public Every Every(int year) => new Every(this, year);
        }
        public class AfterDay : After
        {
            protected override string Token => $"AFTER {Value}";
            internal string Value { get; set; }
            public AfterDay(ExpressionElement parent, string value) : base(parent) { Value = value; }

            public InYear In(Year type) => new InYear(this, type);
            public Every Every(int year) => new Every(this, year);
        }
    }
}

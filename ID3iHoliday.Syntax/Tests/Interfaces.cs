using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ID3iDate;
using static ID3iHoliday.Syntax.Month;
using ID3iHoliday.Syntax.Parsers;
using ID3iHoliday.Core.Parsers;

namespace ID3iHoliday.Syntax.Tests
{
    public class DateComposition : ExpressionElement
    {
        public DateComposition() : base(null) { }
        public DayComposition Fix(DateTime dateTime) => new DayComposition(this, dateTime);
        public SpecificDayComposition Specific(DateTime dateTime) => new SpecificDayComposition(this, dateTime);
        public Catholic Catholic => new Catholic(this);
        public Orthodox Orthodox => new Orthodox(this);
        public MovableComposition Movable(Count count, DayOfWeek dayOfWeek) => new MovableComposition(this, count, dayOfWeek);
        public MovableFromMovableComposition MovableFromMovable(Count count, DayOfWeek dayOfWeek) => new MovableFromMovableComposition(this, count, dayOfWeek);
    }
    public class MoveComposition : ExpressionElement
    {
        protected override string Token => "MOVE";
        protected override ParserBase Parser => new ParserMove();
        public MoveComposition() : base(null) { }
        public SimpleDayComposition Fix(DateTime dateTime) => new SimpleDayComposition(this, dateTime);
    }
    public class ObserveComposition : ExpressionElement
    {
        protected override string Token => "OBSERVE";
        protected override ParserBase Parser => new ParserObserve();
        public ObserveComposition() : base(null) { }
        public SimpleDayComposition Fix(DateTime dateTime) => new SimpleDayComposition(this, dateTime);
    }
    public class SubstituteComposition : ExpressionElement
    {
        protected override string Token => "SUBSTITUTE";
        protected override ParserBase Parser => new ParserSubstitute();
        public SubstituteComposition() : base(null) { }
        public SimpleDayComposition Fix(DateTime dateTime) => new SimpleDayComposition(this, dateTime);
    }

    public class SimpleDayComposition : ExpressionElement
    {
        protected override string Token => DateTime.ToString("MM-dd");
        internal DateTime DateTime { get; }
        public SimpleDayComposition(ExpressionElement parent, DateTime dateTime) : base(parent) => DateTime = dateTime;
        public IfDayComposition If(DayOfWeek dayOfWeek) => new IfDayComposition(this, dayOfWeek);
    }

    public class DayComposition : ExpressionElement
    {
        protected override string Token => DateTime.ToString("MM-dd");
        internal DateTime DateTime { get; }
        public DayComposition(ExpressionElement parent, DateTime dateTime) : base(parent) => DateTime = dateTime;
        public StartComposition StartAt(string value) => new StartComposition(this, value);
    }
    public class SpecificDayComposition : ExpressionElement
    {
        protected override string Token => DateTime.ToString("yyyy-MM-dd");
        internal DateTime DateTime { get; }
        public SpecificDayComposition(ExpressionElement parent, DateTime dateTime) : base(parent) => DateTime = dateTime;
        public StartComposition StartAt(string value) => new StartComposition(this, value);
    }
    public class EasterDayComposition : ExpressionElement
    {
        protected override string Token => Value;
        internal string Value { get; set; }
        public EasterDayComposition(ExpressionElement parent, string value) : base(parent) => Value = value;
        public StartComposition StartAt(string value) => new StartComposition(this, value);
        public StartComposition StartAtMidnight => new StartComposition(this, "00:00");
    }
    public class MovableComposition : ExpressionElement
    {
        protected override string Token => $"MOVABLE {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
        protected override ParserBase Parser => new ParserMovable();
        internal Count Count { get; set; }
        internal DayOfWeek Day { get; set; }
        public MovableComposition(ExpressionElement parent, Count count, DayOfWeek dayOfWeek) : base(parent)
        {
            Count = count;
            Day = Day;
        }
        public BeforeComposition Before(string value) => new BeforeComposition(this, value);
        public BeforeComposition Before(Month month)
        {
            switch (month)
            {
                case January:
                    return new BeforeComposition(this, "01-01");
                case February:
                    return new BeforeComposition(this, "02-01");
                case March:
                    return new BeforeComposition(this, "03-01");
                case April:
                    return new BeforeComposition(this, "04-01");
                case May:
                    return new BeforeComposition(this, "05-01");
                case June:
                    return new BeforeComposition(this, "06-01");
                case July:
                    return new BeforeComposition(this, "07-01");
                case August:
                    return new BeforeComposition(this, "08-01");
                case September:
                    return new BeforeComposition(this, "09-01");
                case October:
                    return new BeforeComposition(this, "10-01");
                case November:
                    return new BeforeComposition(this, "11-01");
                case December:
                    return new BeforeComposition(this, "12-01");
                default:
                    return new BeforeComposition(this, "01-01");
            }
        }
        public AfterComposition After(string value) => new AfterComposition(this, value);
        public AfterComposition In(Month month)
        {
            switch (month)
            {
                case January:
                    return new AfterComposition(this, "01-01");
                case February:
                    return new AfterComposition(this, "02-01");
                case March:
                    return new AfterComposition(this, "03-01");
                case April:
                    return new AfterComposition(this, "04-01");
                case May:
                    return new AfterComposition(this, "05-01");
                case June:
                    return new AfterComposition(this, "06-01");
                case July:
                    return new AfterComposition(this, "07-01");
                case August:
                    return new AfterComposition(this, "08-01");
                case September:
                    return new AfterComposition(this, "09-01");
                case October:
                    return new AfterComposition(this, "10-01");
                case November:
                    return new AfterComposition(this, "11-01");
                case December:
                    return new AfterComposition(this, "12-01");
                default:
                    return new AfterComposition(this, "01-01");
            }
        }
    }
    public class MovableFromMovableComposition : ExpressionElement
    {
        protected override string Token => $"MOVABLE² {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
        protected override ParserBase Parser => new ParserMovableFromMovable();
        internal Count Count { get; set; }
        internal DayOfWeek Day { get; set; }
        public MovableFromMovableComposition(ExpressionElement parent, Count count, DayOfWeek dayOfWeek) : base(parent)
        {
            Count = count;
            Day = dayOfWeek;
        }
        public BeforeMovableComposition Before(Count count, DayOfWeek dayOfWeek) => new BeforeMovableComposition(this, count, dayOfWeek);
        public AfterMovableComposition After(Count count, DayOfWeek dayOfWeek) => new AfterMovableComposition(this, count, dayOfWeek);
    }

    public class StartComposition : ExpressionElement
    {        
        protected override string Token => Value;
        internal string Value { get; set; }
        public StartComposition(ExpressionElement parent, string value) : base(parent) => Value = value;
        public EveryComposition Every(int number) => new EveryComposition(this, number);
        public InYearComposition In(Year year) => new InYearComposition(this, year);
        public DurationComposition Duration(string value) => new DurationComposition(this, value);
    }
    public class DurationComposition : ExpressionElement
    {
        protected override string Token => Value;
        internal string Value { get; set; }
        public DurationComposition(ExpressionElement parent, string value) : base(parent) => Value = value;
        public EveryComposition Every(int number) => new EveryComposition(this, number);
        public InYearComposition In(Year year) => new InYearComposition(this, year);
        public IfComposition If(DayOfWeek dayOfWeek) => new IfComposition(this, dayOfWeek);
    }
    public class IfComposition : ExpressionElement
    {
        protected override string Token => $"IF {DayOfWeek.ToString().ToUpper()}";
        internal DayOfWeek DayOfWeek { get; set; }
        public IfComposition(ExpressionElement parent, DayOfWeek dayOfWeek) : base(parent) => DayOfWeek = dayOfWeek;
        public ThenStartComposition ThenStartAt(string value) => new ThenStartComposition(this, value);
    }
    public class ThenStartComposition : ExpressionElement
    {
        protected override string Token => $"THEN {Value}";
        internal string Value { get; set; }
        public ThenStartComposition(ExpressionElement parent, string value) : base(parent) => Value = value;
        public EveryComposition Every(int number) => new EveryComposition(this, number);
        public InYearComposition In(Year year) => new InYearComposition(this, year);
    }

    public class InYearComposition : ExpressionElement
    {
        protected override string Token => $"IN {Year.ToString().ToUpper()} YEARS";
        internal Year Year { get; set; }
        public InYearComposition(ExpressionElement parent, Year year) : base(parent) => Year = year;
        public EveryComposition Every(int number) => new EveryComposition(this, number);
    }

    public class EveryComposition : ExpressionElement
    {
        protected override string Token => $"EVERY {Number}";
        internal int Number { get; set; }
        public EveryComposition(ExpressionElement parent, int number) : base(parent) => Number = number;
        public YearComposition Year => new YearComposition(this);
    }
    public class YearComposition : ExpressionElement
    {
        protected override string Token => "YEAR";
        public YearComposition(ExpressionElement parent) : base(parent) { }
        public SinceComposition Since(int year) => new SinceComposition(this, year);
    }
    public class SinceComposition : ExpressionElement
    {
        protected override string Token => $"SINCE {Year}";
        internal int Year { get; set; }
        public SinceComposition(ExpressionElement parent, int year) : base(parent) => Year = year;
    }

    public class BeforeComposition : ExpressionElement
    {
        protected override string Token => $"BEFORE {Value}";
        internal string Value { get; set; }
        public BeforeComposition(ExpressionElement parent, string value) : base(parent) => Value = value;
        public EveryComposition Every(int number) => new EveryComposition(this, number);
        public InYearComposition In(Year year) => new InYearComposition(this, year);
    }
    public class AfterComposition : ExpressionElement
    {
        protected override string Token => $"AFTER {Value}";
        internal string Value { get; set; }
        public AfterComposition(ExpressionElement parent, string value) : base(parent) => Value = value;
        public EveryComposition Every(int number) => new EveryComposition(this, number);
        public InYearComposition In(Year year) => new InYearComposition(this, year);
    }

    public class BeforeMovableComposition : MovableComposition
    {
        protected override string Token => $"BEFORE {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
        protected override ParserBase Parser => new ParserMovableFromMovable();
        public BeforeMovableComposition(ExpressionElement parent, Count count, DayOfWeek dayOfWeek) : base(parent, count, dayOfWeek) { }
    }
    public class AfterMovableComposition : MovableComposition
    {
        protected override string Token => $"AFTER {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
        protected override ParserBase Parser => new ParserMovableFromMovable();
        public AfterMovableComposition(ExpressionElement parent, Count count, DayOfWeek dayOfWeek) : base(parent, count, dayOfWeek) { }
    }

    public class IfDayComposition : ExpressionElement
    {
        protected override string Token => $"IF {DayOfWeek.ToString().ToUpper()}";
        internal DayOfWeek DayOfWeek { get; set; }
        public IfDayComposition(ExpressionElement parent, DayOfWeek dayOfWeek) : base(parent) => DayOfWeek = dayOfWeek;
        public ThenActionComposition Then { get; set; }
    }
    public class ThenActionComposition : ExpressionElement
    {
        protected override string Token => "THEN";
        public ThenActionComposition(ExpressionElement parent) : base(parent) { }
        public PreviousComposition Previous(DayOfWeek dayOfWeek) => new PreviousComposition(this, dayOfWeek);
        public NextComposition Next(DayOfWeek dayOfWeek) => new NextComposition(this, dayOfWeek);
    }
    public class PreviousComposition : ExpressionElement
    {
        protected override string Token => $"PREVIOUS {Day.ToString().ToUpper()}";
        internal DayOfWeek Day { get; set; }
        public PreviousComposition(ExpressionElement parent, DayOfWeek dayOfWeek) : base(parent) => Day = dayOfWeek;
        public OrComposition Or => new OrComposition(this);
    }
    public class NextComposition : ExpressionElement
    {
        protected override string Token => $"NEXT {Day.ToString().ToUpper()}";
        internal DayOfWeek Day { get; set; }
        public NextComposition(ExpressionElement parent, DayOfWeek dayOfWeek) : base(parent) => Day = dayOfWeek;
        public OrComposition Or => new OrComposition(this);
    }
    public class OrComposition : ExpressionElement
    {
        protected override string Token => "";
        public OrComposition(ExpressionElement parent) : base(parent) { }
        public IfDayComposition If(DayOfWeek dayOfWeek) => new IfDayComposition(this, dayOfWeek);
    }

    internal class Test
    {
        public void DateFix()
        {
            ExpressionElement rr = null;
            rr = ExpressionTree.Date.Fix(On.January.The10th);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00");
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D");
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00");

            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").In(Year.Leap);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").In(Year.Leap);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Year.Leap);

            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Year.Leap).Every(4).Year.Since(2000);
        }
        public void DateSpec()
        {
            ExpressionElement rr = null;
            rr = ExpressionTree.Date.Specific(On.January.The10th);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00");
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D");
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00");

            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").In(Year.Leap);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").In(Year.Leap);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Year.Leap);

            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Year.Leap).Every(4).Year.Since(2000);
        }

        public void EasterCatholic()
        {
            ExpressionElement rr = null;
            rr = ExpressionTree.Date.Catholic.Easter;
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00");
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D");
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00");
                                      
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").In(Year.Leap);
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").In(Year.Leap);
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Year.Leap);
                                      
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").Every(4).Year.Since(2000);
                                      
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Year.Leap).Every(4).Year.Since(2000);
        }
        public void EasterOrthodox()
        {
            ExpressionElement rr = null;
            rr = ExpressionTree.Date.Orthodox.Easter;
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00");
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D");
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00");
                                      
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").In(Year.Leap);
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").In(Year.Leap);
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Year.Leap);
                                      
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").Every(4).Year.Since(2000);
                                      
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Year.Leap).Every(4).Year.Since(2000);
        }

        public void DateMov()
        {
            ExpressionElement rr = null;
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before("01-01");
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before(January);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).After("01-01");
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).In(January);

            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before("01-01").In(Year.Leap);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before(January).In(Year.Leap);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).After("01-01").In(Year.Leap);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).In(January).In(Year.Leap);

            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before("01-01").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before(January).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).After("01-01").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).In(January).Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before("01-01").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before(January).In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).After("01-01").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).In(January).In(Year.Leap).Every(4).Year.Since(2000);            
        }
        
        public void DateMovFMov()
        {
            ExpressionElement rr = null;
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday);
            
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before("01-01").In(Year.Leap);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before(January).In(Year.Leap);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).After("01-01").In(Year.Leap);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).In(January).In(Year.Leap);

            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before("01-01").In(Year.Leap);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before(January).In(Year.Leap);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).After("01-01").In(Year.Leap);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).In(January).In(Year.Leap);

            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before("01-01").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before(January).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).After("01-01").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).In(January).Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before("01-01").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before(January).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).After("01-01").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).In(January).Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before("01-01").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before(January).In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).After("01-01").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).In(January).In(Year.Leap).Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before("01-01").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before(January).In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).After("01-01").In(Year.Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).In(January).In(Year.Leap).Every(4).Year.Since(2000);
        }

        public void Move()
        {
            ExpressionElement rr = null;

            rr = ExpressionTree.Move.Fix(On.January.The1st).If(DayOfWeek.Sunday).Then.Next(DayOfWeek.Monday).Or.If(DayOfWeek.Saturday).Then.Previous(DayOfWeek.Friday);

            rr = ExpressionTree.Observe.Fix(On.January.The1st).If(DayOfWeek.Sunday).Then.Next(DayOfWeek.Monday).Or.If(DayOfWeek.Saturday).Then.Previous(DayOfWeek.Friday);

            rr = ExpressionTree.Substitute.Fix(On.January.The1st).If(DayOfWeek.Sunday).Then.Next(DayOfWeek.Monday).Or.If(DayOfWeek.Saturday).Then.Previous(DayOfWeek.Friday);
        }
    }
}

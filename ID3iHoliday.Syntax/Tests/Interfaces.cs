using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ID3iDate;
using static ID3iHoliday.Syntax.Month;
using static ID3iHoliday.Syntax.YearType;

namespace ID3iHoliday.Syntax
{ 
    internal class Test
    {
        public void DateFix()
        {
            ExpressionElement rr = null;
            rr = ExpressionTree.Date.Fix(On.January.The10th);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00");
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D");
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00");

            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").In(Leap);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").In(Leap);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Leap);

            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Fix(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Leap).Every(4).Year.Since(2000);
        }
        public void DateSpec()
        {
            ExpressionElement rr = null;
            rr = ExpressionTree.Date.Specific(On.January.The10th);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00");
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D");
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00");

            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").In(Leap);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").In(Leap);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Leap);

            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Specific(On.January.The10th).StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Leap).Every(4).Year.Since(2000);
        }

        public void EasterCatholic()
        {
            ExpressionElement rr = null;
            rr = ExpressionTree.Date.Catholic.Easter;
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00");
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D");
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00");

            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").In(Leap);
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").In(Leap);
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Leap);

            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Catholic.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Leap).Every(4).Year.Since(2000);
        }
        public void EasterOrthodox()
        {
            ExpressionElement rr = null;
            rr = ExpressionTree.Date.Orthodox.Easter;
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00");
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D");
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00");

            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").In(Leap);
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").In(Leap);
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Leap);

            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Orthodox.Easter.StartAt("14:00").Duration("P1D").If(DayOfWeek.Sunday).ThenStartAt("00:00").In(Leap).Every(4).Year.Since(2000);
        }

        public void DateMov()
        {
            ExpressionElement rr = null;
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before("01-01");
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before(January);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).After("01-01");
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).In(January);

            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before("01-01").In(Leap);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before(January).In(Leap);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).After("01-01").In(Leap);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).In(January).In(Leap);

            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before("01-01").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before(January).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).After("01-01").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).In(January).Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before("01-01").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).Before(January).In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).After("01-01").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.Movable(Count.First, DayOfWeek.Monday).In(January).In(Leap).Every(4).Year.Since(2000);
        }

        public void DateMovFMov()
        {
            ExpressionElement rr = null;
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday);            

            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before("01-01").In(Leap);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before(January).In(Leap);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).After("01-01").In(Leap);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).In(January).In(Leap);

            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before("01-01").In(Leap);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before(January).In(Leap);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).After("01-01").In(Leap);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).In(January).In(Leap);

            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before("01-01").ThenStartAt("12:00").In(Leap).Every(1).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before(January).ThenStartAt("12:00").In(Leap).Every(1).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).After("01-01").ThenStartAt("12:00").In(Leap).Every(1).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).In(January).ThenStartAt("12:00").In(Leap).Every(1).Year.Since(2000);

            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before("01-01").ThenStartAt("12:00").In(Leap).Every(1).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before(January).ThenStartAt("12:00").In(Leap).Every(1).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).After("01-01").ThenStartAt("12:00").In(Leap).Every(1).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).In(January).ThenStartAt("12:00").In(Leap).Every(1).Year.Since(2000);

            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before("01-01").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before(January).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).After("01-01").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).In(January).Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before("01-01").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before(January).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).After("01-01").Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).In(January).Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before("01-01").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).Before(January).In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).After("01-01").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).Before(Count.Second, DayOfWeek.Friday).In(January).In(Leap).Every(4).Year.Since(2000);

            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before("01-01").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).Before(January).In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).After("01-01").In(Leap).Every(4).Year.Since(2000);
            rr = ExpressionTree.Date.MovableFromMovable(Count.First, DayOfWeek.Monday).After(Count.Second, DayOfWeek.Friday).In(January).In(Leap).Every(4).Year.Since(2000);
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

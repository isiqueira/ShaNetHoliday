using ID3iHoliday.Core.Models;
using ID3iHoliday.Syntax.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ID3iHoliday.Core.Parsers;

namespace ID3iHoliday.Syntax
{
    public class Christianism : ExpressionElement
    {
        public EasterDay CarnivalMonday => new EasterDay(this, "EASTER -48");
        public EasterDay CarnivalTuesday => new EasterDay(this, "EASTER -47");
        public EasterDay AshWednesday => new EasterDay(this, "EASTER -46");
        public EasterDay PalmSunday => new EasterDay(this, "EASTER -7");
        public EasterDay MaundyThursday => new EasterDay(this, "EASTER -3");
        public EasterDay GoodFriday => new EasterDay(this, "EASTER -2");
        public EasterDay HolySaturday => new EasterDay(this, "EASTER -1");
        public EasterDay Easter => new EasterDay(this, "EASTER");
        public EasterDay EasterMonday => new EasterDay(this, "EASTER +1");
        public EasterDay AscensionDay => new EasterDay(this, "EASTER +39");
        public EasterDay Pentecost => new EasterDay(this, "EASTER +49");
        public EasterDay WhitMonday => new EasterDay(this, "EASTER +50");
        public EasterDay CorpusChristi => new EasterDay(this, "EASTER +60");
        public EasterDay CustomDay(string value) => new EasterDay(this, value);
        protected override ParserBase Parser => new ParserEaster();
        public Christianism(ExpressionElement parent) : base(parent) { }
    }
}

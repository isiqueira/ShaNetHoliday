using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class EasterDay : ExpressionElement
    {
        internal EasterDay(ExpressionElement parent, string value) : base(parent) => Token = value;
        public StartDay Start(string value) => new StartDay(this, value);
        public Duration Duration(string value) => new Duration(this, value);

        public class StartDay : Start
        {
            public StartDay(ExpressionElement parent, string value) : base(parent, value) { }
            public Duration Duration(string value) => new Duration(this, value);
        }
    }
}

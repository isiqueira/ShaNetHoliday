using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class Every : ExpressionElement
    {
        protected override string Token => $"EVERY {Number}";
        internal int Number { get; set; }
        public Every(ExpressionElement parent, int number) : base(parent) { Number = number; }
        public EveryElement Year => new EveryElement(this);
    }
}

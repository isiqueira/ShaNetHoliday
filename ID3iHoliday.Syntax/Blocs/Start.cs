using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class Start : ExpressionElement
    {
        protected override string Token => Value;
        internal string Value { get; set; }
        public Start(ExpressionElement parent, string value) : base(parent) { Value = value; }
    }
}

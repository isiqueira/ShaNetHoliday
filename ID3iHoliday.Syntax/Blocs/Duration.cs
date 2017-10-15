using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class Duration : ExpressionElement
    {
        protected override string Token => Value;
        internal string Value { get; set; }
        public Duration(ExpressionElement parent, string value) : base(parent) { Value = value; }
    }
}

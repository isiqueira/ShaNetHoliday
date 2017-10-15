using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class InYear : In
    {
        protected override string Token => $"IN {Type.ToString().ToUpper()} YEARS";
        internal Year Type { get; set; }
        public InYear(ExpressionElement parent, Year type) : base(parent) { Type = type; }
    }
}

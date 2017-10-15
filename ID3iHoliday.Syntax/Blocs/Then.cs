using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class Then : ExpressionElement
    {
        protected override string Token => "THEN";
        public Then(ExpressionElement parent) : base(parent) { }
    }
}

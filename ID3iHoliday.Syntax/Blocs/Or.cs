using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class Or : ExpressionElement
    {
        protected override string Token => "";
        public Or(ExpressionElement parent) : base(parent) { }
    }
}

using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public class Catholic : Christianism
    {
        protected override string Token => "CATHOLIC";
        public Catholic(ExpressionElement parent) : base(parent) { }
    }
}

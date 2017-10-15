using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public static class ExpressionTree
    {
        public static Date Date => new Date();
        public static Substitute Substitute => new Substitute();
        public static Move Move => new Move();
        public static Observe Observe => new Observe();
    }
}

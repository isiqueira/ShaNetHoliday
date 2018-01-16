using ID3iHoliday.Syntax.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    public static class ExpressionTree
    {
        public static DateComposition Date => new DateComposition();
        public static MoveComposition Move => new MoveComposition();
        public static ObserveComposition Observe => new ObserveComposition();
        public static SubstituteComposition Substitute => new SubstituteComposition();
    }
}

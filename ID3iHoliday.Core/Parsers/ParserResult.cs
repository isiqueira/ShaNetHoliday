using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Core.Parsers
{
    public class ParserResult
    {
        public List<DateTime> DatesToAdd { get; set; } = new List<DateTime>();
        public DateTime? DateToRemove { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iD3iHoliday.WebService.Models
{
    public class GeographicElementModel
    {
        public string Code { get; set; }
        public Dictionary<string, string> Names { get; set; }
        public List<string> Langues { get; set; }
    }
}

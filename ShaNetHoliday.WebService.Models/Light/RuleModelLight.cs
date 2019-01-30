using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.WebService.Models.Light
{
    public class RuleModelLight
    {
        public string Expression { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public bool IsEnable { get; set; }
    }
}

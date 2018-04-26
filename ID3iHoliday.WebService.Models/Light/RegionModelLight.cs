using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.WebService.Models.Light
{
    public class RegionModelLight
    {
        public string Name { get; set; }
        public List<RuleModelLight> Rules { get; set; }
    }
}

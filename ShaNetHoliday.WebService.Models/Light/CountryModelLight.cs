using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.WebService.Models.Light
{
    public class CountryModelLight
    {
        public string Name { get; set; }
        public List<RuleModelLight> Rules { get; set; }
        public List<StateModelLight> States { get; set; }
    }
}

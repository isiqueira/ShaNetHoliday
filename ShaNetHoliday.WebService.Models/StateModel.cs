using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.WebService.Models
{
    public class StateModel : GeographicElementModel
    {
        public List<RegionModel> Regions { get; set; }
    }
}

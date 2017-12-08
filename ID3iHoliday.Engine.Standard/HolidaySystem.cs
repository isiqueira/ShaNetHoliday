using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ID3iHoliday.Engine;
using ID3iHoliday.Countries;

namespace ID3iHoliday.Engine.Standard
{
    public class HolidaySystem : Engine.HolidaySystem
    {
        public static HolidaySystem Instance { get; } = new HolidaySystem();
        private HolidaySystem()
        {
            CountriesAvailable.Add(new FR());
            CountriesAvailable.Add(new AD());
            CountriesAvailable.Add(new AG());
            CountriesAvailable.Add(new AI());
        }
    }
}

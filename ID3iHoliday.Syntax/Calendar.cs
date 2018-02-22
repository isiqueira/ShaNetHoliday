using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Types de calendrier supportés.
    /// </summary>
    public enum Calendar
    {
        /// <summary>
        /// <see cref="System.Globalization.GregorianCalendar"/>.
        /// </summary>
        Gregorian = 0,
        /// <summary>
        /// <see cref="System.Globalization.JulianCalendar"/>.
        /// </summary>
        Julian = 1
    }
}

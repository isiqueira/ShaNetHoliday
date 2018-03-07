using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    /// <summary>
    /// Types de calendrier supportés.
    /// </summary>
    public enum Calendar
    {
        /// <summary>
        /// Tous les calendriers.
        /// </summary>
        All = -1,
        /// <summary>
        /// <see cref="System.Globalization.GregorianCalendar"/>.
        /// </summary>
        Gregorian = 0,
        /// <summary>
        /// <see cref="System.Globalization.JulianCalendar"/>.
        /// </summary>
        Julian = 1,
        /// <summary>
        /// <see cref="System.Globalization.HijriCalendar"/>.
        /// </summary>
        Hijri = 2,
        /// <summary>
        /// <see cref="System.Globalization.HebrewCalendar"/>.
        /// </summary>
        Hebrew = 3
    }
}

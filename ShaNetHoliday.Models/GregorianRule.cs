using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.Models
{
    /// <summary>
    /// Représentation d'une règle dans le calendrier <see cref="System.Globalization.GregorianCalendar"/>.
    /// </summary>
    public class GregorianRule : Rule
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="GregorianRule"/>.
        /// </summary>
        public GregorianRule() : base() => Calendar = Calendar.Gregorian;
    }
}

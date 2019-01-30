using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iD3iHoliday.Models
{
    /// <summary>
    /// Représentation d'une règle dans le calendrier <see cref="System.Globalization.HebrewCalendar"/>.
    /// </summary>
    public class HebrewRule : Rule
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="HebrewRule"/>.
        /// </summary>
        public HebrewRule() : base() => Calendar = Calendar.Hijri;
    }
}

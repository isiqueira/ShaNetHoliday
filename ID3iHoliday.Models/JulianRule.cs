using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iD3iHoliday.Models
{
    /// <summary>
    /// Représentation d'une règle dans le calendrier <see cref="System.Globalization.JulianCalendar"/>.
    /// </summary>
    public class JulianRule : Rule
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="JulianRule"/>.
        /// </summary>
        public JulianRule() : base() => Calendar = Calendar.Julian;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iD3iHoliday.Models
{
    /// <summary>
    /// Représentation d'une règle dans le calendrier <see cref="System.Globalization.ChineseLunisolarCalendar"/>.
    /// </summary>
    public class ChineseRule : Rule
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="ChineseRule"/>.
        /// </summary>
        public ChineseRule() : base() => Calendar = Calendar.Chinese;
    }
}

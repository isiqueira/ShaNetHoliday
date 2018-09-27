using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Enumération pour le type d'année.
    /// </summary>
    public enum YearType
    {
        /// <summary>
        /// Année pair.
        /// </summary>
        Even,

        /// <summary>
        /// Année impair.
        /// </summary>
        Odd,

        /// <summary>
        /// Année bisextile.
        /// </summary>
        Leap,

        /// <summary>
        /// Année non bisextile.
        /// </summary>
        NonLeap
    }
}

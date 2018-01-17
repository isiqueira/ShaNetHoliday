using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    /// <summary>
    /// Représentation d'un long week-end.
    /// </summary>
    public class LongWeekEnd
    {
        /// <summary>
        /// Date de début.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Date de fin.
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Indication si un jour ouvré se trouve entre deux jours non ouvrés.
        /// </summary>
        public bool HasBridge { get; set; } = false;
        /// <summary>
        /// Retourne une chaîne qui représente l'objet actuel.
        /// </summary>
        /// <returns>Chaîne qui représente l'objet actuel.</returns>
        public override string ToString() => $"{CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(StartDate.DayOfWeek)} {StartDate.ToShortDateString()} -> {CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(EndDate.DayOfWeek)} {EndDate.ToShortDateString()} : {EndDate.Subtract(StartDate).TotalDays + 1} jour(s).";
    }
}

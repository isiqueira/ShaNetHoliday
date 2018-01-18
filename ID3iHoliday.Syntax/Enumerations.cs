using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Enumération pour l'adjectif numéral de position du jour.
    /// </summary>
    public enum Count
    {
        /// <summary>
        /// Le premier.
        /// </summary>
        First,
        /// <summary>
        /// Le second.
        /// </summary>
        Second,
        /// <summary>
        /// Le troisième.
        /// </summary>
        Third,
        /// <summary>
        /// Le quatrième.
        /// </summary>
        Fourth,
        /// <summary>
        /// Le cinquième.
        /// </summary>
        Fifth,
        /// <summary>
        /// Le sixième.
        /// </summary>
        Sixth
    }
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
    /// <summary>
    /// Enumération pour les mois.
    /// </summary>
    public enum Month
    {
        /// <summary>
        /// Janvier.
        /// </summary>
        January,
        /// <summary>
        /// Février.
        /// </summary>
        February,
        /// <summary>
        /// Mars.
        /// </summary>
        March,
        /// <summary>
        /// Avril.
        /// </summary>
        April,
        /// <summary>
        /// Mai.
        /// </summary>
        May,
        /// <summary>
        /// Juin.
        /// </summary>
        June,
        /// <summary>
        /// Juillet.
        /// </summary>
        July,
        /// <summary>
        /// Août.
        /// </summary>
        August,
        /// <summary>
        /// Septembre.
        /// </summary>
        September,
        /// <summary>
        /// Octobre.
        /// </summary>
        October,
        /// <summary>
        /// Novembre.
        /// </summary>
        November,
        /// <summary>
        /// Décembre.
        /// </summary>
        December
    }
}

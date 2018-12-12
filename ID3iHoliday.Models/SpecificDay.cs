using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iD3iHoliday.Models
{
    /// <summary>
    /// Réprésentation d'un jour particulier.
    /// </summary>
    public class SpecificDay
    {
        /// <summary>
        /// Date du jour.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Nom du jour.
        /// </summary>
        public Dictionary<Langue, string> Names { get; set; }

        /// <summary>
        /// Type de règle.
        /// </summary>
        public RuleType Type { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="SpecificDay"/>.
        /// </summary>
        /// <param name="type">Type de règle dont est issue ce jour.</param>
        /// <param name="date">Date du jour.</param>
        /// <param name="names">Noms du jour.</param>
        public SpecificDay( RuleType type, DateTime date, Dictionary<Langue, string> names )
        {
            Type = type;
            Date = date;
            Names = names;
        }

        /// <summary>
        /// Retourne une chaîne qui représente l'objet actuel.
        /// </summary>
        /// <returns>Chaîne qui représente l'objet actuel.</returns>
        public override string ToString() => $"{Date.ToShortDateString()} {Names.FirstOrDefault().Value}";
    }
}

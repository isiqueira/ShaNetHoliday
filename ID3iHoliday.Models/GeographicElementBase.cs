using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    /// <summary>
    /// Représentation d'un élément géographique.
    /// </summary>
    public abstract class GeographicElementBase
    {
        /// <summary>
        /// Code.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Nom par défaut.
        /// </summary>
        public string DefaultName => Names.FirstOrDefault().Value;
        /// <summary>
        /// Liste des noms de l'élément.
        /// </summary>
        public Dictionary<Langue, string> Names { get; set; } = new Dictionary<Langue, string>();
        /// <summary>
        /// Liste des langues de l'élément.
        /// </summary>
        public List<Langue> Langues { get; set; } = new List<Langue>();
        /// <summary>
        /// Liste des règles de l'élément.
        /// </summary>
        public ListRule Rules { get; set; } = new ListRule();

        public GeographicElementBase Parent { get; set; }
    }   
}

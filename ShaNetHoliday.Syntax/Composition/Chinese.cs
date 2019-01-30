using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShaNetDate;
using ShaNetHoliday.Core.Models;

namespace ShaNetHoliday.Syntax.Composition
{
    /// <summary>
    /// Racine pour les expressions chinoises.
    /// </summary>
    public class Chinese : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => "CHINESE";
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="Chinese"/>.
        /// </summary>
        public Chinese() : base( null ) { }
        /// <summary>
        /// Elément de syntax pour définir une date lunaire.
        /// </summary>
        /// <param name="value">Définition d'un jour dans un mois lunaire.</param>
        /// <returns>L'élément de syntax <see cref="Composition.LunarDate"/> pour ajouter d'autres comportements.</returns>
        public LunarDate LunarDate( string value ) => new LunarDate( this, value );

        /// <summary>
        /// Elément de syntax pour définir une date solaire.
        /// </summary>
        /// <param name="value">Terme solaire.</param>
        /// <returns>L'élément de syntax <see cref="Composition.SolarDate"/> pour ajouter d'autres comportements.</returns>
        public SolarDate SolarDate( SolarTerm value ) => new SolarDate( this, value );
    }
}

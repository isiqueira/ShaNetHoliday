using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShaNetHoliday.Core.Models;

namespace ShaNetHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour définir le jour d'un mois solaire.
    /// </summary>
    public class The : ExpressionElement
    {
        internal int Value { get; set; }
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"THE {Value.ToString()}";
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="OnChineseCycle"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="value">Numéro du jour dans le mois solaire.</param>
        public The( ExpressionElement parent, int value ) : base( parent ) => Value = value;

        /// <summary>
        /// Elément de syntax pour déplacer le jour à un autre si il tombe un certain jour.
        /// </summary>
        /// <param name="dayOfWeek">Jour particulier.</param>
        /// <returns>L'élément de syntax <see cref="IfDay"/> pour ajouter d'autres comportements.</returns>
        public IfDay If( DayOfWeek dayOfWeek ) => new IfDay( this, dayOfWeek );
    }
}

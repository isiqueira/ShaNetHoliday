using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour changer l'heure.
    /// </summary>
    public class ThenStart : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"THEN {Value}";
        internal string Value { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ThenStart"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="value">Heure de début.</param>
        public ThenStart( ExpressionElement parent, string value ) : base( parent ) => Value = value;

        /// <summary>
        /// Elément de syntax pour gérer la récurrence selon un nombre de période.
        /// </summary>
        /// <param name="number">Nombre de période.</param>
        /// <returns>L'élément de syntax <see cref="Composition.Every"/> pour ajouter d'autres comportements.</returns>
        public Every Every( int number ) => new Every( this, number );

        /// <summary>
        /// Elément de syntax pour gérer le type d'année pris en charge.
        /// </summary>
        /// <param name="year">Type de l'année.</param>
        /// <returns>L'élément de syntax <see cref="InYear"/> pour ajouter d'autres comportements.</returns>
        public InYear In( YearType year ) => new InYear( this, year );
    }
}

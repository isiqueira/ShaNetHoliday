using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour indiquer l'heure de début.
    /// </summary>
    public class Start : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => Value;
        internal string Value { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Start"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="value">Heure de début au format HH:mm</param>
        public Start( ExpressionElement parent, string value ) : base( parent ) => Value = value;

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

        /// <summary>
        /// Elément de syntax pour indiquer que la durée est de 1 jour.
        /// </summary>
        /// <returns>L'élément de syntax <see cref="Composition.Duration"/> pour ajouter d'autres comportements.</returns>
        public Duration UntilMidnight => Duration.Spec( "P1D" );

        /// <summary>
        /// Elément de syntax pour gérer la durée.
        /// </summary>
        /// <returns>L'élément de syntax <see cref="Composition.Duration"/> pour ajouter d'autres comportements.</returns>
        public Duration Duration => new Duration( this );
    }
}

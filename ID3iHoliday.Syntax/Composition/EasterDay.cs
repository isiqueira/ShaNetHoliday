using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour la définition d'un jour en rapport avec le dimanche de Pâques.
    /// </summary>
    public class EasterDay : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => Value;
        internal string Value { get; set; }

        /// <summary>
        /// Initialise une nouvelle classe de <see cref="EasterDay"/>.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="value"></param>
        public EasterDay( ExpressionElement parent, string value ) : base( parent ) => Value = value;

        /// <summary>
        /// Elément de syntax pour indiquer l'heure de début.
        /// </summary>
        /// <param name="value">L'heure de début au format HH:mm</param>
        /// <returns>L'élément de syntax <see cref="Start"/> pour ajouter d'autres comportements.</returns>
        public Start StartAt( string value ) => new Start( this, value );

        /// <summary>
        /// Elément de syntax pour indiquer que l'heure de début est à minuit.
        /// </summary>
        /// <returns>L'élément de syntax <see cref="Start"/> pour ajouter d'autres comportements.</returns>
        public Start StartAtMidnight => new Start( this, "00:00" );
    }
}

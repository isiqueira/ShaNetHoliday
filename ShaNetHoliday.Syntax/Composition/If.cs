using ShaNetHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour changer l'heure de début selon le jour.
    /// </summary>
    public class If : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"IF {DayOfWeek.ToString().ToUpper()}";
        internal DayOfWeek DayOfWeek { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="If"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        public If( ExpressionElement parent, DayOfWeek dayOfWeek ) : base( parent ) => DayOfWeek = dayOfWeek;

        /// <summary>
        /// Elément de syntax pour changer l'heure.
        /// </summary>
        /// <param name="value">Nouvelle heure.</param>
        /// <returns>L'élément de syntax <see cref="ThenStart"/> pour ajouter d'autres comportements.</returns>
        public ThenStart ThenStartAt( string value ) => new ThenStart( this, value );

        /// <summary>
        /// Elément de syntax pour changer l'heure à minuit.
        /// </summary>
        /// <returns>L'élément de syntax <see cref="ThenStart"/> pour ajouter d'autres comportements.</returns>
        public ThenStart ThenStartAtMidnight => new ThenStart( this, "00:00" );
    }
}

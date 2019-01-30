using ShaNetHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour déplacer le jour à un autre si il tombe un certain jour.
    /// </summary>
    public class IfDay : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"IF {DayOfWeek.ToString().ToUpper()}";
        internal DayOfWeek DayOfWeek { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="IfDay"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        public IfDay( ExpressionElement parent, DayOfWeek dayOfWeek ) : base( parent ) => DayOfWeek = dayOfWeek;

        /// <summary>
        /// Elément de syntax <see cref="ThenAction"/> pour choisir l'action à réaliser.
        /// </summary>
        public ThenAction Then => new ThenAction( this );
    }
}

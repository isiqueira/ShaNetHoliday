using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShaNetHoliday.Core.Models;
using ShaNetHoliday.Core.Parsers;
using ShaNetHoliday.Syntax.Parsers;

namespace ShaNetHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour définir une date lunaire.
    /// </summary>
    public class LunarDate : ExpressionElement
    {
        internal string Value { get; set; }
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"LUNAR {Value}";
        /// <summary>
        /// <see cref="ParserChineseLunar"/> associé à l'élément.
        /// </summary>
        protected override ParserBase Parser => new ParserChineseLunar();
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="LunarDate"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="value">Définition d'un jour dans un mois.</param>
        public LunarDate( ExpressionElement parent, string value ) : base( parent ) => Value = value;

        /// <summary>
        /// Elément de syntax pour définir un cycle.
        /// </summary>
        /// <param name="value">Cycle.</param>
        /// <returns>L'élément de syntax <see cref="OnChineseCycle"/> pour ajouter d'autres comportements.</returns>
        public OnChineseCycle OnCycle( int value ) => new OnChineseCycle( this, value );

        /// <summary>
        /// Elément de syntax pour déplacer le jour à un autre si il tombe un certain jour.
        /// </summary>
        /// <param name="dayOfWeek">Jour particulier.</param>
        /// <returns>L'élément de syntax <see cref="IfDay"/> pour ajouter d'autres comportements.</returns>
        public IfDay If( DayOfWeek dayOfWeek ) => new IfDay( this, dayOfWeek );
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShaNetDate;
using ShaNetHoliday.Core.Models;
using ShaNetHoliday.Core.Parsers;
using ShaNetHoliday.Syntax.Parsers;

namespace ShaNetHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour définir une date solaire.
    /// </summary>
    public class SolarDate : ExpressionElement
    {
        internal SolarTerm Value { get; set; }
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"SOLAR {Value.Degrees}°";
        /// <summary>
        /// <see cref="ParserChineseSolar"/> associé à l'élément.
        /// </summary>
        protected override ParserBase Parser => new ParserChineseSolar();
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="LunarDate"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="value">Terme solaire.</param>
        public SolarDate( ExpressionElement parent, SolarTerm value ) : base( parent ) => Value = value;

        /// <summary>
        /// Elément de syntax pour définir le jour d'un mois solaire.
        /// </summary>
        /// <param name="value">Numéro du jour dans le mois solaire.</param>
        /// <returns>L'élément de syntax <see cref="Composition.The"/> pour ajouter d'autres comportements.</returns>
        public The The( int value ) => new The( this, value );

        /// <summary>
        /// Elément de syntax pour définir un cycle.
        /// </summary>
        /// <param name="value">Cycle.</param>
        /// <returns>L'élément de syntax <see cref="OnChineseCycle"/> pour ajouter d'autres comportements.</returns>
        public OnChineseCycle OnCycle( int value ) => new OnChineseCycle( this, value );
    }
}

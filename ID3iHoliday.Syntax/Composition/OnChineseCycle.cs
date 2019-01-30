using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iD3iHoliday.Core.Models;

namespace iD3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour définir un cycle.
    /// </summary>
    public class OnChineseCycle : ExpressionElement
    {
        internal int Value { get; set; }
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"CYCLE {Value.ToString()}";
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="OnChineseCycle"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="value">Cycle.</param>
        public OnChineseCycle( ExpressionElement parent, int value ) : base( parent ) => Value = value;

        /// <summary>
        /// Elément de syntax pour définir l'élément.
        /// </summary>
        /// <param name="element">Elément Chinois.</param>
        /// <returns>L'élément de syntax <see cref="OfChineseElement"/> pour ajouter d'autres comportements.</returns>
        public OfChineseElement Of( ChineseElement element ) => new OfChineseElement( this, element );
    }
}

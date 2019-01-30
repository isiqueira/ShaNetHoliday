using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShaNetHoliday.Core.Models;

namespace ShaNetHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour définir l'élément.
    /// </summary>
    public class OfChineseElement : ExpressionElement
    {
        internal ChineseElement Value { get; set; }
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"ELEMENT {Value.ToString().ToUpper()}";
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="OfChineseElement"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="value">Elément Chinois.</param>
        public OfChineseElement( ExpressionElement parent, ChineseElement value ) : base( parent ) => Value = value;

        /// <summary>
        /// Elément de syntax pour définir l'animal.
        /// </summary>
        /// <param name="zodiac">Animal du Zodiac Chinois.</param>
        /// <returns>L'élément de syntax <see cref="AndChineseZodiac"/> pour ajouter d'autres comportements.</returns>
        public AndChineseZodiac And( ChineseZodiac zodiac ) => new AndChineseZodiac( this, zodiac );
    }
}

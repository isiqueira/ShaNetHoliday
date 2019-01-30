using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShaNetHoliday.Core.Models;

namespace ShaNetHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour définir l'animal.
    /// </summary>
    public class AndChineseZodiac : ExpressionElement
    {
        internal ChineseZodiac Value { get; set; }
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"ANIMAL {Value.ToString().ToUpper()}";
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="AndChineseZodiac"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="value">Animal du Zodiac Chinois.</param>
        public AndChineseZodiac( ExpressionElement parent, ChineseZodiac value ) : base( parent ) => Value = value;

        /// <summary>
        /// Elément de syntax pour déplacer le jour à un autre si il tombe un certain jour.
        /// </summary>
        /// <param name="dayOfWeek">Jour particulier.</param>
        /// <returns>L'élément de syntax <see cref="IfDay"/> pour ajouter d'autres comportements.</returns>
        public IfDay If( DayOfWeek dayOfWeek ) => new IfDay( this, dayOfWeek );
    }
}

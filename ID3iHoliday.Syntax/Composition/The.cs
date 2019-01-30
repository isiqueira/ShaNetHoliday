using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iD3iHoliday.Core.Models;

namespace iD3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour définir le jour d'un mois solaire.
    /// </summary>
    public class The : ExpressionElement
    {
        internal int Value { get; set; }
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"THE {Value.ToString()}";
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="OnChineseCycle"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="value">Numéro du jour dans le mois solaire.</param>
        public The( ExpressionElement parent, int value ) : base( parent ) => Value = value;
    }
}

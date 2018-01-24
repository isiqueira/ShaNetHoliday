using ID3iHoliday.Core.Models;
using ID3iHoliday.Core.Parsers;
using ID3iHoliday.Syntax.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Syntax pour la création d'une expression de déplacement de date.
    /// </summary>
    public class Move : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => "MOVE";
        /// <summary>
        /// <see cref="ParserMove"/> associé à l'élément.
        /// </summary>
        protected override ParserBase Parser => new ParserMove();
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Move"/>.
        /// </summary>
        public Move() : base(null) { }
        /// <summary>
        /// Elément de syntax pour mettre en place une date fixe dans n'importe qu'elle année.
        /// </summary>
        /// <param name="dateTime">Date.</param>
        /// <returns>L'élément de syntax <see cref="SimpleDay"/> pour ajouter d'autres comportements.</returns>
        public SimpleDay Fix(DateTime dateTime) => new SimpleDay(this, dateTime);
    }
}

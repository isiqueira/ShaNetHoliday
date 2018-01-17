using ID3iHoliday.Core.Models;
using ID3iHoliday.Core.Parsers;
using ID3iHoliday.Syntax.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Syntax pour la création d'une expression de déplacement de date.
    /// </summary>
    public class MoveComposition : ExpressionElement
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
        /// Initialise une nouvelle instance de la classe <see cref="MoveComposition"/>.
        /// </summary>
        public MoveComposition() : base(null) { }
        /// <summary>
        /// Elément de syntax pour mettre en place une date fixe dans n'importe qu'elle année.
        /// </summary>
        /// <param name="dateTime">Date.</param>
        /// <returns>L'élément de syntax <see cref="SimpleDayComposition"/> pour ajouter d'autres comportements.</returns>
        public SimpleDayComposition Fix(DateTime dateTime) => new SimpleDayComposition(this, dateTime);
    }
}

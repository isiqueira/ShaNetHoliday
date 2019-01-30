using ShaNetHoliday.Core.Models;
using ShaNetHoliday.Core.Parsers;
using ShaNetHoliday.Syntax.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.Syntax.Composition
{
    /// <summary>
    /// Syntax pour la création d'une expression de substitution de date.
    /// </summary>
    public class Substitute : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => "SUBSTITUTE";

        /// <summary>
        /// <see cref="ParserSubstitute"/> associé à l'élément.
        /// </summary>
        protected override ParserBase Parser => new ParserSubstitute();

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Substitute"/>.
        /// </summary>
        public Substitute() : base( null ) { }

        /// <summary>
        /// Elément de syntax pour mettre en place une date fixe dans n'importe qu'elle année.
        /// </summary>
        /// <param name="dateTime">Date.</param>
        /// <returns>L'élément de syntax <see cref="SimpleDay"/> pour ajouter d'autres comportements.</returns>
        public SimpleDay Fix( DateTime dateTime ) => new SimpleDay( this, dateTime );
    }
}
